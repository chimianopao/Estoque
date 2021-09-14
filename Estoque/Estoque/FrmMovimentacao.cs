using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque {
    public partial class FrmMovimentacao : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");

        public FrmMovimentacao()
        {
            InitializeComponent();
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
                        if (int.TryParse(dataGridMovimentacao.CurrentCell.Value.ToString(), out int codigoProduto))
                        {
                            dataGridMovimentacao.CurrentRow.SetValues(buscaProduto(codigoProduto));
                            //dataGridMovimentacao.CurrentCell = dataGridMovimentacao[0, 0];
                        }
                        else
                            MessageBox.Show("Código inválido");
                    }
                }
        }

        private object[] buscaProduto(int codigoProduto)
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
                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();
            
            return new object[] { codigoProduto, descricao, nomeFabricante, 1, precoVenda, precoVenda };
        }

        private void CalculaQuantidadeTotal()
        {
            int qtdTotal = 0;
            for (int i = 0; i < dataGridMovimentacao.Rows.Count-1; i++)
            {
                bool passou = int.TryParse(dataGridMovimentacao[3, i].Value.ToString(), out int qtd);
                if (passou)
                    qtdTotal += qtd;
            }

            labelQtdTotal.Text = qtdTotal.ToString();
        }

        private void CalculaValorTotal()
        {
            float valorTotal = 0;
            int currentRoll = dataGridMovimentacao.CurrentRow.Index;
            if (dataGridMovimentacao[4, currentRoll].Value != null)
            {
                if (float.TryParse(dataGridMovimentacao[4, currentRoll].Value.ToString(), out float precoUnit)
                    && int.TryParse(dataGridMovimentacao[3, currentRoll].Value.ToString(), out int quant))
                {
                    valorTotal = precoUnit * quant;
                }
                dataGridMovimentacao[5, currentRoll].Value = valorTotal;
            }
        }

        private void CalculaValorSubTotal()
        {
            float valorSubTotal = 0;
            for (int i = 0; i < dataGridMovimentacao.Rows.Count - 1; i++)
            {
                bool passou = float.TryParse(dataGridMovimentacao[5, i].Value.ToString(), out float preco);
                if (passou)
                    valorSubTotal += preco;
            }

            labelValorTotal.Text = valorSubTotal.ToString("0,00");
        }

        private void FrmMovimentacao_Load(object sender, EventArgs e)
        {
            CarregaVendedores();
            labelQtdTotal.Text = "0";
            labelValorTotal.Text = "0,00";
            labelNrMovimentacao.Text = (getUltimaMovimentacao() + 1).ToString();
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
                        $"'SAIDA', {labelQtdTotal.Text}, '{labelValorTotal.Text}', DATETIME('NOW', 'localtime'));";

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
                    if (row.Cells[0].Value != null)
                    {
                        string codigo = row.Cells[0].Value.ToString();
                        string descricao = row.Cells[1].Value.ToString();
                        string fabricante = row.Cells[2].Value.ToString();
                        string quantidade = row.Cells[3].Value.ToString();
                        string valorUnit = row.Cells[4].Value.ToString();

                        cmd.CommandText = "INSERT INTO MOVIMENTACAO (id_movimentacao, codigo_produto, quantidade, tipo, preco_venda, data_movimentacao) " +
                            $"VALUES ({labelNrMovimentacao.Text}, {codigo}, {quantidade}, 'SAIDA', '{valorUnit}', DATETIME('NOW', 'localtime'));";

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

        //private void dataGridMovimentacao_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    //dataGridMovimentacao.CurrentRow.SetValues(new object[] { 454, "pijama", "marcyn", 4, "15,50" });
        //    if (e.ColumnIndex == 0)
        //    {
        //        MessageBox.Show(dataGridMovimentacao.CurrentRow.Cells[0].FormattedValue.ToString());
        //        if(dataGridMovimentacao.CurrentCell.Value != null)
        //            MessageBox.Show(dataGridMovimentacao.CurrentCell.Value.ToString());
        //        //dataGridMovimentacao.CurrentRow.SetValues(buscaProduto());


        //        dataGridMovimentacao.CurrentRow.SetValues(new object[] { dataGridMovimentacao.CurrentCell.Value, "pijama", "marcyn", 1, "15,50" });
        //        //dataGridMovimentacao.get
        //    }
        //}
    }
}
