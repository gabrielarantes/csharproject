using MySql.Data.MySqlClient;
using System.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Triade2018.View;

namespace Triade2018.View
{
    public class ProdutoC
    {

        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public int id;
        public string nome;
        public string precov;
        public string mensagem;
        public Array listaProdutos;
        public DataTable dt = null;

        public Boolean validaCampos()
        {

            if (this.nome == "")
            {
                MessageBox.Show("Nome inválido");
                return false;
            }

            if (this.precov == "")
            {
                MessageBox.Show("Preço de Venda inválido");
                return false;
            }

            return true;
        }

        public void salvar(string id_bd)
        {

            if (id_bd == "")
            {
                cmd.CommandText = "INSERT INTO produtos_compostos (PC_NOME,PC_PRECO_VENDA, PC_DATA_CADASTRO) VALUES (@nome,@precov, NOW() ) ";
                this.mensagem = "Cadastrado com sucesso!";
            }
            else
            {
                cmd.CommandText = "UPDATE produtos_compostos SET PC_NOME = @nome, PC_PRECO_VENDA = @precov WHERE PC_ID = @id ";
                cmd.Parameters.AddWithValue("@id", id_bd);
                this.mensagem = "Atualizado com sucesso!";
            }

            cmd.Parameters.AddWithValue("@nome", this.nome);
            cmd.Parameters.AddWithValue("@precov", this.precov);

            try
            {
                cmd.Connection = conexao.conectar();

                cmd.ExecuteNonQuery();

                conexao.desconectar();

                MessageBox.Show(this.mensagem);

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erro ao tentar se conectar");
            }

        }

        public void excluir(string id_bd)
        {

            cmd.CommandText = "DELETE FROM produtos_compostos WHERE PC_ID = @id ";
            cmd.Parameters.AddWithValue("@id", id_bd);
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
                MessageBox.Show("Erro ao tentar se conectar");
            }

        }


        public Boolean BuscarProduto()
        {
            cmd.CommandText = "SELECT * FROM  produtos_compostos WHERE PC_ID = @id ";
            cmd.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = this.id;

            try
            {
                //conexao com o banco
                cmd.Connection = conexao.conectar();

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == false)
                {
                    return false;
                }
                else
                {

                    dr.Read();

                    this.nome = dr["PC_NOME"].ToString();
                    this.precov = dr["PC_PRECO_VENDA"].ToString();

                    //desconectar
                    conexao.desconectar();

                    return true;

                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Ocorreu algum problema!\nTente novamente");
            }

            return false;

        }

        public DataTable buscaItens(int idPc) {

            //conexao com o banco
            cmd.Connection = conexao.conectar();

            cmd.CommandText = "SELECT ps.PS_NOME, ps.PS_PRECOC, ps.PS_PRECOV, pi.PI_QUANTIDADE, (pi.PI_QUANTIDADE * ps.PS_PRECOV) AS TOTAL_CUSTO_ITEM FROM produtos_simples ps, produtos_compostos_itens pi WHERE ps.PS_ID = pi.PI_PRODUTO_SIMPLES AND pi.PI_PRODUTO_COMPOSTO = @idProd";
            cmd.Parameters.AddWithValue("@idProd", MySqlDbType.Int32).Value = idPc;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            this.dt = new DataTable();

            return dt;

            //this.listaProdutos = da; 


        }
    }


}
