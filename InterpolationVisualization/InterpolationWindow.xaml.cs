using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

using InterpolationVisualization.Services;

using LiveCharts;

namespace InterpolationVisualization
{
    public sealed partial class InterpolationWindow : UserControl, INotifyPropertyChanged
    {
        private bool cubicSplineVisibility;
        private bool dnbCurveVisibility;
        private bool logLinearVisibility;
        private bool polynomialInterpolationVisibility;
        private bool stepInterpolationVisibility;

        private ZoomingOptions zoomingMode;

        public InterpolationWindow()
        {
            InitializeComponent();

            this.zoomingMode = ZoomingOptions.X;

            this.cubicSplineVisibility = false;
            this.dnbCurveVisibility = true;
            this.logLinearVisibility = false;
            this.polynomialInterpolationVisibility = false;
            this.stepInterpolationVisibility = false;

            this.DataContext = this;
        }

        public ChartValues<double> CubicSplineInterpolationValues => LineSeriesService.GetCubicSplineInterpolation();

        public bool CubicSplineInterpolationVisibility
        {
            get => this.cubicSplineVisibility;
            set
            {
                this.cubicSplineVisibility = value;
                OnPropertyChanged(nameof(this.CubicSplineInterpolationVisibility));
            }
        }

        public ChartValues<double> DnbCurveValues => LineSeriesService.GetDnbYieldCurve();

        public bool DnbCurveVisibility
        {
            get => this.dnbCurveVisibility;
            set
            {
                this.dnbCurveVisibility = value;
                OnPropertyChanged(nameof(this.DnbCurveVisibility));
            }
        }

        public ChartValues<double> LinearSplineInterpolationValues => LineSeriesService.GetLinearSplineInterpolation();

        public bool LinearSplineInterpolationVisibility
        {
            get => this.logLinearVisibility;
            set
            {
                this.logLinearVisibility = value;
                OnPropertyChanged(nameof(this.LinearSplineInterpolationVisibility));
            }
        }

        public ChartValues<double> LogLinearInterpolationValues => LineSeriesService.GetLogLinearInterpolation();

        public bool LogLinearInterpolationVisibility
        {
            get => this.logLinearVisibility;
            set
            {
                this.logLinearVisibility = value;
                OnPropertyChanged(nameof(this.LogLinearInterpolationVisibility));
            }
        }

        public ChartValues<double> PolynomialInterpolationValues => LineSeriesService.GetPolynomialEquidistantInterpolation();

        public bool PolynomialInterpolationVisibility
        {
            get => this.polynomialInterpolationVisibility;
            set
            {
                this.polynomialInterpolationVisibility = value;
                OnPropertyChanged(nameof(this.PolynomialInterpolationVisibility));
            }
        }

        public ChartValues<double> StepInterpolationValues => LineSeriesService.GetStepInterpolation();

        public bool StepInterpolationVisibility
        {
            get => this.stepInterpolationVisibility;
            set
            {
                this.stepInterpolationVisibility = value;
                OnPropertyChanged(nameof(this.StepInterpolationVisibility));
            }
        }

        public ZoomingOptions ZoomingMode
        {
            get => this.zoomingMode;
            set
            {
                this.zoomingMode = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ToggleZoomingMode(object sender, RoutedEventArgs e)
        {
            switch (this.ZoomingMode)
            {
                case ZoomingOptions.None:
                    this.ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    this.ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    this.ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    this.ZoomingMode = ZoomingOptions.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
