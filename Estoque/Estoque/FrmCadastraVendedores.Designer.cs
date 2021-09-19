namespace Estoque {
    partial class FrmCadastraVendedores {
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
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.ButtonGravar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTelefone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(171, 157);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpar.TabIndex = 7;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // ButtonGravar
            // 
            this.ButtonGravar.Location = new System.Drawing.Point(72, 157);
            this.ButtonGravar.Name = "ButtonGravar";
            this.ButtonGravar.Size = new System.Drawing.Size(75, 23);
            this.ButtonGravar.TabIndex = 6;
            this.ButtonGravar.Text = "Gravar";
            this.ButtonGravar.UseVisualStyleBackColor = true;
            this.ButtonGravar.Click += new System.EventHandler(this.ButtonGravar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome";
            // 
            // textNome
            // 
            this.textNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textNome.Location = new System.Drawing.Point(69, 37);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(177, 20);
            this.textNome.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Telefone";
            // 
            // textTelefone
            // 
            this.textTelefone.Location = new System.Drawing.Point(69, 73);
            this.textTelefone.MaxLength = 50;
            this.textTelefone.Name = "textTelefone";
            this.textTelefone.Size = new System.Drawing.Size(94, 20);
            this.textTelefone.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "E-mail";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(69, 109);
            this.textEmail.MaxLength = 70;
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(177, 20);
            this.textEmail.TabIndex = 10;
            // 
            // FrmCadastraVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 201);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textTelefone);
            this.Controls.Add(this.buttonLimpar);
            this.Controls.Add(this.ButtonGravar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNome);
            this.Name = "FrmCadastraVendedores";
            this.Text = "Cadastro de Vendedores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLimpar;
        private System.Windows.Forms.Button ButtonGravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTelefone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEmail;
    }
}