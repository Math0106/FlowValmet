using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FlowValmet.Controllers;
using FlowValmet.Models;
using Guna.UI2.WinForms;

public class LembreteUI
{
    // Controle principal que armazena os cards
    private Guna2Panel _panelContainer;

    // Lista atual de lembretes
    private List<Lembrete> _lembretes = new List<Lembrete>();

    ControleLembretes Lembretes = new ControleLembretes();

    public void RecarregarLembretes()
    {
        if (_panelContainer == null) return;

        try
        {
            // Obter a lista atualizada do banco de dados
            var lembretesAtualizados = ObterLembretesDoBanco();

            // Atualizar a exibição
            CarregarLembretes(lembretesAtualizados);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao recarregar lembretes: {ex.Message}", "Erro",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private List<Lembrete> ObterLembretesDoBanco()
    {
        // Implementação conforme mostrado anteriormente
        // Pode ser Entity Framework, ADO.NET, Dapper, etc.
        // Exemplo mock:
        return Lembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");
    }


    // Cores disponíveis para os cards
    private readonly Color[] _cardColors =
    {
        Color.FromArgb(74, 144, 226),
        Color.FromArgb(29, 185, 157),
        Color.FromArgb(255, 159, 67),
        Color.FromArgb(238, 119, 141)
    };

    /// <summary>
    /// Configura o container principal (compatível com Guna2Panel e Guna2ContainerControl)
    /// </summary>
    public void ConfigurarContainer(Control container)
    {
        if (container is Guna2Panel panel)
        {
            _panelContainer = panel;
        }
        else if (container is Guna2ContainerControl containerControl)
        {
            _panelContainer = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(15)
            };
            containerControl.Controls.Add(_panelContainer);
        }
        else
        {
            throw new ArgumentException("Tipo de container não suportado");
        }

        ConfigurarPainelScroll();
    }

    /// <summary>
    /// Carrega uma nova lista de lembretes e atualiza a exibição
    /// </summary>


    /// <summary>
    /// Adiciona um novo lembrete e atualiza a exibição
    /// </summary>
    public void AdicionarLembrete(Lembrete lembrete)
    {
        if (lembrete == null) return;

        _lembretes.Add(lembrete);
        RecarregarCards();
    }

    // Métodos privados de configuração e renderização
    private void ConfigurarPainelScroll()
    {
        if (_panelContainer == null) return;

        _panelContainer.SuspendLayout();
        _panelContainer.AutoScroll = true;
        _panelContainer.HorizontalScroll.Enabled = false;
        _panelContainer.VerticalScroll.Enabled = true;
        _panelContainer.AutoScrollMargin = new Size(0, 15);
        _panelContainer.ResumeLayout();
    }

    private void RecarregarCards()
    {
        if (_panelContainer == null || _panelContainer.IsDisposed) return;

        _panelContainer.SuspendLayout();
        _panelContainer.Controls.Clear();

        if (_lembretes.Count == 0)
        {
            MostrarMensagemSemLembretes();
            _panelContainer.ResumeLayout();
            return;
        }

        int posY = 10;
        int alturaCard = 250;
        int larguraCard = _panelContainer.ClientSize.Width - 35;
        int espacamento = 15;
        int marginInterna = 15;

        foreach (var lembrete in _lembretes)
        {
            var card = CriarCard(lembrete, _cardColors[_lembretes.IndexOf(lembrete) % _cardColors.Length],
                larguraCard, alturaCard, posY);

            AdicionarCabecalho(card, lembrete, larguraCard, marginInterna);
            AdicionarDivisor(card, larguraCard, marginInterna);
            AdicionarDescricao(card, lembrete, larguraCard, alturaCard, marginInterna);

            _panelContainer.Controls.Add(card);
            posY += alturaCard + espacamento;
        }

        _panelContainer.AutoScrollMinSize = new Size(0, posY + 10);
        _panelContainer.ResumeLayout(true);
    }

    private void MostrarMensagemSemLembretes()
    {
        var lblMensagem = new Guna2HtmlLabel
        {
            Text = "Nenhum lembrete encontrado",
            AutoSize = true,
            Font = new Font("Segoe UI Semibold", 11, FontStyle.Italic),
            ForeColor = Color.FromArgb(120, 120, 120),
            Location = new Point(20, 20),
            BackColor = Color.Transparent
        };
        _panelContainer.Controls.Add(lblMensagem);
    }

    public void CarregarLembretes(List<Lembrete> lembretes)
    {
        _panelContainer.VerticalScroll.Value = 0;
        _panelContainer.AutoScrollPosition = new Point(0, 0);

        _lembretes = lembretes ?? new List<Lembrete>();

        if (_panelContainer == null) return;

        _panelContainer.SuspendLayout();

        // Limpa os controles existentes
        _panelContainer.Controls.Clear();

        if (!_lembretes.Any())
        {
            MostrarMensagemSemLembretes();
        }
        else
        {
            CriarCardsLembretes();
        }



        _panelContainer.ResumeLayout(true);
    }

    private void CriarCardsLembretes()
    {
        int posY = 10;
        int alturaCard = 250;
        int larguraCard = _panelContainer.ClientSize.Width - 35;
        int espacamento = 15;
        int marginInterna = 15;

        foreach (var lembrete in _lembretes)
        {
            var card = CriarCard(lembrete, _cardColors[_lembretes.IndexOf(lembrete) % _cardColors.Length],
                larguraCard, alturaCard, posY);

            AdicionarCabecalho(card, lembrete, larguraCard, marginInterna);
            AdicionarDivisor(card, larguraCard, marginInterna);
            AdicionarDescricao(card, lembrete, larguraCard, alturaCard, marginInterna);

            _panelContainer.Controls.Add(card);
            posY += alturaCard + espacamento;
        }

        _panelContainer.AutoScrollMinSize = new Size(0, posY + 10);
    }


    private Guna2Panel CriarCard(Lembrete lembrete, Color cor, int largura, int altura, int posY)
    {
        var card = new Guna2Panel
        {
            Size = new Size(largura, altura),
            Location = new Point(15, posY),
            Tag = lembrete,
            Cursor = Cursors.Hand,
            BorderRadius = 14,
            FillColor = cor,
            BorderColor = Color.FromArgb(40, 255, 255, 255),
            BorderThickness = 1
        };

        // Efeitos de hover
        card.MouseEnter += (sender, e) => card.FillColor = ControlPaint.Light(cor, 0.15f);
        card.MouseLeave += (sender, e) => card.FillColor = cor;
        card.MouseDown += (sender, e) => card.Location = new Point(card.Location.X + 1, card.Location.Y + 1);
        card.MouseUp += (sender, e) => card.Location = new Point(card.Location.X - 1, card.Location.Y - 1);

        return card;
    }

    private void AdicionarCabecalho(Guna2Panel card, Lembrete lembrete, int larguraPanel, int marginInterna)
    {
        int headerHeight = lembrete.Vinculo ? 70 : 50;
        var headerPanel = new Guna2Panel
        {
            Size = new Size(larguraPanel, headerHeight),
            Location = new Point(0, 0),
            BackColor = Color.Transparent,
            Padding = new Padding(10, 5, 10, 5)
        };

        // Título
        var titulo = new Guna2HtmlLabel
        {
            Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold),
            Text = lembrete.Titulo,
            AutoSize = false,
            Size = new Size(larguraPanel - (2 * marginInterna) - (lembrete.Vinculo ? 160 : 30), 30),
            Location = new Point(marginInterna + 5, marginInterna),
            ForeColor = Color.White,
            BackColor = Color.Transparent
        };
        headerPanel.Controls.Add(titulo);

        // Vínculo (se aplicável)
        if (lembrete.Vinculo && !string.IsNullOrEmpty(lembrete.Op))
        {
            var lblVinculo = new Guna2Panel
            {
                Size = new Size(150, 22),
                Location = new Point(marginInterna, 45),
                FillColor = Color.FromArgb(40, 0, 0, 0),
                BorderRadius = 5,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            var lblVinculoText = new Guna2HtmlLabel
            {
                Text = lembrete.Op,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(5, 1)
            };

            lblVinculo.Controls.Add(lblVinculoText);
            headerPanel.Controls.Add(lblVinculo);
        }

        card.Controls.Add(headerPanel);
    }

    private void AdicionarDivisor(Guna2Panel card, int larguraPanel, int marginInterna)
    {
        int posY = card.Controls[0].Height + 5;
        var divisor = new Guna2Panel
        {
            Size = new Size(larguraPanel - (2 * marginInterna), 1),
            Location = new Point(marginInterna, posY),
            FillColor = Color.FromArgb(80, 255, 255, 255),
            BorderThickness = 0
        };
        card.Controls.Add(divisor);
    }

    private void AdicionarDescricao(Guna2Panel card, Lembrete lembrete, int larguraPanel, int alturaPanel, int marginInterna)
    {
        int posYDivisor = card.Controls.OfType<Guna2Panel>().FirstOrDefault(p => p.Height == 1)?.Bottom ?? 85;

        var scrollPanel = new Guna2Panel
        {
            Width = larguraPanel - (2 * marginInterna),
            Height = alturaPanel - posYDivisor - 5,
            Location = new Point(marginInterna, posYDivisor + 5),
            AutoScroll = true,
            BackColor = Color.Transparent,
            BorderThickness = 0,
            Padding = new Padding(0, 5, 0, 0)
        };

        var txtDescricao = new Guna2HtmlLabel
        {
            Text = lembrete.Descricao,
            Font = new Font("Segoe UI", 11),
            AutoSize = false,
            Width = scrollPanel.Width - SystemInformation.VerticalScrollBarWidth - 5,
            BackColor = Color.Transparent,
            ForeColor = Color.White,
            Location = new Point(0, 0),
            MaximumSize = new Size(scrollPanel.Width - SystemInformation.VerticalScrollBarWidth, 0)
        };

        // Cálculo dinâmico da altura
        using (Graphics g = scrollPanel.CreateGraphics())
        {
            SizeF size = g.MeasureString(lembrete.Descricao, txtDescricao.Font, txtDescricao.Width);
            txtDescricao.Height = (int)Math.Ceiling(size.Height) + 10;
        }

        scrollPanel.AutoScroll = txtDescricao.Height >= scrollPanel.Height;
        scrollPanel.Controls.Add(txtDescricao);
        card.Controls.Add(scrollPanel);
    }
}