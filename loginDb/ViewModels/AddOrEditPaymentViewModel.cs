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
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Linq;
using static loginDb.ViewModels.PaymentsViewModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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

        private string _errorMessage;
        private bool _isViewVisible = true;

        private bool _isOpen = true;

        public EditMode CurrentMode { get; set; }

        private Payment _selectedPayment;
        public int Uid { get; set; } 


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
                if (value != null)
                {
                    Debt = userRepository.GetDebtById(Cid.Value, true);
                    OnPropertyChanged(nameof(Debt));

                }
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
                if (value != null)
                {
                    Debt = userRepository.GetDebtById(Pid.Value, false);
                    OnPropertyChanged(nameof(Debt));

                }
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
        public AddOrEditPaymentViewModel(EditMode mode, Payment p, int UserId)
        {
            userRepository = new UserRepository();
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
                Uid = UserId;
            }
            else
            {
                SelectedPayment = new Payment();
                Uid = 325746147; ///////////////////////////////////////////////////////////new MainViewModel().UserId;

            }
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
                if (IsClient)
                {
                    var ps = userRepository.GetWhere<Payment>(p => p.ClientID == Cid.Value && p.IsOpen);
                    if (ps.Count() > 0)
                    {
                        ErrorMessage = "There is an open request for this Client";
                        return false;
                    }
                }
                else //Payer
                {
                    var ps = userRepository.GetWhere<Payment>(p => p.PayerID == Pid.Value && p.IsOpen);
                    if (ps.Count() > 0)
                    {
                        ErrorMessage = "There is an open request for this Payer";
                        return false;
                    }
                }
                if (Debt == 0)
                {
                    ErrorMessage = "Its impossible to send a request with an empty amount";
                    return false;
                }
                return true;
            }
            else
            {
                if (SelectedPayment.IsOpen == false)
                {
                    ErrorMessage = "Payment has already been received.\nRequest is closed";
                    return false;
                }
                return true;
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

        private void ClosePayment()
        {
            DateTime lastUp = CurrentMode == EditMode.Add ? DateTime.Now : SelectedPayment.LastUpdate;
            if (IsClient)
            {
                var lstMeetings = userRepository.GetWhere<Meeting>(m => m.ClientId == Cid && m.Status == Status.unpaid && m.Date <= lastUp);
                foreach (Meeting m in lstMeetings)
                {
                    m.Status = m.Status == Status.partiallyPaid? Status.paid: Status.partiallyPaid; //If part paid than now full paid, else - part paid.
                    userRepository.Edit(m);
                }
            }
            else
            {
                var lstCLients = userRepository.GetWhere<Client>(c => c.PayerId == Pid);
                var lstMeetingss = userRepository.GetWhere<Meeting>(m => m.Client.PayerId == Pid);
                foreach (var c in lstCLients)
                {
                    var lstMeetings = userRepository.GetWhere<Meeting>(m => m.ClientId == c.Id && (m.Status == Status.unpaid || m.Status == Status.partiallyPaid) && m.Date <= lastUp);
                    foreach (Meeting m in lstMeetings)
                    {
                        m.Status = m.Status == Status.partiallyPaid ? Status.paid : Status.partiallyPaid; //If part paid than now full paid, else - part paid.
                        userRepository.Edit(m);
                    }
                }
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
                        Payment p = new Payment { Id = Id, ClientID = Cid, PayerID = Pid, IsOpen = IsOpen, Debt = Debt, LastUpdate = DateTime.UtcNow };
                        int secs = 4000;
                        if (IsOpen == false)
                        {
                            userRepository.Add(p);
                            ClosePayment();
                            ErrorMessage = "Closed Payment added successfully!";
                            secs = 1200;

                        }
                        else if (SendEmail())
                        {
                            userRepository.Add(p);
                            ErrorMessage = "Payment added successfully!";
                            secs = 1200;
                        }
                        Task.Delay(secs).ContinueWith(_ => // Wait before closing
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
                        //     SelectedPayment.Id = SpePaymentId;
                        SelectedPayment.LastUpdate = DateTime.Today; // .Now;
                        SelectedPayment.IsOpen = IsOpen;

                        if (SelectedPayment.IsOpen == false)
                            ClosePayment();

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
        private bool SendEmail()
        {
            try
            {
                User u = u = (User)userRepository.GetById(Uid, "User");
                string toAddress, body;
                if (IsClient)
                {
                    Client c = (Client)userRepository.GetById(Cid.Value, "Client");
                   // u = (User)userRepository.GetById(c.Meeting.First().UserId, "User");
                    toAddress = c.Email;
                    body = GetDebtDetailsForClient(c);
                }
                else
                {
                    Payer p = (Payer)userRepository.GetById(Pid.Value, "Payer");
              //      Client randClient = (Client)userRepository.GetWhere<Client>(c => c.Meeting.Count() != 0 && c.PayerId == Pid.Value ).FirstOrDefault(); // p.Client.First().Meeting;
              //      int uid = randClient.Meeting.FirstOrDefault().UserId;
                  //  u = (User)userRepository.GetById(uid, "User");
                    toAddress = p.ContactEmail;
                    body = GetDebtDetailsForPayer(p);

                }
                var fromAddress = new MailAddress(u.Email, u.Name);
                var fromPassword = "eg325746147"; // כאן את מכניסה את הסיסמה שלך, מומלץ לאחסן את הסיסמה בצורה בטוחה ולא בקוד ישירות.
                var subject = "Request to arrange payment for the last meetings";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, new MailAddress(toAddress))
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                })
                {
                    //smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Cannot sent an email. The request is cancelled.\nTry Later";
                return false;
            }
            return true;
        }

        private string GetDebtDetailsForPayer(Payer p)
        {
            DateTime d = DateTime.Now.Date;
            string open = $"Please find attached a summary of the sessions held for your clients up until {d}.";
            string body = "A detailed breakdown per client is included below:";
            string end = $"\nThe total amount due is {Debt} ILS. \nThank you.";
            int totalMeetings = 0;
            var lstCLients = userRepository.GetWhere<Client>(c => c.PayerId == p.Id);
            var lstMeetingss = userRepository.GetWhere<Meeting>(m => m.Client.PayerId == p.Id);
            foreach (var c in lstCLients)
            {
                int count = lstMeetingss.Where(m => m.Status == Status.unpaid && m.Date <= d).Count();
                body += $"\n * NAME :{c.Cname} - ID : {c.Id} \t {count} meetings.";
                totalMeetings += count;
            }
            string res = open + $"A total of {totalMeetings} meetings have been conducted.\n" + body + end;
            return res;
        }

        private string GetDebtDetailsForClient(Client c)
        {
            DateTime d = DateTime.Now.Date;
            string open = $"Please find attached a summary of the sessions held for you up until {d}.";
            string end = $"\nThe total amount due is {Debt} ILS. \nThank you.";
            var lstMeetings = userRepository.GetWhere<Meeting>(m => m.ClientId == c.Id && m.Status == Status.unpaid && m.Date <= d);
            int totalMeetings = lstMeetings.Count();
            string body = $"A total of {totalMeetings} meetings have been conducted.\n";
            string res = open + body + end;
            return res;
        }
    }
}
