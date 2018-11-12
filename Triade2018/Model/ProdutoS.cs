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
    public class ProdutoS{

        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public int id;
        public string nome;
        public string precoc;
        public string precov;
        public string mensagem;

        public Boolean validaCampos() {

            if (this.nome == "") {
                MessageBox.Show("Nome inválido");
                return false;
            }

            if (this.precoc == "")
            {
                MessageBox.Show("Preço de Custo inválido");
                return false;
            }

            if (this.precov == "")
            {
                MessageBox.Show("Preço de Venda inválido");
                return false;
            }

            return true;
        }

        public void salvar(string id_bd) {

            if (id_bd == "")
            {
                cmd.CommandText = "INSERT INTO produtos_simples (PS_NOME,PS_PRECOC,PS_PRECOV, PS_DATA_CADASTRO) VALUES (@nome,@precoc,@precov, NOW() ) ";
                this.mensagem = "Cadastrado com sucesso!";
            }
            else {
                cmd.CommandText = "UPDATE produtos_simples SET PS_NOME = @nome, PS_PRECOC = @precoc, PS_PRECOV = @precov WHERE PS_ID = @id ";
                cmd.Parameters.AddWithValue("@id", id_bd);
                this.mensagem = "Atualizado com sucesso!";
            }

            cmd.Parameters.AddWithValue("@nome", this.nome);
            cmd.Parameters.AddWithValue("@precoc", this.precoc);
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

            cmd.CommandText = "DELETE FROM produtos_simples WHERE PS_ID = @id ";
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
            cmd.CommandText = "SELECT * FROM  produtos_simples WHERE PS_ID = @id ";
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
                else {

                    dr.Read();

                    this.nome = dr["PS_NOME"].ToString();
                    this.precoc = dr["PS_PRECOC"].ToString();
                    this.precov = dr["PS_PRECOV"].ToString();

                    //desconectar
                    conexao.desconectar();

                    return true;

                }                

            }
            catch (MySqlException e)
            {
                
            }

            return false;

        }

    }

    
}
