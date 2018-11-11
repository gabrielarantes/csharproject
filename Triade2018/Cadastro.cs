using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace Triade2018
{
    public class Cadastro
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();
        public String mensagem;

        public Cadastro(String nome, String telefone) {
            //Comand

            cmd.CommandText = "INSERT INTO pessoas(nome,telefone) VALUES (@nome,@telefone)";

            //parameters
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@telefone", telefone);

            //conectar com banco
            try {
                //conexao com o banco
                cmd.Connection = conexao.conectar();

                //executar comando
                cmd.ExecuteNonQuery();

                //desconectar
                conexao.desconectar();

                //exibe mensagem
                this.mensagem = "Cadastrado com sucesso!";

            }
            catch (MySqlException e) {
                this.mensagem = "Erro ao tentar se conectar";
            }

        }
    }
}
