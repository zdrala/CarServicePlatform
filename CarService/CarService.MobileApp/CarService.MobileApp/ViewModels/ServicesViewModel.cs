using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarService.MobileApp.ViewModels
{
    public class ServicesViewModel:BaseViewModel
    {
        private readonly APIService _ServicesService = new APIService("services");
        public ObservableCollection<Data.Model.Services> ServicesList { get; set; } = new ObservableCollection<Data.Model.Services>();

        public Data.Model.CarService CarService;
        public ServicesViewModel()
        {
            
        }
        public ICommand InitCommand { get; set; }

        public string _carServiceName = string.Empty;
        public string CarServiceName
        {
            get { return _carServiceName; }
            set { SetProperty(ref _carServiceName, value); }
        }
        public async Task Load(Data.Model.CarService cs)
        {
            CarServiceName = cs.CarServiceName;
            var _ServicesList = await _ServicesService.Get<List<Data.Model.Services>>(new ServicesSearchRequest()
            {
                CarServiceID=cs.CarServiceID
            });
            ServicesList.Clear();
            foreach (var s in _ServicesList)
            {
                ServicesList.Add(s);
            }


        }
    }
}
