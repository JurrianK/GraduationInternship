using System;
using System.Collections.Generic;
using System.Linq;

namespace UltimateForwardRateCalculator
{
    public static class RtsService
    {
        private const double UfrPercentage = 0.021;

        public static IEnumerable<double> GetYieldCurveWithUfr(IDictionary<int, double> yieldCurve)
        {
            var forwardRtsWithUfr = GetForwardRtsWithUfr(yieldCurve);
            var extendedForwardRtsWithUfr = ExtendForwardRtsWithUfr(forwardRtsWithUfr, 40, UfrPercentage);
            var helpTable = CalculateHelpTable(extendedForwardRtsWithUfr);

            var rtsWithUfr = GetYieldCurveWithUfr(forwardRtsWithUfr, helpTable);

            var originalYieldCurve = Data.OriginalYieldCurve.Values.ToList();

            originalYieldCurve.AddRange(rtsWithUfr);

            return originalYieldCurve;
        }

        private static IEnumerable<double> GetForwardRtsWithUfr(IDictionary<int, double> yieldCurve)
        {
            var forwardYieldCurve = new List<double>();

            for (var index = 0; index < yieldCurve.Count; index++)
            {
                if (index == 0)
                {
                    forwardYieldCurve.Add(yieldCurve.ElementAt(index).Value);
                }
                else
                {
                    var leftSide = Math.Pow(
                        1 + (yieldCurve.ElementAt(index).Value / 100),
                        yieldCurve.ElementAt(index).Key);
                    var rightSide = Math.Pow(
                        1 + (yieldCurve.ElementAt(index - 1).Value / 100),
                        yieldCurve.ElementAt(index - 1).Key);

                    var calculation = (Math.Pow(
                                           leftSide / rightSide,
                                           1.00 / (yieldCurve.ElementAt(index).Key
                                                   - yieldCurve.ElementAt(index - 1).Key)) - 1) * 100;

                    forwardYieldCurve.Add(calculation);
                }
            }

            return forwardYieldCurve;
        }

        private static IEnumerable<double> ExtendForwardRtsWithUfr(
            IEnumerable<double> forwardYieldCurve,
            int extendToMaturity,
            double ufrToUse)
        {
            var extendedForwardYieldCurve = forwardYieldCurve.ToList();

            for (var index = 0; index < extendToMaturity; index++)
            {
                extendedForwardYieldCurve.Add(ufrToUse * 100);
            }

            return extendedForwardYieldCurve;
        }

        private static IEnumerable<double> CalculateHelpTable(IEnumerable<double> extendedForwardRateYieldCurve)
        {
            var helpList = new List<double> { 1.0000 };

            foreach (var item in extendedForwardRateYieldCurve)
            {
                helpList.Add(1 + (item / 100));
            }

            return helpList;
        }

        private static IEnumerable<double> GetYieldCurveWithUfr(
            IEnumerable<double> yieldCurve,
            IEnumerable<double> helpTable)
        {
            var extendedYieldCurveWithUfr = yieldCurve.ToList();

            var yieldCurveCount = extendedYieldCurveWithUfr.Count;
            var helpTableCount = helpTable.Count();

            for (var index = yieldCurveCount + 1; index < helpTableCount; index++)
            {
                var product = helpTable.Take(index + 1).Aggregate((total, next) => total * next);
                var power = (double)1 / index;
                var minusOne = Math.Pow(product, power) - 1;
                var timesHundred = minusOne * 100;

                extendedYieldCurveWithUfr.Add(timesHundred);
            }

            return extendedYieldCurveWithUfr.Skip(yieldCurveCount);
        }
    }
}