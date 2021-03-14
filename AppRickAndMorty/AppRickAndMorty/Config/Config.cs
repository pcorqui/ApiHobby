using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppRickAndMorty.Config
{
    public class Config
    {
        private string WS_LOGIN { get; set; }

        public static async Task<String> getWebService(String value)
        {

            String query = "https://rickandmortyapi.com/api" + value;


            HttpClient client = new HttpClient();
            client.Timeout = System.TimeSpan.FromMinutes(30);
            var response = await client.GetStringAsync(query);

            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }
        
        public static async Task<String> getWebServiceOnePice(String value)
        {

            String query = "https://onepiececover.com/api" + value;


            HttpClient client = new HttpClient();
            client.Timeout = System.TimeSpan.FromMinutes(30);
            var response = await client.GetStringAsync(query);

            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

    }
    
}
