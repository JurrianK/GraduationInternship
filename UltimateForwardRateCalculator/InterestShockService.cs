using System.Collections.Generic;
using System.Linq;

namespace UltimateForwardRateCalculator
{
    public static class InterestShockService
    {
        public static IDictionary<int, double> GetDownwardsShockPerMaturity(
            IEnumerable<double> yieldCurve,
            int amountOfCashFlows)
        {
            var downwardsShockPerMaturity = new Dictionary<int, double> { { 0, 0.000 } };

            for (var index = 0; index < amountOfCashFlows; index++)
            {
                var rts = yieldCurve.ElementAt(index);
                double downwardShock;

                if (index >= Data.ShockDecrease.Count)
                {
                    downwardShock = Data.ShockDecrease.Last().Value;
                }
                else
                {
                    downwardShock = Data.ShockDecrease.ElementAt(index).Value;
                }

                downwardsShockPerMaturity.Add(index + 1, rts * downwardShock);
            }

            downwardsShockPerMaturity.Remove(amountOfCashFlows);

            return downwardsShockPerMaturity;
        }

        public static IDictionary<int, double> GetUpwardsShockPerMaturity(
            IEnumerable<double> yieldCurve,
            int amountOfCashFlows)
        {
            var upwardsShockPerMaturity = new Dictionary<int, double> { { 0, 0.000 } };

            for (var index = 0; index < amountOfCashFlows; index++)
            {
                var rts = yieldCurve.ElementAt(index);
                double downwardShock;

                if (index >= Data.ShockIncrease.Count)
                {
                    downwardShock = Data.ShockIncrease.Last().Value;
                }
                else
                {
                    downwardShock = Data.ShockIncrease.ElementAt(index).Value;
                }

                upwardsShockPerMaturity.Add(index + 1, rts * downwardShock);
            }

            upwardsShockPerMaturity.Remove(amountOfCashFlows);

            return upwardsShockPerMaturity;
        }
    }
}