using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triade2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if ((txtLogin.Text == "admin") && (txtSenha.Text == "admin"))
            {
                //fecha o formulario de login
                Form1 login = new Form1();
                login.Hide();

                //abre a tela de opcoes


            }
            else {
                MessageBox.Show("Login inválido!","Erro");
            }
        }
    }
}
