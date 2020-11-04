using System;
using Windows.UI.Xaml.Data;

namespace MyWineCellar.Converters
{
	internal sealed class DoubleToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language) => value is double valueIsDouble ? valueIsDouble.ToString() : string.Empty;

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			double valueParseToDouble = 0;
			if (value is string valueIsString)
				double.TryParse(valueIsString, out valueParseToDouble);
			return valueParseToDouble;
		}
	}
}