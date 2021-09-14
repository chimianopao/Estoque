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
    public partial class EstoqueWindow : Form {
        public EstoqueWindow()
        {
            InitializeComponent();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaProduto consultaProduto = new FrmConsultaProduto();
            consultaProduto.MdiParent = this;
            consultaProduto.Show();

            //show dialog abre em outra janela
        }

        private void cadastraAlteraProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastraProduto cadastraProduto = new FrmCadastraProduto();
            cadastraProduto.MdiParent = this;
            cadastraProduto.Show();
        }

        private void saidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimentacao movimentacao = new FrmMovimentacao("SAIDA");
            movimentacao.MdiParent = this;
            movimentacao.Show();
        }

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimentacao movimentacao = new FrmMovimentacao("ENTRADA");
            movimentacao.MdiParent = this;
            movimentacao.Show();
        }
    }
}
