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

            // 8. Scroll and sizing configuration - USER CUSTOMIZABLE
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = true; // Allows column width changes
            dataGridView.AllowUserToOrderColumns = true; // Allows column reordering

            // 9. Enhanced scroll behavior
            dataGridView.AdvancedRowHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // 10. Smart column sizing with user flexibility
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Let users resize

            // Set reasonable defaults but allow user changes
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.MinimumWidth = 150; // Reasonable minimum
                column.Width = 150; // Default width
                column.FillWeight = 100; // Relative weight for Fill mode
            }

            // 11. Make the last column fill remaining space
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns[dataGridView.Columns.Count - 1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
            }
        }
   }
}
