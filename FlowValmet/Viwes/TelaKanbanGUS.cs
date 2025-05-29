//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using FlowValmet.Controllers;
//using FlowValmet.Models;
//using Guna.UI2.WinForms;

//namespace FlowValmet.Viwes
//{

//        public partial class TelaKanbanGUS: Form
//        {
//            private readonly ConsultaProcessos _consultaProcessos;
//            private List<OpCompletaDto> _processos;

//            // Cores para cada status
//            private readonly Color _backlogColor = Color.LightGray;
//            private readonly Color _atrasadoColor = Color.LightCoral;
//            private readonly Color _concluidoColor = Color.LightGreen;
//            private readonly Color _andamentoColor = Color.LightBlue;

//            public TelaKanbanGUS()
//        {
//                InitializeComponent();
//                _consultaProcessos = new ConsultaProcessos();
//                InitializeKanbanColumns();
//            }

//            private void InitializeKanbanColumns()
//            {
//                // Configuração inicial das colunas
//                this.Text = "Kanban de Processos";
//                this.Size = new Size(1000, 600);

//                // Criação dos painéis para cada coluna
//                var panelBacklog = CreateKanbanPanel("Backlog", _backlogColor, 10);
//                var panelAtrasado = CreateKanbanPanel("Atrasado", _atrasadoColor, 260);
//                var panelAndamento = CreateKanbanPanel("Andamento", _andamentoColor, 510);
//                var panelConcluido = CreateKanbanPanel("Concluído", _concluidoColor, 760);

//                this.Controls.Add(panelBacklog);
//                this.Controls.Add(panelAtrasado);
//                this.Controls.Add(panelAndamento);
//                this.Controls.Add(panelConcluido);
//            }

//            private Panel CreateKanbanPanel(string title, Color color, int xPosition)
//            {
//                var panel = new Panel
//                {
//                    Location = new Point(xPosition, 10),
//                    Size = new Size(240, 550),
//                    BackColor = color,
//                    BorderStyle = BorderStyle.FixedSingle
//                };

//                var label = new Label
//                {
//                    Text = title,
//                    Font = new Font("Arial", 12, FontStyle.Bold),
//                    AutoSize = true,
//                    Location = new Point(10, 10)
//                };

//                panel.Controls.Add(label);

//                return panel;
//            }

//            protected override async void OnLoad(EventArgs e)
//            {
//                base.OnLoad(e);
//                await CarregarProcessos();
//            }

//            private async Task CarregarProcessos()
//            {
//                try
//                {
//                    _processos = await _consultaProcessos.RecuperarProcessoAsync();
//                    PopularColunasKanban();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Erro ao carregar processos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }

//            private void PopularColunasKanban()
//            {
//                foreach (var op in _processos)
//                {
//                    foreach (var processo in op.Processos)
//                    {
//                        var card = CriarCardProcesso(op, processo);
//                        Panel panelDestino = ObterPanelPorStatus(processo.Status);
//                        panelDestino?.Controls.Add(card);
//                    }
//                }
//            }

//        private Panel ObterPanelPorStatus(string status)
//        {
//            // Se status for nulo/vazio, vai para Backlog
//            if (string.IsNullOrWhiteSpace(status))
//                return GetPanelByName("panelBacklog");

//            // Otimização: Comparação direta sem criar nova string
//            switch (status.Length)
//            {
//                case 8 when string.Equals(status, "andamento", StringComparison.OrdinalIgnoreCase):
//                    return GetPanelByName("panelAndamento");

//                case 8 when string.Equals(status, "concluido", StringComparison.OrdinalIgnoreCase):
//                    return GetPanelByName("panelConcluido");

//                case 7 when string.Equals(status, "atrasado", StringComparison.OrdinalIgnoreCase):
//                    return GetPanelByName("panelAtrasado");

//                default:
//                    return GetPanelByName("panelBacklog");
//            }
//        }

//        private Panel GetPanelByName(string panelName)
//        {
//            var panels = this.Controls.Find(panelName, true);
//            return panels.Length > 0 ? (Panel)panels[0] : null;
//        }


//        private Panel CriarCardProcesso(OpCompletaDto op, ProcessoDto processo)
//            {
//                var card = new Panel
//                {
//                    Size = new Size(220, 100),
//                    BackColor = Color.White,
//                    BorderStyle = BorderStyle.FixedSingle,
//                    Margin = new Padding(5)
//                };

//                var lblOp = new Label
//                {
//                    Text = $"OP: {op.NumeroOp}",
//                    Font = new Font("Arial", 10, FontStyle.Bold),
//                    Location = new Point(5, 5),
//                    AutoSize = true
//                };

