using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FlowValmet.Viwes
{
    public partial class FaseUserControl : UserControl
    {
        public FaseUserControl()
        {
            InitializeComponent();
            ConfigureAppearance();
        }

        #region Custom Properties
        private string _nomeFase;
        private string _status;
        private DateTime _dataFinal;

        [Category("Custom Props")]
        public string NomeFase
        {
            get => _nomeFase;
            set
            {
                _nomeFase = value;
                Fasetxt.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                UpdateStatusColor();
            }
        }

        [Category("Custom Props")]
        public DateTime DataFinal
        {
            get => _dataFinal;
            set
            {
                _dataFinal = value;
                UpdateStatusColor();
            }
        }
        #endregion

        #region Appearance Configuration
        private void ConfigureAppearance()
        {
            // Configuração básica do controle
            this.Size = new Size(150, 30);
            this.BackColor = Color.LightGray;
            this.BorderStyle = BorderStyle.FixedSingle;

            // Configuração da label
            Fasetxt.Dock = DockStyle.Fill;
            Fasetxt.TextAlign = ContentAlignment.MiddleCenter;
            Fasetxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }
        #endregion

        private void UpdateStatusColor()
        {
            var statusColor = GetStatusColor();
            this.BackColor = statusColor;
            Fasetxt.ForeColor = statusColor.GetBrightness() > 0.5 ? Color.Black : Color.White;
        }

        private Color GetStatusColor()
        {
            // Verifica primeiro se está atrasado
            if (DateTime.Now > DataFinal && Status != "Concluído")
            {
                return Color.DarkRed;
            }

            switch (_status)
            {
                case "Concluído":
                    return Color.LimeGreen;
                case "Em andamento":
                    return Color.Gold;
                case "Pendente":
                    return Color.OrangeRed;
                default:
                    return Color.LightGray;
            }
        }

        private void FaseUserControl_Load(object sender, EventArgs e)
        {

        }

        // Remove todos os controles desnecessários do designer, deixando apenas lblFase
    }
}