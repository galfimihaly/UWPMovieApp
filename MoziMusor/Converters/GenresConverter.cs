using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MoziMusor.Converters
{
    public class GenresConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string genres = "";
            List<string> genresList = value as List<string>;
            int i;
            if (genresList!=null)
            {
                for (i = 0; i < genresList.Count - 1; i++)
                {
                    genres += genresList.ElementAt(i) + ", ";
                }
                genres += genresList.ElementAt(i);
            }
            
            return genres;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
