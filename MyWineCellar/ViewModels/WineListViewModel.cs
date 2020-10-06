using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWineCellar.Models;

namespace MyWineCellar.ViewModels
{
    internal sealed class WineListViewModel : BaseViewModel
    {
        public ObservableCollection<Wine> Wines { get; set; }

        public WineListViewModel()
        {
            this.Wines = new ObservableCollection<Wine>()
            {
                new Wine() {Appellation = "Vin 1", Producer = "Producer 1", Vintage = 2010, Quantity = 6},
                new Wine() {Appellation = "Vin 2", Producer = "Producer 2", Vintage = 2010, Quantity = 6},
                new Wine() {Appellation = "Vin 3", Producer = "Producer 3", Vintage = 2010, Quantity = 6}
            };
        }
    }
}