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
        private string _Res;
        private int _Cliente;
        private string _Item;
        private DateTime _DataEntrega;
        private DateTime _DataReprogramada;
        private decimal _Custos;
        private int _Semana;
        private DateTimePicker dateTimePicker; //

        public void MeuControle()
        {
            dateTimePicker = new DateTimePicker();
            this.Controls.Add(dateTimePicker);
        }
        [Category("Custom Pro")]
        public int Prioridade
        {
            get { return _pri; }
            set { _pri = value; PrioridadeTxt.Text = value.ToString(); }
        }
        [Category("Custom Pro")]
        public string BU
        {
            get { return _BU; }
            set {_BU = value; BuTXT.Text =  value.ToString(); }
        }
        [Category("Custom Pro")]
        public string PCs
        {
            get { return _PCs; }
            set { _PCs = value; PCsTxt.Text = value.ToString(); ; }
        }
        [Category("Custom Pro")]
        public int Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; ClienteTxt.Text = value.ToString(); ; }
        }
        [Category("Custom Pro")]
        public string Item
        {
            get { return _Item; }
            set { _Item = value; ItemTxt.Text = value.ToString(); ; }
        }
        [Category("Custom Pro")]
        public DateTime DataEntrega
        {
            get { return _DataEntrega; }
            set
            {
                _DataEntrega = value;
                DataPrazoSelected.Value = value; // Atualiza o DateTimePicker corretamente
            }
        }

        [Category("Custom Pro")]
        public DateTime DataReprogramadaC
        {
            get { return _DataReprogramada; }
            set { 
                _DataReprogramada = value; 
                DataReproSelected.Value = value; 
            }

        }
        [Category("Custom Pro")]
        public Decimal Custo
        {
            get { return _Custos; }
            set { _Custos = value; CustoTxt.Text = value.ToString(); }
        }
        [Category("Custom Pro")]
        public int Semana
        {
            get { return _Semana; }
            set { _Semana = value; SemanaTxt.Text = value.ToString(); }
        }
        [Category("Custom Pro")]
        public String Res
        {
            get { return _Res; }
            set { _Res = value; Restxt.Text = value.ToString(); }
        }
        #endregion

        public void DetailsC(Projeto p)
        {

            Prioridade = p.Pri;
            BU = p.BU;
            PCs = p.PCs;
            Res = p.Res;
            Semana = p.Semana;
            Custo = p.Custo;
            Cliente = p.Cliente;
            Item = p.Item;
            DateTime dataPrazo = (DateTime)p.DataPrazo;
            DataEntrega = dataPrazo;
            DateTime DataReprogramada = (DateTime)p.DataReprogramada;
            DataReprogramadaC = DataReprogramada;
            Custo = p.Custo;


        }
        private void projetoUserControl_Load(object sender, EventArgs e)
        {
            
        }

      
    }
}
