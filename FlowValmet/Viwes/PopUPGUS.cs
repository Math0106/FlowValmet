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
    public partial class PopUPGUS: Form
    {

            public enum CustomDialogResult
            {
                None,
                Excluir,
                Alterar,
                Cancelar
            }

            public CustomDialogResult Result { get; private set; } = CustomDialogResult.None;

            public PopUPGUS(string titulo, string message)
            {
                InitializeComponent();
                LblMensagem.Text = message;
                LblTitulo.Text = titulo;
            }

         

        private void GnBtnDeletar_Click(object sender, EventArgs e)
        {
            Result = CustomDialogResult.Excluir;
            this.Close();
        }

        private void GNBtnAtualizar_Click_1(object sender, EventArgs e)
        {
            Result = CustomDialogResult.Alterar;
            this.Close();

        }

        private void GNBtnCancelar_Click_1(object sender, EventArgs e)
        {
            Result = CustomDialogResult.Cancelar;
            this.Close();
        }
    }
}
