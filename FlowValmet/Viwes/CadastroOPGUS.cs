using FlowValmet.Controllers;
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
    public partial class CadastroOPGUS: Form
    {

        ControleOp op = new ControleOp();
        public CadastroOPGUS()

        {
            InitializeComponent();
            LimparCampos();

            TrocarIdioma();
        }

        public void LimparCampos()
        {
            BtnAtualizar.Enabled = false;
            BtnCadastrar.Enabled = true;
            GNDatePikerEntregaOP.Value = DateTime.Today;
            GNDatePikerInicioOP.Value = DateTime.Today;
            TxtDescricao.Text = "";
            Txtdesenho.Text = "";
            TxtNumeroOp.Text = "";
            DesingDataGridView.DesignGunaDataGrid(GnDvgOp);
            CarregarOP();
            GnDvgOp.ClearSelection();
            GNlabelIdAtualizar.Text = "";
        }


        public void TrocarIdioma()
        {
            switch (SessaoIdioma.Idioma)
            {
                case "en":
                    {
                        TxtNumeroOp.PlaceholderText = "PO";
                        TxtDescricao.PlaceholderText = "Description";
                        Txtdesenho.PlaceholderText = "Design";
                        LblInicio.Text = "Start Date";
                        LblEntrega.Text = "Delivery Date";
                        BtnCadastrar.Text = "Register";
                        BtnAtualizar.Text = "Update";
                        BtnLimpar.Text = "Clean";

                        GnDvgOp.Columns["id"].HeaderText = "ID"; // string
                        GnDvgOp.Columns["numeroop"].HeaderText = "PO"; // string
                        GnDvgOp.Columns["descricao"].HeaderText = "Description"; // string
                        GnDvgOp.Columns["desenho"].HeaderText = "Design";
                        GnDvgOp.Columns["dataInicio"].HeaderText = "Start Date";
                        GnDvgOp.Columns["dataEntrega"].HeaderText = "Delivery Date"; // DateTime
                        break;
                    }
                case "es":
                    {
                        TxtNumeroOp.PlaceholderText = "OP";
                        TxtDescricao.PlaceholderText = "Descripción";
                        Txtdesenho.PlaceholderText = "Diseño";
                        LblInicio.Text = "Fecha de inicio";
                        LblEntrega.Text = "Fecha de entrega";
                        BtnCadastrar.Text = "Registro";
                        BtnAtualizar.Text = "Actualizar";
                        BtnLimpar.Text = "Limpiar";

                        GnDvgOp.Columns["id"].HeaderText = "ID"; // string
                        GnDvgOp.Columns["numeroop"].HeaderText = "OP"; // string
                        GnDvgOp.Columns["descricao"].HeaderText = "Descripción"; // string
                        GnDvgOp.Columns["desenho"].HeaderText = "Diseño";
                        GnDvgOp.Columns["dataInicio"].HeaderText = "Fecha de inicio";
                        GnDvgOp.Columns["dataEntrega"].HeaderText = "Fecha de entrega"; // DateTime
                        break;
                    }
                case "pt":
                    {
                        TxtNumeroOp.PlaceholderText = "OP";
                        TxtDescricao.PlaceholderText = "Descrição";
                        Txtdesenho.PlaceholderText = "Desenho";
                        LblInicio.Text = "Data de início";
                        LblEntrega.Text = "Data de entrega";
                        BtnCadastrar.Text = "Cadastrar";
                        BtnAtualizar.Text = "Atualizar";
                        BtnLimpar.Text = "Limpar";

                        GnDvgOp.Columns["id"].HeaderText = "ID"; // string
                        GnDvgOp.Columns["numeroop"].HeaderText = "OP"; // string
                        GnDvgOp.Columns["descricao"].HeaderText = "Descrição"; // string
                        GnDvgOp.Columns["desenho"].HeaderText = "Desenho";
                        GnDvgOp.Columns["dataInicio"].HeaderText = "Data de início";
                        GnDvgOp.Columns["dataEntrega"].HeaderText = "Data de entrega"; // DateTime
                        break;
                    }
                default:
                    {
                        TxtNumeroOp.PlaceholderText = "OP";
                        TxtDescricao.PlaceholderText = "Descrição";
                        Txtdesenho.PlaceholderText = "Desenho";
                        LblInicio.Text = "Data de Início";
                        LblEntrega.Text = "Data de entrega";
                        BtnCadastrar.Text = "Cadastrar";
                        BtnAtualizar.Text = "Atualizar";
                        BtnLimpar.Text = "Limpar";

                        GnDvgOp.Columns["id"].HeaderText = "ID"; // string
                        GnDvgOp.Columns["numeroop"].HeaderText = "OP"; // string
                        GnDvgOp.Columns["descricao"].HeaderText = "Descrição"; // string
                        GnDvgOp.Columns["desenho"].HeaderText = "Desenho";
                        GnDvgOp.Columns["dataInicio"].HeaderText = "Data de início";
                        GnDvgOp.Columns["dataEntrega"].HeaderText = "Data de entrega"; // DateTime
                        break;
                    }
            }
        }
        public void CarregarOP()
        {
            try
            {
                var listaDados = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");

                // Limpa dados existentes (opcional)
                GnDvgOp.Rows.Clear();

                // Verifica se há dados
                if (listaDados != null && listaDados.Any())
                {
                    foreach (var tupla in listaDados)
                    {
                        int rowIndex = GnDvgOp.Rows.Add();

                        // Preenche cada célula com os elementos da tupla
                        GnDvgOp.Rows[rowIndex].Cells["id"].Value = tupla.Item1; // string
                        GnDvgOp.Rows[rowIndex].Cells["numeroop"].Value = tupla.Item2; // string
                        GnDvgOp.Rows[rowIndex].Cells["descricao"].Value = tupla.Item3; // string
                        GnDvgOp.Rows[rowIndex].Cells["desenho"].Value = tupla.Item4; 
                        GnDvgOp.Rows[rowIndex].Cells["dataInicio"].Value = tupla.Item5.ToString("dd/MM/yyyy");
                        if (System.DateTime.Now < tupla.Item6)
                        {
                            GnDvgOp.Rows[rowIndex].Cells["dataEntrega"].Value = tupla.Item6.ToString("dd/MM/yyyy"); // DateTime
                            GnDvgOp.Rows[rowIndex].Cells["dataEntrega"].Style.ForeColor = Color.FromArgb(0, 200, 0);
                        }   
                        else
                        {
                            GnDvgOp.Rows[rowIndex].Cells["dataEntrega"].Value = tupla.Item6.ToString("dd/MM/yyyy"); // DateTime
                            GnDvgOp.Rows[rowIndex].Cells["dataEntrega"].Style.ForeColor = Color.FromArgb(255, 50, 50);
                        }
                    }
                }


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


        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (TxtNumeroOp.Text != "" &&
                    Txtdesenho.Text != "" &&
                   TxtDescricao.Text != "" &&
                   GNDatePikerEntregaOP.Text != "" &&
                   GNDatePikerInicioOP.Text != ""
                   )
                {

                    op.InserirOP(TxtNumeroOp.Text, TxtDescricao.Text, Txtdesenho.Text, Convert.ToDateTime(GNDatePikerInicioOP.Value), Convert.ToDateTime(GNDatePikerEntregaOP.Value));
                    LimparCampos();
                }
                else
                {
                    switch (SessaoIdioma.Idioma)
                    {
                        case "en":
                            {
                                MessageBox.Show("Fill in all fields!");

                                break;
                            }
                        case "es":
                            {
                                MessageBox.Show("Complete todos los campos!");
                                break;
                            }
                        case "pt":
                            {
                                MessageBox.Show("Preencher todos os campos");
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Preencher todos os campos");
                                break;
                            }
                    }
                }

            }
            catch (Exception ex)
            {

                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Error registering!" + ex);

                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Error al registrarse!" + ex);
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Erro ao cadastrar: " + ex);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Erro ao cadastrar: " + ex);
                            break;
                        }
                }
                LimparCampos();
            }
       
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {

                if (TxtNumeroOp.Text != "" &&
                    Txtdesenho.Text != "" &&
                   TxtDescricao.Text != "" &&
                   GNDatePikerEntregaOP.Text != "" &&
                   GNDatePikerInicioOP.Text != ""
                   )
                {
                    op.AtualizarOp(Convert.ToInt32(GNlabelIdAtualizar.Text),
                                                    TxtNumeroOp.Text,
                                                    TxtDescricao.Text,
                                                    Txtdesenho.Text,
                                                    Convert.ToDateTime(GNDatePikerInicioOP.Value),
                                                    Convert.ToDateTime(GNDatePikerEntregaOP.Value));
                    LimparCampos();
                }
                else
                {
                    switch (SessaoIdioma.Idioma)
                    {
                        case "en":
                            {
                                MessageBox.Show("Fill in all fields!");

                                break;
                            }
                        case "es":
                            {
                                MessageBox.Show("Complete todos los campos!");
                                break;
                            }
                        case "pt":
                            {
                                MessageBox.Show("Preencher todos os campos");
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Preencher todos os campos");
                                break;
                            }
                    }
                }

            }
            catch (Exception ex)
            {
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Error when updating: " + ex);

                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Error al actualizar: " + ex);
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Erro ao atualizar: " + ex);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Erro ao atualizar: " + ex);
                            break;
                        }
                }

                LimparCampos();
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void GnDvgOp_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var linhas = GnDvgOp.Rows[e.RowIndex];
                    string titulo = "";
                    string descricao = "";
                    switch (SessaoIdioma.Idioma)
                    {
                        case "en":
                            {
                                titulo = "User registration";
                                descricao = "Do you really want to continue?";

                                break;
                            }
                        case "es":
                            {
                                titulo = "Registro de usuario";
                                descricao = "Realmente deseas continuar?";
                                break;
                            }
                        case "pt":
                            {
                                titulo = "Cadastro Usuário";
                                descricao = "Deseja realmente continuar?";
                                break;
                            }
                        default:
                            {
                                titulo = "Cadastro Usuário";
                                descricao = "Deseja realmente continuar?";
                                break;
                            }
                    }

                    var form = new PopUPGUS(titulo, descricao);
                    form.ShowDialog();

                    switch (form.Result)
                    {
                        case PopUPGUS.CustomDialogResult.Excluir:
                            if (op.ExcluirProcessosVinculados(Convert.ToInt32(linhas.Cells[0].Value?.ToString())) == 0)
                            {
                                if (!op.ExcluirOp(Convert.ToInt32(linhas.Cells[0].Value?.ToString())))
                                {
                                    switch (SessaoIdioma.Idioma)
                                    {
                                        case "en":
                                            {
                                                MessageBox.Show("Error when deleting" );

                                                break;
                                            }
                                        case "es":
                                            {
                                                MessageBox.Show("Error al eliminar");
                                                break;
                                            }
                                        case "pt":
                                            {
                                                MessageBox.Show("Erro ao excluir");
                                                break;
                                            }
                                        default:
                                            {
                                                MessageBox.Show("Erro ao excluir");
                                                break;
                                            }
                                    }
                                }
                            }
                            else if (op.ExcluirProcessosVinculados(Convert.ToInt32(linhas.Cells[0].Value?.ToString())) >= 0)
                            {
                                if (!op.ExcluirOp(Convert.ToInt32(linhas.Cells[0].Value?.ToString())))
                                {
                                    switch (SessaoIdioma.Idioma)
                                    {
                                        case "en":
                                            {
                                                MessageBox.Show("Error when deleting");

                                                break;
                                            }
                                        case "es":
                                            {
                                                MessageBox.Show("Error al eliminar");
                                                break;
                                            }
                                        case "pt":
                                            {
                                                MessageBox.Show("Erro ao excluir");
                                                break;
                                            }
                                        default:
                                            {
                                                MessageBox.Show("Erro ao excluir");
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
                                            MessageBox.Show("Error deleting PO links");

                                            break;
                                        }
                                    case "es":
                                        {
                                            MessageBox.Show("Error al eliminar enlaces OP");
                                            break;
                                        }
                                    case "pt":
                                        {
                                            MessageBox.Show("Erro ao excluir vinculos OP");
                                            break;
                                        }
                                    default:
                                        {
                                            MessageBox.Show("Erro ao excluir vinculos OP");
                                            break;
                                        }
                                }

                            }
                            LimparCampos();
                            break;
                        case PopUPGUS.CustomDialogResult.Alterar:

                            BtnCadastrar.Enabled = false;
                            BtnAtualizar.Enabled = true;
                            GNlabelIdAtualizar.Text = linhas.Cells[0].Value.ToString();
                            TxtNumeroOp.Text = linhas.Cells[1].Value.ToString();
                            TxtDescricao.Text = linhas.Cells[2].Value.ToString();
                            Txtdesenho.Text = linhas.Cells[3].Value.ToString();
                            if (linhas.Cells[4].Value != null && DateTime.TryParse(linhas.Cells[4].Value.ToString(), out DateTime dataInicio))
                            {

                                GNDatePikerInicioOP.Value = dataInicio.Date;
                            }
                            if (linhas.Cells[5].Value != null && DateTime.TryParse(linhas.Cells[5].Value.ToString(), out DateTime dataEntrega))
                            {
                                GNDatePikerEntregaOP.Value = dataEntrega;
                            }

                            break;
                        case PopUPGUS.CustomDialogResult.Cancelar:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Error deleting or updating: " + ex);

                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Error al eliminar o actualizar: " + ex);
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Erro ao excluir ou atualizar: " + ex);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Erro ao excluir ou atualizar: " + ex);
                            break;
                        }
                }

            }
        }
    }

}

