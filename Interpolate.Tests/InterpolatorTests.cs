using System.Linq;

using Xunit;

namespace Interpolate.Tests
{
    public class InterpolatorTests
    {
        [Fact]
        public void Test1()
        {
            IInterpolator interpolator = new Interpolator(
                Data.OriginalYieldCurve.Keys.Select(x => (double)x),
                Data.OriginalYieldCurve.Values);

            var result = interpolator.InterpolateLinearlySorted(1.5);
        }
    }
}
