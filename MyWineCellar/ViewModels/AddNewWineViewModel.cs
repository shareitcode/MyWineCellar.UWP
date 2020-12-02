﻿using MyWineCellar.DTO;
using MyWineCellar.Helpers;
using MyWineCellar.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

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
		
		public ICommand CheckProducerValidityCommand => new RelayCommand(this.CheckProducerValidity);

		public ICommand AddNewWineCommand => new RelayCommand(async () => await this.AddNewWine());

		public AddNewWineViewModel()
		{
		}

		public void CheckProducerValidity()
		{
			this.ProducerErrorMessage = string.IsNullOrEmpty(this.Wine.Producer) ? "Le champs ne peut pas être vide" : string.Empty;
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