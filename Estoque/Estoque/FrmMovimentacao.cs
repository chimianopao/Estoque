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

            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "ColumnHeaderCellChanged Event");
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
            if (e.ColumnIndex == 0)
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

            return new object[] { codigoProduto, descricao, nomeFabricante, 1, precoVenda };
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
