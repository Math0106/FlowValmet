using FlowValmet.Controllers;
using FlowValmet.Models;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Helpers;
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
        private LembreteUI _lembreteUI = new LembreteUI();


        public TelaPrincipal()
        {

            InitializeComponent();
            ConfigurarAcessos();
            TrocaIdioma(SessaoIdioma.Idioma);

        }

        public void TrocaIdioma(string idioma)
        {
            switch (idioma)
            {
                case "en":
                    {

                        GNLabel_Entrar.Text = "Login";
                        AjustarLabelAoBotao(GNLabel_Entrar, GNBtnLogin);

                        GNLabel_Lembretes.Text = "Reminders";
                        AjustarLabelAoBotao(GNLabel_Lembretes, GNbtnLembretes);

                        GNLabel_Usuario.Text = "User";
                        AjustarLabelAoBotao(GNLabel_Usuario, GNBtnUsuario);

                        GNLabel_Processo.Text = "Process";
                        AjustarLabelAoBotao(GNLabel_Processo, GNBtnProcessos);

                        GNLabel_Op.Text = "PO";
                        AjustarLabelAoBotao(GNLabel_Op, GNBtnProcessos);

                        GNLabel_Vinculo.Text = "Bond";
                        AjustarLabelAoBotao(GNLabel_Vinculo, GNBtnVincular);

                        GNLabel_PCP.Text = "PPC";
                        AjustarLabelAoBotao(GNLabel_PCP, GNBtnPCP);

                        GNLabel_Quadro.Text = "Frame";
                        AjustarLabelAoBotao(GNLabel_Quadro, GNBtnOpDet);

                        GNLabel_Kanban.Text = "Kanban";
                        AjustarLabelAoBotao(GNLabel_Kanban, GNBtnKanban);

                        GNLabel_Idioma.Text = "Language";
                        AjustarLabelAoBotao(GNLabel_Idioma, GNBtnIdioma);

                        GNLabel_PowerBI.Text = "Power BI";
                        AjustarLabelAoBotao(GNLabel_PowerBI, GNBtnIndicador);

                        GNLblIndicadorDiario.Text = "Indicators";
                        AjustarLabelAoBotao(GNLblIndicadorDiario, GNBtnIndicador);

                        break;
                    }
                case "es":
                    {
                        GNLabel_Entrar.Text = "Acceso";
                        AjustarLabelAoBotao(GNLabel_Entrar, GNBtnLogin);

                        GNLabel_Lembretes.Text = "Recordatorios";
                        AjustarLabelAoBotao(GNLabel_Lembretes, GNbtnLembretes);

                        GNLabel_Usuario.Text = "Usuario";
                        AjustarLabelAoBotao(GNLabel_Usuario, GNBtnUsuario);

                        GNLabel_Processo.Text = "Proceso";
                        AjustarLabelAoBotao(GNLabel_Processo, GNBtnProcessos);

                        GNLabel_Op.Text = "OP";
                        AjustarLabelAoBotao(GNLabel_Op, GNBtnProcessos);

                        GNLabel_Vinculo.Text = "Vínculo";
                        AjustarLabelAoBotao(GNLabel_Vinculo, GNBtnVincular);

                        GNLabel_PCP.Text = "PCP";
                        AjustarLabelAoBotao(GNLabel_PCP, GNBtnPCP);

                        GNLabel_Quadro.Text = "Marco";
                        AjustarLabelAoBotao(GNLabel_Quadro, GNBtnOpDet);

                        GNLabel_Kanban.Text = "Kanban";
                        AjustarLabelAoBotao(GNLabel_Kanban, GNBtnKanban);

                        GNLabel_Idioma.Text = "Idioma";
                        AjustarLabelAoBotao(GNLabel_Idioma, GNBtnIdioma);

                        GNLabel_PowerBI.Text = "Power BI";
                        AjustarLabelAoBotao(GNLabel_PowerBI, GNBtnIndicador);

                        GNLblIndicadorDiario.Text = "Indicadores";
                        AjustarLabelAoBotao(GNLblIndicadorDiario, GNBtnIndicador);

                        break;
                    }
                case "pt":
                    {
                        GNLabel_Entrar.Text = "Entrar";
                        AjustarLabelAoBotao(GNLabel_Entrar, GNBtnLogin);

                        GNLabel_Lembretes.Text = "Lembretes";
                        AjustarLabelAoBotao(GNLabel_Lembretes, GNbtnLembretes);

                        GNLabel_Usuario.Text = "Usuário";
                        AjustarLabelAoBotao(GNLabel_Usuario, GNBtnUsuario);

                        GNLabel_Processo.Text = "Processo";
                        AjustarLabelAoBotao(GNLabel_Processo, GNBtnProcessos);

                        GNLabel_Op.Text = "OP";
                        AjustarLabelAoBotao(GNLabel_Op, GNBtnProcessos);

                        GNLabel_Vinculo.Text = "Vínculo";
                        AjustarLabelAoBotao(GNLabel_Vinculo, GNBtnVincular);

                        GNLabel_PCP.Text = "PCP";
                        AjustarLabelAoBotao(GNLabel_PCP, GNBtnPCP);

                        GNLabel_Quadro.Text = "Quadro";
                        AjustarLabelAoBotao(GNLabel_Quadro, GNBtnOpDet);

                        GNLabel_Kanban.Text = "Kanban";
                        AjustarLabelAoBotao(GNLabel_Kanban, GNBtnKanban);

                        GNLabel_Idioma.Text = "Idioma";
                        AjustarLabelAoBotao(GNLabel_Idioma, GNBtnIdioma);

                        GNLabel_PowerBI.Text = "Power BI";
                        AjustarLabelAoBotao(GNLabel_PowerBI, GNBtnIndicador);

                        GNLblIndicadorDiario.Text = "Indicadores";
                        AjustarLabelAoBotao(GNLblIndicadorDiario, GNBtnIndicador);
                        break;
                    }
                default:
                    {
                        GNLabel_Entrar.Text = "Entrar";
                        AjustarLabelAoBotao(GNLabel_Entrar, GNBtnLogin);

                        GNLabel_Lembretes.Text = "Lembretes";
                        AjustarLabelAoBotao(GNLabel_Lembretes, GNbtnLembretes);

                        GNLabel_Usuario.Text = "Usuário";
                        AjustarLabelAoBotao(GNLabel_Usuario, GNBtnUsuario);

                        GNLabel_Processo.Text = "Processo";
                        AjustarLabelAoBotao(GNLabel_Processo, GNBtnProcessos);

                        GNLabel_Op.Text = "OP";
                        AjustarLabelAoBotao(GNLabel_Op, GNBtnProcessos);

                        GNLabel_Vinculo.Text = "Vínculo";
                        AjustarLabelAoBotao(GNLabel_Vinculo, GNBtnVincular);

                        GNLabel_PCP.Text = "PCP";
                        AjustarLabelAoBotao(GNLabel_PCP, GNBtnPCP);

                        GNLabel_Quadro.Text = "Quadro";
                        AjustarLabelAoBotao(GNLabel_Quadro, GNBtnOpDet);

                        GNLabel_Kanban.Text = "Kanban";
                        AjustarLabelAoBotao(GNLabel_Kanban, GNBtnKanban);

                        GNLabel_Idioma.Text = "Idioma";
                        AjustarLabelAoBotao(GNLabel_Idioma, GNBtnIdioma);

                        GNLabel_PowerBI.Text = "Power BI";
                        AjustarLabelAoBotao(GNLabel_PowerBI, GNBtnIndicador);

                        GNLblIndicadorDiario.Text = "Indicadores";
                        AjustarLabelAoBotao(GNLblIndicadorDiario, GNBtnIndicador);
                        break;
                    }
            }

        }

        private void AjustarLabelAoBotao(Guna.UI2.WinForms.Guna2HtmlLabel label, Guna.UI2.WinForms.Guna2CircleButton botao)
        {
            label.AutoSize = false;
            label.TextAlignment = ContentAlignment.TopCenter;
            //label.TextAlign = ContentAlignment.MiddleCenter;

            // Calcula o tamanho necessário para o texto
            Size tamanhoTexto = TextRenderer.MeasureText(label.Text, label.Font);

            // Ajusta a largura da label (máximo = largura do botão)
            int novaLargura = Math.Min(tamanhoTexto.Width + 10, botao.Width + 30);
            label.Width = novaLargura;

            // Centraliza horizontalmente
            label.Left = botao.Left + (botao.Width - label.Width) / 2;
        }

        public void CarregarIdioma()
        {
            TrocaIdioma(SessaoIdioma.Idioma);
        }


        public void TelaPrincipal_Load(object sender, EventArgs e)
        {
            _lembreteUI.ConfigurarContainer(GNPanelLembretes);

            _lembreteUI.CarregarLembretesIniciais();

        }
        public void ResetarTelaPrincpal()
        {
            GNPanelLembretes.VerticalScroll.Value = 0;
            GNPanelLembretes.AutoScrollPosition = new Point(0, 0);
            ConfigurarAcessos();
            GNPanelCentro.Visible = false;


            _lembreteUI.RecarregarLembretes();

        }
        public void ResetarTelaPrincpalLembretes()
        {
            GNPanelLembretes.VerticalScroll.Value = 0;
            GNPanelLembretes.AutoScrollPosition = new Point(0, 0);

            //_lembreteUI.ConfigurarContainer(GNPanelLembretes);

            _lembreteUI.RecarregarLembretes();

        }


        private void ConfigurarAcessos()
        {
            //// Desabilitar todos os botões inicialmente
            GNBtnOp.Enabled = false;
            GNBtnVincular.Enabled = false;
            GNBtnProcessos.Enabled = false;
            GNBtnUsuario.Enabled = false;
            GNbtnLembretes.Enabled = false;


            GNBtnKanban.Enabled = false;
            GNBtnVincular.Enabled = false;
            GNBtnOpDet.Enabled = false;

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

                        GNBtnKanban.Enabled = true;
                        GNBtnVincular.Enabled = true;
                        GNBtnOpDet.Enabled = true;
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

                        GNBtnKanban.Enabled = true;
                        GNBtnVincular.Enabled = true;
                        GNBtnOpDet.Enabled = true;
                        break;


                    default:
                        // Perfil não reconhecido - acesso mínimo
                        break;
                }
            }
        }
        private async void GNbtnLembretes_Click(object sender, EventArgs e)
        {

            try
            {
                ResetarTelaPrincpal();

                GNPanelCentro.Visible = true;
                var lembrete = new CadastroLembretes();
                lembrete.TopLevel = false;
                lembrete.FormBorderStyle = FormBorderStyle.None;
                lembrete.Dock = DockStyle.Fill;


                // Operações de UI devem estar na thread principal
                GNPanelCentro.Controls.Clear();
                GNPanelCentro.Controls.Add(lembrete);

                // Mostrar o formulário na thread principal
                await Task.Run(() =>
                {
                    GNPanelCentro.Invoke((MethodInvoker)delegate
                    {

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
                var vincular = new VincularProcessos();
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



        private async void GNBtnKanban_Click(object sender, EventArgs e)
        {
            try
            {
                GNPanelCentro.Visible = true;
                var Analise = new TelaKanbanGUS();
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

        private async void GNBtnOpDet_Click(object sender, EventArgs e)
        {
            try
            {
                GNPanelCentro.Visible = true;
                var Analise = new OpDetalhada();
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

        private async void GNBtnIndicador_Click(object sender, EventArgs e)
        {

            try
            {


                var checker = new InternetChecker();
                bool temInternet = await checker.HasInternetAccessAsync();

                if (temInternet)
                {
                    GNPanelCentro.Visible = true;
                    var Analise = new TelaIndicadores();
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
                else
                {
                    MessageBox.Show("Sem conexão com a internet");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}");
            }
        }

        public void LimparPanelCentro()
        {
            GNPanelCentro.Visible = true;
        }

        private async void GNBtnIdioma_Click(object sender, EventArgs e)
        {

            try
            {
                GNPanelCentro.Visible = true;
                var Analise = new TelaIdioma();
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

        private async void GNBtnIndicadoresDiarios_Click(object sender, EventArgs e)
        {
            try
            {
                GNPanelCentro.Visible = true;
                var Analise = new TelaIndicadoresDiarios();
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
    }
}
