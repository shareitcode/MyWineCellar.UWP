using MyWineCellar.DTO;
using MyWineCellar.Helpers;
using MyWineCellar.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media;

namespace MyWineCellar.ViewModels
{
	internal sealed class AddNewWineViewModel : BaseViewModel
	{
		public WineDto Wine { get; set; } = new WineDto();

		public string ErrorMessage => "Le champs ne peut pas être vide";

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

		public ICommand CheckProducerValidityCommand => new RelayCommand(this.CheckProducerValidity);

		public ICommand CheckCountryValidityCommand => new RelayCommand(this.CheckCountryValidity);

		public ICommand CheckRegionValidityCommand => new RelayCommand(this.CheckRegionValidity);

		public ICommand CheckAppellationValidityCommand => new RelayCommand(this.CheckAppellationValidity);

		public ICommand CheckParcelValidityCommand => new RelayCommand(this.CheckParcelValidity);

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		private void CheckProducerValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Producer))
			{
				this.ProducerTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000");
				this.ProducerErrorMessageIsVisible = true;
			}
			else
			{
				this.ProducerTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
				this.ProducerErrorMessageIsVisible = false;
			}
			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckCountryValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Country))
			{
				this.CountryTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000");
				this.CountryErrorMessageIsVisible = true;
			}
			else
			{
				this.CountryTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
				this.CountryErrorMessageIsVisible = false;
			}
			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckRegionValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Region))
			{
				this.RegionTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000");
				this.RegionErrorMessageIsVisible = true;
			}
			else
			{
				this.RegionTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
				this.RegionErrorMessageIsVisible = false;
			}
			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckAppellationValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Appellation))
			{
				this.AppellationTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000");
				this.AppellationErrorMessageIsVisible = true;
			}
			else
			{
				this.AppellationTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
				this.AppellationErrorMessageIsVisible = false;
			}
			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private void CheckParcelValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Parcel))
			{
				this.ParcelTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000");
				this.ParcelErrorMessageIsVisible = true;
			}
			else
			{
				this.ParcelTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
				this.ParcelErrorMessageIsVisible = false;
			}
			this.AddNewWineButtonIsEnabled = this.FormsValid();
		}

		private bool FormsValid() => !(this.CountryErrorMessageIsVisible || this.ProducerErrorMessageIsVisible || this.RegionErrorMessageIsVisible || this.ParcelErrorMessageIsVisible);

		public async Task AddNewWine()
		{
			try
			{
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