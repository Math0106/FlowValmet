using FlowValmet.Controllers;
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
                //titulo.Text = "123456789012345678901234567890";
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

        private void GNbtnLembretes_Click(object sender, EventArgs e)
        {
            GerarLembretes(Lembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes"));

            var lembretes = new CadastroLembretes();
            lembretes.TopLevel = false;
            lembretes.FormBorderStyle = FormBorderStyle.None;
            lembretes.Dock = DockStyle.Fill;

            GNPanelCentro.Controls.Clear(); // Limpa o Panel antes de adicionar
            GNPanelCentro.Controls.Add(lembretes);

            lembretes.Show();
        }
    }
}
