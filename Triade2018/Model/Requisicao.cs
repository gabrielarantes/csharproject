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
        public string data;
        public string nome;
        public string precov;

        public string mensagem;
        

        public Boolean validaCampos()
        {

            if (this.nome == "")
            {
                MessageBox.Show("Nome inválido");
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

            /*JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = @"{ ""nome"" : ""Jose Carlos"", ""sobrenome"" : ""Macoratti"", ""email"": ""macoratti@yahoo.com"" }";

            dynamic resultado = serializer.DeserializeObject(json);

            foreach (KeyValuePair<string, object> entry in resultado)
            {
                var key = entry.Key;
                var value = entry.Value as string;
                MessageBox.Show(String.Format("{0} : {1}", key, value));
            }

            return false;*/

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

            }

            return false;

        }

        public void buscaItens(int idPc)
        {

            //conexao com o banco
            cmd.Connection = conexao.conectar();

            cmd.CommandText = "SELECT ps.PS_NOME, ps.PS_PRECOC, ps.PS_PRECOV, pi.PI_QUANTIDADE, (pi.PI_QUANTIDADE * ps.PS_PRECOV) AS TOTAL_CUSTO_ITEM FROM produtos_simples ps, produtos_compostos_itens pi WHERE ps.PS_ID = pi.PI_PRODUTO_SIMPLES AND pi.PI_PRODUTO_COMPOSTO = @idProd";
            cmd.Parameters.AddWithValue("@idProd", MySqlDbType.Int32).Value = idPc;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dtListaProdutos = new DataTable();

            da.Fill(dtListaProdutos);

            //this.listaProdutos = da; 


        }
    }

}
