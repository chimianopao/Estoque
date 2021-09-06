﻿using System;
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

        private void buttonGravar_Click(object sender, EventArgs e)
        {
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
                        $"{numericQuantidade.Value}, {textPrecoCusto.Text}, {textPrecoVenda.Text}, {textMargemLucro.Text});";

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Produto cadastrado com sucesso.");
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
                        $"quantidade = {numericQuantidade.Value}, preco_custo = {textPrecoCusto.Text}, " +
                        $"preco_venda = {textPrecoVenda.Text}, margem_lucro = {textMargemLucro.Text} " +
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
            }
            
            LimpaCampos();
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos(bool limpaCodigo = true)
        {
            if(limpaCodigo == true)
                maskedTextCodigo.Clear();

            textDescricao.Clear();
            comboBoxFabricante.ResetText();
            numericQuantidade.Value = 1;
            textPrecoCusto.Clear();
            textPrecoVenda.Clear();
            textMargemLucro.Clear();
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

        private void textCodigo_TextChanged(object sender, EventArgs e)
        {

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

        private void maskedTextCodigo_Leave(object sender, EventArgs e)
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
                while (reader.Read())
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
                LimpaCampos(false);
        }
    }
}
