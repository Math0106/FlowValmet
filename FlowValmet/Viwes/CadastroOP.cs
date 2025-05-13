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
            GnDvgOp.DataSource = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");
            GNDatePikerInicioOP.MinDate = DateTime.Today;
            GNDatePikerEntregaOP.MinDate = DateTime.Today;
        }

        private void GBBtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (GNTxtNumeroOP.Text != "" &&
                    GNTxtDesenhoOP.Text != "" &&
                   GNTxtDescriçãoOP.Text != "" &&
                   GNDatePikerEntregaOP.Text != "" &&
                   GNDatePikerInicioOP.Text != ""
                   )
                {

                    op.InserirOP(GNTxtNumeroOP.Text, GNTxtDescriçãoOP.Text,GNTxtDesenhoOP.Text,Convert.ToDateTime(GNDatePikerInicioOP.Value), Convert.ToDateTime(GNDatePikerEntregaOP.Value));
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
            GnDvgOp.DataSource = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");
        }

        public void LimparCampos()
        {
            GNDatePikerEntregaOP.Value = DateTime.Today;
            GNDatePikerInicioOP.Value = DateTime.Today;
            GNTxtDescriçãoOP.Text = "";
            GNTxtDesenhoOP.Text = "";
            GNTxtNumeroOP.Text = "";
        }

        private void GnDvgOp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var linhas = GnDvgOp.Rows[e.RowIndex];



                    var confirmacao = MessageBox.Show($"Deseja escluir linha: {linhas.Cells[0].Value?.ToString()}", linhas.Cells[1].Value?.ToString(), MessageBoxButtons.OKCancel).ToString();
                    if (confirmacao == "OK")
                    {
                        if (op.ExcluirProcessosVinculados(Convert.ToInt32(linhas.Cells[0].Value?.ToString())))
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
                    }

                    GnDvgOp.ClearSelection();
                    GnDvgOp.DataSource = op.RecuperarOp("SELECT * FROM bdflowvalmet.op");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex);
            }
            LimparCampos();

        }
    }
}
