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

            string caminhoProjeto = Application.StartupPath;

            GNDgvLembretes.DataSource = controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");


            GNDgvLembretes.ClearSelection();

            if (GNCheckBoxVincular.Checked)
            {
                GNTxtOPCadastroLembrete.Enabled = true;
            }
            else
            {
                GNTxtOPCadastroLembrete.Enabled = false;
            }

           
            
        }

        private void GNBtnExcluirCadastroLembrete_Click(object sender, EventArgs e)
        {           
            List<Tuple<int, string, string, bool, string>> listaLembretes = new List<Tuple<int, string, string, bool, string>>();
            listaLembretes = controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");      
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
                    GNDgvLembretes.DataSource = controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");
                    GNTxtTituloLembrete.Clear();
                    GNTxtDEscricaoCadastrarLembretes.Clear();
                    GNCheckBoxVincular.Checked = false;
                    GNTxtOPCadastroLembrete.Clear();
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
                var confirmacao = MessageBox.Show($"Deseja escluir linha: {linha.Cells[0].Value?.ToString()}", linha.Cells[1].Value?.ToString(), MessageBoxButtons.OKCancel).ToString();
                if (confirmacao == "OK")
                {
                    controleLembretes.ExcluirLembrete(Convert.ToInt32(linha.Cells[0].Value?.ToString()));
                }
                
                GNDgvLembretes.ClearSelection();
                GNDgvLembretes.DataSource = controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");

            }

            

        }
        
        public void LimparCampos()
        {
            GNTxtOPCadastroLembrete.Clear();
            GNTxtDEscricaoCadastrarLembretes.Clear();
            GNTxtTituloLembrete.Clear();
            GNCheckBoxVincular.Checked = false;
            GNTxtOPCadastroLembrete.Enabled = false;

        }



        private void GnBtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            GNDgvLembretes.ClearSelection();
        }

        private void CadastroLembretes_Load(object sender, EventArgs e)
        {

        }
    }
}
