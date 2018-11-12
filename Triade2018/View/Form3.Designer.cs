namespace Triade2018.View
{
    partial class FormMenu
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
            this.btProdutoS = new System.Windows.Forms.Button();
            this.btProdutosC = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btProdutoS
            // 
            this.btProdutoS.Location = new System.Drawing.Point(13, 13);
            this.btProdutoS.Name = "btProdutoS";
            this.btProdutoS.Size = new System.Drawing.Size(112, 23);
            this.btProdutoS.TabIndex = 0;
            this.btProdutoS.Text = "Produto Simples";
            this.btProdutoS.UseVisualStyleBackColor = true;
            this.btProdutoS.Click += new System.EventHandler(this.btProdutoS_Click);
            // 
            // btProdutosC
            // 
            this.btProdutosC.Location = new System.Drawing.Point(13, 43);
            this.btProdutosC.Name = "btProdutosC";
            this.btProdutosC.Size = new System.Drawing.Size(112, 23);
            this.btProdutosC.TabIndex = 1;
            this.btProdutosC.Text = "Produto Composto";
            this.btProdutosC.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 317);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btProdutosC);
            this.Controls.Add(this.btProdutoS);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tríade - Menu Inicial";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btProdutoS;
        private System.Windows.Forms.Button btProdutosC;
        private System.Windows.Forms.Button button1;
    }
}