using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MyWineCellar.Converters
{
	internal sealed class BooleanToNavigationViewBackButtonVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is bool valueAsBool && valueAsBool)
				return NavigationViewBackButtonVisible.Visible;

			return NavigationViewBackButtonVisible.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language) => (value is NavigationViewBackButtonVisible visibility
																								  && visibility == NavigationViewBackButtonVisible.Visible);
	}
}