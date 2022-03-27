using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7Check.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _7Check.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
            NavigationPage.SetHasNavigationBar(this, false);
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            //vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            //vm.DisplayValidLoginPrompt += () => NextPage();
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                Console.WriteLine("LoginPage.xaml.cs Password completed - before submit command execute " + vm.IsAuthorized);
                vm.SubmitCommand.Execute(null);
                if(vm.IsAuthorized)
                {
                    Console.WriteLine("LoginPage.xaml.cs Password completed - successfull " + vm.IsAuthorized);
                    var startVehiclePage = new StartVehiclePage();
                    Navigation.PushAsync(startVehiclePage);
                }
                else
                {
                    Console.WriteLine("LoginPage.xaml.cs Password completed - submit command executed and rejected " + vm.IsAuthorized);
                    Console.WriteLine("les login sont incorrects");
                }
                

            };
            
        }

        
    }
}