using FlowValmet.Controllers;
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
        }
        public void ResetarTelaOp()
        {
            GnDvgOp.DataSource = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");
            BtnAtualizar.Enabled = false;
            BtnAtualizar.Enabled = true;
        }
        private void GBBtnCadastrar_Click(object sender, EventArgs e)
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

                    op.InserirOP(TxtNumeroOp.Text, Txtdesenho.Text, TxtDescricao.Text, Convert.ToDateTime(GNDatePikerInicioOP.Value), Convert.ToDateTime(GNDatePikerEntregaOP.Value));
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Preencher todos os campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex);
                LimparCampos();
            }
            //GnDvgOp.DataSource = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");
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
            GnDvgOp.DataSource = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");
            GnDvgOp.ClearSelection();
            GNlabelIdAtualizar.Text = "";
        }

        private void GnDvgOp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var linhas = GnDvgOp.Rows[e.RowIndex];


                    var form = new PopUPGUS("Cadastro OP", "Deseja realmente continuar?");
                    form.ShowDialog();

                    switch (form.Result)
                    {
                        case PopUPGUS.CustomDialogResult.Excluir:
                            if (op.ExcluirProcessosVinculados(Convert.ToInt32(linhas.Cells[0].Value?.ToString())) == 0)
                            {
                                if (!op.ExcluirOp(Convert.ToInt32(linhas.Cells[0].Value?.ToString())))
                                {
                                    MessageBox.Show("Erro ao excluir OP");
                                }
                            }
                            else if (op.ExcluirProcessosVinculados(Convert.ToInt32(linhas.Cells[0].Value?.ToString())) >= 0)
                            {
                                if (!op.ExcluirOp(Convert.ToInt32(linhas.Cells[0].Value?.ToString())))
                                {
                                    MessageBox.Show("Erro ao excluir OP");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Erro ao excluir vinculos OP");
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
                MessageBox.Show("Erro ao excluir: " + ex);
            }


        }

        private void GNBtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void GNBtnAtualizar_Click(object sender, EventArgs e)
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
                                                    Txtdesenho.Text,
                                                    TxtDescricao.Text,
                                                    Convert.ToDateTime(GNDatePikerInicioOP.Value),
                                                    Convert.ToDateTime(GNDatePikerEntregaOP.Value));
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Preencher todos os campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex);
                LimparCampos();
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

                    op.InserirOP(TxtNumeroOp.Text, Txtdesenho.Text, TxtDescricao.Text, Convert.ToDateTime(GNDatePikerInicioOP.Value), Convert.ToDateTime(GNDatePikerEntregaOP.Value));
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Preencher todos os campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex);
                LimparCampos();
            }
            //GnDvgOp.DataSource = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");
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
                                                    Txtdesenho.Text,
                                                    TxtDescricao.Text,
                                                    Convert.ToDateTime(GNDatePikerInicioOP.Value),
                                                    Convert.ToDateTime(GNDatePikerEntregaOP.Value));
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Preencher todos os campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex);
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


                    var form = new PopUPGUS("Cadastro OP", "Deseja realmente continuar?");
                    form.ShowDialog();

                    switch (form.Result)
                    {
                        case PopUPGUS.CustomDialogResult.Excluir:
                            if (op.ExcluirProcessosVinculados(Convert.ToInt32(linhas.Cells[0].Value?.ToString())) == 0)
                            {
                                if (!op.ExcluirOp(Convert.ToInt32(linhas.Cells[0].Value?.ToString())))
                                {
                                    MessageBox.Show("Erro ao excluir OP");
                                }
                            }
                            else if (op.ExcluirProcessosVinculados(Convert.ToInt32(linhas.Cells[0].Value?.ToString())) >= 0)
                            {
                                if (!op.ExcluirOp(Convert.ToInt32(linhas.Cells[0].Value?.ToString())))
                                {
                                    MessageBox.Show("Erro ao excluir OP");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Erro ao excluir vinculos OP");
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
                MessageBox.Show("Erro ao excluir: " + ex);
            }
        }
    }

}

