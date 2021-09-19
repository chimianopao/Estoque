namespace Estoque {
    partial class FrmCadastraFabricante {
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
            this.textNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonGravar = new System.Windows.Forms.Button();
            this.buttonLimpar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textNome
            // 
            this.textNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textNome.Location = new System.Drawing.Point(68, 30);
            this.textNome.MaxLength = 17;
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(177, 20);
            this.textNome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome";
            // 
            // ButtonGravar
            // 
            this.ButtonGravar.Location = new System.Drawing.Point(68, 70);
            this.ButtonGravar.Name = "ButtonGravar";
            this.ButtonGravar.Size = new System.Drawing.Size(75, 23);
            this.ButtonGravar.TabIndex = 2;
            this.ButtonGravar.Text = "Gravar";
            this.ButtonGravar.UseVisualStyleBackColor = true;
            this.ButtonGravar.Click += new System.EventHandler(this.ButtonGravar_Click);
            // 
            // buttonLimpar
            // 
            this.buttonLimpar.Location = new System.Drawing.Point(167, 70);
            this.buttonLimpar.Name = "buttonLimpar";
            this.buttonLimpar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpar.TabIndex = 3;
            this.buttonLimpar.Text = "Limpar";
            this.buttonLimpar.UseVisualStyleBackColor = true;
            this.buttonLimpar.Click += new System.EventHandler(this.buttonLimpar_Click);
            // 
            // FrmCadastraFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 145);
            this.Controls.Add(this.buttonLimpar);
            this.Controls.Add(this.ButtonGravar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNome);
            this.Name = "FrmCadastraFabricante";
            this.Text = "Cadastro de Fabricante";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonGravar;
        private System.Windows.Forms.Button buttonLimpar;
    }
}