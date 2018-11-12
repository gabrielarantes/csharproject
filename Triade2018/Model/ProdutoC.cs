using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triade2018.View
{
    public class ProdutoC
    {

        public void BuscarProduto(int id) {

            Conexao conexao = new Conexao();
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT * FROM  produtos WHERE PS_ID = @id ";

            return;

        }

    }
}
