﻿using Microsoft.Data.Sqlite;
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
    public partial class FrmCadastraFabricante : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");
        public FrmCadastraFabricante()
        {
            InitializeComponent();
        }

        private void ButtonGravar_Click(object sender, EventArgs e)
        {
            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);

            try
            {
                connection.Open();
                SqliteCommand cmd = connection.CreateCommand();

                cmd.CommandText = $"SELECT * FROM FABRICANTES WHERE nome = '{textNome.Text}'";
                SqliteDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Fabricante já cadastrado!");
                    reader.Close();
                }

                else
                {
                    reader.Close();
                    cmd.CommandText = "INSERT INTO FABRICANTES (nome) VALUES (@nome);";

                    cmd.Parameters.AddWithValue("@nome", textNome.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fabricante cadastrado com sucesso.");
                }

                cmd.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            connection.Close();
            textNome.Clear();
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textNome.Clear();
        }
    }
}
