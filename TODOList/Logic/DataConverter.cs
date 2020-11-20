using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TODOList.Logic
{
    public class DataConverter : IValueConverter
    {
        //TODO: filter for values
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                if (parameter.ToString() == "tb")
                {
                    if (string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                else
                {
                    DateTime date = (DateTime)value;
                    if (date.Date < DateTime.Now.Date)//date.ToString("dd.MM.yyyy") < DateTime.Now.Date.ToString("dd.MM.yyyy")
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
                return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
