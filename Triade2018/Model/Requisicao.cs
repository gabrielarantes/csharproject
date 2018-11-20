using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web.Script.Serialization;

namespace Triade2018.Model
{
    public class Requisicao
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        public int id;
        //public string dia;
        //public string mes;
        //public string ano;
        public string data;
        public string nome;
        public string precov;

        public string mensagem;
        

        public Boolean validaCampos()
        {

            if (this.nome == "")
            {
                MessageBox.Show("Nome de Funcionário inválido");
                return false;
            }

            if (this.data == "")
            {
                MessageBox.Show("Data inválida");
                return false;
            }

            return true;
        }

        public void salvar(string id_bd)
        {

            if (id_bd == "")
            {
                cmd.CommandText = "INSERT INTO requisicoes (RE_DATA, RE_RESPONSAVEL, RE_DATA_CADASTRO) VALUES (@data,@nome, NOW() ) ";
                this.mensagem = "Cadastrado com sucesso!";
            }
            else
            {
                cmd.CommandText = "UPDATE produtos_compostos SET PC_NOME = @nome, PC_PRECO_VENDA = @precov WHERE PC_ID = @id ";
                cmd.Parameters.AddWithValue("@id", id_bd);
                this.mensagem = "Atualizado com sucesso!";
            }

            cmd.Parameters.AddWithValue("@nome", this.nome);
            cmd.Parameters.AddWithValue("@data", this.data);

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


        public Boolean Buscar()
        {

            cmd.CommandText = "SELECT * FROM  requisicoes WHERE RE_ID = @id ";
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

                    this.nome = dr["RE_RESPONSAVEL"].ToString();
                    this.data = dr["RE_DATA"].ToString();

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
