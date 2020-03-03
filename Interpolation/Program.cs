using MathNet.Numerics.Interpolation;

namespace Interpolation
{
    public static class Program
    {
        public static void Main()
        {
            var xData = new double[] { 1, 2, 3, 5, 10, 20, 30 };
            var yData = new[] { 0.5, 0.8, 1, 1.3, 1.6, 2.2, 2.6 };

            IInterpolationService interpolationService = new InterpolationService();
            var interpolation = interpolationService.PolynomialInterpolationAtPoint(xData, yData, 20.0);

            IInterpolation polynomialInterpolation = new NevillePolynomialInterpolation(xData, yData);

            var interpolatedResult = polynomialInterpolation.Interpolate(20.0);
        }
    }
}
