using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Estoque {
    public partial class FrmCadastraProduto : Form {
        string pathSQL = System.IO.Path.Combine(Environment.CurrentDirectory, @"sql\", "estoque.db");
        bool alteracao = false;
        public FrmCadastraProduto()
        {
            InitializeComponent();
            CarregaFabricantes();
        }

        private bool validaCampos()
        {
            if (string.IsNullOrEmpty(maskedTextCodigo.Text.Trim()))
            {
                MessageBox.Show("Código é um campo obrigatório.");
                return false;
            }
            if (textDescricao.Text == "")
            {
                MessageBox.Show("Descrição é um campo obrigatório.");
                return false;
            }
            if (comboBoxFabricante.SelectedIndex == -1)
            {
                MessageBox.Show("Fabricante é um campo obrigatório.");
                return false;
            }
            if (textPrecoVenda.Text == "")
            {
                MessageBox.Show("Preço de Venda é um campo obrigatório.");
                return false;
            }

            bool precoVenda = Double.TryParse(textPrecoVenda.Text, out double resultV);
            if (precoVenda == false)
            {
                MessageBox.Show("Preço de Venda não possui um número válido.");
                return false;
            }

            bool precoCusto = Double.TryParse(textPrecoCusto.Text, out double resultC);
            if (textPrecoCusto.Text != "" && precoCusto == false)
            {
                MessageBox.Show("Preço de Custo não possui um número válido.");
                return false;
            }

            bool margemLucro = Double.TryParse(textMargemLucro.Text, out double resultM);
            if (textMargemLucro.Text != "" && margemLucro == false)
            {
                MessageBox.Show("Margem de Lucro não possui um número válido.");
                return false;
            }

            return true;
        }

        private string getPrecoCusto()
        {
            if (textPrecoCusto.Text == "")
                return "null";
            else
                return $"'{textPrecoCusto.Text}'";
        }

        private string getMargemLucro()
        {
            if (textMargemLucro.Text == "")
                return "null";
            else
                return $"'{textMargemLucro.Text}'";
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            if (!validaCampos())
                return;

            SqliteConnection connection;
            String strConn = @"Data Source=" + pathSQL;
            connection = new SqliteConnection(strConn);

            if(alteracao == false)
            {
                try
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"INSERT INTO PRODUTOS (codigo, descricao, fabricanteId, quantidade, preco_custo, preco_venda, margem_lucro) " +
                        $"VALUES ({maskedTextCodigo.Text}, '{textDescricao.Text.ToUpper()}', " +
                        $"(select fab.fabricanteId from FABRICANTES fab WHERE fab.nome = '{comboBoxFabricante.Text}'), " +
                        $"{numericQuantidade.Value}, {getPrecoCusto()}, '{textPrecoVenda.Text}', {getMargemLucro()});";

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Produto cadastrado com sucesso.");
                    LimpaCampos();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                connection.Close();
            }

            else
            {
                try
                {
                    connection.Open();
                    SqliteCommand cmd = connection.CreateCommand();
                    cmd.CommandText = $"UPDATE PRODUTOS " +
                        $"SET descricao = '{textDescricao.Text}', " +
                        $"fabricanteId = (select fab.fabricanteId from FABRICANTES fab WHERE fab.nome = '{comboBoxFabricante.Text}'), " +
                        $"quantidade = {numericQuantidade.Value}, preco_custo = {getPrecoCusto()}, " +
                        $"preco_venda = '{textPrecoVenda.Text}', margem_lucro = {getMargemLucro()} " +
                        $"WHERE codigo = {maskedTextCodigo.Text}"; 

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Produto alterado com sucesso.");
                    LimpaCampos();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                connection.Close();
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos(bool insert = false)
        {
            textDescricao.Clear();
            comboBoxFabricante.SelectedIndex = -1;
            numericQuantidade.Value = 1;
            textPrecoCusto.Clear();
            textPrecoVenda.Clear();
            textMargemLucro.Clear();

            if (insert == false)
            {
                maskedTextCodigo.Clear();
                ActiveControl = maskedTextCodigo;
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCadastraFabricante_Click(object sender, EventArgs e)
        {
            FrmCadastraFabricante cadastraFabricante = new FrmCadastraFabricante();
            cadastraFabricante.FormClosing += new FormClosingEventHandler(this.FrmCadastraFabricante_FormClosing);
            cadastraFabricante.ShowDialog();
        }

        private void FrmCadastraFabricante_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CarregaFabricantes();
        }

        private void textDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextCodigo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void codigo_Leave_BuscaProduto(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maskedTextCodigo.Text.Trim()))
            {
                SqliteConnection connection;
                String strConn = @"Data Source=" + pathSQL;
                connection = new SqliteConnection(strConn);
                alteracao = false;

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
                        comboBoxFabricante.Text = Convert.ToString(reader["nome"]);
                        numericQuantidade.Text = Convert.ToString(reader["quantidade"]);
                        textPrecoCusto.Text = Convert.ToString(reader["preco_custo"]);
                        textMargemLucro.Text = Convert.ToString(reader["margem_lucro"]);
                        textPrecoVenda.Text = Convert.ToString(reader["preco_venda"]);
                        alteracao = true;
                    }

                    reader.Dispose();
                    cmd.Dispose();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                connection.Close();

                if (alteracao == false)
                    LimpaCampos(true);
            }
        }

        private void lucro_Leave_AplicaLucro(object sender, EventArgs e)
        {
            if(float.TryParse(textPrecoCusto.Text, out float bruto) &&
                float.TryParse(textMargemLucro.Text, out float margem) &&
                !float.TryParse(textPrecoVenda.Text, out float liquido))
            {
                textPrecoVenda.Text = (bruto + (bruto * (margem / 100))).ToString("0.00");
            }
            
        }
        private void navigationHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Down)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyData == Keys.Up)
            {
                SendKeys.Send("+{TAB}");
            }
        }

        private void maskedTextCodigo_GotFocus(object sender, EventArgs e)
        {
            if (maskedTextCodigo.Text.Length > 0)
                maskedTextCodigo.SelectAll();
        }
    }
}
