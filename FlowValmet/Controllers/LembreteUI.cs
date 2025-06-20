using FlowValmet.Controllers;
using FlowValmet.Models;
using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;

public class LembreteUI
{
    // Controles
    private Guna2Panel _panelContainer;
    private readonly ControleLembretes _controleLembretes = new ControleLembretes();

    // Dados
    private List<Lembrete> _lembretes = new List<Lembrete>();

    // Constantes de layout (FIXAS)
    private const int FIXED_CARD_HEIGHT = 250;
    private const int FIXED_CARD_WIDTH_OFFSET = 40;
    private const int FIXED_CARD_MARGIN = 15;
    private const int FIXED_HEADER_HEIGHT = 50;
    private const int FIXED_HEADER_HEIGHT_WITH_LINK = 70;
    private const int FIXED_DESCRIPTION_HEIGHT = FIXED_CARD_HEIGHT - FIXED_HEADER_HEIGHT - 20;

    // Cores
    private readonly Color PRIMARY_CARD_COLOR = Color.FromArgb(114, 137, 161);
    private readonly Color HOVER_CARD_COLOR = ControlPaint.Light(Color.FromArgb(114, 137, 161), 0.15f);

    public void ConfigurarContainer(Control container)
    {
        if (container == null)
            throw new ArgumentNullException(nameof(container));

        _panelContainer = container as Guna2Panel ?? new Guna2Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(10)
        }; 

        if (!(container is Guna2Panel))
        {
            container.Controls.Add(_panelContainer);
        }

