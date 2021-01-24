using FluentValidation;
using MyWineCellar.Models;

namespace MyWineCellar.Validators
{
	internal class AddNewWineValidator : AbstractValidator<AddWineModel>
	{
		internal AddNewWineValidator()
		{
			this.RuleFor(wine => wine.Producer).Must(producer => !string.IsNullOrEmpty(producer?.Trim())).WithMessage("Please specify a wine producer");
			this.RuleFor(wine => wine.Country).Must(country => !string.IsNullOrEmpty(country?.Trim())).WithMessage("Please specify a wine country");
			this.RuleFor(wine => wine.Region).Must(region => !string.IsNullOrEmpty(region?.Trim())).WithMessage("Please specify a wine region");
			this.RuleFor(wine => wine.Appellation).Must(appellation => !string.IsNullOrEmpty(appellation?.Trim())).WithMessage("Please specify a wine appellation");
			this.RuleFor(wine => wine.Parcel).Must(parcel => !string.IsNullOrEmpty(parcel?.Trim())).WithMessage("Please specify a wine parcel");
			this.RuleFor(wine => wine.Vintage).Must(vintage => vintage.HasValue && vintage.Value > 0).WithMessage("Please specify a wine vintage");
			this.RuleFor(wine => wine.Quantity).Must(quantity => quantity.HasValue && quantity.Value > 0).WithMessage("Please specify a wine quantity");
			this.RuleFor(wine => wine.Color).GreaterThan(vintage => 0).WithMessage("Please specify a wine color");
			this.RuleFor(wine => wine.AcquisitionMeans).GreaterThan(vintage => 0).WithMessage("Please specify a wine acquisition means");
		}
	}
}