using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService.WinUI.Forms
{
    public partial class frmLogin : Form
    {
        APIService _userService = new APIService("user");
        APIService _carService = new APIService("carservice");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Obavezno unesite korisničko ime i lozinku!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var request = new UserSearchRequest()
                {
                    username = txtUsername.Text
                };
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;
                var user = await _userService.Get<List<Data.Model.Users>>(request);
                var obj = user.First();
                if (obj.RoleID == 2)
                {
                    MessageBox.Show("Administrator sa unesenim kredencijalima ne postoji!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Uspješno ste se logovali!", "Uspješna prijava", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CarServiceSearchRequest req = new CarServiceSearchRequest()
                {
                    userID=obj.UserID
                };
                var listCS = await _carService.Get<List<Data.Model.CarService>>(req);
                var objCS = listCS.First();

                frmCarServiceMainMenu frmCS = new frmCarServiceMainMenu(objCS.CarServiceID);
                frmCS.Show();
                this.Hide();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Pogrešno korisničko ime ili lozinka!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtRegisterCarService_Click(object sender, EventArgs e)
        {
            frmOwnerCarServiceRegister frm = new frmOwnerCarServiceRegister();
            frm.Show();
        }
    }
}
