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

namespace TrainChart
{
    public partial class Form4 : Form
    {
        bool direct;
        List<int> valX;
        List<int> valY;
        List<Station> stations;
        List<Tuple<int, int>> trains;

        public Form4(bool dir)
        {
            direct = dir;
            InitializeComponent();
            GetValues();
            LoadStation();
            // LoadTrains();

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    PointGeometrySize = 0,
                    Values =  valY.AsGearedValues().WithQuality(Quality.Low),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    StrokeThickness = 0,
                    Stroke = System.Windows.Media.Brushes.Transparent,
                },
            };

            foreach (var station in stations)
            {
                var val = new List<int>();

                foreach (var _ in valX)
                {
                    val.Add(station.Meters);
                }

                if (station.IsStation)
                {
                    cartesianChart1.Series.Add(
                        new LineSeries
                        {
                            PointGeometrySize = 0,
                            Values = val.AsGearedValues().WithQuality(Quality.Low),
                            Fill = System.Windows.Media.Brushes.Transparent,
                            StrokeThickness = 1,
                            Stroke = System.Windows.Media.Brushes.Black
                        }
                    );
                } 
                else
                {
                    cartesianChart1.Series.Add(
                        new LineSeries
                        {
                            PointGeometrySize = 0,
                            Values = val.AsGearedValues().WithQuality(Quality.Low),
                            Fill = System.Windows.Media.Brushes.Transparent,
                            StrokeThickness = 0.5,
                            Stroke = System.Windows.Media.Brushes.Gray,
                            StrokeDashArray = new DoubleCollection { 10 }
                        }
                    );
                }


            }

            //cartesianChart1.Series.Add(
            //    new LineSeries
            //    { 
            //        Values = GetTrainValues(),
            //        StrokeThickness = 3,
            //        Stroke = System.Windows.Media.Brushes.Red,
            //        Fill = System.Windows.Media.Brushes.Transparent,
            //        PointGeometrySize = 1
            //    }
            //);

            cartesianChart1.AxisY.Add(new Axis
            {
                MinValue = 0,
                MaxValue = GetMaxValue(),
                Separator = new Separator
                {
                    Step = 25,
                    Stroke = System.Windows.Media.Brushes.Transparent
                },
                LabelFormatter = val => GetAxisYVal(val),
            });

            foreach(var i in valX)
            {
                if (i % 60 == 0)
                {
                    var val = GetSepartorHourVal(i);
                    cartesianChart1.Series.Add(
                        new LineSeries
                        {
                            PointGeometrySize = 0,
                            Values = val.AsGearedValues().WithQuality(Quality.Low),
                            Fill = System.Windows.Media.Brushes.Transparent,
                            StrokeThickness = 1.25,
                            Stroke = System.Windows.Media.Brushes.Black,
                        }
                    );

                    continue;
                }

                if (i % 30 == 0)
                {
                    var val = GetSepartorHourVal(i);
                    cartesianChart1.Series.Add(
                        new LineSeries
                        {
                            PointGeometrySize = 0,
                            Values = val.AsGearedValues().WithQuality(Quality.Low),
                            Fill = System.Windows.Media.Brushes.Transparent,
                            StrokeThickness = 1.25,
                            Stroke = System.Windows.Media.Brushes.Black,
                            StrokeDashArray = new DoubleCollection { 5 }
                        }
                    );

                    continue;
                }
            }

            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = val => GetAxisVal(val),
                Separator = new Separator { Step = 10, StrokeDashArray = new DoubleCollection { 5 } },
                Position = AxisPosition.RightTop,
            });

            cartesianChart1.LegendLocation = LegendLocation.None;
        }

        private List<int> GetSepartorHourVal(int i)
        {
            var val = new List<int>();

            foreach(var x in valY)
            {
                val.Add(i);
            }

            return val;            
        }

        private double GetMaxValue()
        {
            return stations.Last().Meters + 10;
        }

        private void GetValues()
        {
            valX = new List<int>();
            valX.AddRange(Enumerable.Range(0, 1440));

            valY = new List<int>();
            foreach (var _ in valX)
            {
                valY.Add(1);
            }
        }

        private string GetAxisVal(double val)
        {
            var intVal = int.Parse(val.ToString());

            if (intVal % 30 == 0)
            {
                var time = TimeSpan.FromMinutes(intVal);
                return time.ToString(@"hh\:mm");
            }

            return string.Empty;
        }

        private string GetAxisYVal(double val)
        {
            var valInt = int.Parse(val.ToString());
            foreach (var station in stations)
            {
                if (!station.IsUsed && (station.Meters >= (valInt - 25) && station.Meters < (valInt + 25)))
                {
                    station.IsUsed = true;
                    var name = station.IsStation
                        ? station.Name.ToUpper()
                        : station.Name + " [PO]";


                    return string.IsNullOrEmpty(station.Blockade)
                        ? $"{name}     "
                        : $"{name}     {station.Blockade}";
                }
            }

            return string.Empty;
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
                    var meters = direct ? int.Parse(values[0]) : int.Parse(values[1]);
                    var isStation = int.Parse(values[3]);

                    stations.Add(new Station(meters, values[2], isStation, values[4]));
                }

                stations = stations.OrderBy(x => x.Meters).ToList();
            }
        }

        void LoadTrains()
        {
            trains = new List<Tuple<int, int>>();
            using (var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Data/train1.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var meters = int.Parse((double.Parse(values[0]) * 1000).ToString());

                    if (!string.IsNullOrEmpty(values[1]))
                    {
                        trains.Add(new Tuple<int, int>(meters, TimeToInt(values[1])));
                    }

                    if (!string.IsNullOrEmpty(values[2]))
                    {
                        trains.Add(new Tuple<int, int>(meters, TimeToInt(values[2])));
                    }
                }
            }
        }

        private ChartValues<ObservablePoint> GetTrainValues()
        {
            var values = new ChartValues<ObservablePoint>();

            foreach (var train in trains)
            {
                values.Add(new ObservablePoint(train.Item2, train.Item1));
            }

            return values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(cartesianChart1.Width, cartesianChart1.Height);
            cartesianChart1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save($"{AppDomain.CurrentDomain.BaseDirectory}/Data/chart.png", ImageFormat.Png);
        }

        int TimeToInt(string val)
        {
            var time = val.Split(':');

            return (int.Parse(time[0]) * 60) + int.Parse(time[1]);
        }
    }
}
