using FluentValidation;
using MyWineCellar.Models;

namespace MyWineCellar.Validators
{
	internal class AddNewWineValidator : ValidatorBase<AddWineModel>
	{
		internal AddNewWineValidator()
		{
			this.RuleFor(wine => ((AddWineModel)wine).Producer).Must(producer => !string.IsNullOrEmpty(producer?.Trim())).WithMessage("Please specify a wine producer");
			this.RuleFor(wine => ((AddWineModel)wine).Country).Must(country => !string.IsNullOrEmpty(country?.Trim())).WithMessage("Please specify a wine country");
			this.RuleFor(wine => ((AddWineModel)wine).Region).Must(region => !string.IsNullOrEmpty(region?.Trim())).WithMessage("Please specify a wine region");
			this.RuleFor(wine => ((AddWineModel)wine).Appellation).Must(appellation => !string.IsNullOrEmpty(appellation?.Trim())).WithMessage("Please specify a wine appellation");
			this.RuleFor(wine => ((AddWineModel)wine).Parcel).Must(parcel => !string.IsNullOrEmpty(parcel?.Trim())).WithMessage("Please specify a wine parcel");
			this.RuleFor(wine => ((AddWineModel)wine).Vintage).Must(vintage => vintage.HasValue && vintage.Value > 0).WithMessage("Please specify a wine vintage");
			this.RuleFor(wine => ((AddWineModel)wine).Quantity).Must(quantity => quantity.HasValue && quantity.Value > 0).WithMessage("Please specify a wine quantity");
			this.RuleFor(wine => ((AddWineModel)wine).Color).GreaterThan(vintage => 0).WithMessage("Please specify a wine color");
			this.RuleFor(wine => ((AddWineModel)wine).AcquisitionMeans).GreaterThan(vintage => 0).WithMessage("Please specify a wine acquisition means");
		}
	}
}