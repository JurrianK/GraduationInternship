using System;
using System.Linq;

using LiveCharts;

using MathNet.Numerics.Interpolation;

namespace InterpolationVisualization.Services
{
    public static class LineSeriesService
    {
        private static readonly int AmountToTake = Data.YieldCurve.Count;

        public static ChartValues<double> GetCubicSplineInterpolation()
        {
            var yieldCurve = Data.YieldCurve;

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            IInterpolation interpolator = CubicSpline.InterpolateNatural(keys, yieldCurve.Values);

            return InterpolateChartValues(interpolator);
        }

        public static ChartValues<double> GetDnbYieldCurve()
        {
            var yieldCurve = Data.YieldCurve;

            var chartValues = new ChartValues<double>();

            for (var index = 0.00; index < AmountToTake; index += 0.50)
            {
                chartValues.Add(index % 1 == 0 ? yieldCurve.Values.ElementAt((int)index) : double.NaN);
            }

            return chartValues;
        }

        public static ChartValues<double> GetLinearSplineInterpolation()
        {
            var yieldCurve = Data.YieldCurve;

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            IInterpolation interpolator = LinearSpline.Interpolate(keys, yieldCurve.Values);

            return InterpolateChartValues(interpolator);
        }

        public static ChartValues<double> GetLogLinearInterpolation()
        {
            var yieldCurve = Data.YieldCurve;

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            IInterpolation interpolator = LogLinear.Interpolate(keys, yieldCurve.Values);

            return InterpolateChartValues(interpolator);
        }

        public static ChartValues<double> GetPolynomialEquidistantInterpolation()
        {
            var yieldCurve = Data.YieldCurve;

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            IInterpolation interpolator = Barycentric.InterpolateRationalFloaterHormann(keys, yieldCurve.Values);

            return InterpolateChartValues(interpolator);
        }

        private static ChartValues<double> InterpolateChartValues(IInterpolation interpolator)
        {
            var chartValues = new ChartValues<double>();

            for (var index = 1.00; index < AmountToTake + 0.50; index += 0.50)
            {
                chartValues.Add(interpolator.Interpolate(index));
            }

            return chartValues;
        }
    }
}