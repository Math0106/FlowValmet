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
using static iText.Kernel.Pdf.Colorspace.PdfDeviceCs;

namespace FlowValmet.Viwes
{
    public partial class CadastroLinhaGUS: Form
    {
        ControleLinhaProducao linha = new ControleLinhaProducao();
        public CadastroLinhaGUS()
        {
            InitializeComponent();
            LimparCampos();
        }



        public void LimparCampos()
        {
            TxtLinhaProdução.Text = "";
            TxtSigla.Text = "";
            CbxCor.SelectedIndex = -1;
            PanelCores.BackColor = Color.White;
            DesingDataGridView.DesignGunaDataGrid(GNDataGridLinhasCadastradaLinhaP);
            CarregarLinhas();
            GNDataGridLinhasCadastradaLinhaP.ClearSelection();

        }
        public void CarregarLinhas()
        {
            try
            {
                var listaDados = linha.RecuperarLinha("SELECT * FROM bdflowvalmet.linhaproducao");

                // Limpa dados existentes (opcional)
                GNDataGridLinhasCadastradaLinhaP.Rows.Clear();

                // Verifica se há dados
                if (listaDados != null && listaDados.Any())
                {
                    foreach (var tupla in listaDados)
                    {
                        string[] rgb = new string[2];
                        string[] valorRgb = new string[3];
                        string resultado;
                        int rowIndex = GNDataGridLinhasCadastradaLinhaP.Rows.Add();

                        // Preenche cada célula com os elementos da tupla
                        GNDataGridLinhasCadastradaLinhaP.Rows[rowIndex].Cells["id"].Value = tupla.Item1; // string
                        GNDataGridLinhasCadastradaLinhaP.Rows[rowIndex].Cells["linhaProducao"].Value = tupla.Item2; // string
                        GNDataGridLinhasCadastradaLinhaP.Rows[rowIndex].Cells["sigla"].Value = tupla.Item3; // string
                        GNDataGridLinhasCadastradaLinhaP.Rows[rowIndex].Cells["cor"].Value = tupla.Item4;
                        rgb = tupla.Item4.ToString().Split('-');
                        resultado = rgb[1].Replace("(", "").Replace(")", "");
                        valorRgb = resultado.Split(',');
                        GNDataGridLinhasCadastradaLinhaP.Rows[rowIndex].Cells["cor"].Style.BackColor = Color.FromArgb(Convert.ToInt32(valorRgb[0]), Convert.ToInt32(valorRgb[1]), Convert.ToInt32(valorRgb[2]));
                        

                    }
                }


            }
            catch
            {
                MessageBox.Show("Erro ao carregar!");
            }

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
            CarregarLinhas();
            //GNDataGridLinhasCadastradaLinhaP.DataSource = linha.RecuperarLinha("SELECT * FROM bdflowvalmet.linhaproducao");
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

