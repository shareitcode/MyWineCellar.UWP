using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace MyWineCellar.Helpers
{
	internal sealed class UserInterfaceHelper
	{
		/// <summary>
		/// Parse hexadecimal string to byte for get color brush from ARGB bytes
		/// </summary>
		/// <param name="hexadecimal">Format example: #FFFFFFFF</param>
		/// <returns></returns>
		public static SolidColorBrush GetSolidColorBrushFromHexadecimal(string hexadecimal)
		{
			string hexadecimalWithoutHash = hexadecimal.Replace("#", string.Empty);

			byte.TryParse(hexadecimalWithoutHash.Substring(0, 2), NumberStyles.HexNumber, new NumberFormatInfo(), out byte a);
			byte.TryParse(hexadecimalWithoutHash.Substring(2, 2), NumberStyles.HexNumber, new NumberFormatInfo(), out byte r);
			byte.TryParse(hexadecimalWithoutHash.Substring(4, 2), NumberStyles.HexNumber, new NumberFormatInfo(), out byte g);
			byte.TryParse(hexadecimalWithoutHash.Substring(6, 2), NumberStyles.HexNumber, new NumberFormatInfo(), out byte b);

			return new SolidColorBrush(Color.FromArgb(a, r, g, b));
		}
	}
}