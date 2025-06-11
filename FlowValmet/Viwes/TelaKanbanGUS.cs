
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowValmet.Controllers;
using FlowValmet.Models;
using Google.Protobuf.WellKnownTypes;
using Guna.UI2.WinForms;
using iTextSharp.text.pdf.qrcode;
using ServiceStack.OrmLite;

namespace FlowValmet.Viwes
{
    public partial class TelaKanbanGUS : Form
    {
        Image nulo = ConverterResx.GetIcon("iconNulo", 25, 25);
        Image andamento = ConverterResx.GetIcon("iconAndamento", 25, 25);
        Image atrasado = ConverterResx.GetIcon("iconAtraso", 25, 25);
        Image concluido = ConverterResx.GetIcon("iconConcluido", 25, 25);
        Image calendario = ConverterResx.GetIcon("calendario", 20, 20);
        Image sair = ConverterResx.GetIcon("calendario", 20, 20);

        private readonly ConsultaProcessos _consultaProcessos;
        private List<OpCompletaDto> _processos;
        private readonly System.Timers.Timer _atualizacaoAutomaticaTimer;

        // Cores para cada coluna
        private readonly Color _backlogColor = Color.FromArgb(240, 240, 240);
        private readonly Color _atrasadoColor = Color.FromArgb(255, 230, 230);
        private readonly Color _concluidoColor = Color.FromArgb(230, 255, 230);
        private readonly Color _andamentoColor = Color.FromArgb(255, 246, 204);

        // Referências aos painéis
        private Guna2Panel _panelBacklog;
        private Guna2Panel _panelAtrasado;
        private Guna2Panel _panelAndamento;
        private Guna2Panel _panelConcluido;

        public TelaKanbanGUS()
        {
            InitializeComponent();
            _consultaProcessos = new ConsultaProcessos();

            // Configura o timer para atualização automática (a cada 5 minutos)
            _atualizacaoAutomaticaTimer = new System.Timers.Timer(300000); // 300000 ms = 5 minutos
            _atualizacaoAutomaticaTimer.AutoReset = true;
            _atualizacaoAutomaticaTimer.Start();

            InitializeKanbanColumns();
            //InitializeMenuContexto();

            // Configuração adicional do Guna2
            this.FormBorderStyle = FormBorderStyle.None;
            //this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint, true);
        }

        private void InitializeKanbanColumns()
        {
            // Configuração inicial do formulário
            this.Text = "Kanban de Processos - FlowValmet";
            this.Size = new Size(2200, 1200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            //this.DoubleBuffered = true;

            _panelBacklog = CreateKanbanPanel("Sem Status", _backlogColor, 20);
            _panelAtrasado = CreateKanbanPanel("Atrasado", _atrasadoColor, 360);  // 20 + 320 + 10 de margem
            _panelAndamento = CreateKanbanPanel("Andamento", _andamentoColor, 700);  // 350 + 320 + 10
            _panelConcluido = CreateKanbanPanel("Concluído", _concluidoColor, 1040);  // 680 + 320 + 10

            // Adiciona os painéis ao formulário
            this.Controls.Add(_panelBacklog);
            this.Controls.Add(_panelAtrasado);
            this.Controls.Add(_panelAndamento);
            this.Controls.Add(_panelConcluido);

            // Configuração do AutoScroll para os painéis
            ConfigurePanelScrolling();
        }



        private Guna2Panel CreateKanbanPanel(string title, Color color, int xPosition)
        {
            var panel = new Guna2Panel
            {
                Name = "panel" + title.Replace(" ", "").Replace("ê", "e").Replace("í", "i"),
                Location = new Point(xPosition, 20),
                Size = new Size(335, 950),  // Aumentei de 270 para 320 (largura) e de 650 para 700 (altura)
                BackColor = color,
                FillColor = color,
                BorderRadius = 10,
                Padding = new Padding(10),  // Aumentei o padding de 10 para 15
                ShadowDecoration = {
            Color = Color.Gray,
            Depth = 10,
            BorderRadius = 10  // Adicionei borda arredondada na sombra
        }
            };

            var label = new Guna2HtmlLabel
            {
                Text = title,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),  // Aumentei a fonte de 14 para 16
                AutoSize = true,
                Location = new Point(90, 10),  // Aumentei a posição de 15 para 20
                ForeColor = Color.FromArgb(64, 64, 64),
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 10)  // Adicionei margem inferior
                
            };

