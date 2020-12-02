using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MyWineCellar.Converters
{
    internal sealed class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string valueAsString)
                return string.IsNullOrEmpty(valueAsString?.Trim()) ? Visibility.Collapsed : Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) => (value is Visibility visibility && visibility == Visibility.Visible);
    }
}