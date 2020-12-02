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

		private string _errorMessage = string.Empty;
		public string ErrorMessage
		{
			get => this._errorMessage;
			set => this.Set(ref this._errorMessage, value);
		}

		private bool _errorMessageIsVisible;
		public bool ErrorMessageIsVisible
		{
			get => this._errorMessageIsVisible;
			set => this.Set(ref this._errorMessageIsVisible, value);
		}

		private bool _addNewWineButtonIsEnabled = true;
		public bool AddNewWineButtonIsEnabled
		{
			get => this._addNewWineButtonIsEnabled;
			set => this.Set(ref this._addNewWineButtonIsEnabled, value);
		}

		private string _producerErrorMessage;
		public string ProducerErrorMessage
		{
			get => this._producerErrorMessage;
			set => this.Set(ref this._producerErrorMessage, value);
		}

		private Brush _producerTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
		public Brush ProducerTextBoxBordersColor 
		{
			get => this._producerTextBoxBordersColor;
			set => this.Set(ref this._producerTextBoxBordersColor, value);
		}

		public ICommand CheckProducerValidityCommand => new RelayCommand(this.CheckProducerValidity);

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		public AddNewWineViewModel()
		{
		}

		public void CheckProducerValidity()
		{
			if (string.IsNullOrEmpty(this.Wine.Producer))
			{
				this.ProducerErrorMessage = "Le champs ne peut pas être vide";
				this.ProducerTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFFF0000");
				this.ErrorMessageIsVisible = true;
			}
            else
			{
				this.ProducerErrorMessage = string.Empty;
				this.ProducerTextBoxBordersColor = UserInterfaceHelper.GetSolidColorBrushFromHexadecimal("#FFA7A7A7");
				this.ErrorMessageIsVisible = false;
			}
		}

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