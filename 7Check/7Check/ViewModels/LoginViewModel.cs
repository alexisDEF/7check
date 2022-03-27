using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using _7Check.Views;
using _7Check.Models;
using System.Threading.Tasks;
using FreshMvvm;
using _7Check.Service;
using Newtonsoft.Json;

namespace _7Check.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        [JsonIgnore]
        public Action DisplayInvalidLoginPrompt;
        [JsonIgnore]
        public Action DisplayValidLoginPrompt;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private bool _isAuthorized;
        public bool IsAuthorized
        {
            get { return _isAuthorized; }
            set
            {
                _isAuthorized = value;
                PropertyChanged(this, new PropertyChangedEventArgs("_isAuthorized"));
            }
        }

        [JsonIgnore]
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            _isAuthorized = false;
            SubmitCommand = new Command(OnSubmit);
        }

        
        public async void OnSubmit()
        {
            Console.WriteLine("OnSubmit");   
            if (email != null || password != null)
            {
                //await BookingModel.Get();
                try
                {
                    
                    Console.WriteLine("Try API service");

                    IsAuthorized = await ApiService.LoginUser(email, password);
                    Console.WriteLine("LoginViewModel OnSumbit - try " + IsAuthorized);
                    //return IsAuthorized;
                }
                catch
                {
                    Console.WriteLine("LoginViewModel OnSumbit - catch " + IsAuthorized);
                    //return IsAuthorized;

                }
                //StartVehicleViewModel.GetBooking();



            }
            //return IsAuthorized;
            

        }
        
    }
}

