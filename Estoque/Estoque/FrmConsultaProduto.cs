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
    public partial class FrmConsultaProduto : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");
        public FrmConsultaProduto()
        {
            InitializeComponent();
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maskedTextCodigo.Text.Trim()))
            {
                SqliteConnection connection;
                String strConn = @"Data Source=" + pathSQL;
                connection = new SqliteConnection(strConn);

                try
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"UPDATE PRODUTOS " +
                        $"SET quantidade = {numericQuantidade.Value} " +
                        $"WHERE codigo = {maskedTextCodigo.Text}";

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Produto alterado com sucesso.");
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                connection.Close();
                LimpaCampos();

            }
        }

        private void maskedTextCodigo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void navigationHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Down)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            if(e.KeyData == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void maskedTextCodigo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maskedTextCodigo.Text.Trim()))
            {
                SqliteConnection connection;
                String strConn = @"Data Source=" + pathSQL;
                connection = new SqliteConnection(strConn);

                try
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM PRODUTOS p " +
                        $"join FABRICANTES f on f.fabricanteId = p.fabricanteId " +
                        $"WHERE p.codigo = {maskedTextCodigo.Text}";

                    SqliteDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textDescricao.Text = Convert.ToString(reader["descricao"]);
                        textFabricante.Text = Convert.ToString(reader["nome"]);
                        numericQuantidade.Text = Convert.ToString(reader["quantidade"]);
                        textPrecoCusto.Text = Convert.ToString(reader["preco_custo"]);
                        textMargemLucro.Text = Convert.ToString(reader["margem_lucro"]);
                        textPrecoVenda.Text = Convert.ToString(reader["preco_venda"]);
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado");
                        LimpaCampos(false);
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
        }
        private void LimpaCampos(bool apagaCodigo = true)
        {
            if(apagaCodigo)
                maskedTextCodigo.Clear();

            textDescricao.Clear();
            textFabricante.Clear();
            numericQuantidade.Value = 0;
            textPrecoCusto.Clear();
            textPrecoVenda.Clear();
            textMargemLucro.Clear();

            ActiveControl = maskedTextCodigo;
        }

        private void buttonLimpar_Click_1(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void numericQuantidade_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
