using CarService.WinUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService.WinUI
{
    public partial class Form1 : Form
    {
        private readonly APIService _apiService = new APIService("CarService");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnServiceID_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtCarServiceID.Text.ToString());

            frmCarServiceMainMenu frm = new frmCarServiceMainMenu(id);
           
            frm.Show();
            
        }
    }
}
