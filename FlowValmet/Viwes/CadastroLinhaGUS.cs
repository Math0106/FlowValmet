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
    public partial class CadastroLinhaGUS: Form
    {
        public CadastroLinhaGUS()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoginUsuarioGUS novaTela = new LoginUsuarioGUS();
            novaTela.Show();
            this.Hide();
        }
    }
}
