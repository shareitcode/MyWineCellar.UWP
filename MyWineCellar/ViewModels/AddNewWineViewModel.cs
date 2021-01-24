using FluentValidation.Results;
using MyWineCellar.DTO;
using MyWineCellar.Extensions;
using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Repository;
using MyWineCellar.Services;
using MyWineCellar.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWineCellar.ViewModels
{
	internal sealed class AddNewWineViewModel : BaseViewModel
	{
		private ObservableCollection<WineListModel> Wines { get; }

		private AddWineModel _wine = new AddWineModel();
		public AddWineModel Wine
		{
			get => this._wine;
			set => this.Set(ref this._wine, value);
		}

		public IEnumerable<string> WineColors { get; } = Constants.WineColors;

		public IEnumerable<string> AcquisitionMeans { get; } = Constants.AcquisitionMeans;

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		private AddNewWineValidator AddNewWineValidator { get; } = new AddNewWineValidator();

		public AddNewWineViewModel()
		{
			if (Session.Instance.IsExist("Wines"))
				this.Wines = Session.Instance.Get<ObservableCollection<WineListModel>>("Wines");
		}

		public async Task AddNewWine()
		{
			try
			{
				// TODO: Try to move error validation responsibility to error object. The model inherit from error object
				//ValidationResult validationResult = await this.Wine.GetValidationResultAsync();
				ValidationResult validationResult = await this.AddNewWineValidator.ValidateAsync(this.Wine);
				if (validationResult.IsValid)
				{
					WineDto wineModelToDto = MapModels.Map<WineDto>(this.Wine);

					await WineRepository.Add(wineModelToDto);

					this.Wines.Add(MapModels.Map<WineListModel>(wineModelToDto));

					Session.Instance.Update("Wines", this.Wines);

					NavigationService.GoBack();
				}
				else
					this.SetErrorMessages(validationResult);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private void SetErrorMessages(ValidationResult validationResult)
		{
			this.Wine.ClearErrorMessages();

			foreach (ValidationFailure validationFailure in validationResult.Errors)
				this.Wine.SetValueOfErrorMessagePropertyInformations(validationFailure);

			this.OnPropertyChanged(nameof(this.Wine));
		}
	}
}