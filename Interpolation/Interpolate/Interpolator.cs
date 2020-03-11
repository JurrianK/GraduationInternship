using System;
using System.Collections.Generic;
using System.Linq;

namespace Interpolate
{
    public interface IInterpolator
    {
        double InterpolateLinearlySorted(double xPosition);
    }

    public class Interpolator : IInterpolator
    {
        private readonly IEnumerable<double> x;
        private readonly IEnumerable<double> y;

        public Interpolator(IEnumerable<double> x, IEnumerable<double> y)
        {
            if (x.Count() != y.Count())
            {
                throw new ArgumentException("Sequences need to have equal x and y points.");
            }

            this.x = x;
            this.y = y;
        }

        public double InterpolateLinearlySorted(double xPosition)
        {
            var precedingIndexFound = false;
            int? precedingIndex = null;
            int? succeedingIndex = null;

            // Find preceding and succeeding values
            for (var index = 0; index < this.x.Count(); index++)
            {
                if (this.x.ElementAt(index) < xPosition)
                {
                    continue;
                }

                if (!precedingIndexFound)
                {
                    precedingIndex = index - 1;
                    precedingIndexFound = true;
                }

                if (this.x.ElementAt(index) >= xPosition)
                {
                    succeedingIndex = index;
                    break;
                }
            }

            // Exception when precedingIndex or succeedingIndex is null
            if (precedingIndex == null || succeedingIndex == null)
            {
                throw new ArgumentException("No value could be interpolated.");
            }

            // Interpolate
            var x1 = this.x.ElementAt((int)precedingIndex);
            var x2 = xPosition;
            var x3 = this.x.ElementAt((int)succeedingIndex);
            var y1 = this.y.ElementAt((int)precedingIndex);
            var y3 = this.y.ElementAt((int)succeedingIndex);

            return (((x2 - x1) * (y3 - y1)) / (x3 - x1)) + y1;
        }
    }
}