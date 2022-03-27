using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace _7Check.Models
{
    class TokenModel
    {
        public User user { get; set; }
        
        [JsonProperty(PropertyName = "success")]
        public Token Success { get; set; }
        

        public partial class Token
        {
            public string token { get; set; }
        }
            
    }
}
