using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace _7Check.Models
{
    class AgencyModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public static async Task<List<AgencyModel>> Get()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "agency");
            return JsonConvert.DeserializeObject<List<AgencyModel>>(response);
        }
    }
}
