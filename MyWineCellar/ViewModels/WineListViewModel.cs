using System;
using MyWineCellar.DTO;
using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.EntityFrameworkCore;
using MyWineCellar.DAL;

namespace MyWineCellar.ViewModels
{
	internal sealed class WineListViewModel : BaseViewModel
	{
		public ObservableCollection<Wine> Wines { get; set; }

		public WineListViewModel()
		{
		}

		public async Task Initialize()
		{
			try
			{
				IEnumerable<WineDto> wines = await WineRepository.GetAllWines(ApplicationData.Current.LocalFolder.Path + "\\MyWineCellar.db");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
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