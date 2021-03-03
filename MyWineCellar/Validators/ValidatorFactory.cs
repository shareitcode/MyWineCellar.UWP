using FluentValidation;
using MyWineCellar.Models;
using System;

namespace MyWineCellar.Validators
{
	internal sealed class ValidatorFactory
	{
		internal static IValidator<ModelBase> GetValidationResultAsync(string modelValidatorTypeName)
		{
			if (modelValidatorTypeName.Equals(nameof(AddNewWineValidator)))
				return new AddNewWineValidator();
			throw new InvalidOperationException("Validator is invalid");
		}
	}
}