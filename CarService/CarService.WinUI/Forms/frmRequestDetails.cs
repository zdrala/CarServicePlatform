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
    public partial class frmRequestDetails : Form
    {
        private readonly APIService _requestService = new APIService("request");
        private readonly int? _requestID;
        public frmRequestDetails(int? id)
        {
            InitializeComponent();
            _requestID = id;
        }

        private  async void frmRequestDetails_Load(object sender, EventArgs e)
        {
            var model = await _requestService.GetById<Data.Model.Request>(_requestID);
            var list = model.ListOfRequestedServices;

            txtUserNameLastName.Text = model.UserNameLastName;
            txtCarModel.Text = model.UserCar;

            listBox1.DataSource = list;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            frmSetSchedule frm = new frmSetSchedule(_requestID);
            frm.Show();
            this.Close();
        }

        private async void btnDecline_Click(object sender, EventArgs e)
        {
            var modelReq = await _requestService.GetById<Data.Model.Request>(_requestID);
            var UpsertReq = new RequestUpsert()
            {
                RequestID = modelReq.RequestID,
                DateOfRequest = modelReq.DateOfRequest,
                UserID = modelReq.UserID,
                CarServiceID = modelReq.CarServiceID,
                RequestStatusID = 3
            };
            var modelUpdateReq = await _requestService.Update<Data.Model.Request>(_requestID, UpsertReq);
            if(modelUpdateReq!=null)
            {
                MessageBox.Show("Odbili ste zahtjev za servisiranje!","Odbijanje zahtjeva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
