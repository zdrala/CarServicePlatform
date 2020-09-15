using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService.WinUI.Forms
{
    public partial class frmCarServiceDetails : Form
    {
        private readonly APIService _carService = new APIService("carservice");
        private readonly int? _carserviceId = null;
        public frmCarServiceDetails(int? id=null)
        {
            InitializeComponent();
            _carserviceId = id;
        }
        CarServiceUpsertRequest request = new CarServiceUpsertRequest();
        public byte[] photoExist;
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

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Photo = file;
                txtPhotoPath.Text = fileName;

                Image image = Image.FromFile(fileName);
                PictureBox.Image = image;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                request.CarServiceName = txtCarServiceName.Text;
                request.Street = txtStreet.Text;
                request.PhoneNumber = txtPhoneNumber.Text;
                if (string.IsNullOrWhiteSpace(txtPhotoPath.Text))
                    request.Photo = photoExist;
                var model = await _carService.Update<Data.Model.CarService>(_carserviceId, request);
                MessageBox.Show("Podaci uspješno izmijenjeni", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private async void frmCarServiceDetails_Load(object sender, EventArgs e)
        {
            var modelCS = await _carService.GetById<Data.Model.CarService>(_carserviceId);
            txtCarServiceName.Text = modelCS.CarServiceName;
            txtStreet.Text = modelCS.Street;
            txtPhoneNumber.Text = modelCS.PhoneNumber;
            if (modelCS.Photo.Length > 5)
            {
                photoExist = modelCS.Photo;
                PictureBox.Image = byteArrayToImage(modelCS.Photo);
            }
        }
        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
    }
}
