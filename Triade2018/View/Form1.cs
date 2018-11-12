using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triade2018.View;

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

                //abre a tela de opcoes
                FormMenu menu = new View.FormMenu();
                menu.Show();

                //esconde o formulario de login
                this.Hide();

            }
            else {
                MessageBox.Show("Login inválido!","Erro");
            }
        }
    }
}
