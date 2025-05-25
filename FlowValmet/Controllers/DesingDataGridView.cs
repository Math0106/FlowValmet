using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Controllers
{
    internal class DesingDataGridView
    {
        //public static void desingGnDataGrid(Guna.UI2.WinForms.Guna2DataGridView dataGridView)
        //{
        //    if (dataGridView == null) return;

        //    // 1. Configurações básicas de estilo
        //    dataGridView.EnableHeadersVisualStyles = false;
        //    dataGridView.BorderStyle = BorderStyle.None;
        //    dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        //    dataGridView.GridColor = Color.FromArgb(230, 230, 230);

        //    // 2. Configuração de fontes e alinhamento
        //    dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11f);
        //    dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11.5f, FontStyle.Bold);
        //    dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dataGridView.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

        //    // 3. Altura das linhas
        //    dataGridView.RowTemplate.Height = 35;
        //    dataGridView.ColumnHeadersHeight = 65;

        //    // 4. Estilo do cabeçalho
        //    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
        //    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

        //    // 5. Estilo zebrado
        //    dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        //    dataGridView.RowsDefaultCellStyle.BackColor = Color.White;

        //    // 6. Estilo de seleção
        //    dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
        //    dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
        //    dataGridView.RowHeadersVisible = false;

        //    // 7. Configurações de desempenho
        //    try
        //    {
        //        typeof(Control).GetProperty("DoubleBuffered",
        //            System.Reflection.BindingFlags.Instance |
        //            System.Reflection.BindingFlags.NonPublic)
        //            .SetValue(dataGridView, true, null);
        //    }
        //    catch { /* Ignora erro */ }

        //    // 8. Configurações gerais de layout
        //    dataGridView.ScrollBars = ScrollBars.Both;
        //    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dataGridView.AllowUserToResizeRows = false;
        //}


        public static void DesignGunaDataGrid(Guna.UI2.WinForms.Guna2DataGridView dataGridView)
        {
            if (dataGridView == null) return;

            // 1. Basic style settings
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.GridColor = Color.FromArgb(230, 230, 230);

            // 2. Font and alignment configuration
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11f);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11.5f, FontStyle.Bold);
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);

            // 3. Row height
            dataGridView.RowTemplate.Height = 35;
            dataGridView.ColumnHeadersHeight = 65;

            // 4. Header style
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // 5. Zebra striping
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;

            // 6. Selection style
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.RowHeadersVisible = false;

            // 7. Performance settings
            try
            {
                typeof(Control).GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                    .SetValue(dataGridView, true, null);
            }
            catch { /* Ignore error */ }

            // 8. Scroll and sizing configuration
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Changed from Fill
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = true;

            // 9. Enhanced scroll behavior
            dataGridView.AdvancedRowHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // 10. Smart column sizing
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            // Set minimum widths for columns (adjust values as needed)
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.MinimumWidth = 100; // Default minimum width
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Special handling for specific column types
                if (column.ValueType == typeof(DateTime))
                {
                    column.MinimumWidth = 120;
                    column.DefaultCellStyle.Format = "dd/MM/yyyy";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (column.Name.ToLower().Contains("id") || column.Name.ToLower().Contains("code"))
                {
                    column.MinimumWidth = 80;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else if (column.Name.ToLower().Contains("name") || column.Name.ToLower().Contains("description"))
                {
                    column.MinimumWidth = 150;
                    column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }

            //// 11. Improved scrollbar appearance (Guna2 specific)
            //dataGridView.ThemeStyle.ScrollBarStyle.ArrowColor = Color.White;
            //dataGridView.ThemeStyle.ScrollBarStyle.FillColor = Color.FromArgb(100, 100, 100);
            //dataGridView.ThemeStyle.ScrollBarStyle.ThumbColor = Color.FromArgb(70, 70, 70);
            //dataGridView.ThemeStyle.ScrollBarStyle.ThumbHoverColor = Color.FromArgb(90, 90, 90);
        }
    }
}
