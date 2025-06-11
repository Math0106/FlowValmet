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
    public partial class TelaIdioma : Form
    {
        TelaPrincipal principal = new TelaPrincipal();
        public TelaIdioma()
        {
            InitializeComponent();
        }

        private void GNBtnEspanhol_Click(object sender, EventArgs e)
        {
            FecharTela();
        }


        public void FecharTela()
        {
            // 2. Obter referência da tela principal
            var telaPrincipal = this.ParentForm as TelaPrincipal;

            // 3. Fechar o painel de login
            this.Parent.Controls.Remove(this);
            this.Close();

            // 4. Resetar/habilitar controles da tela principal
            if (telaPrincipal != null)
            {
                telaPrincipal.ResetarTelaPrincpal();

            }

        }
    }
}
