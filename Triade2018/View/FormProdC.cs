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
    public partial class FormProdC : Form
    {
        public FormProdC()
        {
            InitializeComponent();
        }

        private void btnNovoPS_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoC produtoC = new ProdutoC();

            produtoC.nome = txtNome.Text;
            produtoC.precov = txtPrecoV.Text.Replace(".", "").Replace(",", ".");

            if (produtoC.validaCampos() == true)
            {
                produtoC.salvar(txtId.Text);
                this.limpaCampos();
            }
        }

        private void limpaCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtPrecoV.Text = "";

            txtNome.Enabled = true;
            txtPrecoV.Enabled = true;

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;

            txtProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            btnAdicionar.Enabled = false;
            btnRemover.Enabled = false;
        }

        private void btBuscaPS_Click(object sender, EventArgs e)
        {
            ProdutoC produtoC = new ProdutoC();
            produtoC.id = Convert.ToInt32(txtBuscaId.Text);

            if (produtoC.BuscarProduto() == true)
            {

                txtId.Text = produtoC.id.ToString();
                txtNome.Text = produtoC.nome;
                txtPrecoV.Text = produtoC.precov;

                txtNome.Enabled = true;
                txtPrecoV.Enabled = true;

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                //habilitando os campos de itens
                txtProduto.Enabled = true;
                txtQuantidade.Enabled = true;
                btnAdicionar.Enabled = true;

                //exibindo os itens desse produto composto
                produtoC.buscaItens(txtId.Text);

            }
            else
            {
                MessageBox.Show("Nenhum produto encontrado");
            }
        }

        private void txtPrecoC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarProduto_Click(object sender, EventArgs e)
        {
            ProdutoS produtoSimples = new ProdutoS();
            produtoSimples.id = Convert.ToInt32(txtProduto.Text);

            if (produtoSimples.BuscarProduto() == true)
            {

                txtProduto.Text = produtoSimples.id.ToString();
                txtNomeProduto.Text = produtoSimples.nome;
                txtProdutoPrecoCusto.Text = produtoSimples.precoc;
                txtProdutoPrecoVenda.Text = produtoSimples.precov;

                txtQuantidade.Enabled = true;
                btnAdicionar.Enabled = true;
                btnRemover.Enabled = true;
            }
            else
            {
                MessageBox.Show("Nenhum produto encontrado");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text == "")
            {
                MessageBox.Show("Você precisa informar uma quantidade válida");
            }
            else {

                ProdutoCItem produto_item = new ProdutoCItem();

                produto_item.id_produto_composto = Convert.ToInt32(txtId.Text);
                produto_item.id_produto_simples = Convert.ToInt32(txtProduto.Text);
                produto_item.quantidade = Convert.ToInt32(txtQuantidade.Text);

                produto_item.adicionarItem();

            }
        }
    }
}
