﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace loginDb.Converters
{
    public class DateToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime birthDate)
            {
                var today = DateTime.Today;
                var age = today.Year - birthDate.Year;

                // בדיקה אם עדיין לא חל יום ההולדת השנה
                if (birthDate.Month > today.Month ||
                    (birthDate.Month == today.Month && birthDate.Day > today.Day))
                {
                    age--;
                }

                // חישוב מספר החודשים
                int months = today.Month - birthDate.Month;
                if (months < 0)
                {
                    months += 12;
                    age--;
                }

                // החזרת הגיל בפורמט "xx.y"
                return Math.Round(age + (double)months / 12, 1);
            }

            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
