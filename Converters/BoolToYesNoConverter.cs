using System;
using System.Globalization;
using System.Windows.Data;

namespace EmployeePortal.Converters
{
    public class BoolToYesNoConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (value is bool isMarried)
            {
                return isMarried ? "Yes" : "No";
            }

            return "No";
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}