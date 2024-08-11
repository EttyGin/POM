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
using static loginDb.ViewModels.ClientsViewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace loginDb.ViewModels
{

    public class AddOrEditClientViewModel : ViewModelBase
    {
        public static ObservableCollection<Payer> Payers { get; set; }

        private IUserRepository userRepository;

    //    public ICommand AddClientCommand { get; }
        public ICommand AorECommand { get; }

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

     //   public Payer SelectedPayer { get; set; }

  //      private int? _payerId;
        public int SpePayerId { get; set; }
    /*    {
            get { return _payerId; }
            set
            {
                if (value != _payerId)
                {
                    _payerId = value;
                    Payer = value.HasValue ? (Payer)userRepository.GetById(value.Value, "Payer") : null;
                }
                OnPropertyChanged(nameof(PayerId));
                OnPropertyChanged(nameof(Payer));
            }
        }
    */

        /*      public int? PayerId { get; set; }

              public Payer _payer;

              public Payer Payer{ 
                  get
                  {
                      if (PayerId.HasValue)
                      {
                          return (Payer)userRepository.GetById(PayerId.Value, "Payer");
                      }
                      return null;

                  }
                  set
                  {
                      _payer = value;
                      OnPropertyChanged(nameof(Payer));
                  }
              }
              */
        private string _errorMessage;
        private bool _isViewVisible = true;

        public EditMode CurrentMode { get; set; }

        private Client _selectedClient;


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
            if (client != null)
            {
                _selectedClient = client;
                SpePayerId = SelectedClient.PayerId.Value;
            }
            else
            {
                _selectedClient = new Client();
            }
            userRepository = new UserRepository();
            AorECommand = new ViewModelCommand(ExecuteAorECommand);

            LoadPayers();
        }

        private void LoadPayers()
        {
            userRepository.InitNonePayer();
            Payers = new ObservableCollection<Payer>(userRepository.GetAll<Payer>());
            OnPropertyChanged(nameof(Payers));
        }
     /*   private void ExecuteAddClientCommand(object obj)
        {
            if (CanAorECommand()) {
                try
                {
                    Client c = new Client { Id = Id, Cname = Name, BirthDate = BirthDate, Phone = Phone, Email = Email, PayerId = SpePayerId };// , Payer = Payer};
                                                                                                                                               //Client c =  new Client { Id = 325085215, Cname = "Dudi Ginzburg", BirthDate = new DateTime(2002, 5, 8), Phone = "0556797375", Email = "davidg@gmail.com" , PayerId = null};
                    userRepository.Add(c);
                    //ClientsViewModel.Clients.Add(c);
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
        }
        */
        private bool CanAorECommand()
        {
            if (CurrentMode == EditMode.Add)
            {
                if (Id.ToString().Length < 8)
                {
                    ErrorMessage = $"Incorrect ID";
                    return false;
                }
                else if (Name == null || !Name.All(char.IsLetter) || Name.Length > 20)
                {
                    ErrorMessage = $"Incorrect Name";
                    return false;
                }

                else if (Phone == null || Phone.Length != 10 || !Regex.IsMatch(Phone, @"^\d+$")) //!System.Text.RegularExpressions.Regex.IsMatch(Phone, @"^0\d{9}$"))
                {
                    ErrorMessage = $"Incorrect Phone";
                    return false;
                }

                else if (Email == null || Email.Length > 30 || !Regex.IsMatch(Email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
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
                if (SelectedClient.Id.ToString().Length < 8)
                {
                    ErrorMessage = $"Incorrect ID";
                    return false;
                }
                else if (SelectedClient.Cname == null || !SelectedClient.Cname.All(char.IsLetter) || SelectedClient.Cname.Length > 20)
                {
                    ErrorMessage = $"Incorrect Name";
                    return false;
                }

                else if (SelectedClient.Phone == null || SelectedClient.Phone.Length != 10 || !Regex.IsMatch(SelectedClient.Phone, @"^\d+$")) //!System.Text.RegularExpressions.Regex.IsMatch(Phone, @"^0\d{9}$"))
                {
                    ErrorMessage = $"Incorrect Phone";
                    return false;
                }

                else if (SelectedClient.Email == null || SelectedClient.Email.Length > 30 || !Regex.IsMatch(SelectedClient.Email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
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
        }

        private void ExecuteAorECommand(object obj)
        {
            if (CanAorECommand())
            {
                if (CurrentMode == EditMode.Add)
                {
                    try
                    {
                        Client c  = new Client { Id = Id, Cname = Name, BirthDate = BirthDate, Phone = Phone, Email = Email, PayerId = SpePayerId };
                        //               SelectedClient =  new Client { Id = 325085215, Cname = "Dudi Ginzburg", BirthDate = new DateTime(2002, 5, 8), Phone = "0556797375", Email = "davidg@gmail.com" , PayerId = null};
                        userRepository.Add(c);
                        

                        ErrorMessage = "Client added successfully!";

                        Task.Delay(1200).ContinueWith(_ => // Wait before closing
                        {
                            IsViewVisible = false;
                            LstClients.Add(c);
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
                        //      Payer p = (Payer)userRepository.GetById(SelectedClient.PayerId.Value, "Payer");
                        /*         Client newClinet;
                                 if (SpePayerId == 0)
                                 {
                                     newClinet = new Client { Id = SelectedClient.Id, Cname = SelectedClient.Cname, BirthDate = SelectedClient.BirthDate, Phone = SelectedClient.Phone, Email = SelectedClient.Email };
                                 }
                                 else
                                     newClinet = new Client { Id = SelectedClient.Id, Cname = SelectedClient.Cname, BirthDate = SelectedClient.BirthDate, Phone = SelectedClient.Phone, Email = SelectedClient.Email, PayerId=SpePayerId };
                            */
                        SelectedClient.PayerId = SpePayerId;
                        userRepository.Edit(SelectedClient);

                        ErrorMessage = "Client was saved successfully!";

                        Task.Delay(800).ContinueWith(_ => // Wait before closing
                        {
                            IsViewVisible = false;
                            LstClients.Remove(SelectedClient);
                            LstClients.Add(SelectedClient);
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
}
