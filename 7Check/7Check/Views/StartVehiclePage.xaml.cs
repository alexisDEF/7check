using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7Check.ViewModels;
using _7Check.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace _7Check.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class StartVehiclePage : ContentPage
{

        
    public StartVehiclePage()
    {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            //var test = BookingModel.Booking;
            //listBookings.ItemsSource = BookingModel.Booking;
            
        }

    }
}