using Acr.UserDialogs;
using CarService.MobileApp.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



using Prism.Navigation;

using System.Linq;

using Xamarin.Forms;
using System.Windows.Input;
using CarService.Data.Requests;

namespace CarService.MobileApp.ViewModels
{
    public class PaymentGatwayPageViewModel: BindableBase
    {
        private APIService _userService = new APIService("user");
        private APIService _paymentService = new APIService("payments");
        private APIService _ticketService = new APIService("ticket");

        private APIService _scheduleService = new APIService("ScheduleSecond");

        #region Variable

        private CreditCardModel _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;

        #endregion Variable

        #region Public Property
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }

        public CreditCardModel CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        #endregion Public Property

        #region Constructor

      public Data.Model.Schedule ScheduleModel { get; set; }
        public PaymentGatwayPageViewModel()
        {
            CreditCardModel = new CreditCardModel();
            Title = "Card Details";
            SubmitCommand = new Command( () => _MakePayment());
        }
        public ICommand SubmitCommand { get; set; }
        #endregion Constructor

        #region Command

        
        public async void _MakePayment()
        {
            CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
            CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
            try
            {
               
             
                        IsTransectionSuccess = true;
         
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                Console.Write("Payment Gatway" + ex.Message);
            }
            finally
            {
                if (IsTransectionSuccess)
                {
                    Console.Write("Payment Gateway" + "Payment Successful ");
                    await _paymentService.Insert<Data.Model.Payments>(new PaymentInsertRequest() { PaymentDate=DateTime.Now,ScheduleID=ScheduleModel.ScheduleID,
                    PaymentTypeID=2,Amount=ScheduleModel.totalPrice});

                    var ticketList = await _ticketService.Get<List<Data.Model.Ticket>>(new TicketSearchRequest() { ScheduleID = ScheduleModel.ScheduleID });

                    if(ticketList.Count()>0)
                    {
                        var ticketModel = ticketList.First();
                        if(ticketModel!=null)
                        {
                            await _ticketService.Update<Data.Model.Ticket>(ticketModel.TicketID,null);
                        }
                    }
                    await _scheduleService.Update<Data.Model.Schedule>(ScheduleModel.ScheduleID,new ScheduleSecondUpdateRequest()
                    {
                        updateIsPaid = true
                    });

                    
                
                }
                else
                {

                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert("Oops, something went wrong", "Payment failed", "OK");
                    Console.Write("Payment Gateway" + "Payment Failure ");
                }
            }

        }

        #endregion Command

        #region Method

      
        private string CreateToken()
        {
            try
            {
  
                
               
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = "Ahmed Ždralović",
                        AddressLine1 = "18",
                        AddressLine2 = "19",
                        AddressCity = "Bugojno",
                        AddressZip = "70230",
                        AddressState = "Bosna",
                        AddressCountry = "Bosnia and Herzegovina",
                        Currency = "BAM",
                    }

                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

   
        public bool MakePayment()
        {
            try
            {
              
                var options = new ChargeCreateOptions
                {
                    Amount = (long)float.Parse("1"),
                    Currency = "BAM",
                    Description = "Charge for Jon.rosen@example.com",
                    StatementDescriptor = "Custom descriptor",
                    Capture = true,
                    ReceiptEmail = "esltnk@gmail.com",
                };
                //Make Payment
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        private bool ValidateCard()
        {
            if (CreditCardModel.Number.Length == 16 && ExpMonth.Length == 2 && ExpYear.Length == 2 && CreditCardModel.Cvc.Length == 3)
            {
            }
            return true;
        }

        #endregion Method
    }
}
