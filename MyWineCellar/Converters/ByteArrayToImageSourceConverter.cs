using AutoMapper;
using MyWineCellar.Utils;
using Windows.UI.Xaml.Media.Imaging;

namespace MyWineCellar.Converters
{
	internal sealed class ByteArrayToImageSourceConverter : IValueConverter<byte[], BitmapImage>
	{
		public BitmapImage Convert(byte[] sourceMember, ResolutionContext context)
		{
			BitmapImage bitmapImage = new BitmapImage();

			if (sourceMember?.Length > 0)
				bitmapImage = ImageUtils.ConvertByteToImageAsync(sourceMember).Result;

			return bitmapImage;
		}
	}
}