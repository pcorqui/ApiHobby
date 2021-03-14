using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppRickAndMorty.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }
        public string Species { get; set; }
        public ImageSource UrlImage { get; set; }
    }
}
