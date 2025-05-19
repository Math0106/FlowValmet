using FlowValmet.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace FlowValmet.Viwes
{
    public partial class VincularProcessos : Form
    {
        ControleVincularProcessos Vincular = new ControleVincularProcessos();
        public List<int> listaProcessosVinculados = new List<int>();
        public VincularProcessos()
        {
            InitializeComponent();
            GNDgvVinculado.ColumnHeadersHeight = 20;

            var resultadoOp = Vincular.RecuperarOp_id_numeroOP_descricao("SELECT o.id, o.numeroop, o.descricao FROM bdflowvalmet.op o LEFT JOIN bdflowvalmet.processos p ON o.id = p.op_id WHERE p.op_id IS NULL;");
            foreach (var item in resultadoOp)
            {
                GNCbxOps.Items.Add($"{item.Item1}-{item.Item2} ");
            }

            ResetarCbxProcessos();

            //var resultadoLinha = Vincular.RecuperarLinhaProducao_id_linha_sigla("SELECT id,linha,sigla FROM bdflowvalmet.linhaproducao");
            //foreach (var item in resultadoLinha)
            //{
            //    GnCbxProcessos.Items.Add($"{item.Item1}-{item.Item2}-{item.Item3}");
            //}

            GNDtpDataInicio.MinDate = DateTime.Today;
            GNDtpDataFim.MinDate = DateTime.Today;
        }

        public void ResetarCbxProcessos()
        {
            GnCbxProcessos.Items.Clear();
            var resultadoLinha = Vincular.RecuperarLinhaProducao_id_linha_sigla("SELECT id,linha,sigla FROM bdflowvalmet.linhaproducao");
            foreach (var item in resultadoLinha)
            {
                if (!listaProcessosVinculados.Contains(item.Item1))
                {
                    GnCbxProcessos.Items.Add($"{item.Item1}-{item.Item2}-{item.Item3}");
                }

            }
        }

        private void GNBtnVincular_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (GNDtpDataInicio.Value <= GNDtpDataFim.Value)
                {
                    if (GNCbxOps.Text != "" && GnCbxProcessos.Text != "")
                    {
                        string[] elementoProcesso = GnCbxProcessos.Text.Split('-');
                        string[] elementoOp = GNCbxOps.Text.Split('-');
                        listaProcessosVinculados.Add(int.Parse(elementoProcesso[0]));
                        GNDgvVinculado.Rows.Add(elementoOp[0],GnCbxProcessos.Text , GNDtpDataInicio.Value.Date.ToString("dd/MM/yyyy"), GNDtpDataFim.Value.Date.ToString("dd/MM/yyyy"));
                        GNCbxOps.Enabled = false;
                        GNCheckboxTravarVinculoOp.Checked = true;
                        GnCbxProcessos.SelectedIndex = -1;
                        GNDtpDataInicio.Value = DateTime.Today;
                        GNDtpDataFim.Value = DateTime.Today;

                        ResetarCbxProcessos();
                    }
                    else
                    {
                        MessageBox.Show("Preencher todos os campos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Data das invaldas!");
                    return ;
                }
                


            }
            catch (Exception ex)
            {               
                MessageBox.Show("Erro ao vincular processo: " + ex);   
                return ;
            }
        }

        private void GNDgvVinculado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var linhas = GNDgvVinculado.Rows[e.RowIndex];


                    
                    var confirmacao = MessageBox.Show($"Deseja escluir linha: {linhas.Cells[0].Value?.ToString()}", linhas.Cells[1].Value?.ToString(), MessageBoxButtons.OKCancel).ToString();
                    if (confirmacao == "OK")
                    {
                        listaProcessosVinculados.Remove(int.Parse(linhas.Cells[0].Value?.ToString()));
                        GNDgvVinculado.Rows.RemoveAt(e.RowIndex);
                        ResetarCbxProcessos();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex);
            }
        }

        private void GNCheckboxTravarVinculoOp_Click(object sender, EventArgs e)
        {
            if (GNDgvVinculado.Rows.Count >= 2)
            {
                MessageBox.Show("Não é possivel desvincular antes aplicar ou cancele a operação");
                GNCheckboxTravarVinculoOp.Checked = true;
            }
            else
            {
                if (GNCbxOps.Text != "")
                {
                    
                    if (GNDgvVinculado.Rows.Count >= 1 )
                    {
                        if (GNCheckboxTravarVinculoOp.Checked == false)
                        {
                            GNCbxOps.Enabled = true;
                        }
                        else
                        {
                            GNCbxOps.Enabled = false;
                        }
                        

                    }
                }
                else
                {
                    GNCheckboxTravarVinculoOp.Checked = false;
                    MessageBox.Show("Selecione uma Op para vincular");
                }
            }

        }


        private void GnBtnCadastrarVinculo_Click_1(object sender, EventArgs e)
        {
            if (GNDgvVinculado.Rows.Count >= 1)
            {
                

                List<Tuple<int, int, DateTime, DateTime>> listaProcessos = new List<Tuple<int, int, DateTime, DateTime>>();

                foreach (DataGridViewRow row in GNDgvVinculado.Rows)
                {
                    // Verifica se a linha não é a linha de cabeçalho e se não está vazia
                    if (!row.IsNewRow)
                    {
                        
                        int opId = Convert.ToInt32(row.Cells["Idop"].Value);
                        string[] elemento = row.Cells["processo"].Value.ToString().Split('-');

                        int processo = Convert.ToInt32(elemento[0]);
                        DateTime inicio = Convert.ToDateTime(row.Cells["dataInicio"].Value);

                        // Tratamento para campo fim que pode ser nulo
                        DateTime fim = Convert.ToDateTime(row.Cells["dataFim"].Value);

                        // Adiciona à lista (usando DateTime.MinValue para valores nulos)
                        listaProcessos.Add(Tuple.Create(
                            
                            opId,
                            processo,
                            inicio.Date.Date,
                            fim.Date.Date
                        ));
                    }
                }

                if (Vincular.InserirVinculoProcesso(listaProcessos)){
                    MessageBox.Show("Cadastrado com sucesso");
                    listaProcessosVinculados.Clear();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar");
                }


            }
            else
            {
                MessageBox.Show("Nada no data grid viwes");
            }
        }

        private void GNPanelCadastroOP_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
