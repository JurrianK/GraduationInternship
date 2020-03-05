namespace UltimateForwardRateCalculator
{
    public static class Program
    {
        public static void Main()
        {
            var discountedRts = DiscountService.CalculateDiscountedRts();
            var discountedRtsDown = DiscountService.CalculateDiscountedRtsDown();
            var discountedRtsUp = DiscountService.CalculateDiscountedRtsUp();

            ShockEffectService.CalculateInitialShock(Data.CashFlows, discountedRts);
            ShockEffectService.CalculateRtsDownShock(Data.CashFlows, discountedRtsDown);
            ShockEffectService.CalculateRtsUpShock(Data.CashFlows, discountedRtsUp);
        }
    }
}