//                var lblLinha = new Label
//                {
//                    Text = $"Linha: {processo.LinhaProducao}",
//                    Location = new Point(5, 25),
//                    AutoSize = true
//                };

//                var lblStatus = new Label
//                {
//                    Text = $"Status: {processo.Status}",
//                    Location = new Point(5, 45),
//                    AutoSize = true
//                };

//                var lblPeriodo = new Label
//                {
//                    Text = $"Início: {processo.Inicio:dd/MM/yyyy}\nTérmino: {processo.Fim?.ToString("dd/MM/yyyy") ?? "N/A"}",
//                    Location = new Point(5, 65),
//                    AutoSize = true
//                };

//                card.Controls.Add(lblOp);
//                card.Controls.Add(lblLinha);
//                card.Controls.Add(lblStatus);
//                card.Controls.Add(lblPeriodo);

//                // Adiciona evento de clique para mostrar detalhes
//                card.Click += (sender, e) => MostrarDetalhesProcesso(op, processo);

//                return card;
//            }

//            private void MostrarDetalhesProcesso(OpCompletaDto op, ProcessoDto processo)
//            {
//                var detalhes = $@"OP: {op.NumeroOp}
//Descrição: {op.Descricao}
//Desenho: {op.Desenho}
//Linha: {processo.LinhaProducao}
//Status: {processo.Status}
//Início: {processo.Inicio:dd/MM/yyyy}
//Término: {processo.Fim?.ToString("dd/MM/yyyy") ?? "N/A"}
//Data Início OP: {op.DataInicio:dd/MM/yyyy}
//Data Entrega OP: {op.DataEntrega:dd/MM/yyyy}";

//                MessageBox.Show(detalhes, "Detalhes do Processo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }
//    }


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowValmet.Controllers;
using FlowValmet.Models;

namespace FlowValmet.Viwes
{
    public partial class TelaKanbanGUS : Form
    {
        private readonly ConsultaProcessos _consultaProcessos;
        private List<OpCompletaDto> _processos;

        // Cores para cada status
        private readonly Color _backlogColor = Color.LightGray;
        private readonly Color _atrasadoColor = Color.LightCoral;
        private readonly Color _concluidoColor = Color.LightGreen;
        private readonly Color _andamentoColor = Color.LightBlue;

        // Referências diretas aos painéis
        private Panel _panelBacklog;
        private Panel _panelAtrasado;
        private Panel _panelAndamento;
        private Panel _panelConcluido;

        public TelaKanbanGUS()
        {
            InitializeComponent();
            _consultaProcessos = new ConsultaProcessos();
            InitializeKanbanColumns();
        }

        private void InitializeKanbanColumns()
        {
            // Configuração inicial do formulário
            this.Text = "Kanban de Processos";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Criação dos painéis para cada coluna
            _panelBacklog = CreateKanbanPanel("Backlog", _backlogColor, 10);
            _panelAtrasado = CreateKanbanPanel("Atrasado", _atrasadoColor, 260);
            _panelAndamento = CreateKanbanPanel("Andamento", _andamentoColor, 510);
            _panelConcluido = CreateKanbanPanel("Concluído", _concluidoColor, 760);

            // Adiciona os painéis ao formulário
            this.Controls.Add(_panelBacklog);
            this.Controls.Add(_panelAtrasado);
            this.Controls.Add(_panelAndamento);
            this.Controls.Add(_panelConcluido);

            // Configuração do AutoScroll para os painéis
            ConfigurePanelScrolling();
        }

        private void ConfigurePanelScrolling()
        {
            foreach (var panel in new[] { _panelBacklog, _panelAtrasado, _panelAndamento, _panelConcluido })
            {
                panel.AutoScroll = true;
                panel.VerticalScroll.Enabled = true;
                panel.VerticalScroll.Visible = true;
            }
        }

        private Panel CreateKanbanPanel(string title, Color color, int xPosition)
        {
            var panel = new Panel
            {
                Name = "panel" + title.Replace(" ", "").Replace("ê", "e").Replace("í", "i"),
                Location = new Point(xPosition, 10),
                Size = new Size(240, 550),
                BackColor = color,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5)
            };

            var label = new Label
            {
                Text = title,
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10),
                ForeColor = Color.Black
            };

            panel.Controls.Add(label);

