using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Services;
using System.Windows.Input;

namespace MyWineCellar.ViewModels
{
    internal sealed class AddNewWineViewModel : BaseViewModel
    {
        public Wine Wine { get; set; }

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => this._errorMessage;
            set
            {
                this._errorMessage = value;
                this.OnPropertyChanged();
            }
        }

        private bool _errorMessageIsVisible;
        public bool ErrorMessageIsVisible
        {
            get => this._errorMessageIsVisible;
            set
            {
                this._errorMessageIsVisible = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand AddNewWineCommand => new RelayCommand(this.AddNewWine);

        public AddNewWineViewModel()
        {
            this.Wine = new Wine();
        }

        public void AddNewWine()
        {
            if (Session.Instance.Add(nameof(this.Wine), this.Wine))
            {
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