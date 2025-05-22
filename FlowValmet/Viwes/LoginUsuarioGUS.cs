using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Viwes
{
    public partial class LoginUsuarioGUS: Form
    {
        public LoginUsuarioGUS()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            CadastroUsuarioGUS novaTela = new CadastroUsuarioGUS(); 
            novaTela.Show();              
            this.Hide();                    
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            CadastroLinhaGUS novaTela = new CadastroLinhaGUS();
            novaTela.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            CadastroOPGUS novaTela = new CadastroOPGUS();
            novaTela.Show();
            this.Hide();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
