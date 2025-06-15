using FlowValmet.Controllers;
using FlowValmet.Idioma;
using Guna.UI2.WinForms;
using Org.BouncyCastle.Pkcs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
            Lembretes = new ControleLembretes();
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.ItemHeight = 40; // Altura suficiente para suas imagens
            comboBox1.DrawItem += ComboBox1_DrawItem;

            // Adiciona os itens (o texto não será exibido, mas pode ser útil para identificação)
            comboBox1.Items.Add("pt-BR"); // Português
            comboBox1.Items.Add("es-ES"); // Espanhol
            comboBox1.Items.Add("en-US"); // Inglês

        }
      


        public void TelaPrincipal_Load(object sender, EventArgs e)
        {
            GerarLembretes(Lembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes"));
        }

        public void GerarLembretes(List<Tuple<int, string, string, bool, string>> lista)
        {
            // Limpa os controles existentes (opcional)
            GNPanelLembretes.Controls.Clear();

            int posY = 10; // Posição vertical inicial
            int alturaPanel = 200;
            int larguraPanel = GNPanelLembretes.Width - 35; // Largura do container - margens
            int espacamento = 10;
            int marginInterna = 10; // Margem interna do panel

            foreach (var item in lista)
            {

                Panel card = new Panel();
                card.Size = new Size(larguraPanel, alturaPanel);
                card.BackColor = Color.FromArgb(144, 169, 85);
                card.Location = new Point(10, posY); // 10px de margem horizontal

                //arredondar borda do card(Panel)
                int radius = 20;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(card.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(card.Width - radius, card.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, card.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                card.Region = new Region(path);

                // Adiciona algum conteúdo ao panel (opcional)
                Label titulo = new Label();
                ; // 'W' é a letra mais larga em muitas fontes
                titulo.Font = new Font("Segoe UI", 10);
                titulo.AutoSize = false;
                titulo.Width = 180; // Valor empírico para 25 'W' em Segoe UI 10pt
                titulo.Height = 25; // Altura fixa
                titulo.TextAlign = ContentAlignment.MiddleCenter;

                // Atualiza com o texto real (que pode ser menor que 25 chars)
                titulo.Text = item.Item2.ToString();

                // Centraliza
                titulo.Location = new Point((card.Width - titulo.Width) / 2, 15);
                card.Controls.Add(titulo);

                // Label da descrição 
                Label lblDescricao = new Label();
                lblDescricao.Text = "Descrição:\n" + item.Item3;
                lblDescricao.Font = new Font("Segoe UI", 8);


                // Posiciona considerando a margem e o título acima
                lblDescricao.Location = new Point(marginInterna, marginInterna + titulo.Height + 5);

                // Ajusta a largura para respeitar a margem direita
                lblDescricao.Size = new Size(
                    larguraPanel - (2 * marginInterna),
                    alturaPanel - (marginInterna + titulo.Height + 5 + marginInterna)
                );

                lblDescricao.AutoEllipsis = true; // Adiciona "..." se o texto for muito longo
                card.Controls.Add(lblDescricao);



                GNPanelLembretes.Controls.Add(card);

                // Atualiza a posição Y para o próximo panel
                posY += alturaPanel + espacamento;
            }

            // Ajusta a altura do container para permitir rolagem se necessário
            GNPanelLembretes.AutoScrollMinSize = new Size(0, posY);
        }

        private async void GNbtnLembretes_Click(object sender, EventArgs e)
        {

            try
            {
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

        

        private void GNPanelBtnsEsquerdo_Click(object sender, EventArgs e)
        {

        }

        //Selecionador de idioma com imagem
        public void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            // Pega o código do item (por exemplo "pt-BR")
            string codigo = comboBox1.Items[e.Index].ToString();
            Image imagem = null;

            // Escolhe a imagem com base no código
            switch (codigo)
            {
                case "pt-BR":
                    imagem = Properties.Resources.pt_BR;
                    UpdateComponents("");
                    break;
                case "es-ES":
                    imagem = Properties.Resources.es_ES;
                    UpdateComponents("es-ES");
                    break;
                case "en-US":
                    imagem = Properties.Resources.en_US;
                    UpdateComponents("en-US");
                    break;
            }

           

            // Desenha a imagem
            if (imagem != null)
            {
                Rectangle imageBounds = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, 36, 36);
                e.Graphics.DrawImage(imagem, imageBounds);
            }

            e.DrawFocusRectangle(); // desenha o contorno de foco se necessário

        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = comboBox1.SelectedItem.ToString(); // Pega o texto, não o índice

            switch (codigo)
            {
                case "pt-BR":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
                    break;
                case "es-ES":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
                    break;
                case "en-US":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    break;
            }
            GNPanelCentro.Controls.Clear();

        }

        public void UpdateComponents(string laguage)
        {
            Language.Culture = new CultureInfo(laguage);
            GNBtnVincular.Text = Language.VINCULAR;
            GNBtnProcessos.Text = Language.PROCESSOS;
            GNBtnUsuario.Text = Language.USUARIO;
            guna2CircleButton1.Text = Language.LEMBRETES;


        }

        //Botão de Cadastro de Lembretes
        private async void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var Analise = new CadastroLembretes();
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

        private void GNPanelCentro_Click(object sender, EventArgs e)
        {

        }
    }
}
