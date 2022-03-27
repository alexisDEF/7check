using System;
using System.Collections.Generic;
using System.Text;
using _7Check.Service;
using _7Check.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace _7Check.ViewModels
{
    class StartVehicleViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BookingModel> ItemList { get; set; }

        public StartVehicleViewModel()
        {
            Console.WriteLine("Before");
            ItemList = new ObservableCollection<BookingModel>(BookingModel.Booking);
            Console.WriteLine("After");
        }



        public string _test = "test";

        public string Text
        {
            get => _test;
            set {
                _test = value;
                OnPropertyChanged(nameof(Text));
                    }
            
        }

        public List<string> _test1 = new List<string> { "ok", "gf", "dsd", "ds" };
        public List<string> Test1
        {
            get { return _test1; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
        
        /**public BookingModel booking1 { get; set; }
        

        
          
        public StartVehicleViewModel()
        {
            this.booking1 = booking1;
            
        }

        /**public List<BookingModel> getBooking
        {
            get { return BookingModel.Get().Result; }
        }
        public static List<BookingModel> GetBooking()
        {
            var task = BookingModel.Get();
            return task.Result;
            
        }*/


    }
}
