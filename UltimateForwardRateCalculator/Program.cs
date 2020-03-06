using System;

namespace UltimateForwardRateCalculator
{
    public static class Program
    {
        public static void Main()
        {
            const double PercentageHedged = 0.15;

            var discountedRts = DiscountService.CalculateDiscountedRts();
            var discountedRtsDown = DiscountService.CalculateDiscountedRtsDown();
            var discountedRtsUp = DiscountService.CalculateDiscountedRtsUp();

            var initialShock = ShockEffectService.CalculateInitialShock(Data.CashFlows, discountedRts);
            var rtsDownShock = ShockEffectService.CalculateRtsDownShock(Data.CashFlows, discountedRtsDown);
            var rtsUpShock = ShockEffectService.CalculateRtsUpShock(Data.CashFlows, discountedRtsUp);

            var interestDecrease = rtsDownShock - initialShock;
            var interestIncrease = rtsUpShock - initialShock;

            var shockEffectOnMarketValueAssetsRts = initialShock * PercentageHedged;
            var shockEffectOnMarketValueAssetsRtsDown = rtsDownShock * PercentageHedged;
            var shockEffectOnMarketValueAssetsRtsUp = rtsUpShock * PercentageHedged;

            var shockedMarketValueAssetsOnInterestDecrease =
                shockEffectOnMarketValueAssetsRtsDown - shockEffectOnMarketValueAssetsRts;

            var bufferOnInterestDecrease = -(interestDecrease - shockedMarketValueAssetsOnInterestDecrease);

            Console.WriteLine(bufferOnInterestDecrease);

            // var bufferOnInterestIncrease = interestIncrease - shockedMarketValueAssetsOnInterestIncrease;

            /*var bufferInterestRisk = bufferOnInterestDecrease > bufferOnInterestIncrease
                                         ? -bufferOnInterestDecrease
                                         : -bufferOnInterestIncrease;*/
        }
    }
}
