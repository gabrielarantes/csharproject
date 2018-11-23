namespace Triade2018.View
{
    partial class FormRelReq
    {
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.TextBox();
            this.txtDataFim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.dgResult = new System.Windows.Forms.DataGridView();
            this.lblTotalCusto = new System.Windows.Forms.Label();
            this.lblTotalVenda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Final:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Location = new System.Drawing.Point(16, 30);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(96, 20);
            this.txtDataInicio.TabIndex = 2;
            // 
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(137, 30);
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(96, 20);
            this.txtDataFim.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "a";
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(239, 21);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(161, 36);
            this.btnGerar.TabIndex = 5;
            this.btnGerar.Text = "Gerar Relatório";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // dgResult
            // 
            this.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResult.Location = new System.Drawing.Point(16, 68);
            this.dgResult.Name = "dgResult";
            this.dgResult.Size = new System.Drawing.Size(536, 224);
            this.dgResult.TabIndex = 6;
            // 
            // lblTotalCusto
            // 
            this.lblTotalCusto.AutoSize = true;
            this.lblTotalCusto.Location = new System.Drawing.Point(16, 299);
            this.lblTotalCusto.Name = "lblTotalCusto";
            this.lblTotalCusto.Size = new System.Drawing.Size(110, 13);
            this.lblTotalCusto.TabIndex = 7;
            this.lblTotalCusto.Text = "Preço Total de Custo:";
            // 
            // lblTotalVenda
            // 
            this.lblTotalVenda.AutoSize = true;
            this.lblTotalVenda.Location = new System.Drawing.Point(16, 323);
            this.lblTotalVenda.Name = "lblTotalVenda";
            this.lblTotalVenda.Size = new System.Drawing.Size(114, 13);
            this.lblTotalVenda.TabIndex = 8;
            this.lblTotalVenda.Text = "Preço Total de Venda:";
            this.lblTotalVenda.Click += new System.EventHandler(this.label4_Click);
            // 
            // FormRelReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 345);
            this.Controls.Add(this.lblTotalVenda);
            this.Controls.Add(this.lblTotalCusto);
            this.Controls.Add(this.dgResult);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDataFim);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRelReq";
            this.Text = "Relatório de Requisição";
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataInicio;
        private System.Windows.Forms.TextBox txtDataFim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.DataGridView dgResult;
        private System.Windows.Forms.Label lblTotalCusto;
        private System.Windows.Forms.Label lblTotalVenda;
    }
}