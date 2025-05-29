
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
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            try
            {
                ShowLoadingIndicator(true);
                opList = await Task.Run(() => consultaOP.RecuperarOpCompleta());

                await Task.Run(() =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        CarregarOPsCompleta();
                    });
                });
            }
            finally
            {
                ShowLoadingIndicator(false);
            }
        }

        private void ShowLoadingIndicator(bool show)
        {
            if (show)
            {
                var loadingPanel = new Guna2Panel()
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.FromArgb(100, 0, 0, 0),
                    Visible = true
                };

                var spinner = new Guna2WinProgressIndicator()
                {
                    Size = new Size(80, 80), // Aumentado de 60x60
                    Location = new Point(
                        (this.Width - 80) / 2,
                        (this.Height - 80) / 2),
                    ProgressColor = Color.White
                };

                loadingPanel.Controls.Add(spinner);
                this.Controls.Add(loadingPanel);
                spinner.Start();
                spinner.BringToFront();
            }
            else
            {
                var loadingPanel = this.Controls.OfType<Guna2Panel>()
                    .FirstOrDefault(p => p.BackColor == Color.FromArgb(100, 0, 0, 0));

                if (loadingPanel != null)
                {
                    this.Controls.Remove(loadingPanel);
                    loadingPanel.Dispose();
                }
            }
        }

        public void CarregarOPsCompleta()
        {
            GNPanelPrincipal.Controls.Clear();
            GNPanelPrincipal.Visible = false;

            if (opList == null || opList.Count == 0)
            {
                AdicionarMensagemNenhumRegistro();
                return;
            }

            CriarCardsNoPanelPrincipal();
            GNPanelPrincipal.Visible = true;
        }

        private void AdicionarMensagemNenhumRegistro()
        {
            var lblEmpty = new Guna2HtmlLabel()
            {
                Text = "<span style='color: #666; font-size: 16pt;'>Nenhuma OP encontrada</span>", // Aumentado de 14pt
                AutoSize = false,
                Size = new Size(GNPanelPrincipal.Width - 40, 120), // Aumentado de 100
                TextAlignment = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            GNPanelPrincipal.Controls.Add(lblEmpty);
        }

        private void CriarCardsNoPanelPrincipal()
        {
            var flowPanel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = false,
                WrapContents = true,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            GNPanelPrincipal.Controls.Add(flowPanel);

            foreach (var op in opList)
            {
                flowPanel.Controls.Add(CriarCardOP(op));
            }
        }

        private Guna2Panel CriarCardOP(Tuple<string, string, string, string, DateTime, DateTime, string> op)
        {
            var card = new Guna2Panel()
            {
                Size = new Size(435, 320), // Aumentado de 420x280
                Margin = new Padding(15),
                BorderRadius = 15,
                FillColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Header com fonte maior
            var headerPanel = new Guna2Panel()
            {
                Size = new Size(410, 50), // Aumentado de 390x40
                Location = new Point(15, 15),
                FillColor = Color.FromArgb(92, 132, 156),
                BorderRadius = 10
            };

            var lblOpNumber = new Label()
            {
                Text = $"OP #{op.Item2}",
                Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold), // Aumentado de 12
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(10, 10) // Ajuste de posição
            };
            headerPanel.Controls.Add(lblOpNumber);

            var contentPanel = new Panel()
            {
                Size = new Size(420, 240), // Aumentado de 390x200
                Location = new Point(15, 75), // Ajuste de posição
                BackColor = Color.Transparent
            };

            // Informações com fontes maiores
            AdicionarInfoCard(contentPanel, "ID:", op.Item1, 0);
            AdicionarInfoCard(contentPanel, "Descrição:", op.Item3, 35); // Aumentado espaçamento
            AdicionarInfoCard(contentPanel, "Desenho:", op.Item4, 70);
            AdicionarInfoCard(contentPanel, "Início:", op.Item5.ToShortDateString(), 105);
            AdicionarInfoCard(contentPanel, "Entrega:", op.Item6.ToShortDateString(), 140);

            // Botão com fonte maior
            var btnProcessos = new Guna2Button()
            {
                Text = "Ver Processos",
                Size = new Size(180, 40), // Aumentado de 150x30
                Location = new Point(120, 185), // Ajuste de posição
                BorderRadius = 8,
                FillColor = Color.FromArgb(92, 132, 156),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold), // Aumentado de 9
                Cursor = Cursors.Hand,
                Tag = op.Item7
            };
            btnProcessos.Click += BtnProcessos_Click;
            contentPanel.Controls.Add(btnProcessos);

            card.Controls.Add(headerPanel);
            card.Controls.Add(contentPanel);

            return card;
        }

        private void AdicionarInfoCard(Panel parent, string label, string value, int yPos)
        {
            var lblTitle = new Guna2HtmlLabel()
            {
                Text = $"<span style='color: #666; font-weight: bold; font-size: 12pt;'>{label}</span>", // Aumentado
                Location = new Point(20, yPos),
                AutoSize = true
            };

            var lblValue = new Guna2HtmlLabel()
            {
                Text = $"<span style='color: #444; font-size: 12pt;'>{value}</span>", // Aumentado
                Location = new Point(150, yPos), // Ajuste de posição
                AutoSize = true,
                MaximumSize = new Size(260, 0) // Aumentado de 250
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
                Size = new Size(500, 700), // Aumentado de 530x600
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            // Header com fonte maior
            var headerPanel = new Guna2Panel()
            {
                Dock = DockStyle.Top,
                Height = 60, // Aumentado de 50
                FillColor = Color.FromArgb(50, 120, 200),
                BorderRadius = 0,
                Padding = new Padding(10)
            };

            var lblTitle = new Label()
            {
                Text = "Processos da OP",
                Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold), // Aumentado de 14
                ForeColor = Color.White,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(50, 120, 200),
                AutoSize = true
            };
            headerPanel.Controls.Add(lblTitle);

            var flowPanel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(25, 25, 25, 25),
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
                    Font = new Font("Segoe UI Semibold", 14), // Aumentado de 12
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
                Size = new Size(400, 160), // Aumentado de 450x130
                Margin = new Padding(12, 12, 12, 30), // Aumentado de 10
                BorderRadius = 10,
                FillColor = Color.White,
                Padding = new Padding(20) // Aumentado de 15
            };

            var yPos = 15; // Aumentado de 10
            AddLabelToCard(card, "🏭 Linha:", linha, ref yPos);
            AddLabelToCard(card, "🔄 Status:", FormatStatus(status), ref yPos);
            AddLabelToCard(card, "⏱️ Início:", FormatDate(inicio), ref yPos);
            AddLabelToCard(card, "🏁 Fim:", FormatDate(fim), ref yPos);

            return card;
        }

        private string FormatStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return "❔ Status não informado";

            string trimmedStatus = status.Trim().ToLower();

            // Implementação específica para "em andamento" com destaque
            if (trimmedStatus == "andamento")
            {
                return "🔄 EM ANDAMENTO";
            }

            switch (trimmedStatus)
            {
                case "concluido":
                    return "✅ Concluído";
                case "atrasado":
                    return "❌ Atrasado";
                case "nulo":
                    return "⚠️ Nulo";
                default:
                    return $"� {status}";
            }
        }

        private string FormatDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date) || date.Trim() == "N/A")
                return "⏳ Em andamento";

            date = date.Trim();

            if (DateTime.TryParse(date, out var parsedDate))
                return parsedDate.ToString("dd/MM/yyyy");

            return date;
        }

        private void AddLabelToCard(Guna2Panel panel, string label, string value, ref int yPos)
        {
            var lblLabel = new Label()
            {
                Text = label,
                Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold), // Aumentado de 11
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(20, yPos), // Aumentado de 15
                AutoSize = true
            };

            var lblValue = new Label()
            {
                Text = value,
                Font = new Font("Segoe UI Semibold", 11), // Aumentado de 10
                ForeColor = Color.Black,
                Location = new Point(150, yPos), // Aumentado de 135
                MaximumSize = new Size(600, 60), // Aumentado de 550x30
                Size = new Size(200,5),
                AutoSize = false,
                Height = 30 // Aumentado de 20
            };

            if (label.Contains("Status:") && value.ToLower().Contains("concluído"))
            {
                lblValue.ForeColor = Color.Green; 

            }
            else if (label.Contains("Status:") && value.ToLower().Contains("andamento"))
            {
                lblValue.ForeColor = Color.FromArgb(196,195,2); 
            }
            else if (label.Contains("Status:") && value.ToLower().Contains("atrasado"))
            {
                lblValue.ForeColor = Color.Red; 
            }

            panel.Controls.Add(lblLabel);
            panel.Controls.Add(lblValue);

            yPos += 35; // Aumentado de 30
        }

    }
}
