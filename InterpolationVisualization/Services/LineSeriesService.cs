using System;
using System.Linq;

using LiveCharts;

using MathNet.Numerics.Interpolation;

namespace InterpolationVisualization.Services
{
    public static class LineSeriesService
    {
        private const int AmountToTake = 5;

        private const double StepSize = 1.00 / 2.00;

        public static ChartValues<double> GetCubicSplineInterpolation()
        {
            var yieldCurve = Data.YieldCurve;

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            IInterpolation interpolator = CubicSpline.InterpolateNatural(keys, yieldCurve.Values);

            return Interpolate(interpolator);
        }

        public static ChartValues<double> GetDnbYieldCurve()
        {
            var yieldCurve = Data.YieldCurve;

            var chartValues = new ChartValues<double>();

            for (var index = 0.00; index < AmountToTake; index += StepSize)
            {
                chartValues.Add(Math.Abs(index % 1.00) < 0.1 ? yieldCurve.Values.ElementAt((int)index) : double.NaN);
            }

            return chartValues;
        }

        public static ChartValues<double> GetLinearSplineInterpolation()
        {
            var yieldCurve = Data.YieldCurve;

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            IInterpolation interpolator = LinearSpline.Interpolate(keys, yieldCurve.Values);

            return Interpolate(interpolator);
        }

        public static ChartValues<double> GetLogLinearInterpolation()
        {
            var yieldCurve = Data.YieldCurve;

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            IInterpolation interpolator = LogLinear.Interpolate(keys, yieldCurve.Values);

            return Interpolate(interpolator);
        }

        public static ChartValues<double> GetPolynomialEquidistantInterpolation()
        {
            var yieldCurve = Data.YieldCurve;

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            IInterpolation interpolator = Barycentric.InterpolatePolynomialEquidistant(keys, yieldCurve.Values);

            return Interpolate(interpolator);
        }

        private static ChartValues<double> Interpolate(IInterpolation interpolator)
        {
            var chartValues = new ChartValues<double>();

            for (var index = (double)Data.YieldCurve.Keys.First(); index <= AmountToTake; index += StepSize)
            {
                chartValues.Add(interpolator.Interpolate(index));
            }

            return chartValues;
        }
    }
}