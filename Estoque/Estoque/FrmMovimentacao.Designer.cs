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
            // 
            // FrmMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCadastraVendedor);
            this.Controls.Add(this.comboBoxVendedores);
            this.Controls.Add(this.label1);
            this.Name = "FrmMovimentacao";
            this.Text = "Movimentação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVendedores;
        private System.Windows.Forms.Button buttonCadastraVendedor;
    }
}