        ConfigurarEstiloPainel();
    }

    private void ConfigurarEstiloPainel()
    {
        _panelContainer.SuspendLayout();
        _panelContainer.AutoScroll = true;
        _panelContainer.HorizontalScroll.Enabled = false;
        _panelContainer.VerticalScroll.Enabled = true;
        _panelContainer.AutoScrollMargin = new Size(0, 15);
        _panelContainer.ResumeLayout(false);
    }

    public void CarregarLembretesIniciais()
    {
        if (_panelContainer == null)
        {
            MessageBox.Show("Container não configurado!", "Erro",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _panelContainer.SuspendLayout();
        try
        {
            _lembretes = _controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");
            RenderizarTodosLembretes();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar lembretes: {ex.Message}", "Erro",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _panelContainer.ResumeLayout(true);
        }
    }

    public void RecarregarLembretes()
    {
        _panelContainer.VerticalScroll.Value = 0;
        if (_panelContainer == null) return;

        // Salvar estado do scroll
        var scrollState = new ScrollState
        {
            Position = _panelContainer.VerticalScroll.Value,
            WasAtBottom = _panelContainer.VerticalScroll.Value >=
                         _panelContainer.VerticalScroll.Maximum - _panelContainer.Height
        };

        _panelContainer.SuspendLayout();
        try
        {
            var novosLembretes = _controleLembretes.RecuperarLembrete("SELECT * FROM bdflowvalmet.lembretes");

            // Sempre recriar os cards para garantir consistência
            RenderizarTodosLembretes(novosLembretes);

            // Restaurar posição do scroll
            RestaurarScrollPosition(scrollState);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao recarregar lembretes: {ex.Message}", "Erro",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _panelContainer.ResumeLayout(true);
        }
    }

    private void RenderizarTodosLembretes(List<Lembrete> lembretes = null)
    {
        _lembretes = lembretes ?? _lembretes;

        _panelContainer.Controls.Clear();

        if (!_lembretes.Any())
        {
            MostrarMensagemSemLembretes();
            return;
        }

        int posY = FIXED_CARD_MARGIN;
        int cardWidth = _panelContainer.Width - FIXED_CARD_WIDTH_OFFSET;

        // Loop simples sem ordenação
        foreach (var lembrete in _lembretes)
        {
            var card = CriarCardCompleto(cardWidth, posY, lembrete);
            _panelContainer.Controls.Add(card);
            posY += FIXED_CARD_HEIGHT + FIXED_CARD_MARGIN;

        }

        _panelContainer.AutoScrollMinSize = new Size(0, posY);
    }

    private Guna2Panel CriarCardCompleto(int width, int posY, Lembrete lembrete)
    {
        var card = new Guna2Panel
        {
            Size = new Size(width, FIXED_CARD_HEIGHT),
            Location = new Point(FIXED_CARD_MARGIN, posY),
            Tag = lembrete,
            BorderRadius = 14,
            FillColor = PRIMARY_CARD_COLOR,
            BorderColor = Color.FromArgb(40, 255, 255, 255),
            BorderThickness = 1,
            Margin = new Padding(0, 0, 0, FIXED_CARD_MARGIN),
            Cursor = Cursors.Hand
        };

        // Configurar eventos hover
        card.MouseEnter += (s, e) => card.FillColor = HOVER_CARD_COLOR;
        card.MouseLeave += (s, e) => card.FillColor = PRIMARY_CARD_COLOR;
        card.MouseDown += (s, e) => card.Location = new Point(card.Location.X + 1, card.Location.Y + 1);
        card.MouseUp += (s, e) => card.Location = new Point(card.Location.X - 1, card.Location.Y - 1);

        // Adicionar conteúdo do card
        AdicionarConteudoCard(card, lembrete);

        return card;
    }

    private void AdicionarConteudoCard(Guna2Panel card, Lembrete lembrete)
    {
        // Limpar controles existentes
        card.Controls.Clear();

        // Configurar header
        var headerHeight = lembrete.Vinculo ? FIXED_HEADER_HEIGHT_WITH_LINK : FIXED_HEADER_HEIGHT;
        var header = new Guna2Panel
        {
            Size = new Size(card.Width, headerHeight),
            BackColor = Color.Transparent,
            Padding = new Padding(10, 5, 10, 5)
        };

        // Adicionar título
        var titulo = new Guna2HtmlLabel
        {
            Text = lembrete.Titulo,
            Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold),
            ForeColor = Color.White,
            Location = new Point(10, 10),
            MaximumSize = new Size(card.Width - (lembrete.Vinculo ? 170 : 40), 30),
            AutoSize = false,
            Size = new Size(card.Width - (lembrete.Vinculo ? 170 : 40), 30)
        };
        header.Controls.Add(titulo);

        // Adicionar vínculo se necessário
        if (lembrete.Vinculo && !string.IsNullOrEmpty(lembrete.Op))
        {
            var vinculo = new Guna2Panel
            {
                Size = new Size(150, 22),
                Location = new Point(10, 40),
                FillColor = Color.FromArgb(40, 0, 0, 0),
                BorderRadius = 5
            };

            var vinculoText = new Guna2HtmlLabel
            {
                Text = lembrete.Op,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(5, 1),
                AutoSize = false,
                Size = new Size(140, 20)
            };
            vinculo.Controls.Add(vinculoText);
            header.Controls.Add(vinculo);
        }
        card.Controls.Add(header);

        // Adicionar divisor
        var divisor = new Guna2Panel
        {
            Size = new Size(card.Width - 20, 1),
            Location = new Point(10, header.Bottom + 5),
            FillColor = Color.FromArgb(80, 255, 255, 255)
        };
        card.Controls.Add(divisor);

        // Adicionar área de descrição
        var descPanel = new Guna2Panel
        {
            Size = new Size(card.Width - 20, FIXED_DESCRIPTION_HEIGHT),
            Location = new Point(10, divisor.Bottom + 5),
            AutoScroll = true,
            BackColor = Color.Transparent
        };

        var descricao = new Guna2HtmlLabel
        {
            Text = lembrete.Descricao,
            Font = new Font("Segoe UI", 11),
            ForeColor = Color.White,
            MaximumSize = new Size(descPanel.Width - SystemInformation.VerticalScrollBarWidth - 5, 0),
            AutoSize = false,
            Size = new Size(descPanel.Width - SystemInformation.VerticalScrollBarWidth - 5, FIXED_DESCRIPTION_HEIGHT - 10)
        };
        descPanel.Controls.Add(descricao);
        card.Controls.Add(descPanel);
    }

    private void MostrarMensagemSemLembretes()
    {
        var lbl = new Guna2HtmlLabel
        {
            Text = "Nenhum lembrete encontrado",
            Font = new Font("Segoe UI Semibold", 11, FontStyle.Italic),
            ForeColor = Color.FromArgb(120, 120, 120),
            Location = new Point(20, 20),
            BackColor = Color.Transparent
        };
        _panelContainer.Controls.Add(lbl);
    }

    private void RestaurarScrollPosition(ScrollState scrollState)
    {
        if (scrollState.WasAtBottom)
        {
            _panelContainer.VerticalScroll.Value = _panelContainer.VerticalScroll.Maximum;
        }
        else
        {
            _panelContainer.VerticalScroll.Value =
                Math.Min(scrollState.Position, _panelContainer.VerticalScroll.Maximum);
        }
    }

    private class ScrollState
    {
        public int Position { get; set; }
        public bool WasAtBottom { get; set; }
    }
}