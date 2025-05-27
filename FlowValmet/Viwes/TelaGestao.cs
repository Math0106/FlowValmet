using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using FlowValmet.Controllers;
using FlowValmet.Model2;

namespace FlowValmet.Viwes
{
    public partial class TelaGestao : Form
    {
        public static List<Projeto> listaProdutosEnter = new List<Projeto>();
        private int itemCounter = 0; // Variável para controle dos itens

        public TelaGestao()
        {
            InitializeComponent();
            ConfigurePanelSettings();
        }

        private void ConfigurePanelSettings()
        {
            // Configurações essenciais para o layout vertical
            PanelProject.FlowDirection = FlowDirection.TopDown;
            PanelProject.AutoScroll = true;
            PanelProject.WrapContents = false;
            PanelProject.AutoSize = false;

            // Margem para melhor visualização
            PanelProject.Padding = new Padding(5);
        }
        private void TelaGestao_Load(object sender, EventArgs e)
        {
            populateItems();
        }
        //private void populateItems()
        //{
        //    // Limpa os controles existentes
        //    PanelProject.Controls.Clear();

        //    // Certifique-se de que o PanelProject esteja configurado como FlowLayoutPanel
        //    if (PanelProject is FlowLayoutPanel flowPanel)
        //    {
        //        flowPanel.FlowDirection = FlowDirection.TopDown; // Define para organizar os controles verticalmente
        //        flowPanel.AutoScroll = true; // Habilita a barra de rolagem se houver muitos itens
        //    }

        //    try
        //    {
        //        ProjetoDao dao = new ProjetoDao();
        //        List<Projeto> projetos = dao.GetAllProjetos(); // Método que deve retornar a lista de projetos

        //        foreach (Projeto projeto in projetos)
        //        {
        //            projetoUserControl userControl = new projetoUserControl();

        //            // Preenche os dados do UserControl
        //            userControl.Prioridade = projeto.Pri;
        //            userControl.BU = projeto.BU;
        //            userControl.PCs = projeto.PCs;
        //            userControl.Cliente = projeto.Cliente;
        //            userControl.Item = projeto.Item;
        //            userControl.DataEntrega = (DateTime)projeto.DataPrazo;
        //            userControl.Custo = projeto.Custo;
        //            userControl.Responsavel = projeto.Res;
        //            userControl.Semana = projeto.Semana;

        //            // Adiciona ao painel
        //            PanelProject.Controls.Add(userControl);

        //            if (++itemCounter >= 20) break; // Limitação opcional
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erro ao carregar projetos: {ex.Message}", "Erro",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void populateItems()
        {
            PanelProject.Controls.Clear();

            ProjetoDao dao = new ProjetoDao();
            List<Projeto> projetos = dao.GetAllProjetos();

            foreach (Projeto projeto in projetos)
            {
                projetoUserControl userControl = new projetoUserControl();

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

                // Aqui você busca as fases relacionadas a esse projeto
                List<Fase> fasesDoProjeto = dao.GetFasesByProjeto(projeto.id_projeto); // método que retorna as fases

                // Carrega as fases no user control do projeto
                userControl.LoadFases(fasesDoProjeto);

                PanelProject.Controls.Add(userControl);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2Button9_Click(object sender, EventArgs e) { }
        private void PanelProject_Paint(object sender, PaintEventArgs e) { }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}