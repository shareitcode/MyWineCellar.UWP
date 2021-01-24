using FluentValidation;
using MyWineCellar.Models;

namespace MyWineCellar.Validators
{
	internal class ValidatorBase<TErrorModelBase> where TErrorModelBase : ErrorModelBase
	{
	}
}