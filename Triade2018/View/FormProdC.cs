using MySql.Data.MySqlClient;
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
        private DataTable dt;

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
            produtoC.precov = txtPrecoV.Text.Replace(",", ".");

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
            if (txtBuscaId.Text != "")
            {
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
                    txtBuscarProduto.Enabled = true;

                    //exibindo os itens desse produto composto
                    //produtoC.buscaItens(Convert.ToInt32(txtId.Text));

                    this.buscaItens(Convert.ToInt32(txtId.Text));
                    //dgProdutos.DataSource = produtoC.dt;

                }
                else
                {
                    MessageBox.Show("Nenhum produto encontrado");
                }
            }
            else {
                MessageBox.Show("Digite um id válido!");
            }
            
        }

        private void txtPrecoC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarProduto_Click(object sender, EventArgs e)
        {
            if (txtProduto.Text != "")
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
            else {
                MessageBox.Show("Digite um id de Produto válido!");
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

                this.buscaItens(Convert.ToInt32(txtId.Text));

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este produto?\nEssa operação não poderá ser desfeita!", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                ProdutoC produtoC = new ProdutoC();
                produtoC.excluir(txtId.Text);
                this.limpaCampos();

                //btnSalvar.Enabled = false;

            }
        }

        private void buscaItens(int idPC) {

            Conexao conexao = new Conexao();
            MySqlCommand cmd = new MySqlCommand();

            //conexao com o banco
            cmd.Connection = conexao.conectar();

            cmd.CommandText = "SELECT ps.PS_NOME as Produto, ps.PS_PRECOC as 'Preco Custo', ps.PS_PRECOV as 'Preco Venda', pi.PI_QUANTIDADE as Quantidade, (pi.PI_QUANTIDADE * ps.PS_PRECOV) AS 'Total Item' FROM produtos_simples ps, produtos_compostos_itens pi WHERE ps.PS_ID = pi.PI_PRODUTO_SIMPLES AND pi.PI_PRODUTO_COMPOSTO = @idProd";
            cmd.Parameters.AddWithValue("@idProd", MySqlDbType.Int32).Value = idPC;

            //define o tipo do comando 
            //cmd.CommandType = CommandType.Text;

            //cria um dataadapter
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            //cria um objeto datatable
            DataTable produtos_itens = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(produtos_itens);

            //atribui o datatable ao datagridview para exibir o resultado
            dgProdutos.DataSource = produtos_itens;
            dgProdutos.Enabled = true;

            float preco_total = 0;

            foreach (DataGridViewRow linha in dgProdutos.Rows)
            {
                if ( linha.Cells[4].Value != null ) {
                    preco_total = preco_total + (float.Parse( linha.Cells[4].Value.ToString() ) );
                }                

            }

            lblTotal.Text = "Preço de Custo: R$" + preco_total;

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

            ProdutoCItem produtoc_item = new ProdutoCItem();
            produtoc_item.id_produto_composto = Convert.ToInt32(txtId.Text);
            produtoc_item.id_produto_simples = Convert.ToInt32(txtProduto.Text);

            produtoc_item.remover();

            this.buscaItens(Convert.ToInt32(txtId.Text));

        }
    }
}
