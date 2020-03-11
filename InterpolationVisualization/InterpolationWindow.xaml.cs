using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

using InterpolationVisualization.Services;

using LiveCharts;

namespace InterpolationVisualization
{
    public sealed partial class InterpolationWindow : UserControl, INotifyPropertyChanged
    {
        private bool dnbCurveVisibility;
        private bool polynomialInterpolationVisibility;

        public InterpolationWindow()
        {
            InitializeComponent();

            this.dnbCurveVisibility = true;
            this.polynomialInterpolationVisibility = true;

            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool DnbCurveVisibility
        {
            get => this.dnbCurveVisibility;
            set
            {
                this.dnbCurveVisibility = value;
                OnPropertyChanged(nameof(this.DnbCurveVisibility));
            }
        }

        public bool PolynomialInterpolationVisibility
        {
            get => this.polynomialInterpolationVisibility;
            set
            {
                this.polynomialInterpolationVisibility = value;
                OnPropertyChanged(nameof(this.PolynomialInterpolationVisibility));
            }
        }

        public ChartValues<double> DnbCurveValues => LineSeriesService.GetDnbYieldCurve();

        public ChartValues<double> PolynomialInterpolationValues => LineSeriesService.GetPolynomialEquidistantInterpolation();

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