            return panel;
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
                _processos = await _consultaProcessos.RecuperarProcessoAsync();
                PopularColunasKanban();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar processos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopularColunasKanban()
        {
            // Limpa todos os cards existentes
            foreach (var panel in new[] { _panelBacklog, _panelAtrasado, _panelAndamento, _panelConcluido })
            {
                panel.Controls.Clear();
                // Adiciona o título de volta
                panel.Controls.Add(new Label
                {
                    Text = panel.Name.Replace("panel", ""),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                });
            }

            // Posição vertical inicial para os cards (abaixo do título)
            int yPosition = 40;

            foreach (var op in _processos)
            {
                foreach (var processo in op.Processos)
                {
                    var card = CriarCardProcesso(op, processo);
                    Panel panelDestino = ObterPanelPorStatus(processo.Status);

                    if (panelDestino != null)
                    {
                        card.Location = new Point(10, yPosition);
                        panelDestino.Controls.Add(card);
                        yPosition += card.Height + 5; // Espaço entre os cards
                    }
                }
                yPosition = 40; // Reseta para a próxima OP
            }
        }

        private Panel ObterPanelPorStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return _panelBacklog;

            switch (status.ToLower())
            {
                case "andamento": return _panelAndamento;
                case "concluido": return _panelConcluido;
                case "atrasado": return _panelAtrasado;
                case "nulo": return _panelAtrasado;
                default: return _panelBacklog;
            }
        }

        private Panel CriarCardProcesso(OpCompletaDto op, ProcessoDto processo)
        {
            // Aumentando o tamanho do card (largura x altura)
            var card = new Panel
            {
                Size = new Size(220, 150),  // Aumentei de 100 para 150 pixels de altura
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Tag = new Tuple<OpCompletaDto, ProcessoDto>(op, processo)
            };

            // Configurando as fontes
            var fontRegular = new Font("Arial", 9);
            var fontBold = new Font("Arial", 9, FontStyle.Bold);

            // Ajustando as posições e tamanhos dos labels
            var lblOp = new Label
            {
                Text = $"OP: {op.NumeroOp}",
                Font = fontBold,
                Location = new Point(5, 5),
                AutoSize = true
            };

            var lblDescricao = new Label
            {
                Text = $"Descrição: {op.Descricao}",
                Font = fontRegular,
                Location = new Point(5, 25),
                AutoSize = false,
                Size = new Size(210, 30), // Largura fixa com altura para 2 linhas
                TextAlign = ContentAlignment.TopLeft
            };

            var lblLinha = new Label
            {
                Text = $"Linha: {processo.LinhaProducao}",
                Font = fontRegular,
                Location = new Point(5, 60),
                AutoSize = true
            };

            var lblStatus = new Label
            {
                Text = $"Status: {processo.Status}",
                Font = fontRegular,
                Location = new Point(5, 80),
                AutoSize = true
            };

            var lblInicio = new Label
            {
                Text = $"Início: {processo.Inicio:dd/MM/yyyy}",
                Font = fontRegular,
                Location = new Point(5, 100),
                AutoSize = true
            };

            var lblTermino = new Label
            {
                Text = $"Término: {processo.Fim?.ToString("dd/MM/yyyy") ?? "N/A"}",
                Font = fontRegular,
                Location = new Point(5, 120),
                AutoSize = true
            };

            // Adicionando os controles ao card
            card.Controls.Add(lblOp);
            card.Controls.Add(lblDescricao);
            card.Controls.Add(lblLinha);
            card.Controls.Add(lblStatus);
            card.Controls.Add(lblInicio);
            card.Controls.Add(lblTermino);

            // Configura o evento de clique para todos os controles dentro do card
            foreach (Control control in card.Controls)
            {
                control.Click += (sender, e) => MostrarDetalhesProcesso(op, processo);
                control.Cursor = Cursors.Hand; // Muda o cursor para mãozinha
            }
            card.Click += (sender, e) => MostrarDetalhesProcesso(op, processo);
            card.Cursor = Cursors.Hand;

            return card;
        }

        private void MostrarDetalhesProcesso(OpCompletaDto op, ProcessoDto processo)
        {
            var detalhes = $@"OP: {op.NumeroOp}
Descrição: {op.Descricao}
Desenho: {op.Desenho}
Linha: {processo.LinhaProducao}
Status: {processo.Status}
Início: {processo.Inicio:dd/MM/yyyy}
Término: {processo.Fim?.ToString("dd/MM/yyyy") ?? "N/A"}
Data Início OP: {op.DataInicio:dd/MM/yyyy}
Data Entrega OP: {op.DataEntrega:dd/MM/yyyy}";

            MessageBox.Show(detalhes, "Detalhes do Processo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Método para atualizar o Kanban
        public async Task AtualizarKanban()
        {
            await CarregarProcessos();
        }
    }
}