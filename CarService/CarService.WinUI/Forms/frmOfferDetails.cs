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
    public partial class frmOfferDetails : Form
    {
        private readonly APIService _offerItemsService = new APIService("offeritems");
        private readonly int _offerID;
        public frmOfferDetails(int id)
        {
            InitializeComponent();
            _offerID = id;
        }

        private async void frmOfferDetails_Load(object sender, EventArgs e)
        {
            var model = await _offerItemsService.GetById<Data.ViewModel.OfferItemsVM>(_offerID);
            txtScheduleDate.Text = model.Date;
            txtUserNameAndCar.Text = model.User + " | " + model.UserCar;
            txtStatus.Text = model.Status;

            dgvSelectedItems.AutoGenerateColumns = false;
            dgvSelectedItems.DataSource = model.listOfParts;
        }
    }
}
