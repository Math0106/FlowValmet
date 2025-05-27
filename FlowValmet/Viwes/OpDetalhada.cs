using FlowValmet.Controllers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Viwes
{
    public partial class OpDetalhada : Form
    {
        private ControleConsultaOP consultaOP = new ControleConsultaOP();
        private List<Tuple<string, string, string, string, DateTime, DateTime, string>> opList;

        public OpDetalhada()
        {
            InitializeComponent();
            
            CarregarOPsCompleta();
        }


        public void CarregarOPsCompleta()
        {
            // Limpa o panel principal
            GNPanelPrincipal.Controls.Clear();

            // Carrega os dados
            opList = consultaOP.RecuperarOpCompleta();

            if (opList == null || opList.Count == 0)
            {
                AdicionarMensagemNenhumRegistro();
                return;
            }

            CriarCardsNoPanelPrincipal();
        }

        private void AdicionarMensagemNenhumRegistro()
        {
            var lblEmpty = new Guna2HtmlLabel()
            {
                Text = "<span style='color: #666; font-size: 14pt;'>Nenhuma OP encontrada</span>",
                AutoSize = false,
                Size = new Size(GNPanelPrincipal.Width - 40, 100),
                TextAlignment = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            GNPanelPrincipal.Controls.Add(lblEmpty);
        }

        private void CriarCardsNoPanelPrincipal()
        {
            // Cria um FlowLayoutPanel dentro do panel principal
            var flowPanel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = false, // Já temos scroll no panel principal
                WrapContents = true,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            GNPanelPrincipal.Controls.Add(flowPanel);

            // Cria os cards
            foreach (var op in opList)
            {
                flowPanel.Controls.Add(CriarCardOP(op));
            }
        }

        private Guna2Panel CriarCardOP(Tuple<string, string, string, string, DateTime, DateTime, string> op)
        {
            // Card principal
            var card = new Guna2Panel()
            {
                Size = new Size(420, 280),
                Margin = new Padding(15),
                BorderRadius = 15,
                FillColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Header do card
            var headerPanel = new Guna2Panel()
            {
                Size = new Size(390, 40),
                Location = new Point(15, 15),
                FillColor = Color.FromArgb(50, 120, 200),
                BorderRadius = 10
            };

            var lblOpNumber = new Label()
            {
                Text = $"OP #{op.Item2}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(10, 5)
            };
            headerPanel.Controls.Add(lblOpNumber);

            // Corpo do card
            var contentPanel = new Panel()
            {
                Size = new Size(390, 200),
                Location = new Point(15, 65),
                BackColor = Color.Transparent
            };

            // Adiciona informações básicas
            AdicionarInfoCard(contentPanel, "ID:", op.Item1, 0);
            AdicionarInfoCard(contentPanel, "Descrição:", op.Item3, 30);
            AdicionarInfoCard(contentPanel, "Desenho:", op.Item4, 60);
            AdicionarInfoCard(contentPanel, "Início:", op.Item5.ToShortDateString(), 90);
            AdicionarInfoCard(contentPanel, "Entrega:", op.Item6.ToShortDateString(), 120);

            // Botão de processos
            var btnProcessos = new Guna2Button()
            {
                Text = "Ver Processos",
                Size = new Size(150, 30),
                Location = new Point(120, 160),
                BorderRadius = 8,
                FillColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = op.Item7 // Armazena os processos para usar no click
            };
            btnProcessos.Click += BtnProcessos_Click;
            contentPanel.Controls.Add(btnProcessos);

            // Adiciona os componentes ao card
            card.Controls.Add(headerPanel);
            card.Controls.Add(contentPanel);

            return card;
        }

        private void AdicionarInfoCard(Panel parent, string label, string value, int yPos)
        {
            var lblTitle = new Guna2HtmlLabel()
            {
                Text = $"<span style='color: #666; font-weight: bold;'>{label}</span>",
                Location = new Point(20, yPos),
                AutoSize = true
            };

            var lblValue = new Guna2HtmlLabel()
            {
                Text = $"<span style='color: #444;'>{value}</span>",
                Location = new Point(130, yPos),
                AutoSize = true,
                MaximumSize = new Size(250, 0)
            };

            parent.Controls.Add(lblTitle);
            parent.Controls.Add(lblValue);
        }

        private void BtnProcessos_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn && btn.Tag is string processos)
            {
                ShowProcessDetails(processos);
            }
        }

        private void ShowProcessDetails(string processos)
        {
            if (string.IsNullOrEmpty(processos))
            {
                MessageBox.Show("Nenhum processo encontrado para esta OP.", "Informação",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var detailForm = new Form()
            {
                Text = "Detalhes dos Processos",
                Size = new Size(530, 600),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            // Painel de cabeçalho
            var headerPanel = new Guna2Panel()
            {
                Dock = DockStyle.Top,
                Height = 50,
                FillColor = Color.FromArgb(50, 120, 200),
                BorderRadius = 0,
                Padding = new Padding(10)
            };

            var lblTitle = new Label()
            {
                Text = "Processos da OP",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(50, 120, 200),
                AutoSize = true
            };
            headerPanel.Controls.Add(lblTitle);

            // Container dos cards de processos
            var flowPanel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                BackColor = Color.Transparent
            };

            detailForm.Controls.Add(flowPanel);
            detailForm.Controls.Add(headerPanel);

            var processList = processos.Split(';');

            if (processList.Length == 0)
            {
                var lblEmpty = new Label()
                {
                    Text = "Nenhum processo encontrado",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                flowPanel.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var process in processList)
                {
                    var parts = process.Split('|');
                    if (parts.Length >= 4)
                    {
                        flowPanel.Controls.Add(CreateProcessCard(
                            linha: SanitizeInput(parts[0]),
                            status: SanitizeInput(parts[1]),
                            inicio: SanitizeInput(parts[2]),
                            fim: SanitizeInput(parts[3])
                        ));
                    }
                }
            }

            detailForm.ShowDialog();
        }

        private string SanitizeInput(string input)
        {
            return input?.Replace("\n", "").Replace("\r", "").Trim() ?? string.Empty;
        }
        private Guna2Panel CreateProcessCard(string linha, string status, string inicio, string fim)
        {
            var card = new Guna2Panel()
            {
                Size = new Size(450, 130), // Altura reduzida
                Margin = new Padding(10),
                BorderRadius = 10,
                FillColor = Color.White,
                Padding = new Padding(15)
            };

            var yPos = 10;
            AddLabelToCard(card, "🏭 Linha:", linha, ref yPos);
            AddLabelToCard(card, "🔄 Status:", FormatStatus(status), ref yPos);
            AddLabelToCard(card, "⏱️ Início:", FormatDate(inicio), ref yPos);
            AddLabelToCard(card, "🏁 Fim:", FormatDate(fim), ref yPos);

            return card;
        }
        private string FormatStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return "Status não informado";

            string trimmedStatus = status.Trim();

            if (trimmedStatus == "Ativo")
                return "✅ Ativo";
            if (trimmedStatus == "Concluido" || trimmedStatus == "Concluído")
                return "✔️ Concluído";
            if (trimmedStatus == "Cancelado")
                return "❌ Cancelado";

            return status;
        }

        private string FormatDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date) || date.Trim() == "N/A")
                return "⏳ Em andamento";

            date = date.Trim(); // Remove espaços extras

            if (DateTime.TryParse(date, out var parsedDate))
                return parsedDate.ToString("dd/MM/yyyy");

            return date;
        }

        private void AddLabelToCard(Guna2Panel panel, string label, string value, ref int yPos)
        {
            var lblLabel = new Label()
            {
                Text = label,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(15, yPos),
                AutoSize = true
            };

            var lblValue = new Label()
            {
                Text = value,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                Location = new Point(135, yPos),
                MaximumSize = new Size(550, 30),
                AutoSize = false,
                Height = 20
            };

            panel.Controls.Add(lblLabel);
            panel.Controls.Add(lblValue);

            yPos += 30; // Espaçamento fixo entre linhas
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Ajusta o padding do panel principal quando o formulário redimensiona
            if (WindowState == FormWindowState.Maximized)
            {
                GNPanelPrincipal.Padding = new Padding(40);
            }
            else
            {
                GNPanelPrincipal.Padding = new Padding(20);
            }
        }

        //public partial class OpDetalhada : Form
        //{
        //    ControleConsultaOP consultaOP = new ControleConsultaOP();
        //    public OpDetalhada()
        //    {

        //        //consultaOP.RecuperarOpCompleta();
        //        CarregarOPsCompleta();
        //        InitializeComponent();
        //    }


        //    private FlowLayoutPanel cardsContainer;
        //    private List<Tuple<string, string, string, string, DateTime, DateTime, string>> opList;

        //    public void CarregarOPsCompleta()
        //    {
        //        // Configuração inicial do formulário
        //        this.Text = "Visualização de OPs";
        //        this.ClientSize = new Size(1000, 700);
        //        this.StartPosition = FormStartPosition.CenterScreen;
        //        this.BackColor = Color.FromArgb(240, 240, 240);

        //        // Carrega os dados
        //        opList = consultaOP.RecuperarOpCompleta();

        //        // Cria o container para os cards
        //        cardsContainer = new FlowLayoutPanel
        //        {
        //            Dock = DockStyle.Fill,
        //            AutoScroll = true,
        //            WrapContents = true,
        //            Padding = new Padding(20),
        //            BackColor = Color.Transparent
        //        };
        //        this.Controls.Add(cardsContainer);

        //        // Cria os cards dinamicamente
        //        CreateCards();
        //    }

        //    private void CreateCards()
        //    {
        //        if (opList == null || opList.Count == 0)
        //        {
        //            var lblEmpty = new Label
        //            {
        //                Text = "Nenhuma OP encontrada",
        //                Font = new Font("Segoe UI", 14, FontStyle.Bold),
        //                ForeColor = Color.Gray,
        //                AutoSize = true,
        //                Dock = DockStyle.Fill,
        //                TextAlign = ContentAlignment.MiddleCenter
        //            };
        //            cardsContainer.Controls.Add(lblEmpty);
        //            return;
        //        }

        //        foreach (var op in opList)
        //        {
        //            // Cria o card principal
        //            var card = new Guna2Panel()
        //            {
        //                Size = new Size(420, 280),
        //                Margin = new Padding(15),
        //                BorderRadius = 15,
        //                FillColor = Color.White,
        //            };

        //            // Header do card
        //            var headerPanel = new Guna2Panel()
        //            {
        //                Size = new Size(380, 40),
        //                Location = new Point(20, 15),
        //                FillColor = Color.FromArgb(50, 120, 200),
        //                BorderRadius = 10
        //            };

        //            var lblOpNumber = new Label()
        //            {
        //                Text = $"OP #{op.Item2}",
        //                Font = new Font("Segoe UI", 12, FontStyle.Bold),
        //                ForeColor = Color.White,
        //                AutoSize = true,
        //                Location = new Point(10, 5)
        //            };
        //            headerPanel.Controls.Add(lblOpNumber);

        //            // Corpo do card
        //            var contentPanel = new Panel()
        //            {
        //                Size = new Size(310, 200),
        //                Location = new Point(20, 65),
        //                BackColor = Color.Transparent
        //            };

        //            // Adiciona informações básicas
        //            AddInfoLabel(contentPanel, "ID:", op.Item1, 0);
        //            AddInfoLabel(contentPanel, "Descrição:", op.Item3, 30);
        //            AddInfoLabel(contentPanel, "Desenho:", op.Item4, 60);
        //            AddInfoLabel(contentPanel, "Início:", op.Item5.ToShortDateString(), 90);
        //            AddInfoLabel(contentPanel, "Entrega:", op.Item6.ToShortDateString(), 120);

        //            // Adiciona botão para detalhes dos processos
        //            var btnProcessos = new Guna2Button()
        //            {
        //                Text = "Ver Processos",
        //                Size = new Size(150, 30),
        //                Location = new Point(110, 160),
        //                BorderRadius = 8,
        //                FillColor = Color.FromArgb(70, 130, 180),
        //                ForeColor = Color.White,
        //                Font = new Font("Segoe UI", 9, FontStyle.Bold),
        //                Cursor = Cursors.Hand
        //            };
        //            btnProcessos.Click += (sender, e) => ShowProcessDetails(op.Item7);
        //            contentPanel.Controls.Add(btnProcessos);

        //            // Adiciona os componentes ao card
        //            card.Controls.Add(headerPanel);
        //            card.Controls.Add(contentPanel);

        //            // Adiciona o card ao container
        //            cardsContainer.Controls.Add(card);
        //        }
        //    }

        //    private void AddInfoLabel(Panel parent, string label, string value, int yPos)
        //    {
        //        var lblTitle = new Label()
        //        {
        //            Text = label,
        //            Font = new Font("Segoe UI", 11, FontStyle.Bold),
        //            ForeColor = Color.Gray,
        //            Location = new Point(20, yPos),
        //            AutoSize = true
        //        };

        //        var lblValue = new Label()
        //        {
        //            Text = value,
        //            Font = new Font("Segoe UI", 10),
        //            ForeColor = Color.FromArgb(70, 70, 70),
        //            Location = new Point(130, yPos),
        //            AutoSize = true,
        //            MaximumSize = new Size(200, 0)
        //        };

        //        parent.Controls.Add(lblTitle);
        //        parent.Controls.Add(lblValue);
        //    }
        //    private void ShowProcessDetails(string processos)
        //    {
        //        if (string.IsNullOrEmpty(processos))
        //        {
        //            MessageBox.Show("Nenhum processo encontrado para esta OP.", "Informação",
        //                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        var detailForm = new Form()
        //        {
        //            Text = "Detalhes dos Processos",
        //            Size = new Size(530, 600),
        //            StartPosition = FormStartPosition.CenterParent,
        //            FormBorderStyle = FormBorderStyle.FixedDialog,
        //            MaximizeBox = false,
        //            BackColor = Color.FromArgb(240, 240, 240)
        //        };

        //        // Painel de cabeçalho
        //        var headerPanel = new Guna2Panel()
        //        {
        //            Dock = DockStyle.Top,
        //            Height = 50,
        //            FillColor = Color.FromArgb(50, 120, 200),
        //            BorderRadius = 0,
        //            Padding = new Padding(10)
        //        };

        //        var lblTitle = new Label()
        //        {
        //            Text = "Processos da OP",
        //            Font = new Font("Segoe UI", 14, FontStyle.Bold),
        //            ForeColor = Color.White,
        //            Dock = DockStyle.Left,
        //            BackColor = Color.FromArgb(50, 120, 200),
        //            AutoSize = true
        //        };
        //        headerPanel.Controls.Add(lblTitle);

        //        // Container dos cards de processos
        //        var flowPanel = new FlowLayoutPanel()
        //        {
        //            Dock = DockStyle.Fill,
        //            AutoScroll = true,
        //            Padding = new Padding(20),
        //            BackColor = Color.Transparent
        //        };

        //        detailForm.Controls.Add(flowPanel);
        //        detailForm.Controls.Add(headerPanel);

        //        var processList = processos.Split(';');

        //        if (processList.Length == 0)
        //        {
        //            var lblEmpty = new Label()
        //            {
        //                Text = "Nenhum processo encontrado",
        //                Font = new Font("Segoe UI", 12),
        //                ForeColor = Color.Gray,
        //                AutoSize = true,
        //                Dock = DockStyle.Fill,
        //                TextAlign = ContentAlignment.MiddleCenter
        //            };
        //            flowPanel.Controls.Add(lblEmpty);
        //        }
        //        else
        //        {
        //            foreach (var process in processList)
        //            {
        //                var parts = process.Split('|');
        //                if (parts.Length >= 4)
        //                {
        //                    flowPanel.Controls.Add(CreateProcessCard(
        //                        linha: SanitizeInput(parts[0]),
        //                        status: SanitizeInput(parts[1]),
        //                        inicio: SanitizeInput(parts[2]),
        //                        fim: SanitizeInput(parts[3])
        //                    ));
        //                }
        //            }
        //        }

        //        detailForm.ShowDialog();
        //    }

        //    private string SanitizeInput(string input)
        //    {
        //        return input?.Replace("\n", "").Replace("\r", "").Trim() ?? string.Empty;
        //    }
        //    private Guna2Panel CreateProcessCard(string linha, string status, string inicio, string fim)
        //    {
        //        var card = new Guna2Panel()
        //        {
        //            Size = new Size(450, 130), // Altura reduzida
        //            Margin = new Padding(10),
        //            BorderRadius = 10,
        //            FillColor = Color.White,
        //            Padding = new Padding(15)
        //        };

        //        var yPos = 10;
        //        AddLabelToCard(card, "🏭 Linha:", linha, ref yPos);
        //        AddLabelToCard(card, "🔄 Status:", FormatStatus(status), ref yPos);
        //        AddLabelToCard(card, "⏱️ Início:", FormatDate(inicio), ref yPos);
        //        AddLabelToCard(card, "🏁 Fim:", FormatDate(fim), ref yPos);

        //        return card;
        //    }

        //    private void AddLabelToCard(Guna2Panel panel, string label, string value, ref int yPos)
        //    {
        //        var lblLabel = new Label()
        //        {
        //            Text = label,
        //            Font = new Font("Segoe UI", 11, FontStyle.Bold),
        //            ForeColor = Color.FromArgb(70, 70, 70),
        //            Location = new Point(15, yPos),
        //            AutoSize = true
        //        };

        //        var lblValue = new Label()
        //        {
        //            Text = value,
        //            Font = new Font("Segoe UI", 10),
        //            ForeColor = Color.Black,
        //            Location = new Point(135, yPos),
        //            MaximumSize = new Size(550, 30),
        //            AutoSize = false,
        //            Height = 20
        //        };

        //        panel.Controls.Add(lblLabel);
        //        panel.Controls.Add(lblValue);

        //        yPos += 30; // Espaçamento fixo entre linhas
        //    }


        //    private void AddProcessInfoRow(TableLayoutPanel panel, string label, string value, int row)
        //    {
        //        var lblLabel = new Label()
        //        {
        //            Text = label,
        //            Font = new Font("Segoe UI", 9, FontStyle.Bold),
        //            ForeColor = Color.FromArgb(70, 70, 70),
        //            Dock = DockStyle.Fill,
        //            TextAlign = ContentAlignment.MiddleLeft
        //        };
        //        var lblValue = new Label()
        //        {
        //            Text = value,
        //            Font = new Font("Segoe UI", 9),
        //            ForeColor = Color.Black,
        //            Dock = DockStyle.Fill,
        //            TextAlign = ContentAlignment.MiddleLeft,
        //            MaximumSize = new Size(550, 0),
        //            AutoSize = true // Garante que não haja espaçamento extra
        //        };


        //        panel.Controls.Add(lblLabel, 0, row);
        //        panel.Controls.Add(lblValue, 1, row);
        //    }

        //    private string FormatStatus(string status)
        //    {
        //        if (string.IsNullOrWhiteSpace(status))
        //            return "Status não informado";

        //        string trimmedStatus = status.Trim();

        //        if (trimmedStatus == "Ativo")
        //            return "✅ Ativo";
        //        if (trimmedStatus == "Concluido" || trimmedStatus == "Concluído")
        //            return "✔️ Concluído";
        //        if (trimmedStatus == "Cancelado")
        //            return "❌ Cancelado";

        //        return status;
        //    }

        //    private string FormatDate(string date)
        //    {
        //        if (string.IsNullOrWhiteSpace(date) || date.Trim() == "N/A")
        //            return "⏳ Em andamento";

        //        date = date.Trim(); // Remove espaços extras

        //        if (DateTime.TryParse(date, out var parsedDate))
        //            return parsedDate.ToString("dd/MM/yyyy");

        //        return date;
        //    }

        //}
    }
}

