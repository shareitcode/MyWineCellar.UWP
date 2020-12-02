using FluentValidation;
using MyWineCellar.Models;

namespace MyWineCellar.Validators
{
	internal sealed class AddNewWineValidator : AbstractValidator<AddWineModel>
	{
		public AddNewWineValidator()
		{
			this.RuleFor(wine => wine.Producer).NotNull().NotEmpty().WithMessage("Please specify a wine producer");
			this.RuleFor(wine => wine.Country).NotNull().NotEmpty().WithMessage("Please specify a wine country");
			this.RuleFor(wine => wine.Region).NotNull().NotEmpty().WithMessage("Please specify a wine region");
			this.RuleFor(wine => wine.Appellation).NotNull().NotEmpty().WithMessage("Please specify a wine appellation");
			this.RuleFor(wine => wine.Parcel).NotNull().NotEmpty().WithMessage("Please specify a wine parcel");
			this.RuleFor(wine => wine.Vintage).NotNull().DependentRules(() =>
			{
				this.RuleFor(wine => wine.Vintage).GreaterThan(vintage => 0);
			}).WithMessage("Please specify a wine vintage");
			this.RuleFor(wine => wine.Quantity).NotNull().DependentRules(() =>
			{
				this.RuleFor(wine => wine.Quantity).GreaterThan(vintage => 0);
			}).WithMessage("Please specify a wine quantity");
			this.RuleFor(wine => wine.Color).GreaterThan(vintage => 0).WithMessage("Please specify a wine color");
			this.RuleFor(wine => wine.AcquisitionMeans).GreaterThan(vintage => 0).WithMessage("Please specify a wine acquisition means");
		}

		internal static AddNewWineValidator GetValidator() => new AddNewWineValidator();
	}
}