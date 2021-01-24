using MyWineCellar.Helpers;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.Results;
using MyWineCellar.Models;
using MyWineCellar.Validators;

namespace MyWineCellar.Extensions
{
	internal static class ErrorModelBaseExtension
	{
		internal static void ClearErrorMessages(this ErrorModelBase obj)
		{
			foreach (PropertyInfo property in obj.GetType().GetProperties())
				if (property.Name.EndsWith(Constants.ErrorMessage))
					property.SetValue(obj, string.Empty);
		}

		internal static void SetValueOfErrorMessagePropertyInformations(this ErrorModelBase obj, ValidationFailure validationFailure)
		{
			PropertyInfo winePropertyErrorMessage = obj.GetErrorMessagePropertyInformationsByPropertyName(validationFailure.PropertyName);
			if (winePropertyErrorMessage != null)
				winePropertyErrorMessage.SetValue(obj, validationFailure.ErrorMessage);
		}

		internal static PropertyInfo GetErrorMessagePropertyInformationsByPropertyName(this ErrorModelBase obj, string propertyName)
		{
			PropertyInfo[] properties = obj.GetType().GetProperties();
			return properties.FirstOrDefault(wineProperty => wineProperty.Name.EndsWith(Constants.ErrorMessage) && wineProperty.Name.StartsWith(propertyName));
		}

		//public static async Task<ValidationResult> GetValidationResultAsync(this ErrorModelBase obj)
		//{
		//	return await new ValidatorBase().ValidateAsync(obj);
		//}
	}
}