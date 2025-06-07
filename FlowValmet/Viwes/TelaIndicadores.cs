using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Viwes
{
    public partial class TelaIndicadores : Form
    {
        public TelaIndicadores()
        {
            InitializeComponent();
        }

        private async void TelaIndicadores_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.Source = new Uri("https://app.powerbi.com/groups/me/reports/ea527632-ff5c-4a60-84dc-c1d5fa6291d5/1f5641e97696d1ffc059?language=pt-BR&experience=power-bi");

        }
    }
}
