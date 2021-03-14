using AppRickAndMorty.Models;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppRickAndMorty.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        INavigationService _navigation;
        IPageDialogService _dialogService;


        public ObservableCollection<Character> list { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            list = new ObservableCollection<Character>();
        }

        public override async  void OnNavigatedTo(INavigationParameters parameters)
        {

            var response = await Config.Config.getWebService("/character/");
            var json = JObject.Parse(response);

            var result = json.Value<JArray>("results");
            

            foreach (var item in result)
            {
                var name = item.Value<string>("name");
                var status = item.Value<string>("status");
                var image = item.Value<string>("image");
                list.Add(new Character (){ Name = name, Status = status,UrlImage = ImageSource.FromUri(new Uri(image)) });
            }

            RaisePropertyChanged("list");
        }

        private string _Prueba = "Perro";

        public string Prueba
        {
            get { return _Prueba; }
            set { _Prueba = value; }
        }




    }
}
