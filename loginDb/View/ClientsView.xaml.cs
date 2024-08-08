using loginDb.Repositories;
using loginDb.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace loginDb.View
{
    /// <summary>
    /// Interaction logic for ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
            ClientsViewModel cvm = new ClientsViewModel();
            this.DataContext = cvm;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
           /* var client = sender as Client; // Assuming your object is of type Client

            if (client != null)
            {
        */        var result = MessageBox.Show("Are you sure you want to delete it?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
               //     userRepository.Remove(client);
                 //   ClientsViewModel.Clients.Remove(client);
                }
        //    }

        }
    }
}
