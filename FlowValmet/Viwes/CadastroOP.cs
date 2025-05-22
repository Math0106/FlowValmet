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
using static System.Windows.Forms.LinkLabel;

namespace FlowValmet.Viwes
{
    public partial class CadastroOP : Form
    {
       ControleOp op = new ControleOp();
        public CadastroOP()
        {
            InitializeComponent();
            LimparCampos();
        }
        public void ResetarTelaOp()
        {
            GnDvgOp.DataSource = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");
            GNBtnAtualizar.Enabled = false;
            GNBtnCadastrar.Enabled = true;
        }
        private void GBBtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (GNTxtNumeroOP.Text != "" &&
                    GNTxtDesenhoOP.Text != "" &&
                   GNTxtDescricaoOP.Text != "" &&
                   GNDatePikerEntregaOP.Text != "" &&
                   GNDatePikerInicioOP.Text != ""
                   )
                {

                    op.InserirOP(GNTxtNumeroOP.Text, GNTxtDescricaoOP.Text,GNTxtDesenhoOP.Text,Convert.ToDateTime(GNDatePikerInicioOP.Value), Convert.ToDateTime(GNDatePikerEntregaOP.Value));
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
                       GNBtnAtualizar.Enabled = false;
            GNBtnCadastrar.Enabled = true;
            GNDatePikerEntregaOP.Value = DateTime.Today;
            GNDatePikerInicioOP.Value = DateTime.Today;
            GNTxtDescricaoOP.Text = "";
            GNTxtDesenhoOP.Text = "";
            GNTxtNumeroOP.Text = "";
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

                            GNBtnCadastrar.Enabled = false;
                            GNBtnAtualizar.Enabled = true;
                            GNlabelIdAtualizar.Text = linhas.Cells[0].Value.ToString();
                            GNTxtNumeroOP.Text =  linhas.Cells[1].Value.ToString();
                            GNTxtDescricaoOP.Text = linhas.Cells[2].Value.ToString();
                            GNTxtDesenhoOP.Text = linhas.Cells[3].Value.ToString();
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

                if (GNTxtNumeroOP.Text != "" &&
                    GNTxtDesenhoOP.Text != "" &&
                   GNTxtDescricaoOP.Text != "" &&
                   GNDatePikerEntregaOP.Text != "" &&
                   GNDatePikerInicioOP.Text != ""
                   )
                {
                    op.AtualizarOp(Convert.ToInt32(GNlabelIdAtualizar.Text),
                                                    GNTxtNumeroOP.Text,
                                                    GNTxtDescricaoOP.Text,
                                                    GNTxtDesenhoOP.Text,
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
    }


}
