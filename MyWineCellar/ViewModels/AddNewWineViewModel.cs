﻿using MyWineCellar.DTO;
using MyWineCellar.Helpers;
using MyWineCellar.Services;
using System.Collections.ObjectModel;
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

		public ICommand AddNewWineCommand => new RelayCommand(this.AddNewWine);

		public void AddNewWine()
		{
			if (Session.Instance.IsExist("Wines"))
			{
				Session.Instance.Get<ObservableCollection<WineDto>>("Wines").Add(this.Wine);
				this.Wine = null;
				NavigationService.GoBack();
			}
			else
			{
				this.ErrorMessage = "Couldn't added wine 🙁";
				this.ErrorMessageIsVisible = true;
			}
		}
	}
}