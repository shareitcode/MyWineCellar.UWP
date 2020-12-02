using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
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

		private bool _producerIsValid;
		public bool ProducerIsValid
		{
			get => this._producerIsValid;
			set
			{
				this.Set(ref this._producerIsValid, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _countryIsValid;
		public bool CountryIsValid
		{
			get => this._countryIsValid;
			set
			{
				this.Set(ref this._countryIsValid, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _regionIsValid;
		public bool RegionIsValid
		{
			get => this._regionIsValid;
			set
			{
				this.Set(ref this._regionIsValid, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _appellationIsValid;
		public bool AppellationIsValid
		{
			get => this._appellationIsValid;
			set
			{
				this.Set(ref this._appellationIsValid, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _parcelIsValid;
		public bool ParcelIsValid
		{
			get => this._parcelIsValid;
			set
			{
				this.Set(ref this._parcelIsValid, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _vintageIsValid;
		public bool VintageIsValid
		{
			get => this._vintageIsValid;
			set
			{
				this.Set(ref this._vintageIsValid, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _quantityIsValid;
		public bool QuantityIsValid
		{
			get => this._quantityIsValid;
			set
			{
				this.Set(ref this._quantityIsValid, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _colorIsValid;
		public bool ColorIsValid
		{
			get => this._colorIsValid;
			set
			{
				this.Set(ref this._colorIsValid, value);
				this.AddNewWineButtonIsEnabled = this.AllEntriesAreValid();
			}
		}

		private bool _acquisitionMeansIsValid;
        public bool AcquisitionMeansIsValid
		{
			get => this._acquisitionMeansIsValid;
			set
			{
				this.Set(ref this._acquisitionMeansIsValid, value);
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

		private bool AllEntriesAreValid()
		{
			return this.ProducerIsValid && this.CountryIsValid && this.RegionIsValid
					&& this.AppellationIsValid && this.ParcelIsValid && this.VintageIsValid
					&& this.QuantityIsValid && this.ColorIsValid && this.AcquisitionMeansIsValid;
		}
    }
}