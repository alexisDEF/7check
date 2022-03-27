using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;

namespace _7Check.Models
{
    class BookingModel
{
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartAgency_id { get; set; }
        public int EndAgency_id { get; set; }
        public int Customer_id { get; set; }
        public int Vehicle_id { get; set; }
        public int Driver_id { get; set; }


        public static List<BookingModel> Booking { get {
                return Get().Result;
            } }

        public static async Task<List<BookingModel>> Get()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", string.Empty));
            Console.WriteLine("BookingModel.Auth");
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "reservation");
            Console.WriteLine("BookingModel.response");
            var result =  JsonConvert.DeserializeObject<List<BookingModel>>(response);
            Console.WriteLine("BookingModel.Get");
            //var booking =  new List<BookingModel>(result);
            return result;
        }
        

        


    }
}
