﻿using System;
using System.Globalization;
using System.Windows.Data;

using LiveCharts;

namespace InterpolationVisualization
{
    public class ZoomingModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ZoomingOptions)value)
            {
                case ZoomingOptions.None:
                    return "None";

                case ZoomingOptions.X:
                    return "X";

                case ZoomingOptions.Y:
                    return "Y";

                case ZoomingOptions.Xy:
                    return "XY";

                default:
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}