            panel.Controls.Add(label);

            return panel;
        }

        private void ConfigurePanelScrolling()
        {
            foreach (var panel in new[] { _panelBacklog, _panelAtrasado, _panelAndamento, _panelConcluido })
            {
                panel.AutoScroll = true;
                panel.VerticalScroll.Enabled = true;
                panel.VerticalScroll.Visible = true;
                panel.HorizontalScroll.Enabled = false;
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await CarregarProcessos();
        }

        private async Task CarregarProcessos()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _processos = await _consultaProcessos.RecuperarProcessoAsync();
                PopularColunasKanban();
            }
            catch (Exception ex)
            {
                var dialog = new Guna2MessageDialog()
                {
                    Text = $"Erro ao carregar processos: {ex.Message}",
                    Caption = "Erro",
                    Buttons = MessageDialogButtons.OK,
                    Icon = MessageDialogIcon.Error,
                    Style = MessageDialogStyle.Dark
                };
                dialog.Show();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PopularColunasKanban()
        {
            SuspendLayout(); // Pausa o layout para múltiplas alterações

            try
            {
                // Limpa os controles existentes de forma mais eficiente
                ClearPanels();

                if (_processos == null || _processos.Count == 0)
                    return;

                // Ordena os processos
                _processos.Sort((x, y) => x.DataInicio.CompareTo(y.DataInicio));

                // Processa em paralelo para melhor performance
                Parallel.ForEach(_processos, op =>
                {
                    foreach (var processo in op.Processos)
                    {
                        // Invoke necessário para operações na UI thread
                        this.Invoke((MethodInvoker)delegate
                        {
                            var card = CriarCardProcesso(op, processo);
                            Guna2Panel panelDestino = ObterPanelPorStatus(processo.Status);

                            if (panelDestino != null)
                            {
                                card.Location = new Point(10, panelDestino.Controls.Count > 0 ?
                                    panelDestino.Controls[panelDestino.Controls.Count - 1].Bottom + 15 : 50);
                                panelDestino.Controls.Add(card);
                            }
                        });
                    }
                });

                // Ajusta a altura dos painéis
                AjustarAlturaPainels();
            }
            finally
            {
                ResumeLayout(true); // Retoma o layout e força redesenho
                this.Refresh(); // Força redesenho imediato
            }
        }

        private void ClearPanels()
        {
            foreach (var panel in new[] { _panelBacklog, _panelAtrasado, _panelAndamento, _panelConcluido })
            {
                // Mantém apenas o label do título
                for (int i = panel.Controls.Count - 1; i >= 1; i--)
                {
                    var control = panel.Controls[i];
                    panel.Controls.RemoveAt(i);
                    control.Dispose(); // Libera recursos
                }
            }
        }

        //private void PopularColunasKanban()
        //{
        //    // Limpa todos os cards existentes mantendo apenas os títulos
        //    foreach (var panel in new[] { _panelBacklog, _panelAtrasado, _panelAndamento, _panelConcluido })
        //    {
        //        // Mantém apenas o label do título (primeiro controle)
        //        while (panel.Controls.Count > 1)
        //        {
        //            panel.Controls.RemoveAt(1);
        //        }
        //    }

        //    // Dicionário para controlar a posição Y em cada painel
        //    var panelYPositions = new Dictionary<Guna2Panel, int>
        //    {
        //        { _panelBacklog, 50 },
        //        { _panelAtrasado, 50 },
        //        { _panelAndamento, 50 },
        //        { _panelConcluido, 50 }
        //    };

        //    // Ordena os processos por data de início
        //    _processos.Sort((x, y) => x.DataInicio.CompareTo(y.DataInicio));

        //    foreach (var op in _processos)
        //    {
        //        foreach (var processo in op.Processos)
        //        {
        //            var card = CriarCardProcesso(op, processo);
        //            Guna2Panel panelDestino = ObterPanelPorStatus(processo.Status);

        //            if (panelDestino != null && panelYPositions.ContainsKey(panelDestino))
        //            {
        //                card.Location = new Point(10, panelYPositions[panelDestino]);
        //                panelDestino.Controls.Add(card);

        //                // Atualiza a posição Y para o próximo card
        //                panelYPositions[panelDestino] += card.Height + 15;
        //            }
        //        }
        //    }

        //    // Ajusta a altura dos painéis se necessário
        //    AjustarAlturaPainels();
        //}

        private void AjustarAlturaPainels()
        {
            foreach (var panel in new[] { _panelBacklog, _panelAtrasado, _panelAndamento, _panelConcluido })
            {
                int alturaConteudo = 50; // Altura do título + margem

                foreach (Control control in panel.Controls)
                {
                    if (control is Guna2Panel card)
                    {
                        alturaConteudo += card.Height + 15;
                    }
                }

                // Mantém uma altura mínima e máxima
                panel.Height = Math.Min(950, 950);
            }
        }

        private Guna2Panel ObterPanelPorStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return _panelBacklog;

            status = status.ToLower().Trim();

            switch (status)
            {
                case "andamento": return _panelAndamento;
                case "concluido": return _panelConcluido;
                case "atrasado": return _panelAtrasado;
                case "nulo": return _panelBacklog;
                default: return _panelBacklog;
            }
        }



