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
    public partial class frmSchedules : Form
    {
        private readonly APIService _scheduleService = new APIService("schedule");
        private readonly int? _carServiceID = null;
        public frmSchedules(int? id=null)
        {
            InitializeComponent();
            _carServiceID = id;
        }

        private async void frmSchedules_Load(object sender, EventArgs e)
        {
            var request = new ScheduleRequest()
            {
                ScheduleStatusID=1,
                CarServiceID=_carServiceID.GetValueOrDefault(),
                AdminSearch=true
            };
            var modelList = await _scheduleService.Get<List<Data.Model.Schedule>>(request);
            dgvSchedules.AutoGenerateColumns = false;
            dgvSchedules.DataSource = modelList;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var request = new ScheduleRequest()
            {
                ScheduleStatusID = 0,
                userName = txtUserName.Text,
                userLastName = txtUserLastName.Text,
                CarServiceID = _carServiceID.GetValueOrDefault(),
                AdminSearch = true
            };
            var modelList = await _scheduleService.Get<List<Data.Model.Schedule>>(request);
            dgvSchedules.AutoGenerateColumns = false;
            dgvSchedules.DataSource = modelList;
        }

        private async void btnFinishedSchedules_Click(object sender, EventArgs e)
        {
            var request = new ScheduleRequest()
            {
                ScheduleStatusID = 2,
                CarServiceID = _carServiceID.GetValueOrDefault(),
                AdminSearch=true
            };
            var modelList = await _scheduleService.Get<List<Data.Model.Schedule>>(request);
            dgvSchedules.AutoGenerateColumns = false;
            dgvSchedules.DataSource = modelList;
        }

        private void dgvSchedules_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var _scheduleID = int.Parse(dgvSchedules.SelectedRows[0].Cells[0].Value.ToString());
            frmScheduleDetails frm = new frmScheduleDetails(_scheduleID,_carServiceID);
            frm.Show();
        }

        private async void btnActiveSchedules_Click(object sender, EventArgs e)
        {
            var request = new ScheduleRequest()
            {
                ScheduleStatusID = 1,
                CarServiceID = _carServiceID.GetValueOrDefault(),
                AdminSearch = true
            };
            var modelList = await _scheduleService.Get<List<Data.Model.Schedule>>(request);
            dgvSchedules.AutoGenerateColumns = false;
            dgvSchedules.DataSource = modelList;
        }
    }
}
