using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace Triade2018
{
    public class Conexao
    {

        MySqlConnection con = new MySqlConnection();

        //Construtor
        public Conexao() {
            con.ConnectionString = "SERVER=127.0.0.1;DATABASE=triade;UID=root;PWD=";
        }

        //Metodo de Conexao
        public MySqlConnection conectar(){

            //verificando se a conexao ja esta aberta
            if (con.State == System.Data.ConnectionState.Closed) {
                con.Open();
            }

            return con;
        }

        //Metodo para Desconectar
        public void desconectar() {
            //verificando se a conexao ja esta aberta
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
