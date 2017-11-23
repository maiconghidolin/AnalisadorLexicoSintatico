namespace Views {
    partial class ViewMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.txtArquivoGramatica = new System.Windows.Forms.TextBox();
            this.txtArquivoSaida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSaida = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArquivoCodigoFonte = new System.Windows.Forms.TextBox();
            this.txtArquivoGoldParser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arquivo da gramática";
            // 
            // txtArquivoGramatica
            // 
            this.txtArquivoGramatica.Location = new System.Drawing.Point(13, 48);
            this.txtArquivoGramatica.Name = "txtArquivoGramatica";
            this.txtArquivoGramatica.Size = new System.Drawing.Size(383, 20);
            this.txtArquivoGramatica.TabIndex = 1;
            this.txtArquivoGramatica.Click += new System.EventHandler(this.txtArquivoGramatica_Click);
            // 
            // txtArquivoSaida
            // 
            this.txtArquivoSaida.Location = new System.Drawing.Point(15, 146);
            this.txtArquivoSaida.Name = "txtArquivoSaida";
            this.txtArquivoSaida.Size = new System.Drawing.Size(381, 20);
            this.txtArquivoSaida.TabIndex = 2;
            this.txtArquivoSaida.Click += new System.EventHandler(this.txtArquivoSaida_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Arquivo de Saída";
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(282, 227);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(112, 23);
            this.btnExecutar.TabIndex = 4;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 1001;
            this.label3.Text = "Arquivo do código fonte";
            // 
            // txtArquivoCodigoFonte
            // 
            this.txtArquivoCodigoFonte.Location = new System.Drawing.Point(15, 97);
            this.txtArquivoCodigoFonte.Name = "txtArquivoCodigoFonte";
            this.txtArquivoCodigoFonte.Size = new System.Drawing.Size(381, 20);
            this.txtArquivoCodigoFonte.TabIndex = 1000;
            this.txtArquivoCodigoFonte.Click += new System.EventHandler(this.txtArquivoCodigoFonte_Click);
            // 
            // txtArquivoGoldParser
            // 
            this.txtArquivoGoldParser.Location = new System.Drawing.Point(15, 195);
            this.txtArquivoGoldParser.Name = "txtArquivoGoldParser";
            this.txtArquivoGoldParser.Size = new System.Drawing.Size(381, 20);
            this.txtArquivoGoldParser.TabIndex = 1002;
            this.txtArquivoGoldParser.Click += new System.EventHandler(this.txtArquivoGoldParser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 1003;
            this.label4.Text = "Arquivo Gold Parser";
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 257);
            this.Controls.Add(this.txtArquivoGoldParser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtArquivoCodigoFonte);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.txtArquivoSaida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtArquivoGramatica);
            this.Controls.Add(this.label1);
            this.Name = "ViewMain";
            this.Text = "Gerador de Autômatos Finitos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArquivoGramatica;
        private System.Windows.Forms.TextBox txtArquivoSaida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSaida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArquivoCodigoFonte;
        private System.Windows.Forms.TextBox txtArquivoGoldParser;
        private System.Windows.Forms.Label label4;
    }
}

