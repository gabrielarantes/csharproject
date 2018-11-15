using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triade2018.View
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        public Form1 form1 = new Form1();
        public FormProdS formProdS = new FormProdS();
        public FormProdC formProdC = new FormProdC();
        //public FormProdC formProdC = null;

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void simplesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.closeForms();
            this.formProdS.TopLevel = false;
            this.formProdS.Visible = true;
            this.Controls.Add(this.formProdS);
            //this.ArrangeFormSize(this.formProdS);
            this.formProdS.Location = new Point(0, 25);
        }

        private void FormMenu_SizeChanged() {
            //this.ArrangeFormSize();
        }

        private void closeForms() {
            this.formProdS.Hide();
            this.formProdC.Hide();
        }

        private void ArrangeFormSize() {
            //this.formProdS.Location = new Point(0,25);
            //this.formProdC.Location = new Point(0, 25);
        }

        private void compostosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.closeForms();
            this.formProdC.TopLevel = false;
            this.formProdC.Visible = true;
            this.Controls.Add(this.formProdC);
            //this.ArrangeFormSize(this.formProdC);
            this.formProdC.Location = new Point(0, 25);
        }
    }
}
