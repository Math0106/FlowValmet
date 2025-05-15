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
    public partial class MessagemAtualizarExcluirCancelar : Form
    {
        public enum CustomDialogResult
        {
            None,
            Excluir,
            Alterar,
            Cancelar
        }

        public CustomDialogResult Result { get; private set; } = CustomDialogResult.None;

        public MessagemAtualizarExcluirCancelar(string titulo,string message)
        {
            InitializeComponent();
            GNLblMenssagem.Text = message;
            GNLblTitulo.Text = titulo;
        }



        private void GnBtnExcluir_Click(object sender, EventArgs e)
        {
            Result = CustomDialogResult.Excluir;
            this.Close();
        }

        private void GnBtnAtualizar_Click(object sender, EventArgs e)
        {
            Result = CustomDialogResult.Alterar;
            this.Close();
        }

        private void GnBtnCancelar_Click(object sender, EventArgs e)
        {
            Result = CustomDialogResult.Cancelar;
            this.Close();
        }
    }
}
