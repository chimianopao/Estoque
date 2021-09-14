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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVendedores = new System.Windows.Forms.ComboBox();
            this.buttonCadastraVendedor = new System.Windows.Forms.Button();
            this.dataGridMovimentacao = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelQtdTotal = new System.Windows.Forms.Label();
            this.labelValorTotal = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNrMovimentacao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMovimentacao)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SAÍDA";
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
            this.dataGridMovimentacao.Size = new System.Drawing.Size(726, 288);
            this.dataGridMovimentacao.TabIndex = 3;
            this.dataGridMovimentacao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMovimentacao_CellContentClick);
            this.dataGridMovimentacao.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMovimentacao_CellValueChanged);
            this.dataGridMovimentacao.ColumnHeaderCellChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridView1_ColumnHeaderCellChanged);
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
            // 
            // Fabricante
            // 
            this.Fabricante.HeaderText = "Fabricante";
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.ReadOnly = true;
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor Unitário";
            this.Valor.Name = "Valor";
            // 
            // ValorTotal
            // 
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Valor SubTotal: R$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quantidade SubTotal:";
            // 
            // labelQtdTotal
            // 
            this.labelQtdTotal.AutoSize = true;
            this.labelQtdTotal.Location = new System.Drawing.Point(644, 364);
            this.labelQtdTotal.Name = "labelQtdTotal";
            this.labelQtdTotal.Size = new System.Drawing.Size(0, 13);
            this.labelQtdTotal.TabIndex = 6;
            // 
            // labelValorTotal
            // 
            this.labelValorTotal.AutoSize = true;
            this.labelValorTotal.Location = new System.Drawing.Point(642, 388);
            this.labelValorTotal.Name = "labelValorTotal";
            this.labelValorTotal.Size = new System.Drawing.Size(0, 13);
            this.labelValorTotal.TabIndex = 7;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Location = new System.Drawing.Point(535, 415);
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
            // FrmMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Controls.Add(this.label1);
            this.Name = "FrmMovimentacao";
            this.Text = "Movimentação";
            this.Load += new System.EventHandler(this.FrmMovimentacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMovimentacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVendedores;
        private System.Windows.Forms.Button buttonCadastraVendedor;
        private System.Windows.Forms.DataGridView dataGridMovimentacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelQtdTotal;
        private System.Windows.Forms.Label labelValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNrMovimentacao;
    }
}