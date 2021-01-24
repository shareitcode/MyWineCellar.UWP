using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace MyWineCellar.Extensions
{
	internal static class RandomAccessStreamExtension
	{
		internal static BitmapImage ToBitmapImage(this IRandomAccessStream randomAccessStream)
		{
			BitmapImage bitmapImage = new BitmapImage();
			if (randomAccessStream != null)
				bitmapImage.SetSource(randomAccessStream);
			return bitmapImage;
		}
	}
}