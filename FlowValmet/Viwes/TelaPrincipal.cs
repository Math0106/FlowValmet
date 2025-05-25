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
using System.Runtime.InteropServices;
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
            GNPanelCentro.Visible = false;
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
            GNPanelLembretes.AutoScroll = true; // Habilita scroll no painel principal
            GNPanelLembretes.HorizontalScroll.Visible = false;
            GNPanelLembretes.VerticalScroll.Visible = false;
            GNPanelLembretes.AutoScrollMargin = new Size(0, 0); // Remove margens do scroll

            // Verifica se a lista é nula ou vazia
            if (lista == null || lista.Count == 0)
            {
                Label lblSemLembretes = new Label();
                lblSemLembretes.Text = "Nenhum lembrete encontrado";
                lblSemLembretes.AutoSize = true;
                lblSemLembretes.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                lblSemLembretes.ForeColor = Color.Gray;
                lblSemLembretes.Location = new Point(10, 10);
                GNPanelLembretes.Controls.Add(lblSemLembretes);
                return;
            }

            int posY = 10; // Posição vertical inicial
            int alturaPanel = 250; // Altura mais compacta
            int larguraPanel = GNPanelLembretes.Width - 35;
            int espacamento = 15;
            int marginInterna = 15;
            int borderRadius = 12;

            // Paleta de cores modernas para os cards
            Color[] cardColors = {
    Color.FromArgb(144, 169, 85),   // Verde original
    Color.FromArgb(70, 130, 180),    // Azul Steel
    Color.FromArgb(220, 120, 120),  // Vermelho suave
    Color.FromArgb(255, 187, 51)     // Laranja
};

            int colorIndex = 0;

            foreach (var lembrete in lista)
            {
                Panel card = new Panel();
                card.Size = new Size(larguraPanel, alturaPanel);
                card.BackColor = cardColors[colorIndex % cardColors.Length];
                colorIndex++;

                // Efeito de sombra
                card.Paint += (sender, e) =>
                {
                    int shadowDepth = 3;
                    for (int i = 0; i < shadowDepth; i++)
                    {
                        e.Graphics.DrawRectangle(
                            new Pen(Color.FromArgb(20, 0, 0, 0)),
                            i, i, card.Width - 1 - 2 * i, card.Height - 1 - 2 * i);
                    }
                };

                card.Location = new Point(10, posY);

                // Arredondar bordas
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(card.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(card.Width - borderRadius, card.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, card.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseFigure();
                card.Region = new Region(path);

                // Título
                Label titulo = new Label();
                titulo.Font = new Font("Segoe UI", 15, FontStyle.Bold);
                titulo.Text = lembrete.Titulo; // Corrigido de 'Bitulo' para 'Titulo'
                titulo.AutoSize = false;
                titulo.Size = new Size(larguraPanel - (2 * marginInterna), 35);
                titulo.TextAlign = ContentAlignment.MiddleLeft;
                titulo.Location = new Point(marginInterna, marginInterna);
                titulo.ForeColor = Color.White;
                card.Controls.Add(titulo);

                // Linha divisória
                Panel linhaDivisoria = new Panel();
                linhaDivisoria.BackColor = Color.FromArgb(80, 255, 255, 255);
                linhaDivisoria.Size = new Size(larguraPanel - (2 * marginInterna), 1);
                linhaDivisoria.Location = new Point(marginInterna, marginInterna + titulo.Height + 10);
                card.Controls.Add(linhaDivisoria);


                // Descrição com SCROLL INVISÍVEL
                RichTextBox txtDescricao = new RichTextBox();
                txtDescricao.Text = lembrete.Descricao;
                txtDescricao.Font = new Font("Segoe UI", 12);
                txtDescricao.Location = new Point(marginInterna, marginInterna + titulo.Height + 10);
                txtDescricao.Size = new Size(
                    larguraPanel - (2 * marginInterna),
                    alturaPanel - (marginInterna + titulo.Height + 15 + marginInterna)
                );
                txtDescricao.Multiline = true;
                txtDescricao.BorderStyle = BorderStyle.None;
                txtDescricao.BackColor = card.BackColor;
                txtDescricao.ForeColor = Color.White;
                txtDescricao.ReadOnly = true;
                txtDescricao.ScrollBars = RichTextBoxScrollBars.None; // Scroll invisível

                card.Controls.Add(txtDescricao);

                // Efeito hover interativo
                Color originalColor = card.BackColor;
                card.Cursor = Cursors.Hand;
                card.MouseEnter += (sender, e) =>
                {
                    card.BackColor = ControlPaint.Light(originalColor, 0.15f);
                };
                card.MouseLeave += (sender, e) =>
                {
                    card.BackColor = originalColor;
                };

                GNPanelLembretes.Controls.Add(card);
                posY += alturaPanel + espacamento;

            }
        }

        private async void GNbtnLembretes_Click(object sender, EventArgs e)
        {

            try
            {
                GNPanelCentro.Visible = true;
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
                GNPanelCentro.Visible = true;
                var usuario = new CadastroUsuarioGUS();
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
                GNPanelCentro.Visible = true;
                var linhas = new CadastroLinhaGUS();
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
                GNPanelCentro.Visible = true;
                var op = new CadastroOPGUS();
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
                GNPanelCentro.Visible = true;
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
                GNPanelCentro.Visible = true;
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
                GNPanelCentro.Visible = true;
                var login = new LoginUsuarioGUS();
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
