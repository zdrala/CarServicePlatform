using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarService.MobileApp.ViewModels
{
    public class CarServiceDetailViewModel:BaseViewModel
    {

        public CarServiceDetailViewModel()
        {
            
        }
        public Data.Model.CarService CarService { get; set; }

  


        private string _owner = string.Empty;

        public string Owner
        {
            get { return _owner; }
            set { SetProperty(ref _owner, value); }
        }
        private string _phoneNumber = string.Empty;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }
        private string _street = string.Empty;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }

        private string _csn = string.Empty;
        public string CarServiceName
        {
            get { return _csn; }
            set { SetProperty(ref _csn, value); }
        }

        public byte[] _Photo = null;

        public byte[] Photo
        {
            get { return _Photo; }
            set { SetProperty(ref _Photo, value); }
        }
        public  void LoadInit(Data.Model.CarService model)
        {


            CarServiceName = model.CarServiceName;
            Street = model.Street;
            Owner = model.Owner;
            PhoneNumber = model.PhoneNumber;
            Photo = model.Photo;





        }
    }
}
