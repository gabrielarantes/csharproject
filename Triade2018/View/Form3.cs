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
        public FormRequisicoes formReq = new FormRequisicoes();
        public FormRelReq formRelReq = new FormRelReq();

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
            this.formReq.Hide();
            this.formRelReq.Hide();
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

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.form1.Close();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void requisiçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.closeForms();
            this.formReq.TopLevel = false;
            this.formReq.Visible = true;
            this.Controls.Add(this.formReq);
            //this.ArrangeFormSize(this.formProdS);
            this.formReq.Location = new Point(0, 25);
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void relatórioDeRequisiçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.closeForms();
            this.formRelReq.TopLevel = false;
            this.formRelReq.Visible = true;
            this.Controls.Add(this.formRelReq);
            //this.ArrangeFormSize(this.formProdS);
            this.formRelReq.Location = new Point(0, 25);
        }
    }
}
