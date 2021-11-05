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
    public partial class FrmRelatorioProdutos : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");
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
            try
            {
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
    }
}
