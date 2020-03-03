using MathNet.Numerics;

namespace Interpolation
{
    public class InterpolationService : IInterpolationService 
    {
        public double PolynomialInterpolationAtPoint(double[] xData, double[] yData, double point)
        {
            var interpolation = Interpolate.PolynomialEquidistant(xData, yData);

            return interpolation.Interpolate(point);
        }
    }
}