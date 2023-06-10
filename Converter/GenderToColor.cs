using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfProject.Converter
{
    public class GenderToColor : IValueConverter //create a class that impelements the IvalueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {//at this method create the logic for coloring using if statments or switch 
            if (value.ToString() == "male")
            {
                return "Red";
            }
            else
            {
                return "Green";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
