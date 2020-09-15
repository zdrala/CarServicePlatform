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
    public partial class frmCommunications : Form
    {
        private readonly APIService _communicationsService = new APIService("communications");
        private readonly int? _carServiceID;
        public frmCommunications(int? id)
        {
            InitializeComponent();
            _carServiceID = id;
        }

        private async void frmCommunications_Load(object sender, EventArgs e)
        {
            var modelList = await _communicationsService.Get<List<Data.Model.Communication>>(new Data.Requests.CommunicationsSearchRequest()
            {
                carServiceID=_carServiceID.GetValueOrDefault(),
                AdminSearch=true
            });

            dgvQuestions.AutoGenerateColumns = false;
            dgvQuestions.DataSource = modelList;

            // Set the Multiline property to true.
            txtQuestion.Multiline = true;
            // Add vertical scroll bars to the TextBox control.
            txtQuestion.ScrollBars = ScrollBars.Vertical;
            // Allow the RETURN key to be entered in the TextBox control.
           txtQuestion.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            txtQuestion.AcceptsTab = true;
            // Set WordWrap to true to allow text to wrap to the next line.
            txtQuestion.WordWrap = true;
            // Set the default text of the control.

            txtAnswer.Multiline = true;
            // Add vertical scroll bars to the TextBox control.
            txtAnswer.ScrollBars = ScrollBars.Vertical;
            // Allow the RETURN key to be entered in the TextBox control.
            txtAnswer.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            txtAnswer.AcceptsTab = true;
            // Set WordWrap to true to allow text to wrap to the next line.
            txtAnswer.WordWrap = true;
        }

        private int _communicationID = 0;
        private async void dgvQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             _communicationID = int.Parse(dgvQuestions.SelectedRows[0].Cells[0].Value.ToString());

            var model = await _communicationsService.GetById<Data.Model.Communication>(_communicationID);
            txtUsernameLastName.Text = model.UserNameLastName;
            txtQuestion.Text = model.Content;
        }

        private void txtQuestion_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                errorProvider.SetError(txtQuestion, "Niste odabrali pitanje!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtQuestion, null);
            }
        }

        private void txtAnswer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtAnswer, "Unesite vaš odgovor!");

            }
            else
                errorProvider.SetError(txtAnswer, null);
        }

        private async void btnAnswer_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                var model = await _communicationsService.GetById<Data.Model.Communication>(_communicationID);
                var request = new Data.Requests.CommunicationUpsertRequest()
                {
                    DateOfMessage=model.DateOfMessage,
                    UserID=model.UserID,
                    CarServiceID=model.CarServiceID,
                    Content=model.Content,
                    AnswerContent=txtAnswer.Text,
                    isAnswered=true
                };
                var updateModel = await _communicationsService.Update<Data.Model.Communication>(_communicationID, request);

                if(updateModel!=null)
                {
                    MessageBox.Show("Odgovorili ste na pitanje!", "Odgovor na pitanje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAnswer.Text = null;
                    txtQuestion.Text = null;
                    txtUsernameLastName.Text = null;
                    this.LoadAgain();
                }

            }
        }
        private async void LoadAgain()
        {
            var modelList = await _communicationsService.Get<List<Data.Model.Communication>>(new Data.Requests.CommunicationsSearchRequest()
            {
                carServiceID = _carServiceID.GetValueOrDefault()
            });

            dgvQuestions.AutoGenerateColumns = false;
            dgvQuestions.DataSource = modelList;

            // Set the Multiline property to true.
            txtQuestion.Multiline = true;
            // Add vertical scroll bars to the TextBox control.
            txtQuestion.ScrollBars = ScrollBars.Vertical;
            // Allow the RETURN key to be entered in the TextBox control.
            txtQuestion.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            txtQuestion.AcceptsTab = true;
            // Set WordWrap to true to allow text to wrap to the next line.
            txtQuestion.WordWrap = true;
            // Set the default text of the control.

            txtAnswer.Multiline = true;
            // Add vertical scroll bars to the TextBox control.
            txtAnswer.ScrollBars = ScrollBars.Vertical;
            // Allow the RETURN key to be entered in the TextBox control.
            txtAnswer.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            txtAnswer.AcceptsTab = true;
            // Set WordWrap to true to allow text to wrap to the next line.
            txtAnswer.WordWrap = true;
        }
    }
}
