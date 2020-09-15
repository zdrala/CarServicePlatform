
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;




using Newtonsoft.Json;

using System.Threading;
using System.Windows;
using System.Web.UI.WebControls;


namespace CarService.WinUI.Forms
{
    public partial class frmCompletedServicesByDate : Form
    {
        private readonly APIService _CountCompletedServicesByDateService = new APIService("CountCompletedServicesByDate");
        private readonly int? _carServiceID;
        public frmCompletedServicesByDate(int? id)
        {
            InitializeComponent();
            _carServiceID = id;
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                DateTime dateFrom = new DateTime(DateFrom.Value.Year, DateFrom.Value.Month, DateFrom.Value.Day, 00, 00, 01, 01);
                DateTime dateTo = new DateTime(DateTo.Value.Year, DateTo.Value.Month, DateTo.Value.Day, 23, 59, 59, 59);


                var request = new Data.Requests.CompletedServicesSearchByDateRequest()
                {
                    DateFrom = dateFrom,
                    DateTo = dateTo,
                    carServiceID = _carServiceID.GetValueOrDefault()
                };


                var model = await _CountCompletedServicesByDateService.Get<Data.Model.CountCompletedServices>(request);

                txtDateTo.Text = request.DateTo.ToString("dd.MM.yyyy");
                txtDateFrom.Text = request.DateFrom.ToString("dd.MM.yyyy");
                dgvServices.AutoGenerateColumns = false;
                dgvServices.DataSource = model.servicesList;
            }
        }

        private async void btnToPDF_Click(object sender, EventArgs e)
        {

            DateTime dateFrom = new DateTime(DateFrom.Value.Year, DateFrom.Value.Month, DateFrom.Value.Day, 00, 00, 01, 01);
            DateTime dateTo = new DateTime(DateTo.Value.Year, DateTo.Value.Month, DateTo.Value.Day, 23, 59, 59, 59);


            var request = new Data.Requests.CompletedServicesSearchByDateRequest()
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                carServiceID = _carServiceID.GetValueOrDefault()
            };


            var model = await _CountCompletedServicesByDateService.Get<Data.Model.CountCompletedServices>(request);

            if(model.servicesList.Count()==0)
            {
                MessageBox.Show("U odabranom periodu nema obavljene niti jedne usluge, te nije moguće procesirati izvještaj!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var fileName = request.DateFrom.ToString("dd.MM.yyyy") + "_" + request.DateTo.ToString("dd.MM.yyyy") + ".pdf";
            var path = "..\\..\\Reports\\izvjestaj_" + fileName;

            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            iText.Layout.Element.Paragraph header = new iText.Layout.Element.Paragraph("Izvještaj o broju obavljenih usluga u periodu " + request.DateFrom.ToString("dd.MM.yyyy.")
                        + " - " + request.DateTo.ToString("dd.MM.yyyy.")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    document.Add(header);

                    float[] columnWidths = {  5, 4};
            iText.Layout.Element.Table table = new iText.Layout.Element.Table(UnitValue.CreatePercentArray(columnWidths));
                    table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            Cell[] headerFooter = new Cell[]{
                new Cell().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Usluga")),
                new Cell().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Obavljena puta")),
         
            };

            foreach (Cell hfCell in headerFooter)
            {
                table.AddHeaderCell(hfCell);
            }

            foreach(var x in model.servicesList)
            {
                table.AddCell(new Cell().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).Add(new Paragraph(x.ServiceName)));
                table.AddCell(new Cell().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).Add(new Paragraph(x.Count.ToString())));
        
            }

            document.Add(table);


            MessageBox.Show("Uspješno ste kreirali izvještaj", "Kreiranje izvještaja",MessageBoxButtons.OK, MessageBoxIcon.Information);


            document.Close();

            System.Diagnostics.Process.Start(path);


        }

        private void DateTo_Validating(object sender, CancelEventArgs e)
        {
            DateTime dateFrom = new DateTime(DateFrom.Value.Year, DateFrom.Value.Month, DateFrom.Value.Day, 00, 00, 00, 00);
            DateTime dateTo = new DateTime(DateTo.Value.Year, DateTo.Value.Month, DateTo.Value.Day, 00, 00, 00, 00);
            if (dateTo<dateFrom)
            {
                errorProvider.SetError(DateTo, "Datum DO ne može biti manji od datuma OD!");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(DateTo, null);
        }
    }
}
