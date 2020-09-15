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
    public partial class frmCreateOnlineTicket : Form
    {
        private readonly int _scheduleID;
        public frmCreateOnlineTicket(int id)
        {
            InitializeComponent();
            _scheduleID = id;
        }
        private readonly APIService _scheduleService = new APIService("schedule");
        private readonly APIService _requestClientService = new APIService("requestbyclient");
        private readonly APIService _offerItemsService = new APIService("offeritems");
        private readonly APIService _offerService = new APIService("offers");
        private readonly APIService _ticketService = new APIService("ticket");
        public Data.ViewModel.OffersVM OfferVM { get; set; }
        public Data.ViewModel.OfferItemsVM OfferItemsVM { get; set; }
        public Data.ViewModel.RequestVM RequestVM { get; set; }
        Data.ViewModel.ScheduleVM scheduleVM = new Data.ViewModel.ScheduleVM();

        public List<SelectedPart> _selectedParts { get; set; } = new List<SelectedPart>();

        public class SelectedPart
        {
            public int ItemID { get; set; }
            public int CarPartID { get; set; }
            public byte[] Photo { get; set; }
            public string CarPartName { get; set; }
            public double CarPartPrice { get; set; }
            public string Quality { get; set; }
            public string SubCategoryName { get; set; }
            public int QuantityNeeded { get; set; }
            public double inTotal { get; set; }
        }
        private async void frmCreateOnlineTicket_Load(object sender, EventArgs e)
        {
            scheduleVM = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(_scheduleID);


            txtTotalPrice.Text = scheduleVM.totalPrice.ToString() + " KM";

            


            var listOffer = await _offerService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
            {
                ScheduleID = _scheduleID
            });

            if (listOffer.Count() > 0)
                OfferVM = listOffer.First();
            if (OfferVM != null)
            {
                if (OfferVM.partsSelected)
                {

                    OfferItemsVM = await _offerItemsService.GetById<Data.ViewModel.OfferItemsVM>(OfferVM.OfferID);
                }
            }
            RequestVM = await _requestClientService.GetById<Data.ViewModel.RequestVM>(scheduleVM.RequestID);

            dgvServicesList.AutoGenerateColumns = false;
            dgvServicesList.DataSource = RequestVM.ListOfRequestedServices;
            if (OfferItemsVM != null)
            {
                if (OfferItemsVM.listOfParts.Count() > 0)
                {
                    foreach (var x in OfferItemsVM.listOfParts)
                    {
                        _selectedParts.Add(new SelectedPart()
                        {
                            Photo = x.Photo,
                            CarPartName = x.CarPartName,
                            Quality = x.Quality,
                            QuantityNeeded = x.QuantityNeeded,
                            inTotal = x.QuantityNeeded * x.CarPartPrice
                        });
                    }
                }
            }
            dgvCarPartsList.AutoGenerateColumns = false;
            dgvCarPartsList.DataSource = _selectedParts;
        }

        private async void btnSetPayment_Click(object sender, EventArgs e)
        {
            var modelTicket = await _ticketService.Insert<Data.Model.Ticket>(new TicketInsertRequest()
            {
                IssueDate=DateTime.Now,
                ScheduleID=scheduleVM.ScheduleID,
                totalPrice=scheduleVM.totalPrice,
                isProccessed=false
            });

            if(modelTicket!=null)
            {
                MessageBox.Show("Uspješno ste kreirali i poslali online račun klijentu!", "Operacija uspješna", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
