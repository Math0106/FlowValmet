using FlowValmet.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using FlowValmet.Properties;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FlowValmet.Viwes
{
    public partial class CadastroLembretes : Form
    {
        ControleLembretes controleLembretes = new ControleLembretes();
        public CadastroLembretes()
        {
            InitializeComponent();

            LimparCampos();

            if (GNCheckBoxVincular.Checked)
            {
                GNTxtOPCadastroLembrete.Enabled = true;
            }
            else
            {
                GNTxtOPCadastroLembrete.Enabled = false;
            }

          
        }

        private void GNBtnCadastrarCadastroLembretes_Click(object sender, EventArgs e)
        {
            if (
                GNTxtDEscricaoCadastrarLembretes.Text != "" &&
                GNTxtTituloLembrete.Text != ""
               )
            {
                bool vincular;
                string op;
                try
                {
                    if (GNCheckBoxVincular.Checked)
                    {
                        op = GNTxtOPCadastroLembrete.Text;
                        vincular = true;
                    }
                    else
                    {
                        op = null;
                        vincular = false;
                    }

                    bool confirmaInserir = controleLembretes.InserirLembrete(GNTxtTituloLembrete.Text, GNTxtDEscricaoCadastrarLembretes.Text, vincular, op);
                    LimparCampos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel cadastrar: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Campos em branco ");
            }
        }

        private void GNCheckBoxVincular_Click(object sender, EventArgs e)
        {
            if (GNCheckBoxVincular.Checked)
            {
                
                GNTxtOPCadastroLembrete.Enabled = true;
            }
            else
            {
                GNTxtOPCadastroLembrete.Text = "";
                GNTxtOPCadastroLembrete.Enabled = false;
                
            }
        }

        private void GNDgvLembretes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LimparCampos();
            
            if (e.RowIndex >= 0)
            {
                var linha = GNDgvLembretes.Rows[e.RowIndex];
                var form = new MessagemAtualizarExcluirCancelar("Cadastro Lembrete", "Deseja realmente continuar?");
                form.ShowDialog();

                switch (form.Result)
                {
                    case MessagemAtualizarExcluirCancelar.CustomDialogResult.Excluir:
                        controleLembretes.ExcluirLembrete(Convert.ToInt32(linha.Cells[0].Value?.ToString()));                          
                        LimparCampos();
                        break;
                    case MessagemAtualizarExcluirCancelar.CustomDialogResult.Alterar:
                        GNLblLembreteId.Text = linha.Cells[0].Value.ToString();
                        GNTxtTituloLembrete.Text = linha.Cells[1].Value.ToString();
                        GNTxtDEscricaoCadastrarLembretes.Text = linha.Cells[2].Value.ToString();
                        var obterValorCheck = linha.Cells[3].Value;
                        if (Convert.ToBoolean(obterValorCheck) == true)
                        {
                            GNCheckBoxVincular.Checked = true;
                            GNTxtOPCadastroLembrete.Enabled = true;
                            GNTxtOPCadastroLembrete.Text = linha.Cells[4].Value.ToString();
                        }
                        else
                        {
                            GNCheckBoxVincular.Checked = false;
                            GNTxtOPCadastroLembrete.Enabled = false;
                        }
                        GNBtnCadastrarCadastroLembretes.Enabled = false;
                        GNBtnAtualizar.Enabled = true;
                            break;
                    case MessagemAtualizarExcluirCancelar.CustomDialogResult.Cancelar:
                        break;
                }              
            }
        }
        
        public void LimparCampos()
        {
            GNTxtOPCadastroLembrete.Clear();
            GNTxtDEscricaoCadastrarLembretes.Clear();
            GNTxtTituloLembrete.Clear();
            GNBtnCadastrarCadastroLembretes.Enabled=true;
            GNCheckBoxVincular.Checked = false;
            GNTxtOPCadastroLembrete.Enabled = false;
            GNBtnAtualizar.Enabled = false;
            GNDgvLembretes.ClearSelection();
            GNDgvLembretes.ClearSelection();
            GNLblLembreteId.Text = "";
            GNDgvLembretes.DataSource = controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");

        }



        private void GnBtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void GNBtnAtualizar_Click(object sender, EventArgs e)
        {
            if (
                GNTxtDEscricaoCadastrarLembretes.Text != "" &&
                GNTxtTituloLembrete.Text != ""
               )
            {
                bool vincular;
                string op;
                try
                {
                    if (GNCheckBoxVincular.Checked)
                    {
                        op = GNTxtOPCadastroLembrete.Text;
                        vincular = true;
                    }
                    else
                    {
                        op = null;
                        vincular = false;
                    }
                    controleLembretes.AtualizarLembrete(Convert.ToInt32(GNLblLembreteId.Text),GNTxtTituloLembrete.Text, GNTxtDEscricaoCadastrarLembretes.Text, vincular, op);
                    
                    
                    LimparCampos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel cadastrar: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Campos em branco ");
            }

        }
    }
}
