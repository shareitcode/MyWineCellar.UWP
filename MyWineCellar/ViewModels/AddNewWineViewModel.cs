using MyWineCellar.DTO;
using MyWineCellar.Helpers;
using MyWineCellar.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWineCellar.ViewModels
{
	internal sealed class AddNewWineViewModel : BaseViewModel
	{
		public WineDto Wine { get; set; } = new WineDto();

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

		private bool _producerErrorMessageIsVisible;
		public bool ProducerErrorMessageIsVisible
		{
			get => this._producerErrorMessageIsVisible;
			set => this.Set(ref this._producerErrorMessageIsVisible, value);
		}

		private bool _countryErrorMessageIsVisible;
		public bool CountryErrorMessageIsVisible
		{
			get => this._countryErrorMessageIsVisible;
			set => this.Set(ref this._countryErrorMessageIsVisible, value);
		}

		private bool _regionErrorMessageIsVisible;
		public bool RegionErrorMessageIsVisible
		{
			get => this._regionErrorMessageIsVisible;
			set => this.Set(ref this._regionErrorMessageIsVisible, value);
		}

		private bool _appellationErrorMessageIsVisible;
		public bool AppellationErrorMessageIsVisible
		{
			get => this._appellationErrorMessageIsVisible;
			set => this.Set(ref this._appellationErrorMessageIsVisible, value);
		}

		private bool _parcelErrorMessageIsVisible;
		public bool ParcelErrorMessageIsVisible
		{
			get => this._parcelErrorMessageIsVisible;
			set => this.Set(ref this._parcelErrorMessageIsVisible, value);
		}

		private bool _vintageErrorMessageIsVisible;
		public bool VintageErrorMessageIsVisible
		{
			get => this._vintageErrorMessageIsVisible;
			set => this.Set(ref this._vintageErrorMessageIsVisible, value);
		}

		private bool _quantityErrorMessageIsVisible;
		public bool QuantityErrorMessageIsVisible
		{
			get => this._quantityErrorMessageIsVisible;
			set => this.Set(ref this._quantityErrorMessageIsVisible, value);
		}

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		public async Task AddNewWine()
		{
			try
			{
				WineDto wine = this.Wine;
				//await WineRepository.Add(this.Wine);
				NavigationService.GoBack();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}