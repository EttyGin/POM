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
using System.Linq.Expressions;

namespace loginDb.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        //Fields
        public static ObservableCollection<Client> _lstClients;

        public enum EditMode { Add, Edit }

        private string _errorMessage;
        private bool _isViewVisible = true;


        private IUserRepository userRepository;

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        //Properties
        public static ObservableCollection<Client> LstClients
        {
            get
            {
                return _lstClients;
            }

            set
            {
                _lstClients = value;
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


        //Constructor
        public ClientsViewModel()
        {
            userRepository = new UserRepository();
            
            ShowAddCommand = new ViewModelCommand(ExecuteShowAddCommand, CanExecuteShowAddCommand);
            ShowEditCommand = new ViewModelCommand(ExecuteShowEditCommand, CanExecuteShowEditCommand);
            SearchCommand = new ViewModelCommand(ExecuteSearchCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            LoadClients(c => c.Cname == c.Cname);
        }

        private bool CanExecuteSearchCommand(object obj)
        {
            return true;
        }

        private void ExecuteSearchCommand(object obj)
        {
           if (!string.IsNullOrEmpty(SearchText))
            {
                LoadClients(c => c.Cname.Contains(SearchText));
               Client fake =  new Client { Id = 111111111, Cname = "Dudi Ginzburg", BirthDate = new DateTime(2002, 5, 8), Phone = "0556797375", Email = "davidg@gmail.com" , PayerId = null};


               userRepository.Remove(fake, "Id");
                LstClients.Remove(fake);
            }
            else
            {
                LoadClients(c => c.Cname == c.Cname);
            }
        }



        private void LoadClients(Expression<Func<Client, bool>> predicate) 
        {
            LstClients = new ObservableCollection<Client>(userRepository.GetWhere<Client>(predicate));
            OnPropertyChanged(nameof(LstClients));
            //  LstClients = new ObservableCollection<Client>(userRepository.GetAll<Client>());
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
         //   Client c = LstClients.First();
            
            AddOrEditClientView addClientWin = new AddOrEditClientView(EditMode.Edit, obj as Client);
            addClientWin.ShowDialog();
         }

        private void ExecuteDeleteCommand(object obj)
        {
            Client toRemove = obj as Client;
            string name = toRemove.Cname;

            var result = MessageBox.Show($"Are you sure you want to delete {name}?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                userRepository.Remove(toRemove, "Id");
                LstClients.Remove(toRemove);

            }
        }

    }
}