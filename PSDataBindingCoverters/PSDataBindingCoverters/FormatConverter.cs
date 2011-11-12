using System;
using System.Globalization;
using System.Windows.Data;

namespace PSDataBindingCoverters
{
    public class FormatConverter : IValueConverter
    {
        public string DisplayTime { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string)
            {
                var val = string.Format(parameter as string, value);
                DateTime displayTime;
                if (DateTime.TryParse(DisplayTime, out displayTime))
                {
                    val += displayTime.ToShortDateString();
                }
                return val;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}