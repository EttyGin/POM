using loginDb;
using loginDb.Models;
using loginDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using loginDb.View;
using System.Data.Entity;
using System.Windows;

namespace loginDb.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        //Fields
      //  private readonly POMdbEntities _dbContext = new POMdbEntities();

        public static ObservableCollection<Client> _clients { get; set; }

        public enum EditMode { Add, Edit }

        private string _errorMessage;
        private bool _isViewVisible = true;


        private IUserRepository userRepository;
      //  private Client _selectedClient;

        //Properties
        public static ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }

            set
            {
                _clients = value;
                //OnPropertyChanged(nameof(Clients));

            }
        }   
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        //-> Commands
        public ICommand ShowAddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ShowEditCommand { get; }
        public ICommand SearchCommand { get; }

    /*    public static readonly RoutedCommand DeleteRCommand = new RoutedCommand(
        "DeleteCommand", typeof(ClientsViewModel));
   */     
        //Constructor
        public ClientsViewModel()
        {
            userRepository = new UserRepository();
            
            ShowAddCommand = new ViewModelCommand(ExecuteShowAddCommand, CanExecuteShowAddCommand);
            ShowEditCommand = new ViewModelCommand(ExecuteShowEditCommand, CanExecuteShowEditCommand);
            SearchCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);



            LoadClients();
        }

        private void LoadClients()
        {
            /*     var query =
                     from clinet in _dbContext.Clients
                     select new Client { Id = clinet.Id, Cname = clinet.Cname, BirthDate = clinet.BirthDate, Phone =clinet.Phone, Email = clinet.Email, PayerId = clinet.PayerId };
            */
            Clients = new ObservableCollection<Client>(userRepository.GetAllClients());
        }
        private bool CanExecuteShowAddCommand(object obj)
        {
            return true;
        }

        private void ExecuteShowAddCommand(object obj)
        {
            AddOrEditClientView addClientWin = new AddOrEditClientView(EditMode.Add ,obj as Client);
            addClientWin.Show();
        }

        private bool CanExecuteShowEditCommand(object obj)
        {
            return true;
        }

        private void ExecuteShowEditCommand(object obj)
        {
            Client c = Clients.First();
            AddOrEditClientView addClientWin = new AddOrEditClientView(EditMode.Edit, c);
            addClientWin.Show();
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
        private void ExecuteDeleteCommand(object obj)
        {
            var result = MessageBox.Show("Are you sure you want to delete it?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int c = Clients.First().Id;
                userRepository.Remove(c);
          //      ClientsViewModel.Clients.Remove(c);// obj as Client);
            }
        }

    }
}