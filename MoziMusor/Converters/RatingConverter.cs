using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MoziMusor.Converters
{
    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            float rating = (float)value;
            int digit = int.Parse(parameter.ToString());

            if (digit <= rating)
            {
                return Symbol.SolidStar;
            }

            return Symbol.OutlineStar;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
