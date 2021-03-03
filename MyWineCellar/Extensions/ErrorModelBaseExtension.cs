using FluentValidation;
using FluentValidation.Results;
using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Validators;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyWineCellar.Extensions
{
	internal static class ErrorModelBaseExtension
	{
		internal static void ClearErrorMessages(this ModelBase model)
		{
			foreach (PropertyInfo property in model.GetType().GetProperties())
				if (property.Name.EndsWith(Constants.ErrorMessage))
					property.SetValue(model, string.Empty);
		}

		internal static void SetValueOfErrorMessagePropertyInformations(this ModelBase model, ValidationFailure validationFailure)
		{
			PropertyInfo winePropertyErrorMessage = model.GetErrorMessagePropertyInformationsByPropertyName(validationFailure.PropertyName);
			if (winePropertyErrorMessage != null)
				winePropertyErrorMessage.SetValue(model, validationFailure.ErrorMessage);
		}

		internal static PropertyInfo GetErrorMessagePropertyInformationsByPropertyName(this ModelBase model, string propertyName)
		{
			PropertyInfo[] properties = model.GetType().GetProperties();
			return properties.FirstOrDefault(wineProperty => wineProperty.Name.EndsWith(Constants.ErrorMessage) && wineProperty.Name.StartsWith(propertyName));
		}

		internal static async Task<ValidationResult> GetValidationResultAsync<ModelValidator>(this ModelBase model) where ModelValidator : AbstractValidator<ModelBase>
		{
			IValidator<ModelBase> validator = ValidatorFactory.GetValidationResultAsync(typeof(ModelValidator).Name);
			return await validator.ValidateAsync(model);
		}
	}
}