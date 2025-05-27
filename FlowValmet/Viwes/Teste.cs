using FlowValmet.Controllers;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace FlowValmet.Viwes
{
    public partial class Teste : Form
    {

        public Teste()
        {
            InitializeComponent();


        }
        ConverterResx converter = new ConverterResx();
        private void Teste_Load(object sender, EventArgs e)
        {
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Name = "IconColumn";
            iconColumn.HeaderText = "";
            //Image icone = FlowValmetProperties.Properties.Resources.IconeVerde;
            guna2DataGridView1.Columns.Add(iconColumn);
            guna2DataGridView1.Rows.Add();
            guna2DataGridView1.Rows.Add();
            guna2DataGridView1.Rows.Add();

            // Carrega uma imagem (ex: de um arquivo ou recurso)
            //byte[] imageBytes = Properties.Resources.iconVerde; // Supondo que está como byte[]
            //System.Drawing.Image iconVerde;

            //using (MemoryStream ms = new MemoryStream(imageBytes))
            //{
            //    iconVerde = System.Drawing.Image.FromStream(ms);
            //}

           

            //Image icon = Image.FromFile("FlowValmet\\Imagem\\iconeLixeira.png");

            // Define a imagem para todas as células da coluna
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                row.Cells["IconColumn"].Value = ConverterResx.GetIcon("iconVerde", 16, 16);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    







