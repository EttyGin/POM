using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace loginDb.CustomControls
{
    /// <summary>
    /// Interaction logic for CommandDataGridRow.xaml
    /// </summary>
    public partial class CommandDataGridRow : UserControl
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
