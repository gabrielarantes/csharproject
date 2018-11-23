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

namespace Triade2018.View
{
    public partial class FormRelReq : Form
    {
        public FormRelReq()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {

            if (txtDataInicio.Text != "" && txtDataFim.Text != "")
            {

                var data = txtDataInicio.Text.Replace("/", "-");
                var date = data.Split('-');

                var dia = date[0];
                var mes = date[1];
                var ano = date[2];

                var dataInicio = ano + '-' + mes + '-' + dia;

                var dataF = txtDataFim.Text.Replace("/", "-");
                var dateF = dataF.Split('-');

                var diaF = dateF[0];
                var mesF = dateF[1];
                var anoF = dateF[2];

                var dataFim = anoF + '-' + mesF + '-' + diaF;

                Conexao conexao = new Conexao();
                MySqlCommand cmd = new MySqlCommand();

                //conexao com o banco
                cmd.Connection = conexao.conectar();

                cmd.CommandText = "select ps.PS_NOME as 'Nome', SUM(ri.RI_QUANTIDADE) as 'Qtde', (SUM(ri.RI_QUANTIDADE) * ps.PS_PRECOC) AS 'Preco Custo Total', (SUM(ri.RI_QUANTIDADE) * ps.PS_PRECOV) AS 'Preco Venda Total' from requisicoes r, requisicoes_itens ri, produtos_simples ps WHERE r.RE_ID = ri.RI_REQUISICAO AND ri.RI_PRODUTO = ps.PS_ID AND ri.RI_TIPO = 1 AND r.RE_DATA >= @data_inicio AND r.RE_DATA <= @data_fim GROUP BY ri.RI_PRODUTO UNION select ps.PC_NOME as 'Nome', SUM(ri.RI_QUANTIDADE) as 'Qtde', 0 AS 'Preco Custo Total', (SUM(ri.RI_QUANTIDADE) * ps.PC_PRECO_VENDA) AS 'Preco Venda Total' from requisicoes r, requisicoes_itens ri, produtos_compostos ps WHERE r.RE_ID = ri.RI_REQUISICAO AND ri.RI_PRODUTO = ps.PC_ID AND ri.RI_TIPO = 2 AND r.RE_DATA >= @data_inicio AND r.RE_DATA <= @data_fim GROUP BY ri.RI_PRODUTO";
                cmd.Parameters.AddWithValue("@data_inicio", dataInicio);
                cmd.Parameters.AddWithValue("@data_fim", dataFim);

                //define o tipo do comando 
                //cmd.CommandType = CommandType.Text;

                //cria um dataadapter
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                //cria um objeto datatable
                DataTable produtos_itens = new DataTable();

                //preenche o datatable via dataadapter
                da.Fill(produtos_itens);

                //atribui o datatable ao datagridview para exibir o resultado
                dgResult.DataSource = produtos_itens;
                dgResult.Enabled = true;

                float preco_total_custo = 0;
                float preco_total_venda = 0;

                foreach (DataGridViewRow linha in dgResult.Rows)
                {
                    if (linha.Cells[2].Value != null && linha.Cells[2].Value.ToString() != "")
                    {
                        preco_total_custo = preco_total_custo + (float.Parse(linha.Cells[2].Value.ToString()));
                    }

                    if (linha.Cells[3].Value != null && linha.Cells[3].Value.ToString() != "")
                    {
                        preco_total_venda = preco_total_venda + (float.Parse(linha.Cells[3].Value.ToString()));
                    }

                }

                lblTotalCusto.Text = "Preço Total de Custo: R$" + preco_total_custo;
                lblTotalVenda.Text = "Preço Total de Venda: R$" + preco_total_venda;


            }
            else {
                MessageBox.Show("Insira as datas corretamente!");
            }
            


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
