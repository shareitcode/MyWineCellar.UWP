using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MyWineCellar.Converters
{
	internal sealed class BooleanToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language) => value is bool valueIsBool
																							 && valueIsBool ? Visibility.Visible : Visibility.Collapsed;

		public object ConvertBack(object value, Type targetType, object parameter, string language) => (value is Visibility visibility && visibility == Visibility.Visible);
	}
}