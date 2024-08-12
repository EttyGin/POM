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
    public class MeetingsViewModel : ViewModelBase
    {
        //Fields
        public ObservableCollection<Meeting> _lstMeetings;

        private ObservableCollection<Meeting> _filteredMeetings;

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
                UpdateFilteredMeetings();
            }
        }

        public ObservableCollection<Meeting> LstMeetings
        {
            get
            {
                return _lstMeetings;
            }

            set
            {
                _lstMeetings = value;
                OnPropertyChanged(nameof(LstMeetings));
                UpdateFilteredMeetings();
            }
        }

        public ObservableCollection<Meeting> FilteredMeetings
        {
            get => _filteredMeetings;
            private set
            {
                if (_filteredMeetings != value)
                {
                    _filteredMeetings = value;
                    OnPropertyChanged(nameof(FilteredMeetings));
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
        public MeetingsViewModel()
        {
            userRepository = new UserRepository();

            ShowAddCommand = new ViewModelCommand(ExecuteShowAddCommand);
            ShowEditCommand = new ViewModelCommand(ExecuteShowEditCommand);
            SearchCommand = new ViewModelCommand(ExecuteSearchCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            ShowMeetingsCommand = new ViewModelCommand(ExecuteShowMeetingsCommand);

            LoadMeetings(null);
        }

        private void LoadMeetings(Expression<Func<Meeting, bool>> predicate)
        {
            if (!(predicate is null))
                LstMeetings = new ObservableCollection<Meeting>(userRepository.GetWhere(predicate));
            else
                LstMeetings = new ObservableCollection<Meeting>(userRepository.GetWhere<Meeting>(m => m.Number == m.Number));

            UpdateFilteredMeetings();

            //      FilteredMeetings = new ObservableCollection<Meeting>(LstMeetings);
        }
        private void UpdateFilteredMeetings()
        {
            if (string.IsNullOrWhiteSpace(_searchText))
            {
                FilteredMeetings = new ObservableCollection<Meeting>(_lstMeetings);
            }
            else
            {
                var searchLower = _searchText.ToLower();
                var filtered = _lstMeetings.Where(m => m.ClientId == int.Parse(searchLower));
                FilteredMeetings = new ObservableCollection<Meeting>(filtered);
            }
            //sorting by date - default
            var sortedMeetings = LstMeetings.OrderBy(meeting => meeting.Date).ToList();
            FilteredMeetings.Clear();
            foreach (var meeting in sortedMeetings)
            {
                FilteredMeetings.Add(meeting);
            }
        }

        private void ExecuteShowAddCommand(object obj)
        {
            AddOrEditMeetingView addMeetingWin = new AddOrEditMeetingView(EditMode.Add, obj as Meeting);
            addMeetingWin.Show();
            LoadMeetings(null);
        }

        private void ExecuteSearchCommand(object obj)
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var searchLower = _searchText.ToLower();
                LoadMeetings(m => m.ClientId.ToString().Contains(searchLower));
            }
            else
            {
                LoadMeetings(m => m.Number == m.Number);
            }
        }

        private void ExecuteShowEditCommand(object obj)
        {
            AddOrEditMeetingView addMeetingWin = new AddOrEditMeetingView(EditMode.Edit, obj as Meeting);
            addMeetingWin.ShowDialog();
            LoadMeetings(null);
        }

        private void ExecuteShowMeetingsCommand(object obj)
        {
            IsViewVisible = false;
        }

        private void ExecuteDeleteCommand(object obj)
        {
            Meeting toRemove = obj as Meeting;
            int clntId = toRemove.ClientId;
            int userId = toRemove.UserId;
            int num = toRemove.Number;


            var result = MessageBox.Show($"To delete Meeting number {toRemove.Number} of {clntId}?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                userRepository.RemoveMeeting(userId, clntId, num);
                LstMeetings.Remove(toRemove);

            }
            LoadMeetings(null);
        }
    }
}