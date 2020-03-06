using System.Collections.Generic;
using System.Linq;

namespace UltimateForwardRateCalculator
{
    public static class ShockEffectService
    {
        public static double CalculateInitialShock(IEnumerable<double> cashFlows, IEnumerable<double> discountedRts)
        {
            var initialShock = 0.00;

            for (var cashFlowIndex = 0; cashFlowIndex < cashFlows.Count(); cashFlowIndex++)
            {
                initialShock += cashFlows.ElementAt(cashFlowIndex) * discountedRts.ElementAt(cashFlowIndex);
            }

            initialShock *= 1 + 0.001;

            return initialShock;
        }

        public static double CalculateRtsDownShock(IEnumerable<double> cashFlows, IEnumerable<double> discountedRtsDown)
        {
            var rtsDownShock = 0.00;

            for (var cashFlowIndex = 0; cashFlowIndex < cashFlows.Count(); cashFlowIndex++)
            {
                rtsDownShock += cashFlows.ElementAt(cashFlowIndex) * discountedRtsDown.ElementAt(cashFlowIndex);
            }

            rtsDownShock *= 1 + 0.001;

            return rtsDownShock;
        }

        public static double CalculateRtsUpShock(IEnumerable<double> cashFlows, IEnumerable<double> discountedRtsUp)
        {
            var rtsUpShock = 0.00;

            for (var cashFlowIndex = 0; cashFlowIndex < cashFlows.Count(); cashFlowIndex++)
            {
                rtsUpShock += cashFlows.ElementAt(cashFlowIndex) * discountedRtsUp.ElementAt(cashFlowIndex);
            }

            rtsUpShock *= 1 + 0.001;

            return rtsUpShock;
        }
    }
}