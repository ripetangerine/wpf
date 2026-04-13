using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ParkingManager
{
    // static : 어디서든
    public static class AppData
    {
        public static ObservableCollection<Discountcode> Discountcodes { get; set; } = new();
    }
    public static int Fee10Min { get; set; }

     
}
