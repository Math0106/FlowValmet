using FlowValmet.Controllers;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static ServiceStack.Script.Lisp;

namespace FlowValmet.Viwes
{
    public partial class AnaliseOps : Form
    {
        ControleAnaliseOp analiseOp = new ControleAnaliseOp();
        ControleLinhaProducao linhaProducao = new ControleLinhaProducao();
        Image nulo = ConverterResx.GetIcon("iconNulo", 25, 25);
        Image andamento = ConverterResx.GetIcon("iconAndamento", 25, 25);
        Image atrasado = ConverterResx.GetIcon("iconAtraso", 25, 25);
        Image naoAplicado = ConverterResx.GetIcon("IconNaoAplicavel", 25, 25);
        Image concluido = ConverterResx.GetIcon("iconConcluido", 25, 25);
        public AnaliseOps()
        {
           
            InitializeComponent();



        }

        private void AnaliseOps_Load(object sender, EventArgs e)
        {
            GNDVGAnaliseOp.Font = new Font("Calibri", 11);

            CarregarLinhasProducao();

            CarregarOps();
            GNDVGAnaliseOp.ClearSelection();

        }

        public void CarregarOps()
        {
            try
            {
                var listaDados = analiseOp.RecuperarOp();

                // Limpa dados existentes (opcional)
                GNDVGAnaliseOp.Rows.Clear();

                // Verifica se há dados
                if (listaDados != null && listaDados.Any())
                {
                    foreach (var tupla in listaDados)
                    {
                        // Adiciona uma nova linha ao DataGridView
                        if (tupla.Item6 != "sem vinculo")
                        {
                            int rowIndex = GNDVGAnaliseOp.Rows.Add();

                            // Preenche cada célula com os elementos da tupla
                            GNDVGAnaliseOp.Rows[rowIndex].Cells["numeroOp"].Value = tupla.Item1; // string
                            GNDVGAnaliseOp.Rows[rowIndex].Cells["descricao"].Value = tupla.Item2; // string
                            GNDVGAnaliseOp.Rows[rowIndex].Cells["desenho"].Value = tupla.Item3; // string
                            GNDVGAnaliseOp.Rows[rowIndex].Cells["dataInicio"].Value = tupla.Item4.ToString("dd/MM/yyyy"); // DateTime
                            if (System.DateTime.Now > tupla.Item5)
                            {
                                GNDVGAnaliseOp.Rows[rowIndex].Cells["dataEntrega"].Value = tupla.Item5.ToString("dd/MM/yyyy"); // DateTime
                                GNDVGAnaliseOp.Rows[rowIndex].Cells["dataEntrega"].Style.BackColor = Color.FromArgb(255, 220, 220);
                            }
                            else
                            {
                                GNDVGAnaliseOp.Rows[rowIndex].Cells["dataEntrega"].Value = tupla.Item5.ToString("dd/MM/yyyy"); // DateTime
                                GNDVGAnaliseOp.Rows[rowIndex].Cells["dataEntrega"].Style.BackColor = Color.FromArgb(220, 255, 220);
                            }
                                
                            VincularLinhasAOp(tupla.Item1.ToString(),tupla.Item6.ToString().Split(','), rowIndex); 
                            
                        }

                    }
                }


            }
            catch
            {
                MessageBox.Show("Erro ao carregar as ordens!");
            }
        }

