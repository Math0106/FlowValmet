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
        ControleVincularProcessos Vincular = new ControleVincularProcessos();
        public CadastroLembretes()
        {
            InitializeComponent();

            LimparCampos();

            TrocaIdioma(SessaoIdioma.Idioma);

            var resultadoOp = Vincular.RecuperarOp_id_numeroOP_descricao("SELECT o.id, o.numeroop, o.descricao FROM bdflowvalmet.op o;");
            foreach (var item in resultadoOp)
            {
                GNCbxOps.Items.Add($"{item.Item1}-{item.Item2} ");
            }

            if (GNCheckBoxVincular.Checked)
            {
                GNCbxOps.Enabled = true;

            }
            else
            {
                GNCbxOps.Enabled = true;
            }          
        }

        public void TrocaIdioma(string idioma)
        {
            switch (idioma)
            {
                case "en":
                    {
                        GNTxtTituloLembrete.PlaceholderText = "Title";
                        GNLblVincularOp.Text = "Link in a PO";
                        GNTxtDEscricaoCadastrarLembretes.PlaceholderText = "Description";
                        GNBtnCadastrarCadastroLembretes.Text = "Register";
                        GNBtnAtualizar.Text = "Update";
                        GnBtnLimpar.Text = "Clean";

                        GNDgvLembretes.Columns["id"].HeaderText = "id"; // string
                        GNDgvLembretes.Columns["titulo"].HeaderText = "Title"; // string
                        GNDgvLembretes.Columns["descricao"].HeaderText = "Description"; // string
                        GNDgvLembretes.Columns["vinculo"].HeaderText = "Bond";
                        GNDgvLembretes.Columns["op"].HeaderText = "PO";
                        break;
                    }
                case "es":
                    {
                        GNTxtTituloLembrete.PlaceholderText = "Título";
                        GNLblVincularOp.Text = "Enlace en una orden de compra";
                        GNTxtDEscricaoCadastrarLembretes.PlaceholderText = "Descripción";
                        GNBtnCadastrarCadastroLembretes.Text = "Registro";
                        GNBtnAtualizar.Text = "Actualizar";
                        GnBtnLimpar.Text = "Limpiar";

                        GNDgvLembretes.Columns["id"].HeaderText = "id"; // string
                        GNDgvLembretes.Columns["titulo"].HeaderText = "Título"; // string
                        GNDgvLembretes.Columns["descricao"].HeaderText = "Descripción"; // string
                        GNDgvLembretes.Columns["vinculo"].HeaderText = "Vínculo";
                        GNDgvLembretes.Columns["op"].HeaderText = "OP";

                        break;
                    }
                case "pt":
                    {
                        GNTxtTituloLembrete.PlaceholderText = "Título";
                        GNLblVincularOp.Text = "Vincular em uma OP";
                        GNTxtDEscricaoCadastrarLembretes.PlaceholderText = "Descrição";
                        GNBtnCadastrarCadastroLembretes.Text = "Cadastrar";
                        GNBtnAtualizar.Text = "Atualizar";
                        GnBtnLimpar.Text = "Limpar";



                        GNDgvLembretes.Columns["id"].HeaderText = "id"; // string
                        GNDgvLembretes.Columns["titulo"].HeaderText = "Título"; // string
                        GNDgvLembretes.Columns["descricao"].HeaderText = "Descrição"; // string
                        GNDgvLembretes.Columns["vinculo"].HeaderText = "Vínculo";
                        GNDgvLembretes.Columns["op"].HeaderText = "OP";
                        break;
                    }
                default:
                    {
                        GNTxtTituloLembrete.PlaceholderText = "Título";
                        GNLblVincularOp.Text = "Vincular em uma OP";
                        GNTxtDEscricaoCadastrarLembretes.PlaceholderText = "Descrição";
                        GNBtnCadastrarCadastroLembretes.Text = "Cadastrar";
                        GNBtnAtualizar.Text = "Atualizar";
                        GnBtnLimpar.Text = "Limpar";

                        GNDgvLembretes.Columns["id"].HeaderText = "id"; // string
                        GNDgvLembretes.Columns["titulo"].HeaderText = "Título"; // string
                        GNDgvLembretes.Columns["descricao"].HeaderText = "Descrição"; // string
                        GNDgvLembretes.Columns["vinculo"].HeaderText = "Vínculo";
                        GNDgvLembretes.Columns["op"].HeaderText = "OP";

                        break;
                    }
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
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Error loading!");
                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Error al cargar!");
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Erro ao carregar!");
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Erro ao carregar!");
                            break;
                        }
                }

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
                        opTxt = GNCbxOps.Text;
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

                        var telaPrincipal = this.ParentForm as TelaPrincipal;
                        if (telaPrincipal != null)
                        {
                            telaPrincipal.ResetarTelaPrincpalLembretes();
                        }
                        LimparCampos();
                    }

                }
                catch (Exception ex)
                {
                    switch (SessaoIdioma.Idioma)
                    {
                        case "en":
                            {
                                MessageBox.Show("Unable to register: " + ex);
                                break;
                            }
                        case "es":
                            {
                                MessageBox.Show("No se puede registrar: " + ex);
                                break;
                            }
                        case "pt":
                            {
                                MessageBox.Show("Não foi possivel cadastrar: " + ex);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Não foi possivel cadastrar: " + ex);
                                break;
                            }
                    }

                }
            }
            else
            {
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Blank fields ");
                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Campos en blanco ");
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Campos em branco ");
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Campos em branco ");
                            break;
                        }
                }
            }
        }

        private void GNCheckBoxVincular_Click(object sender, EventArgs e)
        {
            if (GNCheckBoxVincular.Checked)
            {

                GNCbxOps.Enabled = true;

            }
            else
            {
                GNCbxOps.Enabled = false;
                GNCbxOps.SelectedIndex = -1;               
            }
        }

        private void GNDgvLembretes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LimparCampos();
            
            if (e.RowIndex >= 0)
            {
                string titulo;
                string descrição;
                var linha = GNDgvLembretes.Rows[e.RowIndex];
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            titulo = "Registration reminder";
                            descrição = "Do you really want to continue?";
                            break;
                        }
                    case "es":
                        {
                            titulo = "Recordatorio de registro";
                            descrição = "Realmente deseas continuar?";
                            break;
                        }
                    case "pt":
                        {
                            titulo = "Cadastro Lembrete";
                            descrição = "Deseja realmente continuar?";
                            break;
                        }
                    default:
                        {
                            titulo = "Cadastro Lembrete";
                            descrição = "Deseja realmente continuar?";
                            break;
                        }
                }
                var form = new PopUPGUS(titulo, descrição);
                form.ShowDialog();


                switch (form.Result)
                {
                    case PopUPGUS.CustomDialogResult.Excluir:
                        try 
                        {
                            controleLembretes.ExcluirLembrete(Convert.ToInt32(linha.Cells[0].Value?.ToString()));

                            var telaPrincipal = this.ParentForm as TelaPrincipal;
                            if (telaPrincipal != null)
                            {
                                telaPrincipal.ResetarTelaPrincpalLembretes();
                            }
                            LimparCampos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"{ex}");
                        }

                        break;
                    case PopUPGUS.CustomDialogResult.Alterar:
                        try
                        {
                            GNLblLembreteId.Text = linha.Cells[0].Value.ToString();
                            GNTxtTituloLembrete.Text = linha.Cells[1].Value.ToString();
                            GNTxtDEscricaoCadastrarLembretes.Text = linha.Cells[2].Value.ToString();
                            var obterValorCheck = linha.Cells[3].Value;
                            if (Convert.ToBoolean(obterValorCheck) == true)
                            {
                                GNCheckBoxVincular.Checked = true;
                                GNCbxOps.Enabled = true;
                                GNCbxOps.Text = linha.Cells[4].Value.ToString();
                            }
                            else
                            {
                                GNCheckBoxVincular.Checked = false;
                                GNCbxOps.Enabled = false;
                            }
                            GNBtnCadastrarCadastroLembretes.Enabled = false;
                            GNBtnAtualizar.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"{ex}");
                        }

                            break;
                    case PopUPGUS.CustomDialogResult.Cancelar:
                        break;
                }              
            }
        }
        
        public void LimparCampos()
        {
            GNCbxOps.SelectedIndex = -1;
            GNTxtDEscricaoCadastrarLembretes.Clear();
            GNTxtTituloLembrete.Clear();
            GNBtnCadastrarCadastroLembretes.Enabled=true;
            GNCheckBoxVincular.Checked = false;
            GNCbxOps.Enabled = false;
            GNBtnAtualizar.Enabled = false;
            
            GNLblLembreteId.Text = "";
            DesingDataGridView.DesignGunaDataGrid(GNDgvLembretes);
            CarregarLembrete();

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
                        opTxt = GNCbxOps.Text;
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
                        var telaPrincipal = this.ParentForm as TelaPrincipal;
                        if (telaPrincipal != null)
                        {
                            telaPrincipal.ResetarTelaPrincpalLembretes();
                        }
                        LimparCampos();

                    }

                }
                catch (Exception ex)
                {
                    switch (SessaoIdioma.Idioma)
                    {
                        case "en":
                            {
                                MessageBox.Show("Unable to update: " + ex);
                                break;
                            }
                        case "es":
                            {
                                MessageBox.Show("No se puede actualizar: " + ex);
                                break;
                            }
                        case "pt":
                            {
                                MessageBox.Show("Não foi possivel cadastrar: " + ex);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Não foi possivel atualizar: " + ex);
                                break;
                            }
                    }
                }
            }
            else
            {
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Blank fields ");
                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Campos en blanco ");
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Campos em branco ");
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Campos em branco ");
                            break;
                        }
                }
            }
        }

        
    }
}
