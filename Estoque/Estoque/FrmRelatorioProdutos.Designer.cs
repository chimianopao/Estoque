namespace Estoque {
    partial class FrmRelatorioProdutos {
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
            this.buttonTotalGeral = new System.Windows.Forms.Button();
            this.comboBoxFabricante = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonTotalPorFabricante = new System.Windows.Forms.Button();
            this.buttonListaPorFabricante = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTotalGeral
            // 
            this.buttonTotalGeral.Location = new System.Drawing.Point(101, 78);
            this.buttonTotalGeral.Name = "buttonTotalGeral";
            this.buttonTotalGeral.Size = new System.Drawing.Size(118, 33);
            this.buttonTotalGeral.TabIndex = 0;
            this.buttonTotalGeral.Text = "Mostrar total geral";
            this.buttonTotalGeral.UseVisualStyleBackColor = true;
            this.buttonTotalGeral.Click += new System.EventHandler(this.buttonTotalGeral_Click);
            // 
            // comboBoxFabricante
            // 
            this.comboBoxFabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFabricante.FormattingEnabled = true;
            this.comboBoxFabricante.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxFabricante.Location = new System.Drawing.Point(610, 39);
            this.comboBoxFabricante.Name = "comboBoxFabricante";
            this.comboBoxFabricante.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFabricante.Sorted = true;
            this.comboBoxFabricante.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fabricante:";
            // 
            // buttonTotalPorFabricante
            // 
            this.buttonTotalPorFabricante.Location = new System.Drawing.Point(545, 78);
            this.buttonTotalPorFabricante.Name = "buttonTotalPorFabricante";
            this.buttonTotalPorFabricante.Size = new System.Drawing.Size(145, 33);
            this.buttonTotalPorFabricante.TabIndex = 14;
            this.buttonTotalPorFabricante.Text = "Mostrar total por Fabricante";
            this.buttonTotalPorFabricante.UseVisualStyleBackColor = true;
            this.buttonTotalPorFabricante.Click += new System.EventHandler(this.buttonTotalPorFabricante_Click);
            // 
            // buttonListaPorFabricante
            // 
            this.buttonListaPorFabricante.Location = new System.Drawing.Point(545, 134);
            this.buttonListaPorFabricante.Name = "buttonListaPorFabricante";
            this.buttonListaPorFabricante.Size = new System.Drawing.Size(145, 40);
            this.buttonListaPorFabricante.TabIndex = 15;
            this.buttonListaPorFabricante.Text = "Listar por fabricante";
            this.buttonListaPorFabricante.UseVisualStyleBackColor = true;
            this.buttonListaPorFabricante.Click += new System.EventHandler(this.buttonListaPorFabricante_Click);
            // 
            // FrmRelatorioProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonListaPorFabricante);
            this.Controls.Add(this.buttonTotalPorFabricante);
            this.Controls.Add(this.comboBoxFabricante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonTotalGeral);
            this.Name = "FrmRelatorioProdutos";
            this.Text = "FrmRelatorioProdutos";
            this.ResumeLayout(false);
            this.PerformLayout();

            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
        }

        #endregion

        private System.Windows.Forms.Button buttonTotalGeral;
        private System.Windows.Forms.ComboBox comboBoxFabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTotalPorFabricante;
        private System.Windows.Forms.Button buttonListaPorFabricante;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}