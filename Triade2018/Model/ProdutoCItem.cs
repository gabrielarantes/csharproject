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

            cmd.CommandText = "INSERT INTO produtos_compostos_itens (PI_PRODUTO_COMPOSTO,PI_PRODUTO_SIMPLES, PI_QUANTIDADE, PI_DATA_CADASTRO) VALUES (@id_produto_composto,@id_produto_simples, @quantidade ,NOW() ) ";
            cmd.Parameters.AddWithValue("@id_produto_composto", this.id_produto_composto);
            cmd.Parameters.AddWithValue("@id_produto_simples", this.id_produto_simples);
            cmd.Parameters.AddWithValue("@quantidade", this.quantidade);

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
                MessageBox.Show("Erro ao tentar se conectar");
            }

        }

    }
}
