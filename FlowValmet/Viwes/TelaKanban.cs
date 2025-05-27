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
using FlowValmet.Model2;

namespace FlowValmet.Viwes
{
    public partial class TelaKanban : Form
    {
        public TelaKanban()
        {
            InitializeComponent();
            ConfigurePanelSettings();
        }

        private void PendenteFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ConfigurePanelSettings()
        {
            // Configurações essenciais para o layout vertical
            PendenteFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            PendenteFlowLayoutPanel.AutoScroll = true;
            PendenteFlowLayoutPanel.WrapContents = false;
            PendenteFlowLayoutPanel.AutoSize = false;

            // Margem para melhor visualização
            PendenteFlowLayoutPanel.Padding = new Padding(5);
        }

        private void TelaKanban_Load(object sender, EventArgs e)
        {
            populateItems();
        }
        private void populateItems()
        {
            PendenteFlowLayoutPanel.Controls.Clear();
            EmAndamentoflowLayoutPanel.Controls.Clear();
            EmAtrasoflowLayoutPanel.Controls.Clear();

            ProjetoDao dao = new ProjetoDao();
            List<Projeto> projetosPendente = dao.GetProjetosPendente();
            List<Projeto> projetosAndamento = dao.GetProjetosEmAndamento();
            List<Projeto> projetosAtraso = dao.GetProjetosEmAtraso();

            foreach (Projeto projeto in projetosPendente)
            {
                KanbanProjetoUserControl userControl = new KanbanProjetoUserControl();

                // Preenche dados básicos do projeto
                userControl.Prioridade = projeto.Pri;
                userControl.BU = projeto.BU;
                userControl.PCs = projeto.PCs;
                userControl.Cliente = projeto.Cliente;
                userControl.Item = projeto.Item;
                userControl.DataEntrega = (DateTime)projeto.DataPrazo;
                userControl.Custo = projeto.Custo;
                userControl.Responsavel = projeto.Res;
                userControl.Semana = projeto.Semana;



                PendenteFlowLayoutPanel.Controls.Add(userControl);
            }
            foreach (Projeto projeto in projetosAndamento)
            {
                KanbanProjetoUserControl userControl = new KanbanProjetoUserControl();

                // Preenche dados básicos do projeto
                userControl.Prioridade = projeto.Pri;
                userControl.BU = projeto.BU;
                userControl.PCs = projeto.PCs;
                userControl.Cliente = projeto.Cliente;
                userControl.Item = projeto.Item;
                userControl.DataEntrega = (DateTime)projeto.DataPrazo;
                userControl.Custo = projeto.Custo;
                userControl.Responsavel = projeto.Res;
                userControl.Semana = projeto.Semana;



                EmAndamentoflowLayoutPanel.Controls.Add(userControl);
            }
            foreach (Projeto projeto in projetosAtraso)
            {
                KanbanProjetoUserControl userControl = new KanbanProjetoUserControl();

                // Preenche dados básicos do projeto
                userControl.Prioridade = projeto.Pri;
                userControl.BU = projeto.BU;
                userControl.PCs = projeto.PCs;
                userControl.Cliente = projeto.Cliente;
                userControl.Item = projeto.Item;
                userControl.DataEntrega = (DateTime)projeto.DataPrazo;
                userControl.Custo = projeto.Custo;
                userControl.Responsavel = projeto.Res;
                userControl.Semana = projeto.Semana;



                EmAtrasoflowLayoutPanel.Controls.Add(userControl);
            }

        }

        private void EmAndamentoflowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
