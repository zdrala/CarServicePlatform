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
    public partial class frmScheduleDetails : Form
    {
        private readonly APIService _scheduleService = new APIService("schedule");
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _subCategoryService = new APIService("carpartsubcategory");
        private readonly APIService _offerService = new APIService("offers");
        private readonly APIService _offerItemsService = new APIService("offeritems");
        private readonly APIService _carPartsService = new APIService("carparts");
        private readonly APIService _carService = new APIService("carservice");

        private readonly APIService _scheduleSecondService = new APIService("schedulesecond");

        private readonly APIService _requestClientService = new APIService("requestbyclient");

        private readonly APIService _userService = new APIService("user");

        private readonly APIService _ticketService = new APIService("ticket");
        private readonly int _scheduleID;
        private readonly int? _carserviceID;


        public Data.ViewModel.OffersVM OfferVM { get; set; }
        public Data.ViewModel.OfferItemsVM OfferItemsVM { get; set; }
        public Data.ViewModel.RequestVM RequestVM { get; set; }
        public frmScheduleDetails(int id,int? csID)
        {
            InitializeComponent();
            _scheduleID = id;
            _carserviceID = csID;
        }
        Data.ViewModel.ScheduleVM scheduleVM=new Data.ViewModel.ScheduleVM();

  
        private async void frmScheduleDetails_Load(object sender, EventArgs e)
        {
            scheduleVM = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(_scheduleID);
            txtScheduleDate.Text = scheduleVM.Date;
            txtClient.Text = scheduleVM.User + " | " + scheduleVM.UserCar;
            txtStatusSchedule.Text = scheduleVM.Status;
            txtIsPaidSchedule.Text = scheduleVM.isPaidString;
            btnDeleteSchedule.Visible = false;
            LabelTotalPrice.Visible = false;
            txtTotalPrice.Text = "";
            btnShowPaymentDetails.Visible = false;
            if (scheduleVM.offerCreated)
            {
                btnSendOffer.Enabled = false;
                txtIsOfferSent.Visible = true;
                //cmbPartsSubCategories.Visible = false;
              
                btnAddToOfferList.Enabled = false;

                //txtSelectedCategory.Visible = false;
                //txtSubCategoryName.Visible = false;
                //txtQuantityNeeded.Visible = false;
                //txtNeededQuantity.Visible = false;
                txtNeededQuantity.ReadOnly = true;
                txtNeededQuantity.Enabled = false;
                
            }
            else
            {
                cmbPartsSubCategories.Visible = true;
                btnSendOffer.Visible = true;
                txtIsOfferSent.Visible = false;
                btnAddToOfferList.Visible = true;

                txtSelectedCategory.Visible = true;
                txtSubCategoryName.Visible = true;
                txtQuantityNeeded.Visible = true;
                txtNeededQuantity.Visible = true;
            }
            if (scheduleVM.ScheduleStatusID == 2)
            {
                btnFinishSchedule.Visible = false;
                btnDeleteSchedule.Visible = true;

                var ticketList = await _ticketService.Get<List<Data.Model.Ticket>>(new TicketSearchRequest() { ScheduleID=scheduleVM.ScheduleID});

                if (ticketList.Count() > 0)
                {
                    var ticketModel = ticketList.First();
                    if (ticketModel != null)
                    {
                        txtLabelCreateTicket.Text = "Već ste poslali online račun klijentu!";
                        txtLabelCreateTicket.BackColor = System.Drawing.Color.Green;
                        btnCreateOnlineTicket.Enabled = false;
                    }

                }

                if(scheduleVM.isPaid)
                {
                    btnSetPaymentDetails.Enabled = false;
                    btnShowPaymentDetails.Visible = true;
                }


                var listOffer = await _offerService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
                {
                    ScheduleID = scheduleVM.ScheduleID
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

                double UkupnaCijena = 0;
                foreach (var x in RequestVM.ListOfRequestedServices)
                {
                    UkupnaCijena += x.ServicePrice;
                }
                if (OfferItemsVM != null)
                {
                    if (OfferItemsVM.listOfParts.Count() > 0)
                    {
                        foreach (var i in OfferItemsVM.listOfParts)
                        {
                            UkupnaCijena += i.CarPartPrice * i.QuantityNeeded;
                        }
                    }
                }
                LabelTotalPrice.Visible = true;
                txtTotalPrice.Text = UkupnaCijena.ToString() + " KM";
                ScheduleSecondUpdateRequest req = new ScheduleSecondUpdateRequest()
                {
                    updateTotalPrice = true,
                    TotalPrice = UkupnaCijena
                };
                await _scheduleSecondService.Update<Data.Model.Schedule>(scheduleVM.ScheduleID, req);

            }
            scheduleVM.itemsforSelect.Insert(0,new Data.Model.CarPartSubCategory()
                {
              SubCategoryID=0,
              SubCategoryName="Odaberi podkategoriju dijela"
            });
            cmbPartsSubCategories.ValueMember = "SubCategoryID";
            cmbPartsSubCategories.DisplayMember = "SubCategoryName";
            cmbPartsSubCategories.DataSource = scheduleVM.itemsforSelect;

            dgvSelectedSubCategories.AutoGenerateColumns = false;
            dgvSelectedSubCategories.DataSource = scheduleVM.selectedSubCategories;
        }

        private async void cmbPartsSubCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _value = int.Parse(cmbPartsSubCategories.SelectedValue.ToString());
            if (_value > 0)
            {
                var subCategoryModel = await _subCategoryService.GetById<Data.Model.CarPartSubCategory>(_value);
                txtSubCategoryName.Text = subCategoryModel.SubCategoryName;
            }
            else
                txtSubCategoryName.Text = null;
        }

        private void cmbPartsSubCategories_Validating(object sender, CancelEventArgs e)
        {
            int _value = int.Parse(cmbPartsSubCategories.SelectedValue.ToString());

            bool check = false;
            if(_value>0)
            {
                foreach(var x in scheduleVM.selectedSubCategories)
                {
                    if(x.subCategoryID==_value)
                    {
                        errorProvider.SetError(cmbPartsSubCategories, "Ovu Podkategoriju ste već odabrali i nalazi se na listi!");
                        e.Cancel = true;
                        check = true;
                    }
                }
                if (!check)
                    errorProvider.SetError(cmbPartsSubCategories, null);
            }
            else
                errorProvider.SetError(cmbPartsSubCategories, null);
        }

        private void txtNeededQuantity_Validating(object sender, CancelEventArgs e)
        {

            bool check = false;
            if (string.IsNullOrWhiteSpace(txtNeededQuantity.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNeededQuantity, "Obavezno polje!");
                check = true;
            }
            else
            {
                if (int.TryParse(txtNeededQuantity.Text, out int value))
                {
                    if (int.Parse(txtNeededQuantity.Text.ToString()) < 1)
                    {
                        e.Cancel = true;
                        errorProvider.SetError(txtNeededQuantity, "Unesena vrijednost mora biti veća od 0!");
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
                    errorProvider.SetError(txtNeededQuantity, "Slova nisu dozvoljena!");
                    check = true;
                }


            }
            if (!check)
                errorProvider.SetError(txtNeededQuantity, null);
        }

        bool listDeleted = false;
        private async void btnAddToOfferList_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrWhiteSpace(txtSubCategoryName.Text))
            {
                MessageBox.Show("Odaberi podkategoriju dijelova!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ValidateChildren())
            {
                int _value = int.Parse(cmbPartsSubCategories.SelectedValue.ToString());
                if (_value > 0)
                {
                    var subCategoryModel = await _subCategoryService.GetById<Data.Model.CarPartSubCategory>(_value);

                    if (!listDeleted)
                    {
                        scheduleVM.selectedSubCategories = null;
                        scheduleVM.selectedSubCategories = new List<Data.ViewModel.ScheduleVM.ItemsSelected>();
                        listDeleted = true;
                    }
                    scheduleVM.selectedSubCategories.Add(new Data.ViewModel.ScheduleVM.ItemsSelected()
                    {
                        subCategoryID = subCategoryModel.SubCategoryID,
                        SubCategoryName = subCategoryModel.SubCategoryName,
                        QuantityNeeded = int.Parse(txtNeededQuantity.Text.ToString())
                    });
                    dgvSelectedSubCategories.DataSource = null;
                    dgvSelectedSubCategories.DataSource = scheduleVM.selectedSubCategories;
                }
            }
        }

        private async void btnSendOffer_Click(object sender, EventArgs e)
        {
            if (scheduleVM.selectedSubCategories.Count() == 0)
            {
                MessageBox.Show("Niste odabrali niti jednu kategoriju, i ne možete poslati ponudu klijentu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(scheduleVM.ScheduleStatusID==2)
            {
                MessageBox.Show("Ne možete slati ponudu na terminu koji je završen!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var request = new Data.Requests.OfferInsertRequest()
            {
                ScheduleID = _scheduleID,
                isLocked = false,
                partsSelected = false
           
            };
            var model = await _offerService.Insert<Data.Model.Offer>(request);

            if (model != null)          
            {
                foreach (var x in scheduleVM.selectedSubCategories)
                {
                    var carPartsSubCategoryList = await _carPartsService.Get<List<Data.ViewModel.CarPartsVM>>(new CarPartsSearchRequest()
                    {
                        subCategoryID = x.subCategoryID,
                        CarServiceID=_carserviceID.GetValueOrDefault()
                    });

                    foreach (var c in carPartsSubCategoryList)
                    {
                        var itemReq = new Data.Requests.OfferItemsInsertRequest()
                        {
                            OfferID = model.OfferID,
                            subCategoryID = c.SubCategoryID,
                            CarPartID = c.CarPartID,
                            QuantityNeeded = x.QuantityNeeded,
                            isSelected = false
                        };
                        await _offerItemsService.Insert<Data.Model.OfferItems>(itemReq);
                    }
                }
            }
            if(model!=null)
            {
                MessageBox.Show("Poslali ste ponudu klijentu!", "Ponuda uspješno poslana!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                 this.LoadAgain();
            }
        }

        private async void LoadAgain()
        {
            scheduleVM = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(_scheduleID);
            txtScheduleDate.Text = scheduleVM.Date;
            txtClient.Text = scheduleVM.User + " | " + scheduleVM.UserCar;
            txtStatusSchedule.Text = scheduleVM.Status;
            txtIsPaidSchedule.Text = scheduleVM.isPaidString;
            btnDeleteSchedule.Visible = false;
            LabelTotalPrice.Visible = false;
            txtTotalPrice.Text = "";
            btnShowPaymentDetails.Visible = false;
            if (scheduleVM.offerCreated)
            {
                btnSendOffer.Enabled = false;
                txtIsOfferSent.Visible = true;
                //cmbPartsSubCategories.Visible = false;
                btnAddToOfferList.Enabled = false;

                //txtSelectedCategory.Visible = false;
                //txtSubCategoryName.Visible = false;
                //txtQuantityNeeded.Visible = false;
                //txtNeededQuantity.Visible = false;
                txtNeededQuantity.ReadOnly = true;
                txtNeededQuantity.Enabled = false;
                txtNeededQuantity.Text = "";
            }
            else
            {
                cmbPartsSubCategories.Visible = true;
                btnSendOffer.Visible = true;
                txtIsOfferSent.Visible = false;
                btnAddToOfferList.Visible = true;

                txtSelectedCategory.Visible = true;
                txtSubCategoryName.Visible = true;
                txtQuantityNeeded.Visible = true;
                txtNeededQuantity.Visible = true;
            }
            if(scheduleVM.ScheduleStatusID==2)
            {
                btnFinishSchedule.Visible = false;
                btnDeleteSchedule.Visible = true;

                var ticketList = await _ticketService.Get<List<Data.Model.Ticket>>(new TicketSearchRequest() { ScheduleID = scheduleVM.ScheduleID });

                if (ticketList.Count() > 0)
                {
                    var ticketModel = ticketList.First();
                    if (ticketModel != null)
                    {
                        txtLabelCreateTicket.Text = "Već ste poslali online račun klijentu!";
                        txtLabelCreateTicket.BackColor = System.Drawing.Color.Green;
                        btnCreateOnlineTicket.Enabled = false;
                    }

                }



                if (scheduleVM.isPaid)
                {
                    btnSetPaymentDetails.Enabled = false;
                    btnShowPaymentDetails.Visible = true;
                }

                var listOffer = await _offerService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
                {
                    ScheduleID = scheduleVM.ScheduleID
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

                double UkupnaCijena = 0;
                foreach (var x in RequestVM.ListOfRequestedServices)
                {
                    UkupnaCijena += x.ServicePrice;
                }
                if (OfferItemsVM != null)
                {
                    if (OfferItemsVM.listOfParts.Count() > 0)
                    {
                        foreach (var i in OfferItemsVM.listOfParts)
                        {
                            UkupnaCijena += i.CarPartPrice * i.QuantityNeeded;
                        }
                    }
                }
                LabelTotalPrice.Visible = true;
                txtTotalPrice.Text = UkupnaCijena.ToString() + " KM";
                ScheduleSecondUpdateRequest req = new ScheduleSecondUpdateRequest()
                {
                    updateTotalPrice = true,
                    TotalPrice = UkupnaCijena
                };
                await _scheduleSecondService.Update<Data.Model.Schedule>(scheduleVM.ScheduleID, req);
            }
            scheduleVM.itemsforSelect.Insert(0, new Data.Model.CarPartSubCategory()
            {
                SubCategoryID = 0,
                SubCategoryName = "Odaberi podkategoriju dijela"
            });
            cmbPartsSubCategories.ValueMember = "SubCategoryID";
            cmbPartsSubCategories.DisplayMember = "SubCategoryName";
            cmbPartsSubCategories.DataSource = scheduleVM.itemsforSelect;

            dgvSelectedSubCategories.AutoGenerateColumns = false;
            dgvSelectedSubCategories.DataSource = scheduleVM.selectedSubCategories;
        }

        private async void btnFinishSchedule_Click(object sender, EventArgs e)
        {
            var scheduleModel = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(_scheduleID);
            var request = new ScheduleUpsertRequest()
            {
                RequestID=scheduleModel.RequestID,
                ScheduleStatusID=2,
                DateofSchedule=scheduleModel.DateofSchedule,
                isPaid=scheduleModel.isPaid,
                totalPrice=scheduleModel.totalPrice
            };

            var requestModel = await _requestService.GetById<Data.Model.Request>(scheduleModel.RequestID);

            var carServiceModel = await _carService.GetById<Data.Model.CarService>(requestModel.CarServiceID);

            var userModel = await _userService.GetById<Data.Model.Users> (requestModel.UserID);
            var updatedModel = await _scheduleService.Update<Data.Model.Schedule>(_scheduleID, request);
            if (updatedModel != null)
            {
                MessageBox.Show("Označili ste termin završenim, i poslali ste mail klijentu." , "Termin završen!", MessageBoxButtons.OK,MessageBoxIcon.Information);

                Helpers.EmailSending.SendMail_ScheduleFinished(requestModel.UserNameLastName, carServiceModel.CarServiceName,userModel.Email,scheduleModel.Date);
                this.LoadAgain();
            }
        }

        private async void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            var model = await _scheduleService.Delete<Data.Model.Schedule>(_scheduleID);
            if(model!=null)
            {
                MessageBox.Show("Obrisali ste termin!", "Termin uspješno obrisan", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnSetPaymentDetails_Click(object sender, EventArgs e)
        {

            if (scheduleVM.ScheduleStatusID == 1)
            {
                MessageBox.Show("Termin mora biti završen da bi mogli postaviti uplatu!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmSetPayment frm = new frmSetPayment(_scheduleID);
            frm.Show();
        }

        private void frmScheduleDetails_Activated(object sender, EventArgs e)
        {
            this.LoadAgain();
        }

        private void btnShowPaymentDetails_Click(object sender, EventArgs e)
        {
            frmSetPayment frm = new frmSetPayment(_scheduleID);
            frm.Show();
        }

        private void btnCreateOnlineTicket_Click(object sender, EventArgs e)
        {
            if(scheduleVM.isPaid)
            {
                MessageBox.Show("Ne možete kreirati Online račun jer je ovaj termin plaćen!", "Upozorenje- Nije moguće kreirati online račun", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (scheduleVM.ScheduleStatusID==1)
            {
                MessageBox.Show("Ne možete kreirati Online račun jer ovaj termin nije završen!", "Upozorenje- Nije moguće kreirati online račun", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmCreateOnlineTicket frm = new frmCreateOnlineTicket(_scheduleID);
            frm.Show();
        }
    }
}
