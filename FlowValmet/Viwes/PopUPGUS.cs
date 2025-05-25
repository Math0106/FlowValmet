using iText.Kernel.Validation.Context;
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

            // Botão Deletar (vermelho)
            GnBtnDeletar.BackColor = Color.WhiteSmoke; // Vermelho
            GnBtnDeletar.FillColor = Color.FromArgb(220, 53, 69); // Vermelho
            GnBtnDeletar.ForeColor = Color.White;
            GnBtnDeletar.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Botão Atualizar (azul)
            GNBtnAtualizar.BackColor = Color.WhiteSmoke; // Azul
            GNBtnAtualizar.FillColor = Color.FromArgb(13, 110, 253); // Azul
            GNBtnAtualizar.ForeColor = Color.White;
            GNBtnAtualizar.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Botão Cancelar (cinza)
            GNBtnCancelar.BackColor = Color.WhiteSmoke;
            GNBtnCancelar.FillColor = Color.FromArgb(108, 117, 125); // Cinza
            GNBtnCancelar.ForeColor = Color.White;
            GNBtnCancelar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
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
