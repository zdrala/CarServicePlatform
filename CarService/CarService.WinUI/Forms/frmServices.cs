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
    public partial class frmServices : Form
    {
        private readonly APIService _apiService = new APIService("services");
        private readonly APIService _apiCarService = new APIService("CarService");
        private readonly int? _carServiceID = null;
        public frmServices(int? id=null)
        {
            InitializeComponent();

            _carServiceID = id;
        }

        private async void frmServices_Load(object sender, EventArgs e)
        {
            var entity = await _apiCarService.GetById<Data.Model.CarService>(_carServiceID);
            txtCarServiceName.Text = entity.CarServiceName;

            var allServices = await _apiService.Get<List<Data.Model.Services>>(null);
            var list = new List<Data.Model.Services>();
            foreach(var x in allServices)
            {
                if(x.CarServiceID==_carServiceID)
                {
                    list.Add(new Data.Model.Services
                    {
                        ServiceID=x.ServiceID,
                        CarServiceID=x.CarServiceID,
                        ServiceName=x.ServiceName,
                        ServicePrice=x.ServicePrice,
                        ServiceTime=x.ServiceTime,
                        Description=x.Description

                    });
                }
            }

            dgvServices.DataSource = list;
          
            
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
       



            frmAddingUpdateService frm = new frmAddingUpdateService(_carServiceID,null);
            frm.Show();
     
        }

        private async Task frmServices_LoadList()
        {


            var allServices = await _apiService.Get<List<Data.Model.Services>>(null);
            var list = new List<Data.Model.Services>();
            foreach (var x in allServices)
            {
                if (x.CarServiceID == _carServiceID)
                {
                    list.Add(new Data.Model.Services
                    {
                        ServiceID = x.ServiceID,
                        CarServiceID = x.CarServiceID,
                        ServiceName = x.ServiceName,
                        ServicePrice = x.ServicePrice,
                        ServiceTime = x.ServiceTime,
                        Description = x.Description

                    });
                }
            }

            dgvServices.DataSource = list;
        }

       private async void LoadAgain()
        {

            var allServices = await _apiService.Get<List<Data.Model.Services>>(null);
            var list = new List<Data.Model.Services>();
            foreach (var x in allServices)
            {
                if (x.CarServiceID == _carServiceID)
                {
                    list.Add(new Data.Model.Services
                    {
                        ServiceID = x.ServiceID,
                        CarServiceID = x.CarServiceID,
                        ServiceName = x.ServiceName,
                        ServicePrice = x.ServicePrice,
                        ServiceTime = x.ServiceTime,
                        Description = x.Description

                    });
                }
            }

            dgvServices.DataSource = list;
        }

        private void dgvServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var serviceID = int.Parse(dgvServices.SelectedRows[0].Cells[0].Value.ToString());
            frmAddingUpdateService frm = new frmAddingUpdateService(_carServiceID, serviceID);
            frm.Show();
        }

        private async void btnLoadAgain_Click(object sender, EventArgs e)
        {
           await this.frmServices_LoadList();
        }

        private void frmServices_Activated(object sender, EventArgs e)
        {
            this.LoadAgain();
        }
    }
}
