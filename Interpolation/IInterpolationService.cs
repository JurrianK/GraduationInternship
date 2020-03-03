namespace Interpolation
{
    public interface IInterpolationService
    {
        double PolynomialInterpolationAtPoint(double[] xData, double[] yData, double point);

        // double EquidistantPolynomialInterpolationAtPoint(double point);
    }
}