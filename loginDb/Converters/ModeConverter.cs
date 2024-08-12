﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static loginDb.ViewModels.ClientsViewModel;
using static loginDb.ViewModels.ViewModelBase;

namespace loginDb.Converters
{
    public class ModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EditMode mode)
            {
                string elementName = parameter as string;

                switch (mode)
                {
                    case EditMode.Add:
                        return $"Add A {elementName}";
                    case EditMode.Edit:
                        return $"UPDATE A {elementName}";
                    default:
                        return "Unknown Mode";
                }
/*
                {
                    case EditMode.Add:
                        return "Add The Client";
                    case EditMode.Edit:
                        return "Update The Client";
                    default:
                        return "Unknown Mode";
                }
    */        }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