        private Guna2Panel CriarCardProcesso(OpCompletaDto op, ProcessoDto processo)
        {
            // Cores baseadas no status
            Color statusColor = ObterCorCardPorStatus(processo.Status);
            Color darkStatusColor = ControlPaint.Dark(statusColor, 0.2f);
            Color lightStatusColor = ControlPaint.Light(statusColor, 0.7f);
            Color textColor = Color.FromArgb(64, 64, 64);
            Color secondaryTextColor = Color.FromArgb(120, 120, 120);
            Color cardShadowColor = Color.FromArgb(30, 0, 0, 0);

            //Cria o card principal
                var card = new Guna2Panel
                {
                    Size = new Size(300, 300),
                    BackColor = Color.White,
                    FillColor = Color.White,
                    BorderRadius = 12,
                    Margin = new Padding(10),
                    Tag = new Tuple<OpCompletaDto, ProcessoDto>(op, processo),
                    Cursor = Cursors.Hand,
                    ShadowDecoration = {
                Color = cardShadowColor,
                Depth = 20,
                //ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
            },
                    BorderThickness = 4
                };

            // Configurações de fonte
            var fontRegular = new Font("Segoe UI", 9.5f);
            var fontSemiBold = new Font("Segoe UI Semibold", 10);
            var fontTitle = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            var fontStatus = new Font("Segoe UI", 10, FontStyle.Bold);
            var fontBigNumber = new Font("Segoe UI", 14, FontStyle.Bold);

            // Barra de status colorida no topo com borda arredondada
            var statusBar = new Guna2Panel
            {
                Size = new Size(card.Width, 6),
                Location = new Point(0, 0),
                FillColor = statusColor,
                //BorderRadius = new CornerRadius(12, 12, 0, 0),
                BackColor = Color.Transparent
            };

            // Cabeçalho do card
            var headerPanel = new Guna2Panel
            {
                Size = new Size(card.Width, 50),
                Location = new Point(0, statusBar.Height),
                FillColor = Color.White,
                BackColor = Color.Transparent,
                Padding = new Padding(15, 10, 15, 0)
            };

            var lblOp = new Guna2HtmlLabel
            {
                Text = $"OP {op.NumeroOp}",
                Font = fontTitle,
                Location = new Point(15, 10),
                AutoSize = true,
                ForeColor = Color.FromArgb(50, 50, 50),
                BackColor = Color.Transparent
            };

            // Ícone de OP com efeito de gradiente
            var opIcon = new Guna2CirclePictureBox
            {
                Size = new Size(32, 32),
                Location = new Point(card.Width - 50, 10),
                FillColor = lightStatusColor,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Image = Properties.Resources.iconeLixeira, // Substitua pelo seu ícone
                ShadowDecoration = {
            Enabled = true,
            Color = Color.FromArgb(50, 0, 0, 0),
            Depth = 5
        }
            };

            switch (processo.Status.ToLower())
            {
                case "andamento":
                    opIcon.Image = andamento; // Substitua pelo seu ícone
                    break;
                case "concluido":
                    opIcon.Image = concluido; // Substitua pelo seu ícone
                    break;
                case "atrasado":
                    opIcon.Image = atrasado; // Substitua pelo seu ícone

                    break;
                case "nulo":
                    opIcon.Image = nulo; // Substitua pelo seu ícone
                    break;
            }

            headerPanel.Controls.Add(lblOp);
            headerPanel.Controls.Add(opIcon);
            card.Controls.Add(statusBar);
            card.Controls.Add(headerPanel);

            // Corpo do card
            var contentPanel = new Guna2Panel
            {
                Size = new Size(card.Width - 30, 180),
                Location = new Point(15, headerPanel.Bottom),
                BackColor = Color.White,
                FillColor = Color.White,
                BorderRadius = 8
            };

            // Descrição com elipse e melhor espaçamento
            var lblDescricao = new Guna2HtmlLabel
            {
                Text = op.Descricao.Length > 40 ? op.Descricao.Substring(0, 40) + "..." : op.Descricao,
                Font = fontRegular,
                Location = new Point(0, 0),
                Size = new Size(contentPanel.Width, 50),
                ForeColor = textColor,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 0, 0, 5)
            };

