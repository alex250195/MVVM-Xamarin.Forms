using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.Converters
{
    public class AlterColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Color.FromHex("#FFFFFF");
            else if (value.ToString().Length < 3)
                return Color.FromHex("#FF0000");
            else if (value.ToString().Length >= 3 && value.ToString().Length < 6)
                return Color.FromHex("#FFA500");
            else
                return Color.FromHex("#00FF00");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.FromHex("#000000");
        }
    }
}
