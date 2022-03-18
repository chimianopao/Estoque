using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque {
    public partial class FrmMovimentacao : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");
        string tipoMovimentacao = "SAIDA";
        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        private int page = 1;
        private List<string> backupValorUnit = new List<string>();
        public FrmMovimentacao(string tipo)
        {
            InitializeComponent();
            tipoMovimentacao = tipo;
            if (tipo.Equals("SAIDA"))
            {
                labelTipoMovimentacao.Text = "SAÍDA";
            }
            else
            {
                labelTipoMovimentacao.Text = "ENTRADA";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridMovimentacao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridMovimentacao_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("olaaa");
            e.SuppressKeyPress = true;
            int iColumn = dataGridMovimentacao.CurrentCell.ColumnIndex;
            int iRow = dataGridMovimentacao.CurrentCell.RowIndex;
            //MessageBox.Show()
            //if (e.KeyData == Keys.Enter || e.KeyData == Keys.Down)
            if (e.KeyData == Keys.Enter && iColumn == 0)
            {
                MessageBox.Show("coluna zero");
                dataGridMovimentacao.CurrentCell = dataGridMovimentacao[3, iRow];
            }
            else
                dataGridMovimentacao.CurrentCell = dataGridMovimentacao[iColumn + 1, iRow];
        }

        private void DataGridView1_ColumnHeaderCellChanged(Object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void dataGridMovimentacao_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridMovimentacao.Rows[e.RowIndex].ErrorText = "";
            int newInteger;

            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.
            if (dataGridMovimentacao.Rows[e.RowIndex].IsNewRow) { return; }
            if (!int.TryParse(e.FormattedValue.ToString(),
                out newInteger) || newInteger < 0)
            {
                e.Cancel = true;
                dataGridMovimentacao.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
            }
        }

        private void dataGridMovimentacao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
                if (e.ColumnIndex == 3)//quantidade
                {
                    if (dataGridMovimentacao.CurrentCell != null)
                    {
                        CalculaValorTotal();
                        CalculaQuantidadeTotal();
                    }
                }

                if (e.ColumnIndex == 4)//valor unitario
                {
                    if (dataGridMovimentacao.CurrentCell != null)
                    {
                        CalculaValorTotal();
                    }
                }

            if (e.ColumnIndex == 5)//valor total
            {
                if (dataGridMovimentacao.CurrentCell != null)
                {
                    CalculaValorSubTotal();
                }
            }

            if (e.ColumnIndex == 0)// codigo
                {
                    if (dataGridMovimentacao.CurrentCell != null)
                    {
                    if (long.TryParse(dataGridMovimentacao.CurrentCell.Value?.ToString(), out long codigoProduto))
                    {
                        var produto = buscaProduto(codigoProduto);
                        if (produto != null)
                            dataGridMovimentacao.CurrentRow.SetValues(buscaProduto(codigoProduto));
                    }
                    else
                    {
                        MessageBox.Show("Código inválido");
                    }
                    }
                }
        }

        private void dataGridMovimentacao_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Update the balance column whenever rows are deleted.
            CalculaQuantidadeTotal();
            CalculaValorSubTotal();
        }

        private object[] buscaProduto(long codigoProduto)
        {
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);

            string descricao = "";
            string nomeFabricante = "";
            string precoVenda = "";

            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM PRODUTOS p " +
                    $"join FABRICANTES f on f.fabricanteId = p.fabricanteId " +
                    $"WHERE p.codigo = {codigoProduto}";
                SqliteDataReader reader;
                reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    descricao = Convert.ToString(reader["descricao"]);
                    nomeFabricante = Convert.ToString(reader["nome"]);
                    precoVenda = Convert.ToString(reader["preco_venda"]);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.");
                    return null;
                }
                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();
            precoVenda = float.Parse(precoVenda).ToString("0.00");
            return new object[] { codigoProduto, descricao, nomeFabricante, 1, precoVenda, precoVenda };
        }

        private void CalculaQuantidadeTotal()
        {
            int qtdTotal = 0;
            for (int i = 0; i < dataGridMovimentacao.Rows.Count - 1; i++)
            {
                    bool passou = int.TryParse(dataGridMovimentacao[3, i].Value?.ToString(), out int qtd);
                    if (passou)
                        qtdTotal += qtd;
            }

            labelQtdTotal.Text = qtdTotal.ToString();
            labelPaginas.Text = ((qtdTotal / 61) + 1).ToString();
        }

        private void CalculaValorTotal(int currentRoll = -1)
        {
            float valorTotal = 0;
            if(currentRoll == -1)
                currentRoll = dataGridMovimentacao.CurrentRow.Index;
            if (dataGridMovimentacao[4, currentRoll].Value != null)
            {
                if (float.TryParse(dataGridMovimentacao[4, currentRoll].Value.ToString(), out float precoUnit)
                    && int.TryParse(dataGridMovimentacao[3, currentRoll].Value.ToString(), out int quant))
                {
                    valorTotal = precoUnit * quant;
                }
                dataGridMovimentacao[5, currentRoll].Value = valorTotal.ToString("0.00");
            }
        }

        private void CalculaValorSubTotal()
        {
            float valorSubTotal = 0;
            for (int i = 0; i < dataGridMovimentacao.Rows.Count - 1; i++)
            {
                bool passou = float.TryParse(dataGridMovimentacao[5, i].Value?.ToString(), out float preco);
                if (passou)
                    valorSubTotal += preco;
            }

            labelValorTotal.Text = valorSubTotal.ToString("0.00");
        }

        private void FrmMovimentacao_Load(object sender, EventArgs e)
        {
            CarregaVendedores();
            labelQtdTotal.Text = "0";
            labelValorTotal.Text = "0,00";
            labelNrMovimentacao.Text = (getUltimaMovimentacao() + 1).ToString();
            labelData.Text = DateTime.Today.ToShortDateString();
        }

        private int getUltimaMovimentacao()
        {
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);
            int ultMovimento = 0;
            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id_movimentacao FROM MOVIMENTACAO_CONTROLE WHERE id_movimentacao = (SELECT MAX(id_movimentacao)  FROM MOVIMENTACAO_CONTROLE)";

                SqliteDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ultMovimento = Convert.ToInt32(reader["id_movimentacao"]);
                }

                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();
            return ultMovimento;
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            if (comboBoxVendedores.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma vendedora.");
                return;
            }

            if(dataGridMovimentacao[1, 0].Value == null)
            {
                MessageBox.Show("Adicione pelo menos um item.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Gravar Movimentação?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            bool movControleSucesso = insertMovimentacaoControle();
            if (movControleSucesso)
            {
                insertMovimentacao();
            }

            MessageBox.Show("Movimentação " + labelNrMovimentacao.Text + " gravada com sucesso.");

            resetCampos();
        }

        private void resetCampos()
        {
            dataGridMovimentacao.Rows.Clear();
            labelNrMovimentacao.Text = (getUltimaMovimentacao() + 1).ToString();
            labelQtdTotal.Text = "0";
            labelValorTotal.Text = "0,00";
            comboBoxVendedores.SelectedIndex = -1;
        }

        private bool insertMovimentacaoControle()
        {
            bool sucesso = false;
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);

            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO MOVIMENTACAO_CONTROLE (id_movimentacao, codigo_vendedor, tipo, quantidade_total, valor_total, data_movimentacao) " +
                     $"VALUES ({labelNrMovimentacao.Text}, (select vend.codigo from VENDEDORES vend WHERE vend.nome = '{comboBoxVendedores.Text}'), " +
                        $"'{tipoMovimentacao}', {labelQtdTotal.Text}, '{labelValorTotal.Text}', DATETIME('NOW', 'localtime'));";

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                sucesso = true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();
            return sucesso;
        }

        private void insertMovimentacao()
        {
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);

            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();

                foreach (DataGridViewRow row in dataGridMovimentacao.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        string codigo = row.Cells[0].Value.ToString();
                        string descricao = row.Cells[1].Value.ToString();
                        string fabricante = row.Cells[2].Value.ToString();
                        string quantidade = row.Cells[3].Value.ToString();
                        string valorUnit = row.Cells[4].Value.ToString();

                        cmd.CommandText = "INSERT INTO MOVIMENTACAO (id_movimentacao, codigo_produto, quantidade, tipo, preco_venda, data_movimentacao) " +
                            $"VALUES ({labelNrMovimentacao.Text}, {codigo}, {quantidade}, '{tipoMovimentacao}', '{valorUnit}', DATETIME('NOW', 'localtime'));";

                        cmd.ExecuteNonQuery();
                    }
                }

                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                connection.Close();
            }
            connection.Close();
        }

        private void CarregaVendedores()
        {
            this.comboBoxVendedores.Items.Clear();
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);

            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM VENDEDORES";

                SqliteDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.comboBoxVendedores.Items.Add(Convert.ToString(reader["nome"]));
                }

                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();
        }

        private void buttonCadastraVendedor_Click(object sender, EventArgs e)
        {
            FrmCadastraVendedores cadastraVendedores = new FrmCadastraVendedores();
            cadastraVendedores.FormClosing += new FormClosingEventHandler(this.FrmCadastraFabricante_FormClosing);
            cadastraVendedores.ShowDialog();
        }

        private void FrmCadastraFabricante_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CarregaVendedores();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.AllowSomePages = true;
            PrintDialog1.ShowHelp = true;
            PrintDialog1.Document = printDocument1;
            DialogResult result = PrintDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }
        
        private void printDocument1_PrintPage(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString($"MOVIMENTAÇÃO {labelTipoMovimentacao.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 10);
            e.Graphics.DrawString($"Número {labelNrMovimentacao.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 30);
            e.Graphics.DrawString($"Vendedora: {comboBoxVendedores.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 50);
            e.Graphics.DrawString(DateTime.Today.ToShortDateString(), new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 720, 10);
            e.Graphics.DrawString($"Página: {page}/{(int)(dataGridMovimentacao.Rows.Count / 62) + 1}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 720, 30);

            string curdhead = "Monetti";
            e.Graphics.DrawString(curdhead, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 350, 50);
            e.Graphics.DrawString($"Obs: {textBoxObservacao.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 150, 70);

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 90, 900, 90);

            string g1 = "Código";
            e.Graphics.DrawString(g1, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 95);

            string g2 = "Descrição";
            e.Graphics.DrawString(g2, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 130, 95);//100

            string g3 = "Fabricante";
            e.Graphics.DrawString(g3, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 420, 95);//300

            string g4 = "Qtd";
            e.Graphics.DrawString(g4, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 570, 95);//450

            string g5 = "Preço Unit";
            e.Graphics.DrawString(g5, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 620, 95);//500

            string g6 = "Preço Total";
            e.Graphics.DrawString(g6, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 720, 95);//600

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 115, 900, 115);

            int height = 105;
            for (int l = numberOfItemsPrintedSoFar; l < dataGridMovimentacao.Rows.Count-1; l++)
            {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 60)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= dataGridMovimentacao.Rows.Count)
                    {

                        height += (dataGridMovimentacao.Rows[0].Height-6);
                        e.Graphics.DrawString(dataGridMovimentacao.Rows[l].Cells[0].FormattedValue.ToString(), dataGridMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(30, height, dataGridMovimentacao.Columns[0].Width, dataGridMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridMovimentacao.Rows[l].Cells[1].FormattedValue.ToString(), dataGridMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(130, height, dataGridMovimentacao.Columns[1].Width, dataGridMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridMovimentacao.Rows[l].Cells[2].FormattedValue.ToString(), dataGridMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(420, height, dataGridMovimentacao.Columns[2].Width, dataGridMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridMovimentacao.Rows[l].Cells[3].FormattedValue.ToString(), dataGridMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(570, height, dataGridMovimentacao.Columns[3].Width, dataGridMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridMovimentacao.Rows[l].Cells[4].FormattedValue.ToString(), dataGridMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(620, height, dataGridMovimentacao.Columns[4].Width, dataGridMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridMovimentacao.Rows[l].Cells[5].FormattedValue.ToString(), dataGridMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(720, height, dataGridMovimentacao.Columns[5].Width, dataGridMovimentacao.Rows[0].Height));
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }

                }
                else
                {
                    numberOfItemsPerPage = 0;
                    e.HasMorePages = true;
                    page++;
                    return;
                }
            }
            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
            page = 1;
            height = height + 16;
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, height, 900, height);
            e.Graphics.DrawString($"{labelQtdTotal.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 570, height + 5);
            e.Graphics.DrawString($"R$ {labelValorTotal.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 700, height + 5);
        }


        private void buttonAplicaPercentual_Click(object sender, EventArgs e)
        {
            if(!float.TryParse(textBoxPercentual.Text, out float a))
            {
                MessageBox.Show("Número Inválido!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Adicionar {textBoxPercentual.Text}% ?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            backupValorUnit.Clear();

            for (int i = 0; i < dataGridMovimentacao.Rows.Count; i++)
            {
                if(dataGridMovimentacao.Rows[i].Cells[4].Value != null)
                {
                    backupValorUnit.Add(dataGridMovimentacao.Rows[i].Cells[4].Value.ToString());

                    var novoValor = float.Parse(dataGridMovimentacao.Rows[i].Cells[4].Value?.ToString());
                    novoValor = novoValor + (novoValor * (float.Parse(textBoxPercentual.Text) / 100));
                    dataGridMovimentacao.Rows[i].Cells[4].Value = novoValor.ToString("0.00");
                    CalculaValorTotal(i);
                }
            }
        }

        private void buttonRestauraValores_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < backupValorUnit.Count; i++)
            {
                dataGridMovimentacao.Rows[i].Cells[4].Value = backupValorUnit[i];
                CalculaValorTotal(i);
            }
        }
    }
}
