using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService.WinUI.Forms
{
    public partial class frmCarPartsAddingUpdateDelete : Form
    {
        private readonly APIService _partsCategory = new APIService("carpartcategory");
        private readonly APIService _partsSubCategory = new APIService("carpartsubcategory");
        private readonly APIService _carPartsService = new APIService("carparts");
        private readonly int? _carServiceID ;
        private readonly int? _partID = null;
        public frmCarPartsAddingUpdateDelete(int? id=null,int? partID=null)
        {
            InitializeComponent();
            _carServiceID = id;
            _partID = partID;
        }

        public byte[] photoExist;
        private async void frmCarPartsAddingUpdateDelete_Load(object sender, EventArgs e)
        {
            if (!_partID.HasValue)
            {
                await PartsCategoryLoad();
            }
            else
            {
                
                var entity = await _carPartsService.GetById<Data.ViewModel.CarPartsVM>(_partID);
                await PartsCategoryLoad();
               
                txtName.Text = entity.Name;
                txtPrice.Text = entity.Price.ToString();
                txtQuality.Text = entity.Quality;
                cmbPartsCategory.SelectedValue = entity.CategoryID;
                await SubCategoriesLoad(entity.CategoryID);

                var itemSubCategory = await _partsSubCategory.GetById<Data.Model.CarPartSubCategory>(entity.SubCategoryID);
                cmbPartsSubCategory.SelectedValue = entity.SubCategoryID;
                if(itemSubCategory!=null)
                {
                    cmbPartsSubCategory.SelectedItem = itemSubCategory;
                }
                if (entity.Photo != null)
                {
                    if (entity.Photo.Length > 5)
                    {
                        photoExist = entity.Photo;
                        PictureBox.Image = byteArrayToImage(entity.Photo);
                    }
                }
               
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
        private async Task PartsCategoryLoad()
        {
            var list = await _partsCategory.Get<List<Data.Model.CarPartCategory>>(null);
            list.Insert(0, new Data.Model.CarPartCategory() {CategoryID=0, CategoryName = "Odaberi kategoriju dijelova" });
            cmbPartsCategory.ValueMember = "CategoryID";
            cmbPartsCategory.DisplayMember = "CategoryName";
            cmbPartsCategory.DataSource = list;

            
        }

        private async void cmbPartsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbPartsCategory.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                if (id > 0)
                {
                    await SubCategoriesLoad(id);
                }
                else
                {
                    cmbPartsSubCategory.DataSource = null;
                }
            }
        }
        private async Task SubCategoriesLoad(int id)
        {
            var list = await _partsSubCategory.Get<List<Data.Model.CarPartSubCategory>>(new CarPartsSearchRequest()
            {
                categoryID = id
            });

            list.Insert(0, new Data.Model.CarPartSubCategory() {SubCategoryID=0, SubCategoryName = "Odaberi podkategoriju dijelova" });
            cmbPartsSubCategory.ValueMember = "SubCategoryID";
            cmbPartsSubCategory.DisplayMember = "SubCategoryName";
            cmbPartsSubCategory.DataSource = list;

          
        }
        CarPartsUpsertRequest request = new CarPartsUpsertRequest();
       
        private async void btnSave_Click(object sender, EventArgs e)
        {
           
            if (this.ValidateChildren())
            {
               

                var idCategoryObj = cmbPartsCategory.SelectedValue;
                var idSubCategoryObj = cmbPartsSubCategory.SelectedValue;

                request.Name = txtName.Text;
                request.Price = double.Parse(txtPrice.Text.ToString());
                request.Quality = txtQuality.Text;
                request.CarServiceID = _carServiceID.GetValueOrDefault();
                request.CategoryID = int.Parse(idCategoryObj.ToString());
                request.SubCategoryID = int.Parse(idSubCategoryObj.ToString());

                Data.ViewModel.CarPartsVM obj = null;
                if(!_partID.HasValue)
                {
                    
                    var list = await _carPartsService.Get<List<Data.ViewModel.CarPartsVM>>(new CarPartsSearchRequest() { subCategoryID = int.Parse(idSubCategoryObj.ToString()),CarServiceID=_carServiceID.GetValueOrDefault() });


                    if (list.Count() > 0)
                    {
                        MessageBox.Show("Za odabranu podkategoriju ste već dodali odgovarajuće dijelove!", "Dodavanje neuspješno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                 
                    double priceObj;
                   obj= await _carPartsService.Insert<Data.ViewModel.CarPartsVM>(request);
                    priceObj = request.Price;
                    request.Price = priceObj * 1.5;
                    request.Quality = "Quality II";
                    await _carPartsService.Insert<Data.ViewModel.CarPartsVM>(request);
                    request.Price = priceObj * 2;
                    request.Quality = "Quality III";
                    await _carPartsService.Insert<Data.ViewModel.CarPartsVM>(request);
                    if (obj!=null)
                    {
                        MessageBox.Show("Uspješno Dodan auto dio!");
                        this.Close();
                    }
                }
                else
                {
                    var entity = await _carPartsService.GetById<Data.ViewModel.CarPartsVM>(_partID);
                    var list = await _carPartsService.Get<List<Data.ViewModel.CarPartsVM>>(new CarPartsSearchRequest() { subCategoryID = int.Parse(idSubCategoryObj.ToString()), CarServiceID=_carServiceID.GetValueOrDefault() });

                    
                    if(entity.SubCategoryID!= int.Parse(idSubCategoryObj.ToString()))
                    {

                        if(list.Count()>0)
                        {
                            MessageBox.Show("Nije moguće izmijeniti na odabranu podkategoriju, jer ste već dodali odgovarajuće dijelove za istu!", "Izmijena nije moguća", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                           
                  



                    if (photoExist!=null)
                    request.Photo = photoExist;
                   obj= await _carPartsService.Update<Data.ViewModel.CarPartsVM>(_partID,request);
                    if (obj != null)
                    {
                        MessageBox.Show("Uspješno updateovan auto dio!");
                        this.Close();
                    }
                }
            }
  
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Length < 5)
            {
                
                errorProvider.SetError(txtName, "Obavezno polje! Minimalna unesena dužina je 5 karaktera!");
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }

            
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                
                errorProvider.SetError(txtPrice, "Obavezno polje!");
                check = true;
            }
            else
            {
                if (int.TryParse(txtPrice.Text, out int value))
                {
                    if (int.Parse(txtPrice.Text.ToString()) < 1)
                    {
                        e.Cancel = true;
                        errorProvider.SetError(txtPrice, "Unesena vrijednost mora biti veća od 0!");
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
                    errorProvider.SetError(txtPrice, "Slova nisu dozvoljena!");
                    check = true;
                }


            }
            if (!check)
                errorProvider.SetError(txtPrice, null);
        }

        private void cmbPartsCategory_Validating(object sender, CancelEventArgs e)
        {
            var idObj = cmbPartsCategory.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                if (id > 0)
                {
                    errorProvider.SetError(cmbPartsCategory, null);
                }
                else
                {
                    e.Cancel = true;
                    errorProvider.SetError(cmbPartsCategory, "Odaberi kategoriju auto dijela!");
                }
            }
        }

        private void cmbPartsSubCategory_Validating(object sender, CancelEventArgs e)
        {
            var idCategoryObj = cmbPartsCategory.SelectedValue;
            var idSubCategoryObj = cmbPartsSubCategory.SelectedValue;

            if (idSubCategoryObj != null)
            {
                if (int.TryParse(idSubCategoryObj.ToString(), out int idSubCategory))
                {
                    if (idSubCategory > 0)
                    {
                        errorProvider.SetError(cmbPartsSubCategory, null);

                    }
                    else
                    {
                        e.Cancel = true;
                        errorProvider.SetError(cmbPartsSubCategory, "Odaberi podkategoriju auto dijela!");
                    }

                }
            }
            else
            {
                e.Cancel = true;
                errorProvider.SetError(cmbPartsSubCategory, "Odaberi podkategoriju auto dijela!");
            }
        
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var result =openFileDialog1.ShowDialog();
            if(result==DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                 var file = File.ReadAllBytes(fileName);
                request.Photo = file;
                txtSlikaInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                PictureBox.Image = image;
            }
        }
    }
}
