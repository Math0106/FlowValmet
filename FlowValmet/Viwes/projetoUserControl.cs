using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowValmet.Model2;
using FlowValmet.Controllers;
using MySqlX.XDevAPI;
using Guna.UI2.WinForms;


namespace FlowValmet.Viwes
{
    public partial class projetoUserControl : UserControl
    {
        public projetoUserControl()
        {
            InitializeComponent();
        }

        #region propriedades

        private int _pri;
        private string _BU;
        private string _PCs;
      
        private int _Cliente;
        private string _Item;
        private DateTime _DataEntrega;
        private DateTime _DataReprogramada;
        private decimal _Custos;
        private int _Semana;
        private string _res;

        [Category("Custom Pro")]
        public int Prioridade
        {
            get => _pri;
            set { _pri = value; PrioridadeTxt.Text = value.ToString(); }
        }

        [Category("Custom Pro")]
        public string BU
        {
            get => _BU;
            set { _BU = value ?? string.Empty; BuTXT.Text = value; }
        }

        [Category("Custom Pro")]
        public string PCs
        {
            get => _PCs;
            set { _PCs = value ?? string.Empty; PCsTxt.Text = value; }
        }

        [Category("Custom Pro")]
        public int Cliente
        {
            get => _Cliente;
            set { _Cliente = value; ClienteTxt.Text = value.ToString(); }
        }

        [Category("Custom Pro")]
        public string Item
        {
            get => _Item;
            set { _Item = value ?? string.Empty; ItemTxt.Text = value; }
        }

        [Category("Custom Pro")]
        public DateTime DataEntrega
        {
            get => _DataEntrega;
            set { _DataEntrega = value; DataPrazoSelected.Value = value; }
        }

        [Category("Custom Pro")]
        public DateTime DataReprogramadaC
        {
            get => _DataReprogramada;
            set { _DataReprogramada = value; DataReproSelected.Value = value; }
        }

        [Category("Custom Pro")]
        public decimal Custo
        {
            get => _Custos;
            set { _Custos = value; CustoTxt.Text = "R$: " + value.ToString("N2"); }
        }

        [Category("Custom Pro")]
        public string Responsavel
        {
            get => _res;
            set { _res = value ?? string.Empty; Restxt.Text = value; }
        }

        [Category("Custom Pro")]
        public int Semana
        {
            get => _Semana;
            set { _Semana = value; SemanaTxt.Text = value.ToString(); }
        }

        #endregion

        //public void LoadProjetoDetails(Projeto projeto)
        //{
        //    if (projeto == null)
        //    {
        //        throw new ArgumentNullException(nameof(projeto), "O objeto Projeto não pode ser nulo");
        //    }

        //    try
        //    {
        //        // Atribuições básicas
        //        Prioridade = projeto.Pri;
        //        BU = projeto.BU;
        //        PCs = projeto.PCs;
        //        Responsavel = projeto.Res;  // Garantido pelo setter que trata nulos
        //        Semana = projeto.Semana;
        //        Custo =  projeto.Custo;
        //        Cliente = projeto.Cliente;
        //        Item = projeto.Item;

        //        // Atribuições de datas com verificação
        //        if (projeto.DataPrazo != null)
        //        {
        //            DataEntrega = projeto.DataPrazo.Value;
        //        }

        //        if (projeto.DataReprogramada != null)
        //        {
        //            DataReprogramadaC = projeto.DataReprogramada.Value;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erro ao carregar detalhes do projeto: {ex.Message}",
        //                      "Erro",
        //                      MessageBoxButtons.OK,
        //                      MessageBoxIcon.Error);
        //    }
        //}

        private void projetoUserControl_Load(object sender, EventArgs e)
        {
            // Inicialização adicional se necessário
        }

        private void FlowLayoutPanelFases_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LoadFases(List<Fase> fases)
        {
            FlowLayoutPanelFases.Controls.Clear();

            foreach (var fase in fases)
            {
                FaseUserControl faseControl = new FaseUserControl();

                // Configure as propriedades do controle de fase
                faseControl.NomeFase = fase.IdFase.ToString(); // Supondo que sua classe Fase tem NomeFase
                faseControl.Status = fase.Status;
                if (fase.DataFinal != null)
                    faseControl.DataFinal = fase.DataFinal.Value; // Supondo DataFinal nullable

                // Adiciona o controle ao painel de fases
                FlowLayoutPanelFases.Controls.Add(faseControl);
            }
        }
        public void LoadProjetoDetails(Projeto projeto)
        {
            if (projeto == null)
                throw new ArgumentNullException(nameof(projeto), "O objeto Projeto não pode ser nulo");

            try
            {
                
                Prioridade = projeto.Pri;
                BU = projeto.BU;
                PCs = projeto.PCs;
                Responsavel = projeto.Res;  // Garantido pelo setter que trata nulos
                Semana = projeto.Semana;
                Custo = projeto.Custo;
                Cliente = projeto.Cliente;
                Item = projeto.Item;

                // Atribuições de datas com verificação
                if (projeto.DataPrazo != null)
                {
                    DataEntrega = projeto.DataPrazo.Value;
                }

                if (projeto.DataReprogramada != null)
                {
                    DataReprogramadaC = projeto.DataReprogramada.Value;
                }
                LoadFases(projeto.Fases);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar detalhes do projeto: {ex.Message}",
                              "Erro",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }


    }


}