using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace FlowValmet.Viwes
{
    public partial class TelaKanbanGUS: Form
    {
        public TelaKanbanGUS()
        {
            InitializeComponent();
            guna2Panel1.FillColor = Color.FromArgb(150, 0, 0, 0); // 150 = opacidade, RGB = preto
            //BttnModelo.ShadowDecoration.Enabled = true;
            //BttnModelo.ShadowDecoration.Color = Color.Gray; // Cor da sombra
            //BttnModelo.ShadowDecoration.Depth = 10; // Distância da sombra (mais profundo)
            //BttnModelo.ShadowDecoration.Shadow = new Padding(10); // Direção e espessura da sombra
           


        }
    }
}
