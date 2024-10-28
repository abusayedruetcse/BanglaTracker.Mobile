using System.Globalization;

namespace BanglaTracker.Presentation.Converters
{
    public class PointStatusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2 || values[0] == null || values[1] == null)
            {
                return Colors.LightGray; // Default color for unresolved points
            }

            bool isCrossed = (bool)values[0];
            bool isCurrent = (bool)values[1];

            if (isCurrent)
                return Colors.Green;   // Color for current point
            else if (isCrossed)
                return Colors.Gray;    // Color for crossed points
            else
                return Colors.LightGray; // Color for remaining points
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
