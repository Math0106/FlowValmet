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
        }

        private void TelaGestao_Load(object sender, EventArgs e)
        {
            populateItems();
        }
        private void populateItems()
        {
            // Limpa os controles existentes
            PanelProject.Controls.Clear();

            // Certifique-se de que o PanelProject esteja configurado como FlowLayoutPanel
            if (PanelProject is FlowLayoutPanel flowPanel)
            {
                flowPanel.FlowDirection = FlowDirection.TopDown; // Define para organizar os controles verticalmente
                flowPanel.AutoScroll = true; // Habilita a barra de rolagem se houver muitos itens
            }

            try
            {
                ProjetoDao dao = new ProjetoDao();
                List<Projeto> projetos = dao.GetAllProjetos(); // Método que deve retornar a lista de projetos

                foreach (Projeto projeto in projetos)
                {
                    projetoUserControl userControl = new projetoUserControl();

                    // Preenche os dados do UserControl
                    userControl.Prioridade = projeto.Pri;
                    userControl.BU = projeto.BU;
                    userControl.PCs = projeto.PCs;
                    userControl.Cliente = projeto.Cliente;
                    userControl.Item = projeto.Item;
                    userControl.DataEntrega = (DateTime)projeto.DataPrazo;
                    userControl.Custo = projeto.Custo;

                    // Adiciona ao painel
                    PanelProject.Controls.Add(userControl);

                    if (++itemCounter >= 20) break; // Limitação opcional
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar projetos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void populateItems()
        //{
        //    // Limpa os controles existentes
        //    PanelProject.Controls.Clear();

        //    try
        //    {
        //        ProjetoDao dao = new ProjetoDao();
        //        // Supondo que GetDetails retorna uma lista de projetos
        //        List<Projeto> projetos = dao.GetAllProjetos(); // Você precisa implementar este método

        //        foreach (Projeto projeto in projetos)
        //        {
        //            projetoUserControl userControl = new projetoUserControl();

        //            // Preenche os dados do UserControl
        //            userControl.Prioridade = projeto.Pri;
        //            userControl.BU = projeto.BU;
        //            userControl.PCs = projeto.PCs;
        //            userControl.Cliente = projeto.Cliente;
        //            userControl.Item = projeto.Item;
        //            // Atribuição direta da data (formato dd/MM/yyyy)
        //            userControl.DataEntrega = (DateTime)projeto.DataPrazo;

        //            // Atribuição direta do custo (formato R$)
        //            userControl.Custo = projeto.Custo;

        //            PanelProject.Controls.Add(userControl);

        //            // Limita a quantidade de itens (opcional)
        //            if (++itemCounter >= 20) break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erro ao carregar projetos: {ex.Message}", "Erro",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // Métodos de evento vazios (mantidos para estrutura)
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2Button9_Click(object sender, EventArgs e) { }
        private void PanelProject_Paint(object sender, PaintEventArgs e) { }
    }
}