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
                MessageBox.Show("Erro ao carregar!");
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
                    MessageBox.Show("Preencher todos os campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex);
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
                MessageBox.Show("Erro ao excluir ou atualizar: " + ex);
            }
        }
    }

}

