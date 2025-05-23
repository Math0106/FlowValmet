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
    public partial class CadastroLinhaGUS: Form
    {
        ControleLinhaProducao linha = new ControleLinhaProducao();
        public CadastroLinhaGUS()
        {
            InitializeComponent();

            GNDataGridLinhasCadastradaLinhaP.DataSource = linha.RecuperarLinha("SELECT * FROM bdflowvalmet.linhaproducao");
            LimparCampos();
        }

        private void GNCbxCor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxCor.SelectedIndex != -1)
            {
                string[] rgb = new string[2];
                string[] valorRgb = new string[3];
                string resultado;
                rgb = CbxCor.SelectedItem.ToString().Split('-');
                resultado = rgb[1].Replace("(", "").Replace(")", "");
                valorRgb = resultado.Split(',');
                PanelCores.BackColor = Color.FromArgb(Convert.ToInt32(valorRgb[0]), Convert.ToInt32(valorRgb[1]), Convert.ToInt32(valorRgb[2]));
            }

        }

        private void GNBtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (TxtLinhaProdução.Text != "" &&
                   TxtSigla.Text != "" &&
                   CbxCor.Text != "")
                {


                    linha.InserirLinha(TxtLinhaProdução.Text, CbxCor.Text, TxtSigla.Text);
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
            TxtLinhaProdução.Text = "";
            TxtSigla.Text = "";
            CbxCor.SelectedIndex = -1;
            PanelCores.BackColor = Color.White;
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


        private void BttnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (TxtLinhaProdução.Text != "" &&
                   TxtSigla.Text != "" &&
                   CbxCor.Text != "")
                {


                    linha.InserirLinha(TxtLinhaProdução.Text, CbxCor.Text, TxtSigla.Text);
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void CbxCor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxCor.SelectedIndex != -1)
            {
                string[] rgb = new string[2];
                string[] valorRgb = new string[3];
                string resultado;
                rgb = CbxCor.SelectedItem.ToString().Split('-');
                resultado = rgb[1].Replace("(", "").Replace(")", "");
                valorRgb = resultado.Split(',');
                PanelCores.FillColor = Color.FromArgb(Convert.ToInt32(valorRgb[0]), Convert.ToInt32(valorRgb[1]), Convert.ToInt32(valorRgb[2]));
            }
        }

        private void GNDataGridLinhasCadastradaLinhaP_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
    }


}

