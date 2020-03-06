using System;
using System.Collections.Generic;
using System.Linq;

namespace UltimateForwardRateCalculator
{
    public static class DiscountService
    {
        public static IEnumerable<double> CalculateDiscountedRts()
        {
            var discountedRts = new List<double> { 0.500 };
            var rts = RtsService.GetYieldCurveWithUfr(Data.OriginalYieldCurve);

            for (var index = 0; index < rts.Count(); index++)
            {
                var division = rts.ElementAt(index) / 100;
                var plusOne = division + 1;
                var power = Math.Pow(plusOne, index + 1);
                var complete = 1.00 / power;

                discountedRts.Add(complete);
            }

            return discountedRts;
        }

        public static IEnumerable<double> CalculateDiscountedRtsDown()
        {
            var rts = RtsService.GetYieldCurveWithUfr(Data.OriginalYieldCurve);
            var downwardsShockPerMaturity = InterestShockService.GetDownwardsShockPerMaturity(rts, Data.CashFlows.Count());

            var discountedRtsDown = new List<double> { 0.500 };

            for (var index = 1; index < downwardsShockPerMaturity.Count; index++)
            {
                var division = downwardsShockPerMaturity.ElementAt(index).Value / 100;
                var plusOne = division + 1;
                var power = Math.Pow(plusOne, index);
                var complete = 1.00 / power;

                discountedRtsDown.Add(complete);
            }

            return discountedRtsDown;
        }

        public static IEnumerable<double> CalculateDiscountedRtsUp()
        {
            var rts = RtsService.GetYieldCurveWithUfr(Data.OriginalYieldCurve);
            var upwardsShockPerMaturity = InterestShockService.GetUpwardsShockPerMaturity(rts, Data.CashFlows.Count());

            var discountedRtsUp = new List<double> { 0.500 };

            for (var index = 1; index < upwardsShockPerMaturity.Count; index++)
            {
                var division = upwardsShockPerMaturity.ElementAt(index).Value / 2.00 / 100;
                var plusOne = division + 1;
                var power = Math.Pow(plusOne, index);
                var complete = 1.00 / power;

                discountedRtsUp.Add(complete);
            }

            return discountedRtsUp;
        }
    }
}