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
    public partial class frmCarParts : Form
    {
        private readonly APIService _partsCategory = new APIService("carpartcategory");
        private readonly APIService _partsSubCategory = new APIService("carpartsubcategory");
        private readonly APIService _carService = new APIService("carservice");
        private readonly APIService _carPartsService = new APIService("carparts");
        private readonly int? _carServiceID = null;
        public frmCarParts(int? id=null)
        {
            InitializeComponent();
            _carServiceID = id;
        }

        private async void frmCarParts_Load(object sender, EventArgs e)
        {
            var entity = await _carService.GetById<Data.Model.CarService>(_carServiceID);
            txtCarServiceName.Text = entity.CarServiceName;
            await PartsCategoryLoad();
        }
        private async Task PartsCategoryLoad()
        {
            var list =await _partsCategory.Get<List<Data.Model.CarPartCategory>>(null);
            list.Insert(0, new Data.Model.CarPartCategory() { CategoryName="Odaberi kategoriju dijelova"});
            cmbPartsCategory.ValueMember = "CategoryID";
            cmbPartsCategory.DisplayMember = "CategoryName";
            cmbPartsCategory.DataSource = list;
        }

        private async void cmbPartsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbPartsCategory.SelectedValue;

            if(int.TryParse(idObj.ToString(),out int id))
            {
                if (id > 0)
                {
                    await SubCategoriesLoad(id);
                    await CarPartsLoad(id);
                }
                else
                {
                    cmbPartsSubCategory.DataSource = null;
                    dgvParts.DataSource = new List<Data.ViewModel.CarPartsVM>();
                }
            }


           
        }
        private async Task CarPartsLoad(int id)
        {
            var list = await _carPartsService.Get<List<Data.ViewModel.CarPartsVM>>(new CarPartsSearchRequest()
            {
                categoryID = id,
                CarServiceID=_carServiceID.GetValueOrDefault()
            });

            dgvParts.DataSource = list;
        }
        private async Task SubCategoriesLoad(int id)
        {
            var list = await _partsSubCategory.Get<List<Data.Model.CarPartSubCategory>>(new CarPartsSearchRequest()
            {
                categoryID = id
            });

            list.Insert(0, new Data.Model.CarPartSubCategory() { SubCategoryName = "Odaberi podkategoriju dijelova" });
            cmbPartsSubCategory.ValueMember = "SubCategoryID";
            cmbPartsSubCategory.DisplayMember = "SubCategoryName";
            cmbPartsSubCategory.DataSource = list;
        }

        private async void cmbPartsSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idCategoryObj = cmbPartsCategory.SelectedValue;
            var idSubCategoryObj = cmbPartsSubCategory.SelectedValue;

            if (idSubCategoryObj != null)
            {
                if (int.TryParse(idSubCategoryObj.ToString(), out int idSubCategory))
                {
                    if (idSubCategory > 0)
                    {

                        var list = await _carPartsService.Get<List<Data.ViewModel.CarPartsVM>>(new CarPartsSearchRequest()
                        {
                            categoryID = int.Parse(idCategoryObj.ToString()),
                            subCategoryID = idSubCategory,
                            CarServiceID=_carServiceID.GetValueOrDefault()
                        });

                        dgvParts.DataSource = list;
                    }
                    else
                    {

                        await CarPartsLoad(int.Parse(idCategoryObj.ToString()));
                    }

                }
            }
        }

        private void txtAddCarPart_Click(object sender, EventArgs e)
        {
            frmCarPartsAddingUpdateDelete frm = new frmCarPartsAddingUpdateDelete(_carServiceID,null);
            frm.Show();
        }

        private void dgvParts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var _partID = int.Parse(dgvParts.SelectedRows[0].Cells[0].Value.ToString());
            frmCarPartsAddingUpdateDelete frm = new frmCarPartsAddingUpdateDelete(_carServiceID, _partID);
            frm.Show();
        }
    }
}
