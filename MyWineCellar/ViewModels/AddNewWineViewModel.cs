using FluentValidation.Results;
using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Services;
using MyWineCellar.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation.Results;

namespace MyWineCellar.ViewModels
{
    internal sealed class AddNewWineViewModel : BaseViewModel
	{
		private AddWineModel _wine = new AddWineModel();
		public AddWineModel Wine
		{
			get => this._wine;
			set => this.Set(ref _wine, value);
		}

		public IEnumerable<string> WineColors { get; } = Constants.WineColors;

		public IEnumerable<string> AcquisitionMeans { get; } = Constants.AcquisitionMeans;

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		public async Task AddNewWine()
		{
			try
			{
				AddWineModel wine = this.Wine.Clone();
				ValidationResult validationResult = await AddNewWineValidator.GetValidator().ValidateAsync(wine);
				if (validationResult.IsValid)
					NavigationService.GoBack();
				else
                    SetErrorMessages(wine, validationResult);

                //await WineRepository.Add(this.Wine);
            }
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

        private void SetErrorMessages(AddWineModel wine, ValidationResult validationResult)
        {
            wine.ClearErrorMessages();
            foreach (ValidationFailure validationFailure in validationResult.Errors)
            {
                PropertyInfo winePropertyErrorMessage = GetWinePropertyInformationsByValidationPropertyName(validationFailure);
                if (winePropertyErrorMessage != null)
                    winePropertyErrorMessage.SetValue(wine, validationFailure.ErrorMessage);
            }
            this.Wine = wine;
        }

        private PropertyInfo GetWinePropertyInformationsByValidationPropertyName(ValidationFailure validationFailure)
        {
            return this.Wine.GetType().GetProperties().FirstOrDefault(wineProperty => wineProperty.Name.EndsWith(Constants.ErrorMessage)
					&& wineProperty.Name.StartsWith(validationFailure.PropertyName));
        }
    }
}