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
using FlowValmet.Models;

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

        public void CarregarLembrete()
        {
            try
            {
                var listaDados = controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");

                // Limpa dados existentes (opcional)
                GNDgvLembretes.Rows.Clear();

                // Verifica se há dados
                if (listaDados != null && listaDados.Any())
                {
                    foreach (var tupla in listaDados)
                    {
                        int rowIndex = GNDgvLembretes.Rows.Add();

                        // Preenche cada célula com os elementos da tupla
                        GNDgvLembretes.Rows[rowIndex].Cells["id"].Value = tupla.Id; // string
                        GNDgvLembretes.Rows[rowIndex].Cells["titulo"].Value = tupla.Titulo; // string
                        GNDgvLembretes.Rows[rowIndex].Cells["descricao"].Value = tupla.Descricao; // string
                        GNDgvLembretes.Rows[rowIndex].Cells["vinculo"].Value = tupla.Vinculo;
                        GNDgvLembretes.Rows[rowIndex].Cells["op"].Value = tupla.Op;
                    }
                }
                GNDgvLembretes.ClearSelection();


            }
            catch
            {
                MessageBox.Show("Erro ao carregar!");
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
                string opTxt;
                try
                {
                    if (GNCheckBoxVincular.Checked)
                    {
                        opTxt = GNTxtOPCadastroLembrete.Text;
                        vincular = true;
                    }
                    else
                    {
                        opTxt = null;
                        vincular = false;
                    }

                    // Criar o objeto lembrete
                    var lembrete = new Lembrete(
                        id: 0,
                        titulo: GNTxtTituloLembrete.Text,
                        descricao: GNTxtDEscricaoCadastrarLembretes.Text,
                        vinculo: vincular,
                        op: opTxt
                    );

                    // Inserir no banco de dados
                    bool sucesso = controleLembretes.InserirLembrete(lembrete);

                    if (sucesso)
                    {
                        LimparCampos();
                    }

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
                var form = new PopUPGUS("Cadastro Lembrete", "Deseja realmente continuar?");
                form.ShowDialog();

                switch (form.Result)
                {
                    case PopUPGUS.CustomDialogResult.Excluir:
                        controleLembretes.ExcluirLembrete(Convert.ToInt32(linha.Cells[0].Value?.ToString()));                          
                        LimparCampos();
                        break;
                    case PopUPGUS.CustomDialogResult.Alterar:
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
                    case PopUPGUS.CustomDialogResult.Cancelar:
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
            
            GNLblLembreteId.Text = "";
            DesingDataGridView.DesignGunaDataGrid(GNDgvLembretes);
            CarregarLembrete();
            //GNDgvLembretes.DataSource = controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");

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
                string opTxt;
                try
                {
                    if (GNCheckBoxVincular.Checked)
                    {
                        opTxt = GNTxtOPCadastroLembrete.Text;
                        vincular = true;
                    }
                    else
                    {
                        opTxt = null;
                        vincular = false;
                    }

                    // Criar o objeto lembrete
                    var lembrete = new Lembrete(
                        id: Convert.ToInt32(GNLblLembreteId.Text),
                        titulo: GNTxtTituloLembrete.Text,
                        descricao: GNTxtDEscricaoCadastrarLembretes.Text,
                        vinculo: vincular,
                        op: opTxt
                    );

                    // Chamar método de atualização
                    bool sucesso = controleLembretes.AtualizarLembrete(lembrete);

                    if (sucesso)
                    {
                        LimparCampos();
                    }

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
