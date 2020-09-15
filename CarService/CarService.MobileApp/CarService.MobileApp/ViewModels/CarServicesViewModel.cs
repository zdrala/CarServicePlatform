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
    public class CarServicesViewModel:BaseViewModel
    {
        private readonly APIService _carServicesRecommenderService = new APIService("recommender");
        public ObservableCollection<Data.Model.CarService> recommendCarServices { get; set; } = new ObservableCollection<Data.Model.CarService>();
        public ObservableCollection<Data.Model.CarService> others { get; set; } = new ObservableCollection<Data.Model.CarService>();
        public CarServicesViewModel()
        {
            InitCommand = new Command(async () => await Load());
        }
        public ICommand InitCommand { get; set; }
        public async Task Load()
        {

            var RecommenderModel = await _carServicesRecommenderService.Get<Data.Model.CarServicesRecommenderModel>(new UserRecommendationRequest() { UserID = APIService.UserID });

            recommendCarServices.Clear();
            foreach(var x in RecommenderModel.listToRecommend)
            {
                recommendCarServices.Add(x);
            }
            others.Clear();
            foreach (var x in RecommenderModel.others)
            {
                others.Add(x);
            }

        }
    }
}
