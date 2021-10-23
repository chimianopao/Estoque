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
    public partial class FrmConsultaMovimentacao : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");
        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        public FrmConsultaMovimentacao()
        {
            InitializeComponent();
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxNrMovimentacao.Text, out int a))
            {
                MessageBox.Show("Número inválido");
                return;
            }
            dataGridViewMovimentacao.Rows.Clear();
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);
            bool encontrou = false;
            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM MOVIMENTACAO_CONTROLE mc join VENDEDORES v on mc.codigo_vendedor = v.codigo " +
                    $"WHERE mc.id_movimentacao = {textBoxNrMovimentacao.Text};"; 

                SqliteDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    labelQuantidadeTotal.Text = Convert.ToString(reader["quantidade_total"]);
                    labelValorTotal.Text = Convert.ToString(reader["valor_total"]);
                    labelData.Text = DateTime.Parse(Convert.ToString(reader["data_movimentacao"])).ToShortDateString();
                    labelVendedor.Text = Convert.ToString(reader["nome"]);
                    labelTipoMovimentacao.Text = Convert.ToString(reader["tipo"]);
                    encontrou = true;
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Movimentação não encontrada");
                }

                if (encontrou)
                {
                    cmd.CommandText = $"select m.quantidade, m.preco_venda, m.codigo_produto, p.descricao, f.nome from MOVIMENTACAO m JOIN PRODUTOS p ON m.codigo_produto = p.codigo " +
                    $"join FABRICANTES f on f.fabricanteId = p.fabricanteId " +
                    $"WHERE m.id_movimentacao = {textBoxNrMovimentacao.Text}";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var qtd = Convert.ToString(reader["quantidade"]);
                        var valorUnit = Convert.ToString(reader["preco_venda"]);
                        var valorTotal = int.Parse(qtd) * float.Parse(valorUnit);

                        dataGridViewMovimentacao.Rows.Add(
                            Convert.ToString(reader["codigo_produto"]),
                            Convert.ToString(reader["descricao"]),
                            Convert.ToString(reader["nome"]),
                            qtd,
                            valorUnit,
                            valorTotal.ToString("0.00"));
                    }
                    reader.Close();
                }

                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintDialog PrintDialog2 = new PrintDialog();
            PrintDialog2.AllowSomePages = true;
            PrintDialog2.ShowHelp = true;
            PrintDialog2.Document = printDocument2;
            DialogResult result = PrintDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }
        
        Bitmap memoryImage;

        private void printDocument2_PrintPage(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString($"MOVIMENTAÇÃO {labelTipoMovimentacao.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 10);
            e.Graphics.DrawString($"Número {textBoxNrMovimentacao.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 30);
            e.Graphics.DrawString($"Vendedora: {labelVendedor.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 50);
            e.Graphics.DrawString(labelData.Text, new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 720, 10);



            e.Graphics.DrawString("Monetti", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 350, 50);

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 90, 900, 90);

            e.Graphics.DrawString("Código", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 95);

            e.Graphics.DrawString("Descrição", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 130, 95);

            e.Graphics.DrawString("Fabricante", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 420, 95);

            e.Graphics.DrawString("Qtd", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 570, 95);

            e.Graphics.DrawString("Preço Unit", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 620, 95);

            e.Graphics.DrawString("Preço Total", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 720, 95);

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 115, 900, 115);

            int height = 100;
            for (int l = numberOfItemsPrintedSoFar; l < dataGridViewMovimentacao.Rows.Count; l++)
            {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 45)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= dataGridViewMovimentacao.Rows.Count)
                    {

                        height += dataGridViewMovimentacao.Rows[0].Height;
                        e.Graphics.DrawString(dataGridViewMovimentacao.Rows[l].Cells[0].FormattedValue.ToString(), dataGridViewMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(30, height, dataGridViewMovimentacao.Columns[0].Width, dataGridViewMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridViewMovimentacao.Rows[l].Cells[1].FormattedValue.ToString(), dataGridViewMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(130, height, dataGridViewMovimentacao.Columns[1].Width, dataGridViewMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridViewMovimentacao.Rows[l].Cells[2].FormattedValue.ToString(), dataGridViewMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(420, height, dataGridViewMovimentacao.Columns[2].Width, dataGridViewMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridViewMovimentacao.Rows[l].Cells[3].FormattedValue.ToString(), dataGridViewMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(570, height, dataGridViewMovimentacao.Columns[3].Width, dataGridViewMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridViewMovimentacao.Rows[l].Cells[4].FormattedValue.ToString(), dataGridViewMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(620, height, dataGridViewMovimentacao.Columns[4].Width, dataGridViewMovimentacao.Rows[0].Height));
                        e.Graphics.DrawString(dataGridViewMovimentacao.Rows[l].Cells[5].FormattedValue.ToString(), dataGridViewMovimentacao.Font = new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(720, height, dataGridViewMovimentacao.Columns[5].Width, dataGridViewMovimentacao.Rows[0].Height));
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
                    return;

                }


            }
            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;
            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, height - 5, 900, height - 5);
            e.Graphics.DrawString($"{labelQuantidadeTotal.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 570, height + 5);
            e.Graphics.DrawString($"R$ {labelValorTotal.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 700, height + 5);
        }

        private void buttonAplicaPercentual_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxPercentual.Text, out float a))
            {
                MessageBox.Show("Número Inválido!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Adicionar {textBoxPercentual.Text}% ?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            for (int i = 0; i < dataGridViewMovimentacao.Rows.Count; i++)
            {
                if (dataGridViewMovimentacao.Rows[i].Cells[4].Value != null)
                {

                    var novoValor = float.Parse(dataGridViewMovimentacao.Rows[i].Cells[4].Value?.ToString());
                    novoValor = novoValor + (novoValor * (float.Parse(textBoxPercentual.Text) / 100));
                    dataGridViewMovimentacao.Rows[i].Cells[4].Value = novoValor.ToString("0.00");
                    CalculaValorTotal(i);
                }
            }

            CalculaQuantidadeTotal();
            CalculaValorSubTotal();
        }

        private void CalculaValorTotal(int currentRoll = -1)
        {
            float valorTotal = 0;
            if (currentRoll == -1)
                currentRoll = dataGridViewMovimentacao.CurrentRow.Index;
            if (dataGridViewMovimentacao[4, currentRoll].Value != null)
            {
                if (float.TryParse(dataGridViewMovimentacao[4, currentRoll].Value.ToString(), out float precoUnit)
                    && int.TryParse(dataGridViewMovimentacao[3, currentRoll].Value.ToString(), out int quant))
                {
                    valorTotal = precoUnit * quant;
                }
                dataGridViewMovimentacao[5, currentRoll].Value = valorTotal.ToString("0.00");
            }
        }

        private void CalculaQuantidadeTotal()
        {
            int qtdTotal = 0;
            for (int i = 0; i < dataGridViewMovimentacao.Rows.Count - 1; i++)
            {
                bool passou = int.TryParse(dataGridViewMovimentacao[3, i].Value?.ToString(), out int qtd);
                if (passou)
                    qtdTotal += qtd;
            }

            labelQuantidadeTotal.Text = qtdTotal.ToString();
        }

        private void CalculaValorSubTotal()
        {
            float valorSubTotal = 0;
            for (int i = 0; i < dataGridViewMovimentacao.Rows.Count - 1; i++)
            {
                bool passou = float.TryParse(dataGridViewMovimentacao[5, i].Value?.ToString(), out float preco);
                if (passou)
                    valorSubTotal += preco;
            }

            labelValorTotal.Text = valorSubTotal.ToString("0.00");
        }

    }
}
