using AppRickAndMorty.Models;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppRickAndMorty.ViewModels
{
    public class OnePieceViewModel : BindableBase, INavigationAware
    {
        public ObservableCollection<OnePieceChapter> Chapters { get; set; }
        public OnePieceViewModel()
        {
            Chapters = new ObservableCollection<OnePieceChapter>();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            var response = await Config.Config.getWebServiceOnePice("/chapters");
            var json = JObject.Parse(response);

            var result = json.Value<JArray>("items");


            foreach (var item in result)
            {
                var name = item.Value<string>("title");
                var summary = item.Value<string>("summary");
                var image = item.Value<string>("cover_images");
                string[] subs = image.Split('|');
                var explanation = item.Value<string>("explanation");
                Chapters.Add(new OnePieceChapter() { Chapter = name, 
                    Summary = summary, 
                    ImageUrl = subs[0], 
                    Explanation = explanation });
            }

            RaisePropertyChanged("Chapters");
        }
    }
}
