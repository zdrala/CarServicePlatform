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
    public partial class frmSetSchedule : Form
    {
        private readonly APIService _scheduleService = new APIService("schedule");
        private readonly APIService _requestService = new APIService("request");
        private readonly int? _requestID;
        public frmSetSchedule(int? id)
        {
            _requestID = id;
            InitializeComponent();
        }

        private void frmSetSchedule_Load(object sender, EventArgs e)
        {
            TimePicker.Format = DateTimePickerFormat.Time;
            TimePicker.ShowUpDown = true;

            
        }

        private async void btnSetSchedule_Click(object sender, EventArgs e)
        {
            var request = new ScheduleUpsertRequest()
            {
                RequestID= _requestID.GetValueOrDefault(),
                
            };
            var date = new DateTime(dateTimePicker.Value.Year,
                dateTimePicker.Value.Month, dateTimePicker.Value.Day, TimePicker.Value.Hour, TimePicker.Value.Minute,TimePicker.Value.Second);
            request.DateofSchedule = date;
            request.isPaid = false;
            request.totalPrice = 0;
            request.ScheduleStatusID = 1;

            var model = await _scheduleService.Insert<Data.Model.Schedule>(request);
            if (model != null)
            {
                MessageBox.Show("Termin servisiranja uspješno evidentiran!", "Zakazivanje termina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            var modelReq = await _requestService.GetById<Data.Model.Request>(_requestID);
            var UpsertReq = new RequestUpsert()
            {
                RequestID = modelReq.RequestID,
                DateOfRequest = modelReq.DateOfRequest,
                UserID = modelReq.UserID,
                CarServiceID = modelReq.CarServiceID,
                RequestStatusID = 2
            };
           var modelUpdateReq= await _requestService.Update<Data.Model.Request>(_requestID, UpsertReq);
        }
    }
}
