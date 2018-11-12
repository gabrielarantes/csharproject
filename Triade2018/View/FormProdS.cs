using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triade2018.View;

namespace Triade2018.View
{
    public partial class FormProdS : Form
    {
        public FormProdS()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNovoPS_Click(object sender, EventArgs e)
        {
            limpaCampos();

            
        }

        private void btBuscaPS_Click(object sender, EventArgs e)
        {
            ProdutoS produtoSimples = new ProdutoS();
            produtoSimples.id = Convert.ToInt32(txtBuscaId.Text);

            if (produtoSimples.BuscarProduto() == true)
            {

                txtId.Text = produtoSimples.id.ToString();
                txtNome.Text = produtoSimples.nome;
                txtPrecoC.Text = produtoSimples.precoc;
                txtPrecoV.Text = produtoSimples.precov;

                txtNome.Enabled = true;
                txtPrecoC.Enabled = true;
                txtPrecoV.Enabled = true;

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

            }
            else {
                MessageBox.Show("Nenhum produto encontrado");
            }
            
        }

        private void FormProdS_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProdutoS produtoS = new ProdutoS();

            //produtoS.id = Convert.ToInt32(txtId.Text);
            produtoS.nome = txtNome.Text;
            produtoS.precoc = txtPrecoC.Text.Replace(".", "").Replace(",", ".");
            produtoS.precov = txtPrecoV.Text.Replace(".", "").Replace(",", ".");

            if (produtoS.validaCampos() == true) {
                produtoS.salvar(txtId.Text);
                this.limpaCampos();
            }

        }

        private void limpaCampos() {
            txtId.Text = "";
            txtNome.Text = "";
            txtPrecoC.Text = "";
            txtPrecoV.Text = "";

            txtNome.Enabled = true;
            txtPrecoC.Enabled = true;
            txtPrecoV.Enabled = true;

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("Deseja realmente excluir este produto?\nEssa operação não poderá ser desfeita!","Cuidado",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes) {

                ProdutoS produtoS = new ProdutoS();
                produtoS.excluir(txtId.Text);
                this.limpaCampos();

                btnSalvar.Enabled = false;

            }
            
            
        }
    }
}
