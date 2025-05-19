using FlowValmet.Controllers;
using FlowValmet.Models;
using Org.BouncyCastle.Pkcs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace FlowValmet.Viwes
{
    public partial class TelaPrincipal : Form
    {
        ControleLembretes Lembretes = new ControleLembretes();
        public TelaPrincipal()
        {
            InitializeComponent();

            ConfigurarAcessos();
        }

        public void TelaPrincipal_Load(object sender, EventArgs e)
        {
            GerarLembretes(Lembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes"));
        }
        public void ResetarTelaPrincpal()
        {
            ConfigurarAcessos();
            GerarLembretes(Lembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes"));
        }

        private void ConfigurarAcessos()
        {
            // Desabilitar todos os botões inicialmente
            GNBtnOp.Enabled = false;
            GNBtnVincular.Enabled = false;
            GNBtnProcessos.Enabled = false;
            GNBtnUsuario.Enabled = false;
            GNbtnLembretes.Enabled = false;

            // Verificar se há usuário logado e habilitar botões conforme perfil
            if (!string.IsNullOrEmpty(SessaoUsuario.Perfil))
            {
                // Habilitar botões baseado no perfil do usuário
                switch (SessaoUsuario.Perfil.ToLower())
                {
                    case "admin":
                        // Admin tem acesso a tudo
                        GNBtnOp.Enabled = true;
                        GNBtnPCP.Enabled = true;
                        GNBtnVincular.Enabled = true;
                        GNBtnProcessos.Enabled = true;
                        GNBtnUsuario.Enabled = true;
                        GNbtnLembretes.Enabled = true;
                        GNBtnLogin.Enabled = false;
                        break;

                    case "user":
                        // Supervisor tem acesso limitado
                        GNBtnOp.Enabled = true;
                        GNBtnPCP.Enabled = true;
                        GNBtnVincular.Enabled = true;
                        GNBtnProcessos.Enabled = true;
                        GNBtnUsuario.Enabled = true;
                        GNbtnLembretes.Enabled = true;
                        GNBtnLogin.Enabled = false;
                        break;


                    default:
                        // Perfil não reconhecido - acesso mínimo
                        break;
                }
            }
        }
        public void GerarLembretes(List<Lembrete> lista)  
        {
            // Limpa os controles existentes
            GNPanelLembretes.Controls.Clear();

            // Verifica se a lista é nula ou vazia
            if (lista == null || lista.Count == 0)
            {
                Label lblSemLembretes = new Label();
                lblSemLembretes.Text = "Nenhum lembrete encontrado";
                lblSemLembretes.AutoSize = true;
                lblSemLembretes.Location = new Point(10, 10);
                GNPanelLembretes.Controls.Add(lblSemLembretes);
                return;
            }

            int posY = 10; // Posição vertical inicial
            int alturaPanel = 200;
            int larguraPanel = GNPanelLembretes.Width - 35;
            int espacamento = 10;
            int marginInterna = 10;

            foreach (var lembrete in lista)
            {
                Panel card = new Panel();
                card.Size = new Size(larguraPanel, alturaPanel);
                card.BackColor = Color.FromArgb(144, 169, 85);
                card.Location = new Point(10, posY);

                // Arredondar bordas
                int radius = 20;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(card.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(card.Width - radius, card.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, card.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                card.Region = new Region(path);

                // Título
                Label titulo = new Label();
                titulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                titulo.Text = lembrete.Titulo;
                titulo.AutoSize = false;
                titulo.Size = new Size(larguraPanel - (2 * marginInterna), 25);
                titulo.TextAlign = ContentAlignment.MiddleCenter;
                titulo.Location = new Point(marginInterna, marginInterna);
                card.Controls.Add(titulo);

                // Descrição
                Label lblDescricao = new Label();
                lblDescricao.Text = lembrete.Descricao;
                lblDescricao.Font = new Font("Segoe UI", 8);
                lblDescricao.Location = new Point(marginInterna, marginInterna + titulo.Height + 5);
                lblDescricao.Size = new Size(
                    larguraPanel - (2 * marginInterna),
                    alturaPanel - (marginInterna + titulo.Height + 5 + marginInterna)
                );
                lblDescricao.AutoEllipsis = true;
                card.Controls.Add(lblDescricao);

                GNPanelLembretes.Controls.Add(card);
                posY += alturaPanel + espacamento;
            }
        }

        //public void GerarLembretes(List<Tuple<int, string, string, bool, string>> lista)
        //{
        //    // Limpa os controles existentes (opcional)
        //    GNPanelLembretes.Controls.Clear();

        //    int posY = 10; // Posição vertical inicial
        //    int alturaPanel = 200;
        //    int larguraPanel = GNPanelLembretes.Width - 35; // Largura do container - margens
        //    int espacamento = 10;
        //    int marginInterna = 10; // Margem interna do panel

        //    foreach (var item in lista)
        //    {

        //        Panel card = new Panel();
        //        card.Size = new Size(larguraPanel, alturaPanel);
        //        card.BackColor = Color.FromArgb(144, 169, 85);
        //        card.Location = new Point(10, posY); // 10px de margem horizontal

        //        //arredondar borda do card(Panel)
        //        int radius = 20;
        //        GraphicsPath path = new GraphicsPath();
        //        path.AddArc(0, 0, radius, radius, 180, 90);
        //        path.AddArc(card.Width - radius, 0, radius, radius, 270, 90);
        //        path.AddArc(card.Width - radius, card.Height - radius, radius, radius, 0, 90);
        //        path.AddArc(0, card.Height - radius, radius, radius, 90, 90);
        //        path.CloseFigure();
        //        card.Region = new Region(path);

        //        // Adiciona algum conteúdo ao panel (opcional)
        //        Label titulo = new Label();
        //        ; // 'W' é a letra mais larga em muitas fontes
        //        titulo.Font = new Font("Segoe UI", 10);
        //        titulo.AutoSize = false;
        //        titulo.Width = 180; // Valor empírico para 25 'W' em Segoe UI 10pt
        //        titulo.Height = 25; // Altura fixa
        //        titulo.TextAlign = ContentAlignment.MiddleCenter;

        //        // Atualiza com o texto real (que pode ser menor que 25 chars)
        //        titulo.Text = item.Item2.ToString();

        //        // Centraliza
        //        titulo.Location = new Point((card.Width - titulo.Width) / 2, 15);
        //        card.Controls.Add(titulo);

        //        // Label da descrição 
        //        Label lblDescricao = new Label();
        //        lblDescricao.Text = "Descrição:\n" + item.Item3;
        //        lblDescricao.Font = new Font("Segoe UI", 8);


        //        // Posiciona considerando a margem e o título acima
        //        lblDescricao.Location = new Point(marginInterna, marginInterna + titulo.Height + 5);

        //        // Ajusta a largura para respeitar a margem direita
        //        lblDescricao.Size = new Size(
        //            larguraPanel - (2 * marginInterna),
        //            alturaPanel - (marginInterna + titulo.Height + 5 + marginInterna)
        //        );

        //        lblDescricao.AutoEllipsis = true; // Adiciona "..." se o texto for muito longo
        //        card.Controls.Add(lblDescricao);



        //        GNPanelLembretes.Controls.Add(card);

        //        // Atualiza a posição Y para o próximo panel
        //        posY += alturaPanel + espacamento;
        //    }

        //    // Ajusta a altura do container para permitir rolagem se necessário
        //    GNPanelLembretes.AutoScrollMinSize = new Size(0, posY);
        //}

        private async void GNbtnLembretes_Click(object sender, EventArgs e)
        {

            try
            {
                var lembrete = new CadastroLembretes();
                lembrete.TopLevel = false;
                lembrete.FormBorderStyle = FormBorderStyle.None;
                lembrete.Dock = DockStyle.Fill;
                GNPanelLembretes.VerticalScroll.Value = 0;

                // Operações de UI devem estar na thread principal
                GNPanelCentro.Controls.Clear();
                GNPanelCentro.Controls.Add(lembrete);

                // Mostrar o formulário na thread principal
                await Task.Run(() =>
                {
                    GNPanelCentro.Invoke((MethodInvoker)delegate
                    {
                        GerarLembretes(Lembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes"));
                        lembrete.Show();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}");
            }



        }

        private async void GNBtnUsuario_Click(object sender, EventArgs e)
        {

            try
            {
                var usuario = new CadastrarUsuario();
                usuario.TopLevel = false;
                usuario.FormBorderStyle = FormBorderStyle.None;
                usuario.Dock = DockStyle.Fill;

                // Operações de UI devem estar na thread principal
                GNPanelCentro.Controls.Clear();
                GNPanelCentro.Controls.Add(usuario);

                // Mostrar o formulário na thread principal
                await Task.Run(() =>
                {
                    GNPanelCentro.Invoke((MethodInvoker)delegate
                    {
                        usuario.Show();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}");
            }

        }

        private async void GNBtnProcessos_Click(object sender, EventArgs e)
        {

            try
            {
                var linhas = new CadastroLinhaProducao();
                linhas.TopLevel = false;
                linhas.FormBorderStyle = FormBorderStyle.None;
                linhas.Dock = DockStyle.Fill;

                // Operações de UI devem estar na thread principal
                GNPanelCentro.Controls.Clear();
                GNPanelCentro.Controls.Add(linhas);

                // Mostrar o formulário na thread principal
                await Task.Run(() =>
                {
                    GNPanelCentro.Invoke((MethodInvoker)delegate
                    {
                        linhas.Show();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}");
            }
        }

        private async void GNBtnOp_Click(object sender, EventArgs e)
        {
            try
            {
                var op = new CadastroOP();
                op.TopLevel = false;
                op.FormBorderStyle = FormBorderStyle.None;
                op.Dock = DockStyle.Fill;

                // Operações de UI devem estar na thread principal
                GNPanelCentro.Controls.Clear();
                GNPanelCentro.Controls.Add(op);

                // Mostrar o formulário na thread principal
                await Task.Run(() =>
                {
                    GNPanelCentro.Invoke((MethodInvoker)delegate
                    {
                        op.Show();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}");
            }

        }

        private async void GNBtnVincular_Click(object sender, EventArgs e)
        {
            try
            {
                var vincular= new VincularProcessos();
                vincular.TopLevel = false;
                vincular.FormBorderStyle = FormBorderStyle.None;
                vincular.Dock = DockStyle.Fill;

                // Operações de UI devem estar na thread principal
                GNPanelCentro.Controls.Clear();
                GNPanelCentro.Controls.Add(vincular);

                // Mostrar o formulário na thread principal
                await Task.Run(() =>
                {
                    GNPanelCentro.Invoke((MethodInvoker)delegate
                    {
                        vincular.Show();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}");
            }
        }

        private async void GNBtnPCP_Click(object sender, EventArgs e)
        {
            try
            {
                var Analise = new AnaliseOps();
                Analise.TopLevel = false;
                Analise.FormBorderStyle = FormBorderStyle.None;
                Analise.Dock = DockStyle.Fill;

                // Operações de UI devem estar na thread principal
                GNPanelCentro.Controls.Clear();
                GNPanelCentro.Controls.Add(Analise);

                // Mostrar o formulário na thread principal
                await Task.Run(() =>
                {
                    GNPanelCentro.Invoke((MethodInvoker)delegate
                    {
                        Analise.Show();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}");
            }
        }

        private async void GNBtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var login = new Login();
                login.TopLevel = false;
                login.FormBorderStyle = FormBorderStyle.None;
                login.Dock = DockStyle.Fill;

                // Operações de UI devem estar na thread principal
                GNPanelCentro.Controls.Clear();
                GNPanelCentro.Controls.Add(login);

                // Mostrar o formulário na thread principal
                await Task.Run(() =>
                {
                    GNPanelCentro.Invoke((MethodInvoker)delegate
                    {
                        login.Show();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}");
            }
        }
    }
}