        private void GNDVGAnaliseOp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verifica se o clique foi em uma célula válida (não no cabeçalho)
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtém a célula clicada
                    DataGridViewCell cell = GNDVGAnaliseOp.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (cell.Value == nulo)
                    {
                        cell.Value = andamento;
                        if (cell.Value == andamento && analiseOp.AtualizarStatus("andamento", GNDVGAnaliseOp.Rows[e.RowIndex].Cells["numeroop"].Value.ToString(), GNDVGAnaliseOp.Columns[e.ColumnIndex].Name.ToString().ToUpper()))
                        {
                            return;
                        }
                        else
                        {
                            MessageBox.Show("deu ruim");
                            cell.Value = nulo;
                            return;
                        }
                    }
                    else if (cell.Value == andamento)
                    {
                        cell.Value = atrasado;
                        if (cell.Value == atrasado && analiseOp.AtualizarStatus("atrasado", GNDVGAnaliseOp.Rows[e.RowIndex].Cells["numeroop"].Value.ToString(), GNDVGAnaliseOp.Columns[e.ColumnIndex].Name.ToString().ToUpper()))
                        {
                            return;
                        }
                        else
                        {
                            MessageBox.Show("deu ruim");
                            cell.Value = andamento;
                            return;
                        }
                    }
                    else if (cell.Value == atrasado)
                    {
                        cell.Value = concluido;
                        if (cell.Value == concluido && analiseOp.AtualizarStatus("concluido", GNDVGAnaliseOp.Rows[e.RowIndex].Cells["numeroop"].Value.ToString(), GNDVGAnaliseOp.Columns[e.ColumnIndex].Name.ToString().ToUpper()))
                        {
                            return;
                        }
                        else
                        {
                            MessageBox.Show("deu ruim");
                            cell.Value = atrasado;
                            return;
                        }
                    }
                    else if (cell.Value == concluido)
                    {
                        cell.Value = nulo;
                        if (cell.Value == nulo && analiseOp.AtualizarStatus("nulo", GNDVGAnaliseOp.Rows[e.RowIndex].Cells["numeroop"].Value.ToString(), GNDVGAnaliseOp.Columns[e.ColumnIndex].Name.ToString().ToUpper()))
                        {
                            return;
                        }
                        else
                        {
                            MessageBox.Show("deu ruim");
                            cell.Value = concluido;
                            return;
                        }
                    }
                    GNDVGAnaliseOp.ClearSelection();
                }
            }
            catch
            {
                MessageBox.Show("Foi possivel alterar o status do processo!");
               
            }

        }

        public void CarregarLinhasProducao()
        {
            var listaSiglas = linhaProducao.RecuperarLinhaSigla("SELECT id,sigla FROM bdflowvalmet.linhaproducao;");
            foreach (var itens in listaSiglas)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.Name = itens.Item2.ToLower();
                iconColumn.MinimumWidth = 45;
                iconColumn.Width = 45;
                iconColumn.Resizable = DataGridViewTriState.False;

                iconColumn.HeaderText = itens.Item2.ToUpper();
                GNDVGAnaliseOp.Columns.Add(iconColumn);
                GNDVGAnaliseOp.Rows.Add(itens.Item2.ToLower());
                //iconColumn.Image = nulo;
            }

        }

        public void VincularLinhasAOp(string numeroOp, string[] linhasProducao, int indice)
        {
            var siglas = linhaProducao.RecuperarLinhaSigla("SELECT id,sigla FROM bdflowvalmet.linhaproducao;");
            foreach(var itens in siglas)
            {
                int verificarLinha = Array.IndexOf(linhasProducao, itens.Item2);
                if (verificarLinha != -1)
                {
                    var listastatus = analiseOp.RecuperarStatusPCP(numeroOp, itens.Item2);
                    foreach (var item in listastatus)
                    {
                        if (item.Item2 == "concluido")
                        {
                            GNDVGAnaliseOp.Rows[indice].Cells[linhasProducao[verificarLinha]].Value = concluido;
                        }
                        else if (item.Item2 == "andamento")
                        {
                            GNDVGAnaliseOp.Rows[indice].Cells[linhasProducao[verificarLinha]].Value = andamento;
                        }else if (item.Item2 == "atrasado")
                        {
                            GNDVGAnaliseOp.Rows[indice].Cells[linhasProducao[verificarLinha]].Value = atrasado;
                        }
                        else
                        {
                            GNDVGAnaliseOp.Rows[indice].Cells[linhasProducao[verificarLinha]].Value = nulo;
                        }                            
                    }                
                }
                else
                {

                    GNDVGAnaliseOp.Rows[indice].Cells[itens.Item2].Value = naoAplicado;
                }
            }

        }

        private void GNBTnSalvar_Click(object sender, EventArgs e)
        {
            ExportarPDF pdf = new ExportarPDF();    
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf"; 
            saveDialog.FileName = "RelatorioPCP.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                pdf.ExportarRelatorioEstilizado(GNDVGAnaliseOp, saveDialog.FileName);
                MessageBox.Show("PDF gerado com sucesso!");
            }
        }
    }
}
