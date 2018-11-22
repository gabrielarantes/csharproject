using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triade2018.Model
{
    public class RequisicaoItem
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public string id;
        public string id_requisicao;
        public string id_produto;
        public string tipo;
        public string quantidade;
        public string mensagem;

        public void salvar() {

            //verifica se o produto já está cadastrado no banco
            cmd.CommandText = "SELECT RI_ID FROM requisicoes_itens WHERE RI_PRODUTO = @id_produto AND RI_TIPO = @tipo AND RI_REQUISICAO = @requisicao";
            cmd.Parameters.AddWithValue("@id_produto", this.id_produto);
            cmd.Parameters.AddWithValue("@tipo", this.tipo);
            cmd.Parameters.AddWithValue("@requisicao", this.id_requisicao);
            cmd.Parameters.AddWithValue("@quantidade", this.quantidade);

            try
            {
                //conexao com o banco
                cmd.Connection = conexao.conectar();

                MySqlDataReader dr = cmd.ExecuteReader();

                //se já estiver cadastrado, apenas atualiza a quantidade informada
                if (dr.HasRows == true)
                {
                    conexao.desconectar();

                    cmd.CommandText = "UPDATE requisicoes_itens SET RI_QUANTIDADE = @quantidade WHERE RI_PRODUTO = @id_produto AND RI_TIPO = @tipo AND RI_REQUISICAO = @requisicao";

                    this.mensagem = "Atualizado com sucesso!";

                    try
                    {
                        cmd.Connection = conexao.conectar();

                        cmd.ExecuteNonQuery();

                        conexao.desconectar();

                        MessageBox.Show(this.mensagem);

                    }
                    catch (MySqlException e)
                    {
                        MessageBox.Show("Erro ao tentar se conectar" + e);
                    }

                }
                //INSERE O PRODUTO NA COLEÇÃO
                else
                {
                    conexao.desconectar();

                    cmd.CommandText = "INSERT INTO requisicoes_itens (RI_REQUISICAO,RI_PRODUTO, RI_QUANTIDADE, RI_TIPO) VALUES (@requisicao,@id_produto, @quantidade ,@tipo ) ";

                    this.mensagem = "Cadastrado com sucesso!";

                    try
                    {
                        cmd.Connection = conexao.conectar();

                        cmd.ExecuteNonQuery();

                        conexao.desconectar();

                        MessageBox.Show(this.mensagem);

                    }
                    catch (MySqlException e)
                    {
                        MessageBox.Show("Erro ao tentar se conectar" + e);
                    }

                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro ao tentar se conectar" + e);
            }

        }

    }
}