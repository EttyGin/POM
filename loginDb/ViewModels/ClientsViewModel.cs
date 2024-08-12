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
using FontAwesome.Sharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Data.Entity.Infrastructure;

namespace loginDb.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        //Fields
        public ObservableCollection<Client> _lstClients;

        private ObservableCollection<Client> _filteredClients;

        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        private string _searchText;

        //Properties
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                UpdateFilteredClients();
            }
        }

        public ObservableCollection<Client> LstClients
        {
            get
            {
                return _lstClients;
            }

            set
            {
                _lstClients = value;
                OnPropertyChanged(nameof(LstClients));
                UpdateFilteredClients();
            }
        }

        public ObservableCollection<Client> FilteredClients
        {
            get => _filteredClients;
            private set
            {
                if (_filteredClients != value)
                {
                    _filteredClients = value;
                    OnPropertyChanged(nameof(FilteredClients));
                }
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
        public ICommand ShowMeetingsCommand { get; }

        //Constructor
        public ClientsViewModel()
        {
            userRepository = new UserRepository();

            ShowAddCommand = new ViewModelCommand(ExecuteShowAddCommand);
            ShowEditCommand = new ViewModelCommand(ExecuteShowEditCommand);
            SearchCommand = new ViewModelCommand(ExecuteSearchCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            ShowMeetingsCommand = new ViewModelCommand(ExecuteShowMeetingsCommand);

            LoadClients(null);
        }

        private void LoadClients(Expression<Func<Client, bool>> predicate)
        {
            if (!(predicate is null))
                LstClients = new ObservableCollection<Client>(userRepository.GetWhere<Client>(predicate));
            else
                LstClients = new ObservableCollection<Client>(userRepository.GetWhere<Client>(c => c.Cname == c.Cname));
            
            FilteredClients = new ObservableCollection<Client>(LstClients);
        }
        private void UpdateFilteredClients()
        {
            if (string.IsNullOrWhiteSpace(_searchText))
            {
                FilteredClients = new ObservableCollection<Client>(_lstClients);
            }
            else
            {
                var searchLower = _searchText.ToLower();
                var filtered = _lstClients.Where(c => c.Cname.ToLower().Contains(searchLower));
                FilteredClients = new ObservableCollection<Client>(filtered);
            }
        }

        private void ExecuteShowAddCommand(object obj)
        {
            AddOrEditClientView addClientWin = new AddOrEditClientView(EditMode.Add ,obj as Client);
            addClientWin.Show();
            LoadClients(null);
            }

        private void ExecuteSearchCommand(object obj)
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                LoadClients(c => c.Cname.Contains(SearchText));
            }
            else
            {
                LoadClients(c => c.Cname == c.Cname);
            }
        }

        private void ExecuteShowEditCommand(object obj)
        {
            AddOrEditClientView addClientWin = new AddOrEditClientView(EditMode.Edit, obj as Client);
            addClientWin.ShowDialog();
            LoadClients(null);
         }

        private void ExecuteShowMeetingsCommand(object obj)
        {
            IsViewVisible = false;
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
            LoadClients(null);
        }
    }
}