using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowValmet.Controllers;

namespace FlowValmet.Viwes
{
    public partial class TesteFase : Form
    {
        public TesteFase()
        {
            InitializeComponent();
            // Configurações importantes para o flowLayoutPanel
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TesteFase_Load(object sender, EventArgs e)
        {
            CarregarProjetos();
        }

        private void CarregarProjetos()
        {
            flowLayoutPanel1.Controls.Clear(); // Limpa o painel antes de adicionar

            ProjetoDao dao = new ProjetoDao();
            var listaProjetos = dao.GetAllProjetosComFases();

            foreach (var projeto in listaProjetos)
            {
                // Cria um painel para cada projeto
                Panel painelProjeto = new Panel();

                // Ajusta a largura para caber dentro do flowLayoutPanel (com margem)
                painelProjeto.Width = flowLayoutPanel1.ClientSize.Width - 25;

                // Ajusta a altura conforme quantidade de fases
                painelProjeto.Height = 100 + (projeto.Fases.Count * 50);

                painelProjeto.BorderStyle = BorderStyle.FixedSingle;
                painelProjeto.Margin = new Padding(10);

                // Remove AutoScroll daqui para evitar barras dentro do painel individual
                // painelProjeto.AutoScroll = true; // REMOVIDO

                // Label do Projeto
                Label lblTitulo = new Label();
                lblTitulo.Text = $"Projeto: {projeto.id_projeto} - {projeto.Item}";
                lblTitulo.Font = new Font("Arial", 10, FontStyle.Bold);
                lblTitulo.AutoSize = true;
                lblTitulo.Location = new Point(10, 10);

                Label lblInfo = new Label();
                lblInfo.Text = $"Cliente: {projeto.Cliente} | BU: {projeto.BU} | PCs: {projeto.PCs}\n" +
                               $"Prazo: {projeto.DataPrazo?.ToString("dd/MM/yyyy") ?? "Sem prazo"} | " +
                               $"Custo: {projeto.Custo:C} | Status: {projeto.Status}";
                lblInfo.AutoSize = true;
                lblInfo.Location = new Point(10, 35);

                painelProjeto.Controls.Add(lblTitulo);
                painelProjeto.Controls.Add(lblInfo);

                // Adiciona as Fases do Projeto
                int yOffset = 70;
                foreach (var fase in projeto.Fases)
                {
                    Label lblFase = new Label();
                    lblFase.Text = $"Fase {fase.IdFase}: " +
                                   $"Início: {fase.DataInicial?.ToString("dd/MM/yyyy") ?? "N/A"} | " +
                                   $"Fim: {fase.DataFinal?.ToString("dd/MM/yyyy") ?? "N/A"} | " +
                                   $"Status: {fase.Status} | Obs: {fase.Observacao}";
                    lblFase.AutoSize = true;
                    lblFase.Location = new Point(10, yOffset);

                    painelProjeto.Controls.Add(lblFase);

                    yOffset += 30; // Espaço entre as fases
                }

                // Adiciona o painel no FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(painelProjeto);
            }
        }

    }
}
