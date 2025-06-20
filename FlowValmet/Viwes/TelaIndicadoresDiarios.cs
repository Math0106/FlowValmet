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
    public partial class TelaIndicadoresDiarios : Form
    {
        public TelaIndicadoresDiarios()
        {
            InitializeComponent();
            
        }

        
        //private async void webViewDiarios_Click(object sender, EventArgs e)
        //{
        //    // Inicializa o componente WebView2 de forma assíncrona
        //    await webViewDiarios.EnsureCoreWebView2Async(null);

        //    // Configura o fator de zoom para 60% do tamanho original
        //    webViewDiarios.ZoomFactor = 0.7;

        //    webViewDiarios.Source = new Uri("file:///D:/SSD1TB_Downloads/Indicadoresdiarios.html");
        //}

        private async void TelaIndicadoresDiarios_Load(object sender, EventArgs e)
        {
            try
            {
                // Inicializa o componente WebView2 de forma assíncrona
                await webViewDiarios.EnsureCoreWebView2Async(null);

                // Configura o fator de zoom para 60% do tamanho original
                webViewDiarios.ZoomFactor = 0.7;

                webViewDiarios.Source = new Uri("file:///D:/SSD1TB_Downloads/Indicadoresdiarios.html");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erro: " + ex);
            }


        }
    }
}
