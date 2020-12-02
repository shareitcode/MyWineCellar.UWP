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
		public AddWineModel Wine { get; set; } = new AddWineModel();

		public IEnumerable<String> WineColors { get; } = Constants.WineColors;

		public IEnumerable<string> AcquisitionMeans { get; } = Constants.AcquisitionMeans;

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
				this.Set(ref this._producerErrorMessageIsVisible, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _countryErrorMessageIsVisible = true;
		public bool CountryErrorMessageIsVisible
		{
			get => this._countryErrorMessageIsVisible;
			set
			{
				this.Set(ref this._countryErrorMessageIsVisible, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _regionErrorMessageIsVisible = true;
		public bool RegionErrorMessageIsVisible
		{
			get => this._regionErrorMessageIsVisible;
			set
			{
				this.Set(ref this._regionErrorMessageIsVisible, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _appellationErrorMessageIsVisible = true;
		public bool AppellationErrorMessageIsVisible
		{
			get => this._appellationErrorMessageIsVisible;
			set
			{
				this.Set(ref this._appellationErrorMessageIsVisible, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _parcelErrorMessageIsVisible = true;
		public bool ParcelErrorMessageIsVisible
		{
			get => this._parcelErrorMessageIsVisible;
			set
			{
				this.Set(ref this._parcelErrorMessageIsVisible, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _vintageErrorMessageIsVisible = true;
		public bool VintageErrorMessageIsVisible
		{
			get => this._vintageErrorMessageIsVisible;
			set
			{
				this.Set(ref this._vintageErrorMessageIsVisible, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _quantityErrorMessageIsVisible = true;
		public bool QuantityErrorMessageIsVisible
		{
			get => this._quantityErrorMessageIsVisible;
			set
			{
				this.Set(ref this._quantityErrorMessageIsVisible, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		public async Task AddNewWine()
		{
			try
			{
				AddWineModel wine = this.Wine;
				//await WineRepository.Add(this.Wine);
				NavigationService.GoBack();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

        private bool AllEntriesAreValid() => !this.ProducerErrorMessageIsVisible && !this.CountryErrorMessageIsVisible && !this.RegionErrorMessageIsVisible
											 && !this.AppellationErrorMessageIsVisible && !this.ParcelErrorMessageIsVisible && !this.VintageErrorMessageIsVisible
											 && !this.QuantityErrorMessageIsVisible;
    }
}