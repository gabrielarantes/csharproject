using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Triade2018.Model
{

    class ProdutoCItem
    {

        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public int id;
        public int id_produto_composto;
        public int id_produto_simples;
        public int quantidade;
        public string mensagem;

        public void adicionarItem() {

            //verifica se o produto simples ja está cadastrado neste conjunto
            cmd.CommandText = "SELECT PI_ID FROM produtos_compostos_itens WHERE PI_PRODUTO_COMPOSTO = @id_produto_composto AND PI_PRODUTO_SIMPLES = @id_produto_simples";
            cmd.Parameters.AddWithValue("@id_produto_composto", this.id_produto_composto);
            cmd.Parameters.AddWithValue("@id_produto_simples", this.id_produto_simples);
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

                    cmd.CommandText = "UPDATE produtos_compostos_itens SET PI_quantidade = @quantidade WHERE PI_PRODUTO_COMPOSTO = @id_produto_composto AND PI_PRODUTO_SIMPLES = @id_produto_simples";
                    
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

                    cmd.CommandText = "INSERT INTO produtos_compostos_itens (PI_PRODUTO_COMPOSTO,PI_PRODUTO_SIMPLES, PI_QUANTIDADE, PI_DATA_CADASTRO) VALUES (@id_produto_composto,@id_produto_simples, @quantidade ,NOW() ) ";
                    
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

        public void remover() {
            cmd.CommandText = "DELETE FROM produtos_compostos_itens WHERE PI_PRODUTO_COMPOSTO = @id_produto AND PI_PRODUTO_SIMPLES = @id_produto_simples ";
            cmd.Parameters.AddWithValue("@id_produto", this.id_produto_composto);
            cmd.Parameters.AddWithValue("@id_produto_simples", this.id_produto_simples);
            this.mensagem = "Excluído com sucesso!";

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
}
