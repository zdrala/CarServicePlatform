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
    public partial class frmRequests : Form
    {
        private readonly APIService _requestService = new APIService("request");
        private readonly int? _carserviceID;
        public frmRequests(int? id)
        {
            InitializeComponent();
            _carserviceID = id;
        }

        private async void frmRequests_Load(object sender, EventArgs e)
        {
            var list = await _requestService.Get<List<Data.Model.Request>>(new Data.Requests.RequestSearch() { carserviceID = _carserviceID });
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = list;
           
        }
        private async void LoadAgain()
        {
            var list = await _requestService.Get<List<Data.Model.Request>>(new Data.Requests.RequestSearch() { carserviceID = _carserviceID });
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = list;
        }
        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var _requestID = int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString());
            frmRequestDetails frm = new frmRequestDetails(_requestID);
            frm.Show();
        }

        private  void frmRequests_Activated(object sender, EventArgs e)
        {
               this.LoadAgain();
        }
    }
}
