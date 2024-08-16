﻿using loginDb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using FontAwesome.Sharp;
using loginDb.Models;
using loginDb.Repositories;
using loginDb.View;
using System.Windows.Media.Imaging;
using System.IO;

using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using NavigationService = loginDb.Models.NavigationService;



namespace loginDb.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccount _currentUserAccount;
        private int _userId;
        private ViewModelBase _currntChildView;
        private string _caption;
        private IconChar _icon;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;
  //      private readonly INavigationService _navigationService;


        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }



        //Properties
        public UserAccount CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currntChildView;
            }
            set
            {
                _currntChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
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

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowClientsViewCommand { get; }
        public ICommand ShowMeetingsViewCommand { get; }
        public ICommand ShowPayersViewCommand { get; }
        public ICommand ShowReportsViewCommand { get; }
        public ICommand ShowPaymentsViewCommand { get; }

        public ICommand LogoutCommand { get; }

      //  public INavigationService NavigationService => _navigationService;



        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccount();
<<<<<<< HEAD
          //  _navigationService = new NavigationService(this);
=======
>>>>>>> 5b548790048d32e0a487964fe57616b5c7302b04

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowClientsViewCommand = new ViewModelCommand(ExecuteShowClientViewCommand);
            ShowMeetingsViewCommand = new ViewModelCommand(ExecuteShowMeetingsViewCommand);
<<<<<<< HEAD
=======
            ShowPayersViewCommand = new ViewModelCommand(ExecuteShowPayersViewCommand);
<<<<<<< HEAD
            ShowReportsViewCommand = new ViewModelCommand(ExecuteShowReportsViewCommand);
            ShowPaymentsViewCommand = new ViewModelCommand(ExecuteShowPaymentsViewCommand);
=======
>>>>>>> 5b548790048d32e0a487964fe57616b5c7302b04
>>>>>>> a897a612b33cf9c9d4da0052c0a8b4525411def8
            LogoutCommand = new ViewModelCommand(ExecuteLogoutCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);
            LoadCurrentUserData();
        }



        private void ExecuteLogoutCommand(object obj)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Thread.CurrentPrincipal = null;
             //   IsViewVisible = false;
               // CurrentChildView = new LoginViewModel();
                
                var loginView = new LoginView();
                loginView.Show();

                //הפונקציה הזו היא בשביל לאפס את המצב בהתחברות הבאה, ולא שיכנס לאותם נתונים שעזב
                loginView.IsVisibleChanged += (s, ev) =>
                {
                    if (loginView.IsVisible == false && loginView.IsLoaded)
                    {
                        var mainView = new MainView();
                        mainView.Show();
                        loginView.Close();
                    }
                };
   
           
            }
        }


        private void ExecuteShowClientViewCommand(object obj)
        {
//            var navigationService = new NavigationService(this);
            CurrentChildView = new ClientsViewModel();
            Caption = "Clients";
            Icon = IconChar.UserGroup;
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void ExecuteShowMeetingsViewCommand(object obj)
        {
//            var navigationService = new NavigationService(this);
            CurrentChildView = new MeetingsViewModel();
            Caption = "Meetings";
            Icon = IconChar.Couch;
        }
        private void ExecuteShowPayersViewCommand(object obj)
        {
            CurrentChildView = new PayersViewModel();
            Caption = "Payers";
            Icon = IconChar.HandHoldingHeart;
        }

        private void ExecuteShowPaymentsViewCommand(object obj)
        {
            CurrentChildView = new PaymentsViewModel();
            Caption = "Payments";
            Icon = IconChar.HandHoldingHeart;
        }
        private void ExecuteShowReportsViewCommand(object obj)
        {
            CurrentChildView = new ReportsViewModel();
            Caption = "Reports";
            Icon = IconChar.ChartPie;
        }

        
        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";

                CurrentUserAccount.ProfilePic = null; // "/Images/profileP.png";
                UserId = user.Id;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }

    }
}




