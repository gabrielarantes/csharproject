using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triade2018.Model;

namespace Triade2018.View
{
    public partial class FormRequisicoes : Form
    {

        Requisicao Req = new Requisicao();

        public FormRequisicoes()
        {
            InitializeComponent();
        }

        public void habilita_campos() {
            btnSalvar.Enabled = true;
            txtData.Enabled = true;
            txtFuncionario.Enabled = true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.habilita_campos();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FormRequisicoes_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarItem_Click(object sender, EventArgs e)
        {
            Req.BuscarProduto();
        }
    }
}
