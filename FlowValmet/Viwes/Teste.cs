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
    public partial class Teste : Form
    {
        public Teste()
        {
            InitializeComponent();
            Panel panel = new Panel();
            panel.Size = new Size(320, 190);
            panel.BackColor = Color.LightCyan;
            panel.Location = new Point(10, 10); // Definir posição

            // Criar e configurar o botão
            Button btn = new Button();
            btn.Size = new Size(100, 30); // Tamanho mais adequado
            btn.Location = new Point(10, 10); // Posição relativa ao painel
            btn.Text = "Clique Aqui";

            // Adicionar o botão ao painel
            panel.Controls.Add(btn);

            // Adicionar o painel ao formulário
            this.Controls.Add(panel);
        }


        public void CriarPanel()
        {

        }
    }
}
