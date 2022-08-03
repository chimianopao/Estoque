using Microsoft.Data.Sqlite;
using System;
using System.Collections;
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
    public partial class FrmRelatorioProdutos : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");

        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        private int page = 1;
        List<Produto> listaProdutos = new List<Produto>();
        private PrintDocument printDocument = new PrintDocument();
        public FrmRelatorioProdutos()
        {
            InitializeComponent();
            CarregaFabricantes();
        }

        private void buttonTotalGeral_Click(object sender, EventArgs e)
        {
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);
            var quantidadeTotal = 0;
            double valorTotal = 0;
            //try
            //{
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PRODUTOS";

                SqliteDataReader reader;
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    var quantidade = int.Parse(Convert.ToString(reader["quantidade"]));
                    if (quantidade > 0)
                    {
                    var codigo = Convert.ToString(reader["codigo"]);
                        quantidadeTotal += quantidade;
                        valorTotal += quantidade * double.Parse(Convert.ToString(reader["preco_venda"]));
                    }
                }

                reader.Dispose();
                cmd.Dispose();
            //}
            //catch (Exception erro)
            //{
            //    MessageBox.Show(erro.Message);
            //}
            connection.Close();

            MessageBox.Show($"Quantidade total: {quantidadeTotal} \nValor de venda total: R$ {valorTotal.ToString("0.00")}");
        }

        private void CarregaFabricantes()
        {
            this.comboBoxFabricante.Items.Clear();
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);

            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM FABRICANTES";

                SqliteDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.comboBoxFabricante.Items.Add(Convert.ToString(reader["nome"]));
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

        private void buttonTotalPorFabricante_Click(object sender, EventArgs e)
        {
            if (comboBoxFabricante.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione um Fabricante.");
                return;
            }

            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);
            var quantidadeTotal = 0;
            double valorTotal = 0;
            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PRODUTOS p join FABRICANTES f on f.fabricanteId = p.fabricanteId " +
                    $"WHERE f.nome = '{comboBoxFabricante.Text}'";

                SqliteDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var quantidade = int.Parse(Convert.ToString(reader["quantidade"]));
                    if(quantidade > 0)
                    {
                        quantidadeTotal += quantidade;
                        valorTotal += quantidade * double.Parse(Convert.ToString(reader["preco_venda"]));
                    }
                }

                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();

            MessageBox.Show($"Quantidade total: {quantidadeTotal} \nValor de venda total: R$ {valorTotal.ToString("0.00")}");
        }

        private class Produto
        {
            public string codigo;
            public string descricao;
            public string fabricante;
            public string qtd;
            public string precoCusto;
            public string precoVenda;
            public string margemLucro;

            public Produto(string codigo, string descricao, string fabricante, string qtd, string precoCusto, string precoVenda, string margemLucro)
            {
                this.codigo = codigo;
                this.descricao = descricao;
                this.fabricante = fabricante;
                this.qtd = qtd;
                this.precoCusto = precoCusto;
                this.precoVenda = precoVenda;
                this.margemLucro = margemLucro;
            }
        }

        private void buttonListaPorFabricante_Click(object sender, EventArgs e)
        {
            if (comboBoxFabricante.SelectedIndex == -1)
            {
                MessageBox.Show("Primeiro selecione um Fabricante.");
                return;
            }

            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);
            var quantidadeTotal = 0;
            double valorTotal = 0;
            listaProdutos = new List<Produto>();

            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PRODUTOS p join FABRICANTES f on f.fabricanteId = p.fabricanteId " +
                    $"WHERE f.nome = '{comboBoxFabricante.Text}'";

                SqliteDataReader reader;
                reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    listaProdutos.Add(new Produto(
                        Convert.ToString(reader["codigo"]),
                        Convert.ToString(reader["descricao"]),
                        Convert.ToString(reader["nome"]),
                        Convert.ToString(reader["quantidade"]),
                        Convert.ToString(reader["preco_custo"]),
                        Convert.ToString(reader["preco_venda"]),
                        Convert.ToString(reader["margem_lucro"])));

                    var quantidade = int.Parse(Convert.ToString(reader["quantidade"]));
                    if (quantidade > 0)
                    {
                        quantidadeTotal += quantidade;
                        valorTotal += quantidade * double.Parse(Convert.ToString(reader["preco_venda"]));
                    }
                }

                reader.Dispose();
                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();

            numberOfItemsPrintedSoFar = 0;
            imprimirListagem();

            //MessageBox.Show($"Quantidade total: {quantidadeTotal} \nValor de venda total: R$ {valorTotal.ToString("0.00")}");
        }

        

        public void imprimirListagem()
        {
            System.Windows.Forms.PrintDialog PrintDialog = new PrintDialog();
            PrintDialog.AllowSomePages = true;
            PrintDialog.ShowHelp = true;
            PrintDialog.Document = printDocument;
            DialogResult result = PrintDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }

        }

        public void printDocument_PrintPage(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString($"RELATÓRIO DO FABRICANTE {comboBoxFabricante.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 10);
            e.Graphics.DrawString(DateTime.Today.ToShortDateString(), new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 720, 10);
            //e.Graphics.DrawString($"Página: {page}/{(int)(listaProdutos.Count / 62) + 1}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 720, 30);



            e.Graphics.DrawString("Monetti", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 350, 50);

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 90, 900, 90);

            e.Graphics.DrawString("Código", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 30, 95);

            e.Graphics.DrawString("Descrição", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 130, 95);

            e.Graphics.DrawString("Lucro", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 420, 95);

            e.Graphics.DrawString("Qtd", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 570, 95);

            e.Graphics.DrawString("Preço Custo", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 620, 95);

            e.Graphics.DrawString("Preço Venda", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 720, 95);

            e.Graphics.DrawLine(new Pen(Color.Black, 2), 0, 115, 900, 115);

            int height = 105;
            

            for (int l = numberOfItemsPrintedSoFar; l < listaProdutos.Count - 1; l++)
                {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 60)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= listaProdutos.Count)
                    {

                        height += (22 - 6);
                        e.Graphics.DrawString(listaProdutos[l].codigo.ToString(), new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(30, height, 100, 22));
                        e.Graphics.DrawString(listaProdutos[l].descricao.ToString(), new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(130, height, 280, 22));
                        e.Graphics.DrawString(listaProdutos[l].margemLucro.ToString()+"%", new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(420, height, 150, 22));
                        e.Graphics.DrawString(listaProdutos[l].qtd.ToString(), new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(570, height, 40, 22));
                        e.Graphics.DrawString(listaProdutos[l].precoCusto.ToString(),new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(620, height, 95, 22));
                        e.Graphics.DrawString(listaProdutos[l].precoVenda.ToString(), new Font("Book Antiqua", 8), Brushes.Black, new RectangleF(720, height, 95, 22));
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
            //e.Graphics.DrawString($"{labelQuantidadeTotal.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 570, height + 5);
            //e.Graphics.DrawString($"R$ {labelValorTotal.Text}", new System.Drawing.Font("Book Antiqua", 9, FontStyle.Bold), Brushes.Black, 700, height + 5);
        }
    }
}
