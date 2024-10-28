using BanglaTracker.Core.Entities;
using System.Globalization;

namespace BanglaTracker.Presentation.Converters
{
    public class PointStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var point = value as LocationPoint;
            if (point == null) return Colors.LightGray;

            if (point.IsCurrent)
                return Colors.Green; // Color for the current point
            if (point.IsCrossed)
                return Colors.Gray;  // Color for reached points

            return Colors.LightGray; // Color for upcoming points
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
