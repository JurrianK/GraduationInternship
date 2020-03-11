using System;
using System.Linq;

using LiveCharts;

using MathNet.Numerics.Interpolation;

namespace InterpolationVisualization.Services
{
    public static class LineSeriesService
    {
        private static readonly int AmountToTake = Data.YieldCurve.Count;

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

        public static ChartValues<double> GetPolynomialEquidistantInterpolation()
        {
            var yieldCurve = Data.YieldCurve;
            var chartValues = new ChartValues<double>();

            var keys = yieldCurve.Select(x => Convert.ToDouble(x.Key));

            var interpolator = Barycentric.InterpolateRationalFloaterHormann(keys, yieldCurve.Values);

            for (var index = 0.00; index < AmountToTake; index += 0.50)
            {
                chartValues.Add(interpolator.Interpolate(index));
            }

            return chartValues;
        }
    }
}