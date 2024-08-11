using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace loginDb.CustomControls
    {
        public class CommandDataGridRow1 : DataGridRow
        {
            public ICommand RowClickCommand
            {
                get { return (ICommand)GetValue(RowClickCommandProperty); }
                set { SetValue(RowClickCommandProperty, value); }
            }

            public static readonly DependencyProperty RowClickCommandProperty =
                DependencyProperty.Register("RowClickCommand", typeof(ICommand), typeof(CommandDataGridRow), new PropertyMetadata(null));

            protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
            {
                base.OnPreviewMouseLeftButtonUp(e);
                if (RowClickCommand != null && RowClickCommand.CanExecute(DataContext))
                {
                    RowClickCommand.Execute(DataContext);
                }
            }
        }
    }

