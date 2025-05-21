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
    public partial class CadastroLinhaProducao : Form
    {
        ControleLinhaProducao linha = new ControleLinhaProducao();
        public CadastroLinhaProducao()
        {
            InitializeComponent();

            GNDataGridLinhasCadastradaLinhaP.DataSource = linha.RecuperarLinha("SELECT * FROM bdflowvalmet.linhaproducao");
            LimparCampos();
        }

        private void GNCbxCor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GNCbxCor.SelectedIndex != -1)
            {
                string[] rgb = new string[2];
                string[] valorRgb = new string[3];
                string resultado;
                rgb = GNCbxCor.SelectedItem.ToString().Split('-');
                resultado = rgb[1].Replace("(", "").Replace(")", "");
                valorRgb = resultado.Split(',');
                GNPanelCores.BackColor = Color.FromArgb(Convert.ToInt32(valorRgb[0]), Convert.ToInt32(valorRgb[1]), Convert.ToInt32(valorRgb[2]));
            }

        }

        private void GNBtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (GNTxtNomeLinhaP.Text != "" &&
                   GNTxtSilglaLinhaP.Text != "" &&
                   GNCbxCor.Text != "")
                {


                    linha.InserirLinha(GNTxtNomeLinhaP.Text, GNCbxCor.Text, GNTxtSilglaLinhaP.Text);
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
            GNDataGridLinhasCadastradaLinhaP.DataSource = linha.RecuperarLinha("SELECT * FROM bdflowvalmet.linhaproducao");
        }

        public void LimparCampos()
        {
            GNTxtNomeLinhaP.Text = "";
            GNTxtSilglaLinhaP.Text = "";
            GNCbxCor.SelectedIndex = -1;
            GNPanelCores.BackColor =  Color.White;
            GNDataGridLinhasCadastradaLinhaP.ClearSelection();

        }

        private void GNDataGridLinhasCadastradaLinhaP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var linhas = GNDataGridLinhasCadastradaLinhaP.Rows[e.RowIndex];



                    var confirmacao = MessageBox.Show($"Deseja escluir linha: {linhas.Cells[0].Value?.ToString()}", linhas.Cells[1].Value?.ToString(), MessageBoxButtons.OKCancel).ToString();
                    if (confirmacao == "OK")
                    {
                        linha.ExcluirLinha(Convert.ToInt32(linhas.Cells[0].Value?.ToString()));
                    }

                    GNDataGridLinhasCadastradaLinhaP.ClearSelection();
                    GNDataGridLinhasCadastradaLinhaP.DataSource = linha.RecuperarLinha("SELECT * FROM bdflowvalmet.linhaproducao");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex);
            }
            LimparCampos();


        }

        private void GNLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
