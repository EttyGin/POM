using loginDb.Models;
using loginDb.Repositories;
using loginDb.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using static loginDb.ViewModels.MeetingsViewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace loginDb.ViewModels
{

    public class AddOrEditMeetingViewModel : ViewModelBase
    {
        public static ObservableCollection<Client> Clients { get; set; }

        private IUserRepository userRepository;
        public ICommand AorECommand { get; }

        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public Status Status { get; set; }

        public int UserId { get; set; }
        public int ClientId { get; set; }

        private string _errorMessage;
        private bool _isViewVisible = true;

        public EditMode CurrentMode { get; set; }

        private Meeting _selectedMeeting;

        public int SpeClientId { get; set; }


        //Properties
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

        public Meeting SelectedMeeting
        {
            get { return _selectedMeeting; }
            set
            {
                _selectedMeeting = value;
                OnPropertyChanged(nameof(SelectedMeeting));
            }
        }


        public AddOrEditMeetingViewModel(EditMode mode, Meeting meeting)
        {
            CurrentMode = mode;
            if (meeting != null)
            {
                _selectedMeeting = meeting;
                UserId = SelectedMeeting.UserId;
            }
            else
            {
                _selectedMeeting = new Meeting();
            }
            userRepository = new UserRepository();
            AorECommand = new ViewModelCommand(ExecuteAorECommand);

            LoadClients();
        }

        private void LoadClients()
        {
            Clients = new ObservableCollection<Client>(userRepository.GetAll<Client>());
            OnPropertyChanged(nameof(Clients));
        }
        
        private bool CanAorECommand()
        {
    /*         if (CurrentMode == EditMode.Add)
            {
               if (Number.ToString().Length < 8)
                {
                    ErrorMessage = $"Incorrect Number";
                    return false;
                }
                else if (Name == null || !Name.All(char.IsLetter) || Name.Length > 20)
                {
                    ErrorMessage = $"Incorrect Name";
                    return false;
                }
                else if (Date != null) {
                    int minAge = 5, maxAge = 100;
                    DateTime today = DateTime.Today;
                    int age = today.Year - Date.Year;

                    if (age < minAge || age > maxAge)
                    {
                        ErrorMessage = $"Incorrect Birth Date";
                        return false; 
                    }
                }
                else if (Summary == null || Summary.Length > 100)
                {
                    ErrorMessage = $"Incorrect Summary";
                    return false;
                }

                else if (Status)
                {
                    ErrorMessage = $"Incorrect Email";
                    return false;
                }
                else
                {
                    ErrorMessage = "";
                }
                return true;
            }
            else
            {
                if (SelectedMeeting.Number.ToString().Length < 8)
                {
                    ErrorMessage = $"Incorrect Number";
                    return false;
                }
                else if (SelectedMeeting.Cname == null || !SelectedMeeting.Cname.All(char.IsLetter) || SelectedMeeting.Cname.Length > 20)
                {
                    ErrorMessage = $"Incorrect Name";
                    return false;
                }

                else if (SelectedMeeting.Summary == null || SelectedMeeting.Summary.Length > 100)
                {
                    ErrorMessage = $"Incorrect Summary";
                    return false;
                }
                else if (SelectedMeeting.Date != null)
                {
                    int minAge = 5, maxAge = 100;
                    DateTime today = DateTime.Today;
                    int age = today.Year - SelectedMeeting.Date.Year;

                    if (age < minAge || age > maxAge)
                    {
                        ErrorMessage = $"Incorrect Birth Date";
                        return false;
                    }
                }

                else if (SelectedMeeting.Email == null || SelectedMeeting.Email.Length > 30 || !Regex.IsMatch(SelectedMeeting.Email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
                {
                    ErrorMessage = $"Incorrect Email";
                    return false;
                }
               else
                {
                    ErrorMessage = "";
                }
       */         return true;

            }
        
        private void ExecuteAorECommand(object obj)
        {
            if (CanAorECommand())
            {
                if (CurrentMode == EditMode.Add)
                {
                    try
                    {

                       // Meeting m  = new Meeting {Number = Number, Date = Date, Summary = Summary, Status = Status, UserId = UserId, ClientId = ClientId};
                        Meeting m  = new Meeting {Date = DateTime.Today, Summary = "get ready", Status = Status.planned, UserId = 325746147, ClientId = 325085215};
                        userRepository.Add(m);
                        
                        ErrorMessage = "Meeting added successfully!";

                        Task.Delay(1200).ContinueWith(_ => // Wait before closing
                        {
                            IsViewVisible = false;
                        }, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    catch (Exception)
                    {
                        ErrorMessage = $"Please fill in all required fields correctly";
                    }
                }
                else // CurrentMode == EditMode.Edit
                {
                    try
                    {
                        SelectedMeeting.UserId = UserId;
                        userRepository.Edit(SelectedMeeting);

                        ErrorMessage = "Meeting was saved successfully!";

                        Task.Delay(800).ContinueWith(_ => // Wait before closing
                        {
                            IsViewVisible = false;
                         //   LstMeetings.Remove(SelectedMeeting);
                           // LstMeetings.Add(SelectedMeeting);
                        }, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = $"Error updating Meeting: {ex.Message}";
                        // ErrorMessage = $"Please fill in all required fields correctly";
                    }
                }
            }
        }
    }
}
