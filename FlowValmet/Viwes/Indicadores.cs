using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    public partial class Indicadores : Form
    {
        public Indicadores()
        {
            InitializeComponent();

            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                    new ObservablePoint(10, 10),
                    new ObservablePoint(20, 30),
                    new ObservablePoint(30, 15)
                    },
                    PointGeometrySize = 15
                }
            };

        }


    }
}
