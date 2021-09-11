using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using TrainChart.Model;
using System.Globalization;

namespace TrainChart
{
    public partial class Form1 : Form
    {
        List<string> valX;
        List<double> valY;
        List<double> speedLimits;
        List<Station> stations;
        bool direct;
        TrainType trainType;

        public Form1(bool dir, TrainType type)
        {
            direct = dir;
            trainType = type;

            InitializeComponent();
            LoadValues();
            LoadStation();

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = speedLimits.Select(x => 130).AsGearedValues().WithQuality(Quality.High),
                    Fill = System.Windows.Media.Brushes.Orange,
                    StrokeThickness = 0,
                },
                new LineSeries
                {
                    Values = speedLimits.AsGearedValues().WithQuality(Quality.High),
                    Fill = System.Windows.Media.Brushes.White,
                    StrokeThickness = 0,
                },
                new LineSeries
                {
                    Title = "Series 1",
                    Values = valY.AsGearedValues().WithQuality(Quality.Low),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(28, 142, 196)),
                }
            };


            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Prędkość [V]",
                MinValue = 0,
                MaxValue = 130
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = val => GetStationName(val),
                Separator = new Separator { Step = 50 }
            });

            cartesianChart1.LegendLocation = LegendLocation.None;

            cartesianChart1.DataClick += cartesianChart1_DataClick;
        }

        private void cartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        void LoadValues()
        {
            using (var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Data/{(direct ? 1.ToString() : 0.ToString())}speed{trainType}.csv"))
            {
                valX = new List<string>();
                valY = new List<double>();
                speedLimits = new List<double>();
                var info = CultureInfo.GetCultureInfo("en-EN");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    valX.Add(values[0]);
                    valY.Add(double.Parse(values[1].ToString(), info));
                    speedLimits.Add(double.Parse(values[2].ToString(), info));
                }
            }
        }

        void LoadStation()
        {
            using (var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Data/station.csv"))
            {
                stations = new List<Station>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var meters = direct ? int.Parse(values[1]) : int.Parse(values[0]);

                    stations.Add(new Station(meters, values[2]));
                }

                stations = stations.OrderBy(x => x.Meters).ToList();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            cartesianChart1.Height = Size.Height - 50;
            cartesianChart1.Width = Size.Width - 50;
        }

        private string GetStationName(double val)
        {
            var valInt = int.Parse(val.ToString());
            foreach(var station in stations)
            {
                if (!station.IsUsed && (station.Meters >= (valInt - 50) && station.Meters < (valInt + 50 )))
                {
                    station.IsUsed = true;
                    return GetStationName(station);
                }
            }

            return string.Empty;
        }

        private string GetStationName(Station station)
        {
            var name = station.Name;

            if (name.Contains("Czarnowo") || name == ("Śniadowo") || name.Contains("Baciuty"))
            {
                return string.Empty;
            }

            return station.IsStation ? name : name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(cartesianChart1.Width, cartesianChart1.Height);
            cartesianChart1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save($"{AppDomain.CurrentDomain.BaseDirectory}/Data/{(direct ? 1.ToString() : 0.ToString())}speed{trainType}.png", ImageFormat.Png);
        }
    }
}