            // Separador
            var separator = new Guna2Separator
            {
                Size = new Size(contentPanel.Width, 1),
                Location = new Point(0, lblDescricao.Bottom + 5),
                FillColor = Color.FromArgb(240, 240, 240)
            };

            // Linha de produção com ícone
            var linhaPanel = new Guna2Panel
            {
                Size = new Size(contentPanel.Width, 30),
                Location = new Point(0, separator.Bottom + 10),
                BackColor = Color.Transparent
            };

            var lblLinha = new Guna2HtmlLabel
            {
                Text = $"Linha: {processo.LinhaProducao}",
                Font = fontSemiBold,
                Location = new Point(0, 0),
                AutoSize = true,
                ForeColor = secondaryTextColor,
                BackColor = Color.Transparent
            };

            // Badge de status moderno
            var statusBadge = new Guna2Panel
            {
                Size = new Size(contentPanel.Width, 32),
                Location = new Point(0, linhaPanel.Bottom + 10),
                FillColor = Color.FromArgb(245, 245, 245),
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(225, 225, 225),
                Padding = new Padding(5)
            };

            var lblStatus = new Guna2HtmlLabel
            {
                Text = processo.Status.ToUpper(),
                Font = fontStatus,
                Location = new Point((statusBadge.Width - TextRenderer.MeasureText(processo.Status.ToUpper(), fontStatus).Width) / 2, 5),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Cores de status mais modernas
            switch (processo.Status.ToLower())
            {
                case "andamento":
                    lblStatus.ForeColor = Color.FromArgb(255, 212, 0);
                    statusBadge.FillColor = Color.FromArgb(255, 246, 204);
                    break;
                case "concluido":
                    lblStatus.ForeColor = Color.FromArgb(16, 124, 16);
                    statusBadge.FillColor = Color.FromArgb(223, 246, 221);
                    break;
                case "atrasado":
                    lblStatus.ForeColor = Color.FromArgb(196, 43, 28);
                    statusBadge.FillColor = Color.FromArgb(253, 231, 233);

                    break;
                case "nulo":
                    lblStatus.ForeColor = Color.FromArgb(161, 159, 157);
                    statusBadge.FillColor = Color.FromArgb(243, 242, 241);
                    break;
            }

            statusBadge.Controls.Add(lblStatus);

            // Linha do tempo vertical
            var timelinePanel = new Guna2Panel
            {
                Size = new Size(contentPanel.Width, 60),
                Location = new Point(0, statusBadge.Bottom + 15),
                BackColor = Color.Transparent
            };



            var startIcon = new Guna2CirclePictureBox
            {
                Size = new Size(20, 20),
                Location = new Point(0, 0),
                FillColor = statusColor,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Image = calendario // Ícone de calendário
            };

            var lblInicio = new Guna2HtmlLabel
            {
                Text = $"Início: {processo.Inicio:dd/MM/yyyy}",
                Font = fontRegular,
                Location = new Point(25, 0),
                AutoSize = true,
                ForeColor = secondaryTextColor,
                BackColor = Color.Transparent
            };

            var endIcon = new Guna2CirclePictureBox
            {
                Size = new Size(20, 20),
                Location = new Point(0, 30),
                FillColor = statusColor,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Image = calendario // Ícone de calendário
            };

            var lblTermino = new Guna2HtmlLabel
            {
                Text = processo.Fim.HasValue ? $"Término: {processo.Fim.Value:dd/MM/yyyy}" : "Em andamento",
                Font = fontRegular,
                Location = new Point(25, 30),
                AutoSize = true,
                ForeColor = secondaryTextColor,
                BackColor = Color.Transparent
            };

            // Botão "Ver Mais" moderno
            var btn = new Guna2Button
            {
                Text = "VER DETALHES",
                Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = statusColor,
                Location = new Point(15, contentPanel.Bottom + 10),
                BorderRadius = 8,
                Size = new Size(card.Width - 30, 36),
                Cursor = Cursors.Hand,
                Animated = true,
                Margin = new Padding(5),
                ShadowDecoration = {
            Enabled = true,
            Color = Color.FromArgb(100, statusColor),
            Depth = 8
        }
            };

            // Efeitos Hover
            btn.MouseEnter += (s, e) => btn.FillColor = ControlPaint.Dark(statusColor, 0.1f);
            btn.MouseLeave += (s, e) => btn.FillColor = statusColor;
            btn.Click += (s, e) => MostrarDetalhesProcesso(op,processo);
            // Adiciona controles aos painéis
            linhaPanel.Controls.Add(lblLinha);
            timelinePanel.Controls.Add(startIcon);
            timelinePanel.Controls.Add(lblInicio);
            timelinePanel.Controls.Add(endIcon);
            timelinePanel.Controls.Add(lblTermino);

            contentPanel.Controls.Add(lblDescricao);
            contentPanel.Controls.Add(separator);
            contentPanel.Controls.Add(linhaPanel);
            contentPanel.Controls.Add(statusBadge);
            contentPanel.Controls.Add(timelinePanel);

            card.Controls.Add(contentPanel);
            card.Controls.Add(btn);

            // Efeito hover no card inteiro
            card.MouseEnter += (s, e) => {
                card.ShadowDecoration.Depth = 30;
                card.ShadowDecoration.Color = Color.FromArgb(50, 0, 0, 0);
            };
            card.MouseLeave += (s, e) => {
                card.ShadowDecoration.Depth = 20;
                card.ShadowDecoration.Color = cardShadowColor;
            };

            return card;
        }


