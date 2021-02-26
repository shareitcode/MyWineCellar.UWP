using FluentValidation;
using MyWineCellar.Models;

namespace MyWineCellar.Validators
{
	internal abstract class ValidatorBase<ErrorModel> : AbstractValidator<ErrorModelBase> where ErrorModel : class
	{
	}
}