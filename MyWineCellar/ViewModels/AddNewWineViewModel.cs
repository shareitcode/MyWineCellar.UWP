using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Services;
using MyWineCellar.Validators;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation.Results;

namespace MyWineCellar.ViewModels
{
	internal sealed class AddNewWineViewModel : BaseViewModel
	{
		public AddWineModel Wine { get; set; } = new AddWineModel();

		public IEnumerable<string> WineColors { get; } = Constants.WineColors;

		public IEnumerable<string> AcquisitionMeans { get; } = Constants.AcquisitionMeans;

		private string _errorMessage;
		public string ErrorMessage
		{
			get => this._errorMessage;
			set => this.Set(ref this._errorMessage, value);
		}

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		public async Task AddNewWine()
		{
			try
			{
				AddWineModel wine = this.Wine;
				ValidationResult validationResult = await AddNewWineValidator.GetValidator().ValidateAsync(wine);
				if (validationResult.IsValid)
					NavigationService.GoBack();
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (ValidationFailure validationFailure in validationResult.Errors)
					{
						stringBuilder.AppendLine($"- {validationFailure.ErrorMessage}");
					}
					this.ErrorMessage = stringBuilder.ToString();
				}
				//await WineRepository.Add(this.Wine);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}