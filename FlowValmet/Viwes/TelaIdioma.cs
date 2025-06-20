using FlowValmet.Models;
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
        
        //TelaPrincipal _principalForm = new TelaPrincipal();
        TelaPrincipal _principalForm = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();
        SessaoIdioma _sessaoIdioma;
        public TelaIdioma()
        {
            InitializeComponent();
        }

        private void GNBtnEspanhol_Click(object sender, EventArgs e)
        {
            FecharTela();
            SessaoIdioma.Idioma = "es";
            //_sessaoIdioma = new SessaoIdioma("es");
            _principalForm.CarregarIdioma();

        }


        private void GNBtnIngles_Click(object sender, EventArgs e)
        {
            FecharTela();
            SessaoIdioma.Idioma = "en";
            //_sessaoIdioma = new SessaoIdioma("en");
            _principalForm.CarregarIdioma();

        }

        private void GNBtnPortugues_Click(object sender, EventArgs e)
        {
            FecharTela();
            SessaoIdioma.Idioma = "pt";
            //_sessaoIdioma = new SessaoIdioma("pt");
            _principalForm.CarregarIdioma();
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
