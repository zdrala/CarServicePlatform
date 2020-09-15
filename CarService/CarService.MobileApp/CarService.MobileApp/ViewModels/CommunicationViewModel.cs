using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CarService.MobileApp.ViewModels
{
    public class CommunicationViewModel:BaseViewModel
    {
        public Data.Model.CarService modelCS { get; set; }

        private string _csName = string.Empty;

        public string CsName
        {
            get { return _csName; }
            set { SetProperty(ref _csName, value); }
        }


        private string _QuestionContent = string.Empty;

        public string QuestionContent
        {
            get { return _QuestionContent; }
            set { SetProperty(ref _QuestionContent, value); }
        }
        private readonly APIService _communicationsService = new APIService("Communications");
        public ObservableCollection<Data.Model.Communication> userCommunications { get; set; } = new ObservableCollection<Data.Model.Communication>();

        public async void Load()
        {

            CsName = modelCS.CarServiceName;
            var req = new CommunicationsSearchRequest()
            {
                UserID = APIService.UserID,
                ClientSearch = true,
                carServiceID=modelCS.CarServiceID

            };

            var list = await _communicationsService.Get<List<Data.Model.Communication>>(req);
            userCommunications.Clear();
        foreach(var x in list)
            {
                userCommunications.Add(x);
            }

        }
        public Data.Model.Communication modelCommunication { get; set; }
        public async Task SendQuestion()
        {
            var request = new CommunicationUpsertRequest()
            {
                DateOfMessage = DateTime.Now,
                UserID = APIService.UserID,
                CarServiceID = modelCS.CarServiceID,
                Content = QuestionContent,
                AnswerContent="",
                isAnswered=false
            };

            modelCommunication = await _communicationsService.Insert<Data.Model.Communication>(request);
        }

    }
}
