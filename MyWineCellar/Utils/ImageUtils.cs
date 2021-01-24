using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace MyWineCellar.Utils
{
	internal static class ImageUtils
	{
		public static async Task<BitmapImage> ConvertByteToImageAsync(byte[] imageBytes)
		{
			BitmapImage image = new BitmapImage();
			using InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
			using DataWriter writer = new DataWriter(randomAccessStream.GetOutputStreamAt(0));
			writer.WriteBytes(imageBytes);
			await writer.StoreAsync();
			image.SetSource(randomAccessStream);
			return image;
		}
	}
}