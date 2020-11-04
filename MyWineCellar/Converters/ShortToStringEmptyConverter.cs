using System;
using Windows.UI.Xaml.Data;

namespace MyWineCellar.Converters
{
	internal sealed class ShortToStringEmptyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language) => value is short valueIsShort ? valueIsShort.ToString() : string.Empty;

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			short valueParseToShort = 0;

			if (value is string valueIsString)
				short.TryParse(valueIsString, out valueParseToShort);

			return valueParseToShort;
		}
	}
}