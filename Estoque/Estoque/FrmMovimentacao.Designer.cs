using System.Drawing.Printing;
using System.Windows.Forms;

namespace Estoque {
    partial class FrmMovimentacao {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMovimentacao));
            this.labelTipoMovimentacao = new System.Windows.Forms.Label();
            this.comboBoxVendedores = new System.Windows.Forms.ComboBox();
            this.buttonCadastraVendedor = new System.Windows.Forms.Button();
            this.dataGridMovimentacao = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelQtdTotal = new System.Windows.Forms.Label();
            this.labelValorTotal = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNrMovimentacao = new System.Windows.Forms.Label();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.labelData = new System.Windows.Forms.Label();
            this.textBoxPercentual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAplicaPercentual = new System.Windows.Forms.Button();
            this.buttonRestauraValores = new System.Windows.Forms.Button();
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMovimentacao)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTipoMovimentacao
            // 
            this.labelTipoMovimentacao.AutoSize = true;
            this.labelTipoMovimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoMovimentacao.Location = new System.Drawing.Point(12, 9);
            this.labelTipoMovimentacao.Name = "labelTipoMovimentacao";
            this.labelTipoMovimentacao.Size = new System.Drawing.Size(39, 13);
            this.labelTipoMovimentacao.TabIndex = 0;
            this.labelTipoMovimentacao.Text = "SAÍDA";
            // 
            // comboBoxVendedores
            // 
            this.comboBoxVendedores.FormattingEnabled = true;
            this.comboBoxVendedores.Location = new System.Drawing.Point(486, 10);
            this.comboBoxVendedores.Name = "comboBoxVendedores";
            this.comboBoxVendedores.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVendedores.TabIndex = 1;
            // 
            // buttonCadastraVendedor
            // 
            this.buttonCadastraVendedor.Location = new System.Drawing.Point(622, 9);
            this.buttonCadastraVendedor.Name = "buttonCadastraVendedor";
            this.buttonCadastraVendedor.Size = new System.Drawing.Size(119, 23);
            this.buttonCadastraVendedor.TabIndex = 2;
            this.buttonCadastraVendedor.Text = "Cadastrar Vendedora";
            this.buttonCadastraVendedor.UseVisualStyleBackColor = true;
            this.buttonCadastraVendedor.Click += new System.EventHandler(this.buttonCadastraVendedor_Click);
            // 
            // dataGridMovimentacao
            // 
            this.dataGridMovimentacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMovimentacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descricao,
            this.Fabricante,
            this.Quantidade,
            this.Valor,
            this.ValorTotal});
            this.dataGridMovimentacao.Location = new System.Drawing.Point(15, 69);
            this.dataGridMovimentacao.Name = "dataGridMovimentacao";
            this.dataGridMovimentacao.Size = new System.Drawing.Size(804, 288);
            this.dataGridMovimentacao.TabIndex = 3;
            this.dataGridMovimentacao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMovimentacao_CellContentClick);
            this.dataGridMovimentacao.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMovimentacao_CellValueChanged);
            this.dataGridMovimentacao.ColumnHeaderCellChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridView1_ColumnHeaderCellChanged);
            this.dataGridMovimentacao.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.dataGridMovimentacao_RowsRemoved);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Valor SubTotal: R$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quantidade SubTotal:";
            // 
            // labelQtdTotal
            // 
            this.labelQtdTotal.AutoSize = true;
            this.labelQtdTotal.Location = new System.Drawing.Point(695, 369);
            this.labelQtdTotal.Name = "labelQtdTotal";
            this.labelQtdTotal.Size = new System.Drawing.Size(0, 13);
            this.labelQtdTotal.TabIndex = 6;
            // 
            // labelValorTotal
            // 
            this.labelValorTotal.AutoSize = true;
            this.labelValorTotal.Location = new System.Drawing.Point(680, 393);
            this.labelValorTotal.Name = "labelValorTotal";
            this.labelValorTotal.Size = new System.Drawing.Size(0, 13);
            this.labelValorTotal.TabIndex = 7;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Location = new System.Drawing.Point(586, 420);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 8;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nr:";
            // 
            // labelNrMovimentacao
            // 
            this.labelNrMovimentacao.AutoSize = true;
            this.labelNrMovimentacao.Location = new System.Drawing.Point(36, 36);
            this.labelNrMovimentacao.Name = "labelNrMovimentacao";
            this.labelNrMovimentacao.Size = new System.Drawing.Size(0, 13);
            this.labelNrMovimentacao.TabIndex = 10;
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Location = new System.Drawing.Point(673, 420);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(75, 23);
            this.buttonImprimir.TabIndex = 11;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(763, 10);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(0, 13);
            this.labelData.TabIndex = 12;
            // 
            // textBoxPercentual
            // 
            this.textBoxPercentual.Location = new System.Drawing.Point(381, 380);
            this.textBoxPercentual.Name = "textBoxPercentual";
            this.textBoxPercentual.Size = new System.Drawing.Size(35, 20);
            this.textBoxPercentual.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Percentual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "%";
            // 
            // buttonAplicaPercentual
            // 
            this.buttonAplicaPercentual.Location = new System.Drawing.Point(313, 406);
            this.buttonAplicaPercentual.Name = "buttonAplicaPercentual";
            this.buttonAplicaPercentual.Size = new System.Drawing.Size(103, 23);
            this.buttonAplicaPercentual.TabIndex = 16;
            this.buttonAplicaPercentual.Text = "Aplica Percentual";
            this.buttonAplicaPercentual.UseVisualStyleBackColor = true;
            this.buttonAplicaPercentual.Click += new System.EventHandler(this.buttonAplicaPercentual_Click);
            // 
            // buttonRestauraValores
            // 
            this.buttonRestauraValores.Location = new System.Drawing.Point(425, 406);
            this.buttonRestauraValores.Name = "buttonRestauraValores";
            this.buttonRestauraValores.Size = new System.Drawing.Size(75, 23);
            this.buttonRestauraValores.TabIndex = 17;
            this.buttonRestauraValores.Text = "Restaurar";
            this.buttonRestauraValores.UseVisualStyleBackColor = true;
            this.buttonRestauraValores.Click += new System.EventHandler(this.buttonRestauraValores_Click);
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.Location = new System.Drawing.Point(182, 38);
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(305, 20);
            this.textBoxObservacao.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Obs:";
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 280;
            // 
            // Fabricante
            // 
            this.Fabricante.HeaderText = "Fabricante";
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.ReadOnly = true;
            this.Fabricante.Width = 150;
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Qtd";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.Width = 40;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor Unitário";
            this.Valor.Name = "Valor";
            this.Valor.Width = 95;
            // 
            // ValorTotal
            // 
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            this.ValorTotal.Width = 95;
            // 
            // FrmMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxObservacao);
            this.Controls.Add(this.buttonRestauraValores);
            this.Controls.Add(this.buttonAplicaPercentual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPercentual);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.labelNrMovimentacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.labelValorTotal);
            this.Controls.Add(this.labelQtdTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridMovimentacao);
            this.Controls.Add(this.buttonCadastraVendedor);
            this.Controls.Add(this.comboBoxVendedores);
            this.Controls.Add(this.labelTipoMovimentacao);
            this.Name = "FrmMovimentacao";
            this.Text = "Movimentação";
            this.Load += new System.EventHandler(this.FrmMovimentacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMovimentacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTipoMovimentacao;
        private System.Windows.Forms.ComboBox comboBoxVendedores;
        private System.Windows.Forms.Button buttonCadastraVendedor;
        private System.Windows.Forms.DataGridView dataGridMovimentacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelQtdTotal;
        private System.Windows.Forms.Label labelValorTotal;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNrMovimentacao;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.TextBox textBoxPercentual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAplicaPercentual;
        private System.Windows.Forms.Button buttonRestauraValores;
        private System.Windows.Forms.TextBox textBoxObservacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
    }
}