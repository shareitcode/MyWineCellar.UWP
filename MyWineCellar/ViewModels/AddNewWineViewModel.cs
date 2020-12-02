using MyWineCellar.DTO;
using MyWineCellar.Helpers;
using MyWineCellar.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media;

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

		public string ErrorMessage => Constants.ErrorMessageTheFieldCannotBeEmpty;

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

		private Brush _producerTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
		public Brush ProducerTextBoxBordersColor
		{
			get => this._producerTextBoxBordersColor;
			set => this.Set(ref this._producerTextBoxBordersColor, value);
		}

		private Brush _countryTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
		public Brush CountryTextBoxBordersColor
		{
			get => this._countryTextBoxBordersColor;
			set => this.Set(ref this._countryTextBoxBordersColor, value);
		}

		private Brush _regionTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
		public Brush RegionTextBoxBordersColor
		{
			get => this._regionTextBoxBordersColor;
			set => this.Set(ref this._regionTextBoxBordersColor, value);
		}

		private Brush _appellationTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
		public Brush AppellationTextBoxBordersColor
		{
			get => this._appellationTextBoxBordersColor;
			set => this.Set(ref this._appellationTextBoxBordersColor, value);
		}

		private Brush _parcelTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
		public Brush ParcelTextBoxBordersColor
		{
			get => this._parcelTextBoxBordersColor;
			set => this.Set(ref this._parcelTextBoxBordersColor, value);
		}

		private Brush _vintageTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
		public Brush VintageTextBoxBordersColor
		{
			get => this._vintageTextBoxBordersColor;
			set => this.Set(ref this._vintageTextBoxBordersColor, value);
		}

		private Brush _quantityTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
		public Brush QuantityTextBoxBordersColor
		{
			get => this._quantityTextBoxBordersColor;
			set => this.Set(ref this._quantityTextBoxBordersColor, value);
		}

		public ICommand CheckProducerValidityCommand => new RelayCommand(this.CheckProducerValidity);

		public ICommand CheckCountryValidityCommand => new RelayCommand(this.CheckCountryValidity);

		public ICommand CheckRegionValidityCommand => new RelayCommand(this.CheckRegionValidity);

		public ICommand CheckAppellationValidityCommand => new RelayCommand(this.CheckAppellationValidity);

		public ICommand CheckParcelValidityCommand => new RelayCommand(this.CheckParcelValidity);

		public ICommand CheckVintageValidityCommand => new RelayCommand(this.CheckVintageValidity);

		public ICommand CheckQuantityValidityCommand => new RelayCommand(this.CheckQuantityValidity);

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		private void CheckProducerValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Producer))
				this.SetInvalid(brush => this.ProducerTextBoxBordersColor = brush, visible => this.ProducerErrorMessageIsVisible = visible);
			else
				this.SetValid(brush => this.ProducerTextBoxBordersColor = brush, visible => this.ProducerErrorMessageIsVisible = visible);

			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckCountryValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Country))
				this.SetInvalid(brush => this.CountryTextBoxBordersColor = brush, visible => this.CountryErrorMessageIsVisible = visible);
			else
				this.SetValid(brush => this.CountryTextBoxBordersColor = brush, visible => this.CountryErrorMessageIsVisible = visible);

			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckRegionValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Region))
				this.SetInvalid(brush => this.RegionTextBoxBordersColor = brush, visible => this.RegionErrorMessageIsVisible = visible);
			else
				this.SetValid(brush => this.RegionTextBoxBordersColor = brush, visible => this.RegionErrorMessageIsVisible = visible);

			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckAppellationValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Appellation))
				this.SetInvalid(brush => this.AppellationTextBoxBordersColor = brush, visible => this.AppellationErrorMessageIsVisible = visible);
			else
				this.SetValid(brush => this.AppellationTextBoxBordersColor = brush, visible => this.AppellationErrorMessageIsVisible = visible);

			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckParcelValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Parcel))
				this.SetInvalid(brush => this.ParcelTextBoxBordersColor = brush, visible => this.ParcelErrorMessageIsVisible = visible);
			else
				this.SetValid(brush => this.ParcelTextBoxBordersColor = brush, visible => this.ParcelErrorMessageIsVisible = visible);

			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckVintageValidity()
		{
			if (this.Wine.Vintage <= 0)
				this.SetInvalid(brush => this.VintageTextBoxBordersColor = brush, visible => this.VintageErrorMessageIsVisible = visible);
			else
				this.SetValid(brush => this.VintageTextBoxBordersColor = brush, visible => this.VintageErrorMessageIsVisible = visible);

			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckQuantityValidity()
		{
			if (this.Wine.Quantity <= 0)
				this.SetInvalid(brush => this.QuantityTextBoxBordersColor = brush, visible => this.QuantityErrorMessageIsVisible = visible);
			else
				this.SetValid(brush => this.QuantityTextBoxBordersColor = brush, visible => this.QuantityErrorMessageIsVisible = visible);

			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void SetInvalid(Action<Brush> uiBorderColor, Action<bool> uiErrorMessageVisible)
		{
			uiBorderColor(UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000"));
			uiErrorMessageVisible(true);

		}

		private void SetValid(Action<Brush> uiBorderColor, Action<bool> uiErrorMessageVisible)
		{
			uiBorderColor(UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7"));
			uiErrorMessageVisible(false);
		}

		private bool FormsValid() => !(this.CountryErrorMessageIsVisible || this.RegionErrorMessageIsVisible
										|| this.ParcelErrorMessageIsVisible || this.VintageErrorMessageIsVisible || this.QuantityErrorMessageIsVisible);

		public AddNewWineViewModel()
		{
		}

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