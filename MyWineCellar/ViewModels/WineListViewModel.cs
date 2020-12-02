using MyWineCellar.Helpers;
using MyWineCellar.Models;
using System.Collections.ObjectModel;

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
			if (Session.Instance.IsExist("Wine"))
			{
				this.Wines.Add(Session.Instance.Get<Wine>("Wine"));
			}
		}
	}
}