        private Color ObterCorCardPorStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return Color.White;

            status = status.ToLower().Trim();

            switch (status)
            {
                case "andamento": return Color.FromArgb(255, 212, 0);
                case "concluido": return Color.FromArgb(64, 145, 108);
                case "atrasado": return Color.FromArgb(210, 43, 43);
                default: return Color.DimGray;
            }
        }

        private void MostrarDetalhesProcesso(OpCompletaDto op, ProcessoDto processo)
        {
            var formDetalhes = new Form
            {
                MinimizeBox = false,  // Desabilita o botão de minimizar
                MaximizeBox = false,  // Desabilita o botão de maximizar
                ControlBox = true,     // Mantém o botão de fechar
                Text = $"Detalhes da OP: {op.NumeroOp}",
                Size = new Size(700, 750), // Slightly larger for better spacing
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(248, 249, 250), // Light gray background
                FormBorderStyle = FormBorderStyle.FixedDialog,
                
            };
            //using (var ms = new MemoryStream(Properties.Resources.sair))
            //{
            //    formDetalhes.Icon = new Icon(ms);
            //}

            // Enhanced Header Panel
            var headerPanel = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                FillColor = Color.FromArgb(59, 89, 152), // More professional blue
                BorderRadius = 0,
                Padding = new Padding(20, 15, 20, 15),
                ShadowDecoration = {
            Color = Color.FromArgb(30, 0, 0, 0),
            Depth = 10,
            //ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped
        }
            };

            var lblTitle = new Guna2HtmlLabel
            {
                Text = $"<b>OP {op.NumeroOp}</b>", // Added truncated description
                Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Left,
                BackColor = Color.Transparent,
                AutoSize = true
            };

            // Add close button to header


            headerPanel.Controls.Add(lblTitle);


            // Main content panel
            var mainPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30, 20, 30, 30),
                AutoScroll = true,
                BackColor = Color.Transparent
            };

            // Style configuration for cards
            var cardBorderColor = Color.FromArgb(225, 225, 225);
            var cardShadowColor = Color.FromArgb(20, 0, 0, 0);
            var labelFont = new Font("Segoe UI", 10);
            var valueFont = new Font("Segoe UI Semibold", 10);
            var sectionSpacing = 25;

            // Main Info Card (enhanced)
            var mainCard = CreateDetailCard("INFORMAÇÕES PRINCIPAIS", cardBorderColor, cardShadowColor);
            var mainTable = CreateDetailTable(180);

            AddStyledDetailRow(mainTable, "Número OP:", op.NumeroOp, labelFont, valueFont);
            AddStyledDetailRow(mainTable, "Descrição:", op.Descricao, labelFont, valueFont);
            AddStyledDetailRow(mainTable, "Desenho:", op.Desenho, labelFont, valueFont);
            mainCard.Controls.Add(mainTable);

            // Process Info Card (enhanced)
            var processCard = CreateDetailCard("INFORMAÇÕES DO PROCESSO", cardBorderColor, cardShadowColor);
            var processTable = CreateDetailTable(180);

            AddStyledDetailRow(processTable, "Linha de Produção:", processo.LinhaProducao, labelFont, valueFont);
            AddStyledDetailRow(processTable, "Status:", GetStatusFormatted(processo.Status), labelFont, valueFont, GetStatusColor(processo.Status));
            AddStyledDetailRow(processTable, "Início:", processo.Inicio.ToString("dd/MM/yyyy"), labelFont, valueFont);
            AddStyledDetailRow(processTable, "Término:", processo.Fim?.ToString("dd/MM/yyyy") ?? "Em andamento", labelFont, valueFont);
            processCard.Controls.Add(processTable);

            // Deadline Card (enhanced)
            var deadlineCard = CreateDetailCard("PRAZOS", cardBorderColor, cardShadowColor);
            var deadlineTable = CreateDetailTable(180);

            AddStyledDetailRow(deadlineTable, "Data Início OP:", op.DataInicio.ToString("dd/MM/yyyy"), labelFont, valueFont);
            AddStyledDetailRow(deadlineTable, "Data Entrega OP:", op.DataEntrega.ToString("dd/MM/yyyy"), labelFont, valueFont);
            AddStyledDetailRow(deadlineTable, "Dias Restantes:", GetDaysRemainingFormatted(op.DataEntrega), labelFont, valueFont, GetDaysRemainingColor(op.DataEntrega));
            deadlineCard.Controls.Add(deadlineTable);

            // Add cards to main panel with consistent spacing
            mainPanel.Controls.Add(deadlineCard);
            mainPanel.Controls.Add(new Panel { Height = sectionSpacing, Dock = DockStyle.Top });
            mainPanel.Controls.Add(processCard);
            mainPanel.Controls.Add(new Panel { Height = sectionSpacing, Dock = DockStyle.Top });
            mainPanel.Controls.Add(mainCard);

            // Add panels to form
            formDetalhes.Controls.Add(mainPanel);
            formDetalhes.Controls.Add(headerPanel);

            // Add smooth opening animation
            formDetalhes.Opacity = 0;
            formDetalhes.Shown += (s, e) =>
            {
                for (double i = 0; i <= 1; i += 0.1)
                {
                    formDetalhes.Opacity = i;
                    System.Threading.Thread.Sleep(15);
                }
            };

            formDetalhes.ShowDialog(this);
        }

        // Helper methods for creating consistent UI elements
        private Guna2Panel CreateDetailCard(string title, Color borderColor, Color shadowColor)
        {
            return new Guna2Panel
            {
                Dock = DockStyle.Top,
                BackColor = Color.White,
                BorderColor = borderColor,
                BorderThickness = 1,
                BorderRadius = 10,
                Margin = new Padding(0, 0, 0, 15),
                Padding = new Padding(25, 20, 25, 20),
                AutoSize = true,
                ShadowDecoration = {
            Color = shadowColor,
            Depth = 8,
            
        }
            };
        }

        private TableLayoutPanel CreateDetailTable(int labelWidth)
        {
            return new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Margin = new Padding(0, 0, 0, 5)
            };
        }

        private void AddStyledDetailRow(TableLayoutPanel table, string label, string value, Font labelFont, Font valueFont, Color? valueColor = null)
        {
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var lblLabel = new Guna2HtmlLabel
            {
                Text = label,
                Font = labelFont,
                ForeColor = Color.FromArgb(120, 120, 120),
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 5, 0, 5),
                AutoSize = true
            };

            var lblValue = new Guna2HtmlLabel
            {
                Text = value,
                Font = valueFont,
                ForeColor = valueColor ?? Color.FromArgb(64, 64, 64),
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 5, 0, 5),
                AutoSize = true
            };

            table.Controls.Add(lblLabel);
            table.Controls.Add(lblValue);
        }

        private Color GetStatusColor(string status)
        {
            switch (status.ToLower())
            {
                case "andamento": return Color.FromArgb(255, 212, 0);
                case "concluido": return Color.FromArgb(64, 145, 108);
                case "atrasado": return Color.FromArgb(210, 43, 43);
                default: return Color.DimGray;
            }
        }

        private Color GetDaysRemainingColor(DateTime deadline)
        {
            var days = (deadline - DateTime.Today).Days;
            if (days < 0) return Color.FromArgb(196, 43, 28); // Red for overdue
            if (days <= 3) return Color.FromArgb(216, 158, 0); // Yellow for urgent
            return Color.FromArgb(16, 124, 16); // Green for good
        }



        private string GetStatusFormatted(string status)
        {
            return status == "andamento" ? "Em Andamento" :
                   status == "concluido" ? "Concluído" :
                   status == "atrasado" ? "Atrasado" :
                   status == "nulo" ? "Nulo" :
                   status;
        }


        private string GetDaysRemainingFormatted(DateTime dataEntrega)
        {
            int dias = CalcularDiasRestantes(dataEntrega);

            if (dias > 3) return $" {dias} dias";
            if (dias > 0) return $" {dias} dias";
            if (dias == 0) return " Hoje";
            return $"{Math.Abs(dias)} dias atrás";
        }

        private int CalcularDiasRestantes(DateTime dataEntrega)
        {
            // Obtém a data atual sem a parte de horário
            DateTime dataAtual = DateTime.Today;

            // Calcula a diferença em dias
            TimeSpan diferenca = dataEntrega.Date - dataAtual;

            // Retorna o número inteiro de dias
            return diferenca.Days;
        }

        public async Task AtualizarKanban()
        {
            await CarregarProcessos();
        }

    }
}






