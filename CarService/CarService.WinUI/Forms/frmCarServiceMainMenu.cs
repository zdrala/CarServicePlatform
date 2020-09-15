using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;
//using Tulpep.NotificationWindow;

namespace CarService.WinUI.Forms
{
    public partial class frmCarServiceMainMenu : Form
    {
        private int childFormNumber = 0;

        private readonly APIService _apiCarService = new APIService("CarService");
        private readonly APIService _offersService = new APIService("offers");
        private readonly int? _id = null;
        public frmCarServiceMainMenu(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }



        private void btnServices_Click(object sender, EventArgs e)
        {
            frmServices frm = new frmServices(_id);


            frm.Show();
        }
        private System.Windows.Forms.Timer timer1;
        private async void frmCarServiceMainMenu_Load(object sender, EventArgs e)
        {
            var entity = await _apiCarService.GetById<Data.Model.CarService>(_id);
            txtServiceName.Text = entity.CarServiceName;

            if (entity.Photo.Length > 5)
            {
                PictureBox.Image = byteArrayToImage(entity.Photo);
            }



             CheckselectedOffers();

        timer1 = new System.Windows.Forms.Timer();
        timer1.Tick += new EventHandler(Check_selectedOffers);
        timer1.Interval = 1800000; // in miliseconds   ->30 minutes
                timer1.Start();





          
        
        }
        private async void LoadAgain()
        {
            var entity = await _apiCarService.GetById<Data.Model.CarService>(_id);
            txtServiceName.Text = entity.CarServiceName;

            if (entity.Photo.Length > 5)
            {
                PictureBox.Image = byteArrayToImage(entity.Photo);
            }



            //CheckselectedOffers();

            //timer1 = new System.Windows.Forms.Timer();
            //timer1.Tick += new EventHandler(Check_selectedOffers);
            //timer1.Interval = 10000; // in miliseconds   ->10 minutes
            //timer1.Start();



        }
        private async void CheckselectedOffers()
        {
            var modelList = await _offersService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
            {
                CarServiceID = _id.GetValueOrDefault(),
                AdminSearch = true
            });
            if (modelList.Count > 0)
            {
                MessageBox.Show("Imate nove odabire sa ponude od strane klijenta! Kliknite u glavnom meni-u na dugme 'Termini u toku na kojima su klijenti odabrali dijelove sa ponude'!", "Termini u toku", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
                 
            }
        }
        private async void Check_selectedOffers(object sender, EventArgs e)
        {
            var modelList = await _offersService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
            {
                CarServiceID = _id.GetValueOrDefault(),
                AdminSearch = true
            });
            if (modelList.Count > 0)
            {
                MessageBox.Show("Imate nove odabire sa ponude od strane klijenta! Kliknite u glavnom meni-u na dugme 'Termini u toku na kojima su klijenti odabrali dijelove sa ponude'!", "Termini u toku", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
        private void txtCarParts_Click(object sender, EventArgs e)
        {
            frmCarParts frm = new frmCarParts(_id);


            frm.Show();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            frmCarServiceDetails frm = new frmCarServiceDetails(_id);
            frm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void btnRequests_Click(object sender, EventArgs e)
        {
            frmRequests frm = new frmRequests(_id);
            frm.Show();
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            frmSchedules frm = new frmSchedules(_id);
            frm.Show();
        }

        private void btnSchedulesInProgress_Click(object sender, EventArgs e)
        {
            frmSchedulesInProgress frm = new frmSchedulesInProgress(_id);
            frm.Show();
        }

        private void btnQuestions_Click(object sender, EventArgs e)
        {
            frmCommunications frm = new frmCommunications(_id);
            frm.Show();
        }

        private void btnCompletedServicesByDate_Click(object sender, EventArgs e)
        {
            frmCompletedServicesByDate frm = new frmCompletedServicesByDate(_id);
            frm.Show();
        }

        private void btnEarnings_Click(object sender, EventArgs e)
        {
            frmEarningsByDate frm = new frmEarningsByDate(_id);
            frm.Show();
        }

        private void frmCarServiceMainMenu_Activated(object sender, EventArgs e)
        {
            this.LoadAgain();
        }
    }
}
