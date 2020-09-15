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
    public partial class frmSchedulesInProgress : Form
    {
        private readonly APIService _offersService = new APIService("offers");
        private readonly int? _carserviceID;
        public frmSchedulesInProgress(int? id)
        {
            InitializeComponent();
            _carserviceID = id;
        }

        private async void frmSchedulesInProgress_Load(object sender, EventArgs e)
        {
            var modelList = await _offersService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
            {
                AdminSearch = true,
                CarServiceID=_carserviceID.GetValueOrDefault()
            });
            dgvOfferPartsSelected.AutoGenerateColumns = false;
            dgvOfferPartsSelected.DataSource = modelList;
        }

        private void dgvOfferPartsSelected_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var _offerID = int.Parse(dgvOfferPartsSelected.SelectedRows[0].Cells[0].Value.ToString());
            frmOfferDetails frm = new frmOfferDetails(_offerID);
            frm.Show();
        }
    }
}
