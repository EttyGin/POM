using loginDb.Models;
using loginDb.Repositories;
using loginDb.View;
using loginDb.ViewModels;
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
using static loginDb.ViewModels.PaymentsViewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace loginDb.ViewModels
{

    public class AddOrEditPaymentViewModel : ViewModelBase
    {
        public static ObservableCollection<Payment> Payments { get; set; }

        private ObservableCollection<Payer> _lstPayers = null;
        private ObservableCollection<Client> _lstClients = null;

        private IUserRepository userRepository;
        public ICommand AorECommand { get; }
        public ICommand OpenCommand { get; }

        public int Id { get; set; }

        private int? _cid;
        private int? _pid;

        private bool _isClient;
        private bool _isPayer;
        public int Debt { get; set; }
        public DateTime Update { get; set; }

        private string _errorMessage;
        private bool _isViewVisible = true;

        private bool _isOpen = true;

        public EditMode CurrentMode { get; set; }

        private Payment _selectedPayment;


        //Properties
        public ObservableCollection<Payer> LstPayers
        {
            get => _lstPayers; set
            {
                _lstPayers = value;
                OnPropertyChanged(nameof(LstPayers));
            }
        }
        public ObservableCollection<Client> LstClients
        {
            get => _lstClients; set
            {
                _lstClients = value;
                OnPropertyChanged(nameof(LstClients));
            }
        }
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }

            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }
        public bool IsClient
        {
            get
            {
                return _isClient;
            }

            set
            {
                _isClient = value;
                OnPropertyChanged(nameof(IsClient));
            }
        }
        public bool IsPayer
        {
            get
            {
                return _isPayer;
            }

            set
            {
                _isPayer = value;
                OnPropertyChanged(nameof(IsPayer));
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
        public Nullable<int> Cid
        {
            get
            {
                return _cid;
            }

            set
            {
                _cid = value;

                OnPropertyChanged(nameof(Cid));
            }
        }
        public Nullable<int> Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;

                OnPropertyChanged(nameof(Pid));
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
        public Payment SelectedPayment
        {
            get { return _selectedPayment; }
            set
            {
                _selectedPayment = value;
                OnPropertyChanged(nameof(SelectedPayment));
            }
        }

        //constructor
        public AddOrEditPaymentViewModel(EditMode mode, Payment p)
        {
            CurrentMode = mode;
            if (p != null)
            {
                SelectedPayment = p;
                Pid = p.PayerID;
                Cid = p.ClientID;
                IsOpen = p.IsOpen;
                if (p.ClientID != null)
                    IsClient = true;
                else IsClient = false;
                if (p.PayerID != null)
                    IsPayer = true;
                else IsPayer = false;
            }
            else
            {
                SelectedPayment = new Payment();
            }
            userRepository = new UserRepository();
            AorECommand = new ViewModelCommand(ExecuteAorECommand);
            OpenCommand = new ViewModelCommand(ExecuteOpenCommand);

            LoadPayments();
            LoadAll();
        }
        private void LoadPayments()
        {
            Payments = new ObservableCollection<Payment>(userRepository.GetAll<Payment>());
            OnPropertyChanged(nameof(Payments));
        }
        private void LoadAll()
        {
            userRepository.InitNonePayer();
            LstPayers = new ObservableCollection<Payer>(userRepository.GetWhere<Payer>(p => p.Pname != " -"));
            LstClients = new ObservableCollection<Client>(userRepository.GetAll<Client>());
        }
        private bool CanAorECommand()
        {
            if (CurrentMode == EditMode.Add)
            {
           /*     if (Name == null || !Name.Replace(" ", "").All(char.IsLetter) || Name.Length > 20)
                {
                    ErrorMessage = "Incorrect Payment Name";
                    return false;
                }
                if (CName == null || !CName.Replace(" ", "").All(char.IsLetter) || CName.Length > 20)
                {
                    ErrorMessage = "Incorrect Contact Name";
                    return false;
                }
                else if (CEmail == null || CEmail.Length > 30 || !Regex.IsMatch(CEmail, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
                {
                    ErrorMessage = $"Incorrect Email";
                    return false;
                }
                else if (Payment == 0 )
                {
                    ErrorMessage = $"Incorrect Payment";
                    return false;
                }
                {
                    ErrorMessage = "";
                }
          */      return true;
            }
            else
            {
          /*      if (SelectedPayment.Pname == null || !SelectedPayment.Pname.Replace(" ", "").All(char.IsLetter) || SelectedPayment.Pname.Length > 20)
                {
                    ErrorMessage = "Incorrect Payment Name";
                    return false;
                }
                if (SelectedPayment.ContactName == null || !SelectedPayment.ContactName.Replace(" ", "").All(char.IsLetter) || SelectedPayment.ContactName.Length > 20)
                {
                    ErrorMessage = "Incorrect Contact Name";
                    return false;
                }
                else if (SelectedPayment.ContactEmail == null || SelectedPayment.ContactEmail.Length > 30 || !Regex.IsMatch(SelectedPayment.ContactEmail, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
                {
                    ErrorMessage = $"Incorrect Email";
                    return false;
                }
                else if (SelectedPayment.TotalPayment == 0)
                {
                    ErrorMessage = $"Incorrect Payment";
                    return false;
                }
                {
                    ErrorMessage = "";
                }
         */       return true;
            }
        }
        private void ExecuteOpenCommand(object obj)
        {
            string val = (string)obj;
            if (CurrentMode == EditMode.Add)
                IsOpen = val.Equals("true");
            else 
                SelectedPayment.IsOpen = val.Equals("true");
        }
        private void ExecuteAorECommand(object obj)
        {
            if (CanAorECommand())
            {
                if (CurrentMode == EditMode.Add)
                {
                    try
                    {
                        Payment p = new Payment {Id = Id, ClientID = Cid, PayerID = Pid, IsOpen = IsOpen , Debt = Debt, LastUpdate = Update};
                        userRepository.Add(p);
                        

                        ErrorMessage = "Payment added successfully!";

                        Task.Delay(1200).ContinueWith(_ => // Wait before closing
                        {
                            //LstPayments.Add(p);
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
                   //     SelectedPayment.Id = SpePaymentId;
                        userRepository.Edit(SelectedPayment);

                        ErrorMessage = "Payment was saved successfully!";

                        Task.Delay(800).ContinueWith(_ => // Wait before closing
                        {
                            IsViewVisible = false;


                        }, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = $"Error updating Payment: {ex.Message}";

                    }
                }
            }
        }
    }
}
