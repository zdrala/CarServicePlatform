using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarService.Data.Requests;
namespace CarService.WinUI.Forms
{
    public partial class frmAddingUpdateService : Form
    {
        private readonly APIService _apiService = new APIService("services");
        private readonly int? _CarServiceID = null;
        private readonly int? _ServiceID = null;
        public frmAddingUpdateService(int? id=null,int? serviceID=null)
        {
            InitializeComponent();
            _CarServiceID = id;
            _ServiceID = serviceID;
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren())
            {

                var list = await _apiService.Get<List<Data.Model.Services>>(new ServicesSearchRequest() { CarServiceID = _CarServiceID });

                foreach (var x in list)
                {
                    
                    if (x.ServiceName.ToLower() == txtServiceName.Text.ToLower()&&x.ServiceID!=_ServiceID)
                    {
                        MessageBox.Show("Usluga sa nazivom: "+txtServiceName.Text+" već postoji na listi!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
              
                }



                var request = new ServicesInsertUpdateRequest()
                {
                    ServiceName = txtServiceName.Text,
                    ServicePrice = double.Parse(txtServicePrice.Text.ToString()),
                    Description = txtDescription.Text,
                    ServiceTime = txtServiceTime.Text,
                    CarServiceID = _CarServiceID.Value
                };
                Data.Model.Services entity = null;
                if (!_ServiceID.HasValue)
                {
                    entity = await _apiService.Insert<Data.Model.Services>(request);
                    if (entity != null)
                    {
                        MessageBox.Show("Uspješno Dodana usluga!");
                        this.Close();

                    }
                }
                else
                {
                    entity = await _apiService.Update<Data.Model.Services>(_ServiceID, request);
                    if (entity != null)
                    {
                        MessageBox.Show("Uspješno izmijenjena usluga!");
                        this.Close();

                    }
                }
                if(entity==null)
                {
                    MessageBox.Show("Desila se greška!");
                    this.Close();
                }
               
            }
        }

        private async void frmAddingUpdateService_Load(object sender, EventArgs e)
        {
            if(_ServiceID.HasValue)
            {
                var entity = await _apiService.GetById<Data.Model.Services>(_ServiceID);
                txtServiceName.Text = entity.ServiceName;
                txtServicePrice.Text = entity.ServicePrice.ToString();
                txtDescription.Text = entity.Description;
                txtServiceTime.Text = entity.ServiceTime;
           
            }
        }

        private void txtServiceName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text)||txtServiceName.Text.Length<5)
            {
                
                errorProvider.SetError(txtServiceName, "Obavezno polje! Minimalna unesena dužina je 5 karaktera!");
            }
            else
            {
                errorProvider.SetError(txtServiceName, null);
            }
        }

        private void txtServicePrice_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtServicePrice.Text))
            {
                
                errorProvider.SetError(txtServicePrice, "Obavezno polje!");
                check = true;
            }
            else
            {
                if (int.TryParse(txtServicePrice.Text, out int value))
                {
                    if (int.Parse(txtServicePrice.Text.ToString()) < 1)
                    {
                        e.Cancel = true;
                        errorProvider.SetError(txtServicePrice, "Unesena vrijednost mora biti veća od 0!");
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }
                }
                else
                {
                    e.Cancel = true;
                    errorProvider.SetError(txtServicePrice, "Slova nisu dozvoljena!");
                    check = true;
                }


            }
          if(!check)
          errorProvider.SetError(txtServicePrice, null);
            
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                
                errorProvider.SetError(txtDescription, "Obavezno polje!");
            }
            else
            {
                errorProvider.SetError(txtDescription, null);
            }
        }

        private void txtServiceTime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceTime.Text)||!int.TryParse(txtServiceTime.Text,out int value))
            {
                
                errorProvider.SetError(txtServiceTime, "Obavezno polje!Dozvoljen unos brojeva samo!");
            }
            else
            {
                errorProvider.SetError(txtServiceTime, null);
            }
        }
    }
}
