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
    class VehicleModel
    {
        public int Id { get; set; }
        public string LicencePlate { get; set; }
        public string Status { get; set; }
        public float Mileage { get; set; }


        public static async Task<List<VehicleModel>> Get()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "vehicles");
            return JsonConvert.DeserializeObject<List<VehicleModel>>(response);
        }
    }
}
