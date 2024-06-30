using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using static Kursovaya.KursovayaDBDataSet;

namespace Kursovaya
{
    public partial class Show_progress : Form
    {
        public Show_progress()
        {
            InitializeComponent();
            Load_Chart();
        }

        private void Show_progress_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovayaDBDataSet.exersises". При необходимости она может быть перемещена или удалена.
            this.exersisesTableAdapter.Fill(this.kursovayaDBDataSet.exersises);

        }

        private void Load_Chart()
        {
            chart1.Series.Clear();
            Series series = new Series
            {
                Name = "Weight",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };
            chart1.Series.Add(series);

            DataTable dataTable = exersisesTableAdapter.GetData();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i][3] != DBNull.Value)
                {
                    series.Points.AddXY(i + 1, Convert.ToDouble(dataTable.Rows[i][3]));
                }
            }
            chart1.ChartAreas[0].AxisY.Minimum = 50;
            chart1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddExercise().ShowDialog();
            this.exersisesTableAdapter.Fill(this.kursovayaDBDataSet.exersises);
            Load_Chart();
        }
    }
}
