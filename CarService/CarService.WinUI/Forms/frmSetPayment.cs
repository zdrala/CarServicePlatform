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
    public partial class frmSetPayment : Form
    {

        private readonly APIService _scheduleService = new APIService("schedule");
        private readonly APIService _requestClientService = new APIService("requestbyclient");
        private readonly APIService _offerItemsService = new APIService("offeritems");
        private readonly APIService _offerService = new APIService("offers");
        private readonly APIService _paymentService = new APIService("payments");
        private readonly APIService _scheduleSecondService = new APIService("schedulesecond");


        private readonly int _scheduleID;
        public frmSetPayment(int sID)
        {
            InitializeComponent();
            _scheduleID = sID;
        }
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
        private async void frmSetPayment_Load(object sender, EventArgs e)
        {
            scheduleVM = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(_scheduleID);


            txtTotalPrice.Text = scheduleVM.totalPrice.ToString() + " KM";

            if(scheduleVM.isPaid)
            {
                btnSetPayment.Visible = false;
                txtLabelHeaderText.Text = "Informacije o uplati klijenta";
                var paymentsList = await _paymentService.Get<List<Data.Model.Payments>>(new PaymentSearchRequest() { scheduleID=scheduleVM.ScheduleID});
                if(paymentsList.Count()>0)
                {
                    var paymentModel = paymentsList.First();
                    if(paymentModel.PaymentTypeID==2)
                    {
                        txtPaymentType.Text = "Online plaćeno kreditnom karticom";
                    }
                 
                }
            }


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
            var paymentModel = await _paymentService.Insert<Data.Model.Payments>(new PaymentInsertRequest() { 
            PaymentDate=DateTime.Now,
            Amount=scheduleVM.totalPrice,
            PaymentTypeID=1,
            ScheduleID=scheduleVM.ScheduleID
            });
            if(paymentModel!=null)
            {
                MessageBox.Show("Evidentirali ste uplatu klijenta.", "Operacija uspješno izvršena.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ScheduleSecondUpdateRequest req = new ScheduleSecondUpdateRequest()
                {
                    updateIsPaid=true
                    
                };
                await _scheduleSecondService.Update<Data.Model.Schedule>(scheduleVM.ScheduleID, req);
                this.Close();
            }
        }
    }
}
