﻿using System;

namespace Estoque {
    partial class FrmCadastraProduto {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextCodigo = new System.Windows.Forms.MaskedTextBox();
            this.buttonCadastraFabricante = new System.Windows.Forms.Button();
            this.comboBoxFabricante = new System.Windows.Forms.ComboBox();
            this.numericQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textMargemLucro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPrecoVenda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPrecoCusto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextCodigo);
            this.groupBox1.Controls.Add(this.buttonCadastraFabricante);
            this.groupBox1.Controls.Add(this.comboBoxFabricante);
            this.groupBox1.Controls.Add(this.numericQuantidade);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.buttonLimpar);
            this.groupBox1.Controls.Add(this.buttonGravar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textMargemLucro);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textPrecoVenda);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textPrecoCusto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textDescricao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 332);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // maskedTextCodigo
            // 
            this.maskedTextCodigo.AllowDrop = true;
            this.maskedTextCodigo.Location = new System.Drawing.Point(89, 54);
            this.maskedTextCodigo.Mask = "0000000000000";
            this.maskedTextCodigo.Name = "maskedTextCodigo";
            this.maskedTextCodigo.Size = new System.Drawing.Size(86, 20);
            this.maskedTextCodigo.TabIndex = 0;
            this.maskedTextCodigo.ValidatingType = typeof(int);
            this.maskedTextCodigo.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextCodigo_MaskInputRejected);
            this.maskedTextCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationHandler);
            this.maskedTextCodigo.Leave += new System.EventHandler(this.codigo_Leave_BuscaProduto);
            this.maskedTextCodigo.GotFocus += new EventHandler(this.maskedTextCodigo_GotFocus);
            // 
            // buttonCadastraFabricante
            // 
            this.buttonCadastraFabricante.Location = new System.Drawing.Point(216, 113);
            this.buttonCadastraFabricante.Name = "buttonCadastraFabricante";
            this.buttonCadastraFabricante.Size = new System.Drawing.Size(134, 23);
            this.buttonCadastraFabricante.TabIndex = 25;
            this.buttonCadastraFabricante.Text = "Cadastrar Fabricante";
            this.buttonCadastraFabricante.UseVisualStyleBackColor = true;
            this.buttonCadastraFabricante.Click += new System.EventHandler(this.buttonCadastraFabricante_Click);
            // 
            // comboBoxFabricante
            // 
            this.comboBoxFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFabricante.FormattingEnabled = true;
            this.comboBoxFabricante.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxFabricante.Location = new System.Drawing.Point(89, 114);
            this.comboBoxFabricante.Name = "comboBoxFabricante";
            this.comboBoxFabricante.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFabricante.Sorted = true;
            this.comboBoxFabricante.TabIndex = 2;
            this.comboBoxFabricante.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBoxFabricante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationHandler);
            // 
            // numericQuantidade
            // 
            this.numericQuantidade.InterceptArrowKeys = false;
            this.numericQuantidade.Location = new System.Drawing.Point(89, 148);
            this.numericQuantidade.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericQuantidade.Name = "numericQuantidade";
            this.numericQuantidade.Size = new System.Drawing.Size(58, 20);
            this.numericQuantidade.TabIndex = 3;
            this.numericQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationHandler);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "%";
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(114, 293);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpar.TabIndex = 8;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // buttonGravar
            // 
            this.buttonGravar.Location = new System.Drawing.Point(24, 293);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 7;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Margem de Lucro:";
            // 
            // textMargemLucro
            // 
            this.textMargemLucro.Location = new System.Drawing.Point(132, 214);
            this.textMargemLucro.Name = "textMargemLucro";
            this.textMargemLucro.Size = new System.Drawing.Size(71, 20);
            this.textMargemLucro.TabIndex = 5;
            this.textMargemLucro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationHandler);
            this.textMargemLucro.Leave += new System.EventHandler(this.lucro_Leave_AplicaLucro);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Preço de Venda:";
            // 
            // textPrecoVenda
            // 
            this.textPrecoVenda.Location = new System.Drawing.Point(132, 248);
            this.textPrecoVenda.Name = "textPrecoVenda";
            this.textPrecoVenda.Size = new System.Drawing.Size(71, 20);
            this.textPrecoVenda.TabIndex = 6;
            this.textPrecoVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationHandler);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Preço de Custo:";
            // 
            // textPrecoCusto
            // 
            this.textPrecoCusto.Location = new System.Drawing.Point(132, 186);
            this.textPrecoCusto.Name = "textPrecoCusto";
            this.textPrecoCusto.Size = new System.Drawing.Size(71, 20);
            this.textPrecoCusto.TabIndex = 4;
            this.textPrecoCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationHandler);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Quantidade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fabricante:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Descrição:";
            // 
            // textDescricao
            // 
            this.textDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textDescricao.Location = new System.Drawing.Point(89, 84);
            this.textDescricao.MaxLength = 34;
            this.textDescricao.Name = "textDescricao";
            this.textDescricao.Size = new System.Drawing.Size(261, 20);
            this.textDescricao.TabIndex = 1;
            this.textDescricao.TextChanged += new System.EventHandler(this.textDescricao_TextChanged);
            this.textDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.navigationHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código:";
            // 
            // FrmCadastraProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 373);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCadastraProduto";
            this.Text = "Cadastra/Altera Produto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPrecoVenda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textMargemLucro;
        private System.Windows.Forms.TextBox textPrecoCusto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericQuantidade;
        private System.Windows.Forms.ComboBox comboBoxFabricante;
        private System.Windows.Forms.Button buttonCadastraFabricante;
        private System.Windows.Forms.MaskedTextBox maskedTextCodigo;
    }
}