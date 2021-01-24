using Windows.ApplicationModel.Resources;

namespace MyWineCellar.Helpers
{
	internal static class Constants
	{
		internal static string[] WineColors { get; } =
		{
				ResourceLoader.GetForViewIndependentUse().GetString("WineColor"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineColorRed"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineColorWhite"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineColorRose")
		};

		internal static string[] AcquisitionMeans { get; } =
		{
				ResourceLoader.GetForViewIndependentUse().GetString("WineAcquisitionMeans"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineAcquisitionMeansProducer"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineAcquisitionMeansShop"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineAcquisitionMeansSupermarkets"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineAcquisitionMeansInternet"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineAcquisitionMeansTradeFair"),
				ResourceLoader.GetForViewIndependentUse().GetString("WineAcquisitionMeansGift")
		};

		internal static string ErrorMessage { get; } = "ErrorMessage";
		internal static string RegexPatternImage { get; } = ".jpg|.jpeg|.png";
	}
}