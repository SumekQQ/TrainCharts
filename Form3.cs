using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace TrainChart
{
    public partial class Form3 : Form
    {
        string train;
        List<string> valX;
        List<int> valY;

        public Form3(string selectedTrain)
        {
            train = selectedTrain;
            Text = train;
            InitializeComponent();
            LoadValues();

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    PointGeometrySize = 0.1,
                    Values = valY.AsChartValues(),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(28, 142, 196)),
                },
            };


            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Siła [N]",
                MinValue = 0,
                MaxValue = GetMaxValue()
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Prędkość [V]",
                LabelFormatter = val => GetAxisVal(val),
                Separator = new Separator { Step = 1 }
            });

            cartesianChart1.LegendLocation = LegendLocation.None;
        }

        private void LoadValues()
        {
            using (var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Data/{train}/values.csv"))
            {
                valX = new List<string>();
                valY = new List<int>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    valX.Add(values[0]);
                    valY.Add(int.Parse(values[1]));
                }
            }
        }

        private int GetMaxValue()
        {
            if (train == "EN57")
            {
                return 135;
            }

            return 100;
        }

        private string GetAxisVal(double val)
        {
            var intVal = int.Parse(val.ToString());

            if (intVal % 10 == 0)
            {
                return intVal.ToString();
            }

            return string.Empty;
        }
    }
}
