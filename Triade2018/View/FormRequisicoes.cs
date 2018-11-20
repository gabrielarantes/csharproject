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
    public partial class FormRequisicoes : Form
    {

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
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Requisicao requisicao = new Requisicao();

            //requisicao.id = Convert.ToInt32(txtId.Text);
            var data = txtData.Text.Replace("/","-");
            var date = data.Split('-');

            var dia = date[0];
            var mes = date[1];
            var ano = date[1];

            requisicao.data = ano + '-' + mes + '-' + dia;

            requisicao.nome = txtFuncionario.Text;

            if (requisicao.validaCampos() == true)
            {
                requisicao.salvar(txtId.Text);
                this.limpaCampos();
            }
        }

        private void limpaCampos()
        {
            txtId.Text = "";
            txtFuncionario.Text = "";
            txtData.Text = "";

            //txtId.Enabled = true;
            txtFuncionario.Enabled = true;
            txtData.Enabled = true;

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
        }

        private void btBusca_Click(object sender, EventArgs e)
        {
            if (txtBuscaId.Text != "")
            {
                Requisicao requisicao = new Requisicao();
                requisicao.id = Convert.ToInt32(txtBuscaId.Text);

                if (requisicao.Buscar() == true)
                {

                    txtId.Text = requisicao.id.ToString();
                    txtFuncionario.Text = requisicao.nome;
                    txtData.Text = requisicao.data;
                    //txtPrecoC.Text = produtoSimples.precoc;
                    //txtPrecoV.Text = produtoSimples.precov;

                    txtFuncionario.Enabled = true;
                    txtData.Enabled = true;
                    //txtPrecoV.Enabled = true;

                    btnSalvar.Enabled = true;
                    btnExcluir.Enabled = true;

                    //buscar itens dessa requisição
                    this.buscaItens(Convert.ToInt32(txtId.Text));

                }
                else
                {
                    MessageBox.Show("Nenhum produto encontrado");
                }
            }
            else
            {
                MessageBox.Show("Digite um id válido!");
            }
        }

        private void buscaItens(int idPC)
        {

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
                if (linha.Cells[4].Value != null)
                {
                    preco_total = preco_total + (float.Parse(linha.Cells[4].Value.ToString()));
                }

            }

            lblTotal.Text = "Preço de Custo: R$" + preco_total;

        }


    }
}
