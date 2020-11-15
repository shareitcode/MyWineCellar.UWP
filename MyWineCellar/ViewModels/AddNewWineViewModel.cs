using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWineCellar.ViewModels
{
	internal sealed class AddNewWineViewModel : BaseViewModel
	{
		public Wine Wine { get; set; } = new Wine();

		public IEnumerable<string> WineColors { get; } = Constants.WineColors;

		private int _wineColor;
		public int WineColor
		{
			get => this._wineColor;
			set => this.Set(ref this._wineColor, value);
		}

		private bool _addNewWineButtonIsEnabled;
		public bool AddNewWineButtonIsEnabled
		{
			get => this._addNewWineButtonIsEnabled;
			set => this.Set(ref this._addNewWineButtonIsEnabled, value);
		}

		private bool _producerErrorMessageIsVisible = true;
		public bool ProducerErrorMessageIsVisible
		{
			get => this._producerErrorMessageIsVisible;
			set
			{
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
				this.Set(ref this._producerErrorMessageIsVisible, value);
			}
		}

		private bool _countryErrorMessageIsVisible = true;
		public bool CountryErrorMessageIsVisible
		{
			get => this._countryErrorMessageIsVisible;
			set
			{
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
				this.Set(ref this._countryErrorMessageIsVisible, value);
			}
		}

		private bool _regionErrorMessageIsVisible = true;
		public bool RegionErrorMessageIsVisible
		{
			get => this._regionErrorMessageIsVisible;
			set
			{
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
				this.Set(ref this._regionErrorMessageIsVisible, value);
			}
		}

		private bool _appellationErrorMessageIsVisible = true;
		public bool AppellationErrorMessageIsVisible
		{
			get => this._appellationErrorMessageIsVisible;
			set
			{
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
				this.Set(ref this._appellationErrorMessageIsVisible, value);
			}
		}

		private bool _parcelErrorMessageIsVisible = true;
		public bool ParcelErrorMessageIsVisible
		{
			get => this._parcelErrorMessageIsVisible;
			set
			{
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
				this.Set(ref this._parcelErrorMessageIsVisible, value);
			}
		}

		private bool _vintageErrorMessageIsVisible = true;
		public bool VintageErrorMessageIsVisible
		{
			get => this._vintageErrorMessageIsVisible;
			set
			{
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
				this.Set(ref this._vintageErrorMessageIsVisible, value);
			}
		}

		private bool _quantityErrorMessageIsVisible = true;
		public bool QuantityErrorMessageIsVisible
		{
			get => this._quantityErrorMessageIsVisible;
			set
			{
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
				this.Set(ref this._quantityErrorMessageIsVisible, value);
			}
		}

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		public async Task AddNewWine()
		{
			try
			{
				Wine wine = this.Wine;
				//await WineRepository.Add(this.Wine);
				NavigationService.GoBack();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private bool AllEntriesAreValid() => !(this.ProducerErrorMessageIsVisible && this.CountryErrorMessageIsVisible && this.RegionErrorMessageIsVisible
											&& this.AppellationErrorMessageIsVisible && this.ParcelErrorMessageIsVisible && this.VintageErrorMessageIsVisible
											&& this.QuantityErrorMessageIsVisible);
	}
}