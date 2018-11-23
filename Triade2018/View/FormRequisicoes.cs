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
            if (this.validaCamposItem() == true) {

                if (cmbTipo.Text == "Simples")
                {

                    Conexao conexao = new Conexao();
                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = "SELECT * FROM  produtos_simples WHERE PS_ID = @id ";
                    cmd.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = txtProd.Text;

                    //conexao com o banco
                    cmd.Connection = conexao.conectar();

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows == false)
                    {
                        MessageBox.Show("Nenhum produto encontrado!");
                    }
                    else
                    {
                        txtQuantidade.Text = "1";
                        txtQuantidade.Enabled = true;

                        dr.Read();

                        txtProduto.Text = dr["PS_NOME"].ToString();
                        txtPrecoVenda.Text = dr["PS_PRECOV"].ToString();
                        //this.precoc = dr["PS_PRECOC"].ToString();
                        //this.precov = dr["PS_PRECOV"].ToString();

                        this.calculaSubTotal();

                        btnAdicionar.Enabled = true;
                        btnRemover.Enabled = true;

                        //desconectar
                        conexao.desconectar();

                        //return true;

                    }


                }
                else {

                    Conexao conexao = new Conexao();
                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = "SELECT * FROM  produtos_compostos WHERE PC_ID = @id ";
                    cmd.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = txtProd.Text;

                    //conexao com o banco
                    cmd.Connection = conexao.conectar();

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows == false)
                    {
                        MessageBox.Show("Nenhum produto encontrado!");
                    }
                    else
                    {
                        txtQuantidade.Text = "1";
                        txtQuantidade.Enabled = true;

                        dr.Read();

                        txtProduto.Text = dr["PC_NOME"].ToString();
                        txtPrecoVenda.Text = dr["PC_PRECO_VENDA"].ToString();
                        //this.precoc = dr["PS_PRECOC"].ToString();
                        //this.precov = dr["PS_PRECOV"].ToString();

                        this.calculaSubTotal();

                        btnAdicionar.Enabled = true;
                        btnRemover.Enabled = true;

                        //desconectar
                        conexao.desconectar();

                        //return true;

                    }

                }

            }
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Requisicao requisicao = new Requisicao();

            //requisicao.id = Convert.ToInt32(txtId.Text);
            var data = txtData.Text.Replace("/","-");
            var date = data.Split('-');

            var dia = date[0];
            var mes = date[1];
            var ano = date[2];

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

                    //habilitando campos dos itens
                    txtProd.Enabled = true;
                    cmbTipo.Enabled = true;
                    btnBuscarItem.Enabled = true;

                    //buscar itens dessa requisição
                    this.buscaItens(Convert.ToInt32(txtBuscaId.Text));

                }
                else
                {
                    MessageBox.Show("Nenhuma requisição encontrada");
                }
            }
            else
            {
                MessageBox.Show("Digite um id válido!");
            }
        }

        private void buscaItens(int idReq)
        {

            Conexao conexao = new Conexao();
            MySqlCommand cmd = new MySqlCommand();

            //conexao com o banco
            cmd.Connection = conexao.conectar();

            cmd.CommandText = "SELECT ID, NOME, QUANTIDADE, PRECOVENDA, SUBTOTAL FROM (SELECT ps.PS_ID AS ID, ps.PS_NOME AS NOME, ri.RI_QUANTIDADE AS QUANTIDADE, ps.PS_PRECOV AS PRECOVENDA, (ps.PS_PRECOV * ri.RI_QUANTIDADE) AS SUBTOTAL FROM produtos_simples ps, requisicoes_itens ri WHERE ps.PS_ID = ri.RI_PRODUTO AND ri.RI_TIPO = 1 AND ri.RI_REQUISICAO = @idReq UNION SELECT pc.PC_ID AS ID, pc.PC_NOME AS NOME, ri.RI_QUANTIDADE AS QUANTIDADE, pc.PC_PRECO_VENDA AS PRECOVENDA, (pc.PC_PRECO_VENDA * ri.RI_QUANTIDADE) AS SUBTOTAL FROM produtos_compostos pc, requisicoes_itens ri WHERE pc.PC_ID = ri.RI_PRODUTO AND ri.RI_TIPO = 2 AND ri.RI_REQUISICAO = @idReq) AS produtos";
            cmd.Parameters.AddWithValue("@idReq", MySqlDbType.Int32).Value = idReq;

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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "") {
                if (txtQuantidade.Text == "")
                {
                    MessageBox.Show("Informe a quantidade!");
                }
                else {

                    RequisicaoItem requisicaoItem = new RequisicaoItem();

                    requisicaoItem.id_requisicao = txtId.Text;
                    requisicaoItem.id_produto = txtProd.Text;

                    if (cmbTipo.Text == "Simples")
                    {
                        requisicaoItem.tipo = "1";
                    }
                    else {
                        requisicaoItem.tipo = "2";
                    }

                    requisicaoItem.quantidade = txtQuantidade.Text;

                    requisicaoItem.salvar();

                    this.buscaItens(Convert.ToInt32(txtBuscaId.Text));

                }
            }
            
        }

        private Boolean validaCamposItem() {

            if (txtProd.Text == "") {
                MessageBox.Show("Id de produto inválido");
                return false; 
            }

            return true;

        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            this.calculaSubTotal();
        }

        private void calculaSubTotal() {
            if (txtQuantidade.Text !="" && txtPrecoVenda.Text !="" ) {
                txtSubTotal.Text = (Convert.ToInt32(txtQuantidade.Text) * float.Parse(txtPrecoVenda.Text)).ToString();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este item?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                RequisicaoItem requsicao_item = new RequisicaoItem();
                requsicao_item.id_requisicao = txtId.Text;
                requsicao_item.id_produto = txtProd.Text;
                if (cmbTipo.Text == "Simples")
                {
                    requsicao_item.tipo = "1";
                }
                else {
                    requsicao_item.tipo = "2";
                }
                
                requsicao_item.excluir();
                this.buscaItens(Convert.ToInt32(txtBuscaId.Text));

            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir esta requisição?\nEssa operação não poderá ser desfeita!", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (txtId.Text != "")
                {
                    Requisicao requisicao = new Requisicao();
                    requisicao.id = Convert.ToInt32(txtId.Text);
                    requisicao.excluir();
                }

            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
