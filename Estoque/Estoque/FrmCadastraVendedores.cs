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
    public partial class FrmCadastraVendedores : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");
        public FrmCadastraVendedores()
        {
            InitializeComponent();
        }

        private void ButtonGravar_Click(object sender, EventArgs e)
        {
            if (textNome.Text == "")
            {
                MessageBox.Show("Nome é um campo obrigatório.");
                return;
            }

            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);

            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();

                cmd.CommandText = $"SELECT * FROM VENDEDORES WHERE nome = '{textNome.Text}'";
                SqliteDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Vendedor(a) já cadastrado(a)!");
                    reader.Close();
                }

                else
                {
                    reader.Close();

                    cmd.CommandText = "INSERT INTO VENDEDORES (nome, telefone, email) VALUES (@nome, @telefone, @email);";

                    cmd.Parameters.AddWithValue("@nome", textNome.Text);
                    cmd.Parameters.AddWithValue("@telefone", textTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", textEmail.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vendedor(a) cadastrado(a) com sucesso.");
                }

                cmd.Dispose();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();
            LimpaCampos();
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            textNome.Clear();
            textTelefone.Clear();
            textEmail.Clear();
        }
    }
}
