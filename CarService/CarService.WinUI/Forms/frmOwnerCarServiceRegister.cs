using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService.WinUI.Forms
{
    public partial class frmOwnerCarServiceRegister : Form
    {
        private readonly APIService _citiesService = new APIService("cities");
        private readonly APIService _userService = new APIService("userregister");
        private readonly APIService _carService = new APIService("carserviceregister");
        public frmOwnerCarServiceRegister()
        {
            InitializeComponent();
        }

        private async void frmOwnerCarServiceRegister_Load(object sender, EventArgs e)
        {
            var list = await _citiesService.Get<List<Data.Model.Cities>>(null);
     
            cmbCities.DisplayMember = "CityName";
            cmbCities.ValueMember = "CityID";
            cmbCities.DataSource = list;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new UserInsertUpdateRequest()
                {
                    FirstName = txtName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dateTimePicker.Value,
                    CityID = int.Parse(cmbCities.SelectedValue.ToString()),
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPasswordConfirmation.Text,
                    RoleID = 1
                };

                var model = await _userService.Insert<Data.Model.Users>(request);
                CarServiceUpsertRequest csRequest = new CarServiceUpsertRequest()
                {
                    CarServiceName = txtCarServiceName.Text,
                    Street = txtStreet.Text,
                    CityID = model.CityID,
                    PhoneNumber = model.PhoneNumber,
                    UserID = model.UserID,
                    Owner = model.FirstName + " " + model.LastName
                };
                var modelCS = await _carService.Insert<Data.Model.CarService>(csRequest);

                if (model != null && modelCS != null)
                    MessageBox.Show("Uspješno ste registrovali vaš auto servis. Logirajte se da bi pristupili u menu auto servisa.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //frmLogin frm = new frmLogin();
                //frm.Show();
                this.Hide();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtName.Text)||txtName.Text.Length<3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, "Ime je obavezno polje!Minimalna dužina mora biti 3 karaktera");
                check = true;
            }
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                if (char.IsLower(txtName.Text[0]))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtName, "Prvo slovo imena mora biti veliko!");
                    check = true;
                }
            }
            bool containsInt = txtName.Text.Any(char.IsDigit);
            if(containsInt)
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, "Brojevi nisu dozvoljeni!");
                check = true;
            }

            if (!check)
                errorProvider.SetError(txtName, null);

            
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || txtLastName.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtLastName, "Prezime je obavezno polje!Minimalna dužina mora biti 3 karaktera");
                check = true;
            }
            if (!string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                if (char.IsLower(txtLastName.Text[0]))
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtLastName, "Prvo slovo prezimena mora biti veliko!");
                    check = true;
                }
            }
            bool containsInt = txtLastName.Text.Any(char.IsDigit);
            if (containsInt)
            {
                e.Cancel = true;
                errorProvider.SetError(txtLastName, "Brojevi nisu dozvoljeni!");
                check = true;
            }

            if (!check)
                errorProvider.SetError(txtLastName, null);


        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;

            if (!ValidateEmail(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email mora biti u formatu: nešto@(gmail,hotmail,fit,edu.fit,outlook,yahoo).(ba,com,org)");
                e.Cancel = true;
                check = true;
            }
            else
                errorProvider.SetError(txtEmail, null);

            if (!check)
                errorProvider.SetError(txtEmail, null);

        }
        private bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"([a-z]+)([\\.]?)([a-z]*)([@])(yahoo|outlook|gmail|hotmail|fit|edu.fit)(.ba|.com|.org)");
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtUsername, "Korisničko ime je obavezno polje!Minimalna dužina mora biti 3 karaktera");
                check = true;
            }
            if (!check)
                errorProvider.SetError(txtUsername, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtPassword.Text) )
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, "Unesi lozinku!");
                check = true;
            }
            if (!check)
                errorProvider.SetError(txtPassword, null);
        }

        private void txtPasswordConfirmation_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtPasswordConfirmation.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPasswordConfirmation, "Unesi potvrdu lozinke!");
                check = true;
            }
            if (txtPasswordConfirmation.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPasswordConfirmation, "Potvrda se ne podudara sa gore unesenom lozinkom");
                check = true;
            }
            else
                errorProvider.SetError(txtPasswordConfirmation, null);
               
            if (!check)
                errorProvider.SetError(txtPasswordConfirmation, null);
        }

        private void txtCarServiceName_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtCarServiceName.Text) || txtCarServiceName.Text.Length < 5)
            {
                e.Cancel = true;
                errorProvider.SetError(txtCarServiceName, "Naziv auto servisa je obavezno polje!Minimalna dužina mora biti 5 karaktera");
                check = true;
            }
            if (!check)
                errorProvider.SetError(txtCarServiceName, null);
        }

        private void txtStreet_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtStreet.Text) || txtStreet.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtStreet, "Ulica je obavezno polje!Minimalna dužina mora biti 3 karaktera");
                check = true;
            }
            if (!check)
                errorProvider.SetError(txtStreet, null);
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;

            if (!ValidateNumber(txtPhoneNumber.Text))
            {
                errorProvider.SetError(txtPhoneNumber, "Broj telefona mora biti u formatu: 06X/XXX-XXX");
                e.Cancel = true;
                check = true;
            }
            else
                errorProvider.SetError(txtPhoneNumber, null);

            if (!check)
                errorProvider.SetError(txtPhoneNumber, null);
        }
        private bool ValidateNumber(string number)
        {
            return Regex.IsMatch(number, @"(06[0-9])([/])([0-9]){3}([-])([0-9]){3}$");
        }
    }
    
}
