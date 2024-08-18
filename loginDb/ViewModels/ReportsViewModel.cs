using loginDb;
using loginDb.Models;
using loginDb.Repositories;
using System.Windows.Input;
using System.Collections.ObjectModel;
using loginDb.View;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


namespace loginDb.ViewModels
{



    public class ReportsViewModel : ViewModelBase
    {
        public class FilteredClient : ViewModelBase
        {
            public string Name { get; set; }
            public int MeetingsAmount { get; set; }
            public int Debt { get; set; }
            private string _toShow;



            public FilteredClient(string name, int meetingsAmount, int debt)
            {
                Name = name;
                MeetingsAmount = meetingsAmount;
                Debt = debt;
            }
        }
        //Fields
        private int _numOfClients;
        private int _numOfMeetings;
        private int _revenue;
        private int _receivable;

        private ObservableCollection<Client> _lstClients;
        
        private ObservableCollection<FilteredClient> _filteredClients;

        //private List<Tuple<string, int, string>> _filteredClients;

        private string _errorMessage;
        private bool _isViewVisible = false;

        private IUserRepository userRepository;

        private bool _show = true;
        public bool Show
        {
            get { return _show; }
            set
            {
                if (_show != value)
                {
                    _show = value;
                    OnPropertyChanged(nameof(Show));
                }
            }
        }
        //Properties
        public int NumOfClients
        {
            get { return _numOfClients; }
            set
            {
                _numOfClients = value;
                OnPropertyChanged(nameof(NumOfClients));
            }
        }        
        public int NumOfMeetings
        {
            get { return _numOfMeetings; }
            set
            {
                _numOfMeetings = value;
                OnPropertyChanged(nameof(NumOfMeetings));
            }
        }        
        public int Revenue
        {
            get { return _revenue; }
            set
            {
                _revenue = value;
                OnPropertyChanged(nameof(Revenue));
            }
        }
        public int Receivable
        {
            get { return _receivable; }
            set
            {
                _receivable = value;
                OnPropertyChanged(nameof(Receivable));
            }
        }

        public ObservableCollection<FilteredClient> FilteredClients
        {
            get
            {
                return _filteredClients;
            }

            set
            {
                _filteredClients = value;
                OnPropertyChanged(nameof(FilteredClients));
              //  UpdateFilteredPayers();
            }
        }

        public ObservableCollection<Client> LstClients
        {
            get => _lstClients;
            private set
            {
                if (_lstClients != value)
                {
                    _lstClients = value;
                    OnPropertyChanged(nameof(LstClients));
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
        public ICommand ChangeShowCommand { get; }

        //Constructor
        public ReportsViewModel()
        {
            userRepository = new UserRepository();
            ChangeShowCommand = new ViewModelCommand(ExecuteChangeShowCommand);
            LoadAll();
        }

        private async void LoadAll()
        {
            LstClients = new ObservableCollection<Client>(userRepository.GetWhere<Client>(c => c.Cname == c.Cname));
            var results = await userRepository.LoadAllAsync();
            int Price = userRepository.GetUserPrice(LstClients.FirstOrDefault().Id);
            NumOfClients = results.NumOfClients;
            NumOfMeetings = results.NumOfMeetings;
            Revenue = results.Revenue * Price;
            Receivable = results.Receivable * Price;

            FilteredClients = new ObservableCollection<FilteredClient>(
                LstClients.Select(c => new FilteredClient(c.Cname, ?, ?))
            );


        }
        private void ExecuteChangeShowCommand(object obj)
        {
            FilteredClient crt = obj as FilteredClient;
        }

    }
}