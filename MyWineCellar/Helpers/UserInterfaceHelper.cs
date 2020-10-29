using System;
using Windows.UI.Xaml.Media;

namespace MyWineCellar.Helpers
{
    internal static class UserInterfaceHelper
    {
        public static SolidColorBrush GetSolidColorBrushFromHexadecimal(string hexadecimal)
        {
            hexadecimal = hexadecimal.Replace("#", string.Empty);

            byte a = (byte)Convert.ToUInt32(hexadecimal.Substring(0, 2), 16);
            byte r = (byte)Convert.ToUInt32(hexadecimal.Substring(2, 2), 16);
            byte g = (byte)Convert.ToUInt32(hexadecimal.Substring(4, 2), 16);
            byte b = (byte)Convert.ToUInt32(hexadecimal.Substring(6, 2), 16);

            return new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
        }
    }
}