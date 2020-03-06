using System;
using System.Windows;

using LiveCharts;
using LiveCharts.Wpf;

namespace InterpolationVisualization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.SeriesCollection = new SeriesCollection
                                        {
                                            new LineSeries
                                                {
                                                    Title = "First series",
                                                    Values = new ChartValues<double> { 4.00, 5.00, 3.00, 5.50 }
                                                }
                                        };

            this.Labels = new[] { "First", "Second", "Third", "Fourth" };
            this.YFormatter = value => value.ToString("G");

            this.DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels { get; set; }

        public Func<double, string> YFormatter { get; set; }
    }
}
