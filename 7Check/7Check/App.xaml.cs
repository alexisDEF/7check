using System;
using Xamarin.Forms;
using _7Check.Views;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Connectivity;

namespace _7Check
{
    public partial class App : Application
    {
        public App()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
            //Preferences.Set("token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiI5IiwianRpIjoiYmRkODNjZjVmNWU0ZDFhZWVhNjgwODhiYjJmM2RlODQ3ODgyNDA5NTJlNGI0YjZhYTQ3YmUyNWUwYmFkMThjNDYxODU0NmFhODMzYWRiNTYiLCJpYXQiOjE2NDc1MjA2ODUuMjYwMjYsIm5iZiI6MTY0NzUyMDY4NS4yNjAyNjQsImV4cCI6MTY3OTA1NjY4NS4yNDUxNjIsInN1YiI6IjEiLCJzY29wZXMiOltdfQ.B_l7_gxzOoZPFFiCnf1S8h2phzNPMmISexzVfKvcNb_RCouhUw3nKjo3bEYVzYBFOcaR2sutagAOSHXtVGDlqcPUkGvd0GB-VmTIH7lAyUehCH5jSolosprj8blUO3CffxKDGSZD1_A_ebuZRKqtbh0dzY8SeYNZastSQ9gN5_3qbGnR_R0MQlzfFNlxPGVpn8piuY27kVRvZgmg7Jj5xUYl9nx15ybCbex5XPweEIXsSS469Gevx_5ZeYnJ0YiFuCKyOnICSbX6UBimvxBHfyAMcOHvAb84Kd6RsLEbHTCLVxUYikcYshKoUhwgbtDUR2LqJ3od3iNFFzKvpvZMJ6YkWSFokknhtdfUBnrxGFjMtTlP6Ahv5tSkZt99qYYhTQoT1COVm26mXPmlc5iBC_khGCiR3b9EY13OEzxueD99JkOfEaag2yQe0iZC90KM9NLe8iA25O__2L7Xp7lW7MQKlPl7KZj5u14Yb3FPLf54AUHViR4LVG7g13nAaOzErSvWHwapqUQVsiSYxEt0gH4brNqUZ-lLTb5iqesqtLls8WH6kF19p7AkXl7MOaV-JS6m8IR6oKpOA_cvqc_L2AwFjigG200QA5G-MF1TRFLPnE3PDqvzE7SvTyWHk8GG6NARlnl9SE-InVUouHDm9Y1IJYk9n2UpXUXiPH9g0Fw");
            //var access_token = Preferences.Get("token", string.Empty);
        }
            /**if(string.IsNullOrEmpty(access_token))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new StartVehiclePage());
            }
        }

        protected override void OnStart()
        {
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
        }
            dzzdzd
        private void HandleConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            Type currentPage = this.MainPage.GetType();
            if (e.IsConnected && currentPage != typeof(StartVehiclePage)) this.MainPage = new StartVehiclePage();
            else if (!e.IsConnected && currentPage != typeof(StartVehiclePage)) this.MainPage = new LoginPage();
        }*/
        protected override void OnSleep()
        {
            Preferences.Set("token", string.Empty);
            Preferences.Set("userId", string.Empty);
            Preferences.Set("userName", string.Empty);

        }

        protected override void OnResume()
        {
        }
    }
}
