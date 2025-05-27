using FlowValmet.Controllers;
using FlowValmet.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Guna.UI2;
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
            if (!string.IsNullOrEmpty(SessaoUsuario.Perfil))
            {
                // Habilitar botões baseado no perfil do usuário
                switch (SessaoUsuario.Perfil.ToLower())
                {
                    case "admin":
                        GNBTnSalvarPDF.Enabled = true; 
                        break;

                    case "user":
                        GNBTnSalvarPDF.Enabled = false;
                        break;

                }
            }
            else
            {
                GNBTnSalvarPDF.Enabled =false;
            }
            GNDVGAnaliseOp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GNDVGAnaliseOp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            GNDVGAnaliseOp.ScrollBars = ScrollBars.Both;
            EstilizarGunaDataGridView(GNDVGAnaliseOp);
        }
        public void EstilizarGunaDataGridView(Guna.UI2.WinForms.Guna2DataGridView dataGridView)
        {


            if (dataGridView == null) return;

            // 1. Configurações básicas de estilo
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.GridColor = Color.FromArgb(230, 230, 230);

            // 2. Configuração de fontes maiores e alinhamento
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11f);  // Fonte aumentada para 11pt
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11.5f, FontStyle.Bold);
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);  // Padding aumentado

            // 3. Aumentar altura das linhas
            dataGridView.RowTemplate.Height = 35;  // Altura padrão das linhas
            dataGridView.ColumnHeadersHeight = 65;  // Altura do cabeçalho

            // 4. Estilo do cabeçalho
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // 5. Estilo de linhas alternadas (zebrado)
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;

            // 6. Estilo de seleção
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowHeadersVisible = false;

            // 7. Configuração para coluna de descrição (se existir)
            if (dataGridView.Columns.Contains("descricao"))
            {
                dataGridView.Columns["descricao"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            // 8. Configuração de datas (se existirem)
            string[] dateColumns = { "dataInicio", "dataEntrega" };
            foreach (var col in dateColumns)
            {
                if (dataGridView.Columns.Contains(col))
                {
                    dataGridView.Columns[col].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataGridView.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            // 9. Configuração de desempenho
            try
            {
                typeof(Control).GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                    .SetValue(dataGridView, true, null);
            }
            catch { /* Ignora se não for possível setar */ }

            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 10. Ajustes para colunas específicas
            if (dataGridView.Columns.Contains("numeroOp"))
            {
                dataGridView.Columns["numeroOp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns["numeroOp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dataGridView.Columns.Contains("desenho"))
            {
                dataGridView.Columns["desenho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView.Columns["numeroOp"].MinimumWidth = 100;
            dataGridView.Columns["descricao"].MinimumWidth = 300;
            dataGridView.Columns["desenho"].MinimumWidth = 170;
            dataGridView.Columns["dataInicio"].MinimumWidth = 135;
            dataGridView.Columns["dataEntrega"].MinimumWidth = 135;

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
                            if (System.DateTime.Now < tupla.Item5)
                            {
                                GNDVGAnaliseOp.Rows[rowIndex].Cells["dataEntrega"].Value = tupla.Item5.ToString("dd/MM/yyyy"); // DateTime
                                GNDVGAnaliseOp.Rows[rowIndex].Cells["dataEntrega"].Style.ForeColor = Color.FromArgb(0, 200, 0);
                            }
                            else
                            {
                                GNDVGAnaliseOp.Rows[rowIndex].Cells["dataEntrega"].Value = tupla.Item5.ToString("dd/MM/yyyy"); // DateTime
                                GNDVGAnaliseOp.Rows[rowIndex].Cells["dataEntrega"].Style.ForeColor = Color.FromArgb(255, 50, 50);
                            }

                            VincularLinhasAOp(tupla.Item1.ToString(), tupla.Item6.ToString().Split(','), rowIndex);

                        }

                    }
                }


            }
            catch
            {
                MessageBox.Show("Erro ao carregar as ordens!");
            }
        }

        public void CarregarLinhasProducao()
        {
            var listaSiglas = linhaProducao.RecuperarLinhaSigla("SELECT id,sigla FROM bdflowvalmet.linhaproducao;");
            foreach (var itens in listaSiglas)
            {
                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                iconColumn.Name = itens.Item2.ToLower();
                
                iconColumn.MinimumWidth = 65;
                iconColumn.Width = 65;
                iconColumn.Resizable = DataGridViewTriState.False;

                iconColumn.HeaderText = itens.Item2.ToUpper();
                GNDVGAnaliseOp.Columns.Add(iconColumn);
                GNDVGAnaliseOp.Rows.Add(itens.Item2.ToLower());
            }

        }

        public void VincularLinhasAOp(string numeroOp, string[] linhasProducao, int indice)
        {
            var siglas = linhaProducao.RecuperarLinhaSigla("SELECT id,sigla FROM bdflowvalmet.linhaproducao;");
            foreach (var itens in siglas)
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
                        }
                        else if (item.Item2 == "atrasado")
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


        private void AnaliseOps_Load_1(object sender, EventArgs e)
        {
            GNDVGAnaliseOp.Font = new Font("Calibri", 11);

            CarregarLinhasProducao();

            CarregarOps();
            GNDVGAnaliseOp.ClearSelection();
        }

        private void GNBTnSalvar_Click_1(object sender, EventArgs e)
        {
            ExportarPDF pdf = new ExportarPDF();
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveDialog.FileName = "RelatorioPCP.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtenha as informações do usuário da sessão
                string setorUsuario = SessaoUsuario.Setor; // Ou "Manutenção" como no exemplo
                string emailUsuario = SessaoUsuario.Email; // Ou "matheusheppe@gmail.com" como no exemplo

                pdf.ExportarRelatorioEstilizado(GNDVGAnaliseOp, saveDialog.FileName, setorUsuario, emailUsuario);
                MessageBox.Show("PDF gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GNDVGAnaliseOp_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
                            MessageBox.Show("Erro");
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
                            MessageBox.Show("Erro");
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
                            MessageBox.Show("Erro");
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

        private void GNBtnSalvarExecel_Click(object sender, EventArgs e)
        {
            // Cria uma instância do SaveFileDialog para selecionar onde salvar
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Salvar como Excel";
                saveFileDialog.FileName = "Relatorio.xlsx"; // Nome padrão

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Usa o ExcelExporter dentro de um using para garantir a liberação de recursos
                    using (ExportarExcel exporter = new ExportarExcel())
                    {
                        try
                        {
                            // dataGridView1 é o nome do seu DataGridView no formulário
                            exporter.ExportToExcel(GNDVGAnaliseOp, saveFileDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Falha ao exportar: {ex.Message}", "Erro",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void GNPanelCentro_Click(object sender, EventArgs e)
        {

        }
    }
}