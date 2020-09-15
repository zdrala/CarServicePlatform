using CarService.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarService.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentGatwayPage : ContentPage
    {
        private PaymentGatwayPageViewModel model;
        
        public PaymentGatwayPage(Data.Model.Schedule item)
        {
            InitializeComponent();
            BindingContext = model = new PaymentGatwayPageViewModel() { ScheduleModel=item};
        }
        protected override void OnAppearing()
        {
            Submit_Button.IsEnabled = false;
            ErrorLabel_CardNumber.IsVisible = false;
            ErrorLabel_Cvv.IsVisible = false;
            ErrorLabel_Month.IsVisible = false;
            ErrorLabel_Year.IsVisible = false;
        }
        private void CardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CardNumber.Text.Length > 16)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                CardNumber.Text = RemoveLastCharacter(CardNumber.Text);
                ErrorLabel_CardNumber.Text = "Invalid Card number";
            }
            else if (CardNumber.Text.Length < 1)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                ErrorLabel_CardNumber.Text = "Card number can not be empty !!";

            }
            else
            {
                ErrorLabel_CardNumber.IsVisible = false;

            }
            EnableSubmitButton();
        }
        private void CardNumber_Completed(object sender, System.EventArgs e)
        {
            if (CardNumber.Text.Length > 16 || CardNumber.Text.Length < 12)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                ErrorLabel_CardNumber.Text = "Invalid Card number";
                EnableSubmitButton();
            }
            else
            {
                ErrorLabel_CardNumber.IsVisible = false;
            }
            CardNumber.Unfocus();
            Month.Focus();
            EnableSubmitButton();
        }

        private void Month_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Month.Text.Length < 1)
            {
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "month can not be empty !!";
            }
            else if (Month.Text.Length > 2)
            {
                Month.Text = RemoveLastCharacter(Month.Text);
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "Invalid month !!";
            }
            else
            {
                ErrorLabel_Month.IsVisible = false;
                EnableSubmitButton();
            }

            if (int.TryParse(Month.Text, out int month))
                {
                if (month > 12)
                {
                    ErrorLabel_Month.IsVisible = true;
                    Month.Text = RemoveLastCharacter(Month.Text);
                    EnableSubmitButton();
                }
            }
            EnableSubmitButton();
        }
        private void Month_Completed(object sender, System.EventArgs e)
        {
            Month.Unfocus();
            Year.Focus();
        }

        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Year.Text.Length < 1)
            {
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "month can not be empty !!";
            }
            else if (Year.Text.Length > 2)
            {
                Year.Text = RemoveLastCharacter(Year.Text);
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "Invalid year !!";
            }
            else
            {
                ErrorLabel_Year.IsVisible = false;
                EnableSubmitButton();
            }
      
            EnableSubmitButton();
        }
        private void Year_Completed(object sender, System.EventArgs e)
        {
            Year.Unfocus();
            Cvv.Focus();
        }

        private void Cvv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Cvv.Text.Length < 1)
            {
                ErrorLabel_Cvv.IsVisible = true;
                ErrorLabel_Cvv.Text = "CVV can not be empty !!";
            }
            else if (Cvv.Text.Length > 3)
            {
                Cvv.Text = RemoveLastCharacter(Cvv.Text);
                ErrorLabel_Cvv.IsVisible = true;
                ErrorLabel_Cvv.Text = "Invalid Cvv !!";
            }
            else
            {
                ErrorLabel_Cvv.IsVisible = false;
                EnableSubmitButton();
            }

            EnableSubmitButton();
        }
        private void Cvv_Completed(object sender, System.EventArgs e)
        {
            Cvv.Unfocus();
        }

        private void EnableSubmitButton()
        {
            if (ErrorLabel_CardNumber.IsVisible || ErrorLabel_Cvv.IsVisible || ErrorLabel_Month.IsVisible || ErrorLabel_Year.IsVisible)
            {
                Submit_Button.IsEnabled = false;
            }
            else
            {
                Submit_Button.IsEnabled = true;
            }
        }
        private string RemoveLastCharacter(string str)
        {
            int l = str.Length;
            string text = str.Remove(l - 1, 1);
            return text;
        }

        private async void SetPayment(object sender, EventArgs e)
        {
            bool check = true;
            if (CardNumber.Text == null || Month.Text == null || Year.Text == null || Cvv.Text == null)
            {
               await Application.Current.MainPage.DisplayAlert("Unesite sva polja ispravno", "Greška", "OK");
                check = false;
            }
            bool makePay = false;
            if (check)
            {
                var errorCounter = Regex.Matches(CardNumber.Text, @"[a-zA-Z]").Count;
                if (errorCounter > 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Broj kartice ne smije sadržavat slova!", "Greška", "OK");
                    return;
                }

                errorCounter = Regex.Matches(Month.Text, @"[a-zA-Z]").Count;
                if (errorCounter > 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Mjesec isteka ne smije sadržavat slova!", "Greška", "OK");
                    return;
                }

                errorCounter = Regex.Matches(Year.Text, @"[a-zA-Z]").Count;
                if (errorCounter > 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Godina isteka ne smije sadržavat slova!", "Greška", "OK");
                    return;
                }

                errorCounter = Regex.Matches(Cvv.Text, @"[a-zA-Z]").Count;
                if (errorCounter > 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Cvv ne smije sadržavat slova!", "Greška", "OK");
                    return;
                }
                makePay = true;
            }
            if (makePay)
            {
                model._MakePayment();
                await Application.Current.MainPage.DisplayAlert("Operacija uspješno izvršena", "Plaćanje izvršeno", "OK");
                await Navigation.PopAsync();
            }
        }

      
    }
}