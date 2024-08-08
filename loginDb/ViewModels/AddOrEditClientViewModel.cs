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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using static loginDb.ViewModels.ClientsViewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace loginDb.ViewModels
{

    public class AddOrEditClientViewModel : ViewModelBase
    {
        public static ObservableCollection<Payer> Payers { get; set; }

        public ICommand AddClientCommand { get; }
        public ICommand AorECommand { get; }

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int? PayerId { get; set; }

        private string _errorMessage;
        private bool _isViewVisible = true;

        public EditMode CurrentMode { get; set; }

        private Client _selectedClient;

        private IUserRepository userRepository;

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

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }




        public AddOrEditClientViewModel(EditMode mode, Client client)
        {
            CurrentMode = mode;
            SelectedClient = client is null ? new Client() : client;
            if (!(client is null)) PayerId = SelectedClient.Id;
            userRepository = new UserRepository();
            AddClientCommand = new ViewModelCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
            AorECommand = new ViewModelCommand(ExecuteAorECommand, CanExecuteAorECommand);

            LoadPayers();
        }

        private void LoadPayers()
        {
            Payers = new ObservableCollection<Payer>(userRepository.GetAllPayers());
            OnPropertyChanged(nameof(Payers));
        }

        private bool CanExecuteAddClientCommand(object obj)
        {
  /*          if (Id.ToString().Length != 9)
                return false;
            if (Name == null || Name.All(char.IsLetter) || Name.Length > 20)
                return false;

           if (Phone == null || !System.Text.RegularExpressions.Regex.IsMatch(Phone, @"^0\d{9}$"))
                return false;

            if (Email == null || Email.Length > 30 || !System.Text.RegularExpressions.Regex.IsMatch(Email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
                return false;

         */   return true;
        }

        private void ExecuteAddClientCommand(object obj)
        {
            try {
                  Client c = new Client { Id = Id, Cname = Name, BirthDate = BirthDate, Phone = Phone, Email = Email, PayerId = PayerId };
                //Client c =  new Client { Id = 325085215, Cname = "Dudi Ginzburg", BirthDate = new DateTime(2002, 5, 8), Phone = "0556797375", Email = "davidg@gmail.com" , PayerId = null};
                userRepository.Add(c);
                ClientsViewModel.Clients.Add(c);
                ErrorMessage = "Client added successfully!";

                Task.Delay(1200).ContinueWith(_ => // Wait before closing
                {
                    IsViewVisible = false; 
                }, TaskScheduler.FromCurrentSynchronizationContext());


            }
            catch (Exception ex)
            {
             //   ErrorMessage = $"Error adding client: {ex.Message}";
                ErrorMessage = $"Please fill in all required fields correctly";
            }
        }

        private bool CanExecuteAorECommand(object obj)
        {
            return true ;
        }

        private void ExecuteAorECommand(object obj)
        {
            // בדוק האם החלון נפתח במצב הוספה (Add) או עריכה (Edit)
            if (CurrentMode == EditMode.Add)
            {
                try
                {
                    Client c = new Client { Id = Id, Cname = Name, BirthDate = BirthDate, Phone = Phone, Email = Email, PayerId = PayerId };
                    //               SelectedClient =  new Client { Id = 325085215, Cname = "Dudi Ginzburg", BirthDate = new DateTime(2002, 5, 8), Phone = "0556797375", Email = "davidg@gmail.com" , PayerId = null};
                    if (PayerId.HasValue)
                    {
                        c.Payer = (Payer)userRepository.GetById(PayerId.Value, "Payer");
                    }
                    userRepository.Add(c);
                    ClientsViewModel.Clients.Add(c);

                    ErrorMessage = "Client added successfully!";

                    Task.Delay(1200).ContinueWith(_ => // Wait before closing
                    {
                        IsViewVisible = false;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch (Exception ex)
                {
                       ErrorMessage = $"Error adding client: {ex.Message}";
                   // ErrorMessage = $"Please fill in all required fields correctly";
                }
            }
            else // CurrentMode == EditMode.Edit
            {
                try
                {
                    //new Client { Id = Id, Cname = Name, BirthDate = BirthDate, Phone = Phone, Email = Email, PayerId = PayerId };
                    Payer p= (Payer)userRepository.GetById(SelectedClient.PayerId.Value, "Payer");
                    userRepository.Edit(SelectedClient);
                  //  ClientsViewModel.Clients (SelectedClient);

                    ErrorMessage = "Client was saved successfully!";

                    Task.Delay(1200).ContinueWith(_ => // Wait before closing
                    {
                        IsViewVisible = false;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Error updating client: {ex.Message}";
                    // ErrorMessage = $"Please fill in all required fields correctly";
                }
            }
        }

    }
}
