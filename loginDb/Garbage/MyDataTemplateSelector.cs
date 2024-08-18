using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace loginDb.Models
{
    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public class Label : DataTemplateSelector
        {
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                if (item is Label )
                {
                    return (DataTemplate)Application.Current.FindResource("MeetingsAmountTemplate");
                }
                else
                {
                    return (DataTemplate)Application.Current.FindResource("NameTemplate");
                }
            }
        }

    }

}
