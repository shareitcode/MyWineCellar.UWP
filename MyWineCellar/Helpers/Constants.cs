using Windows.ApplicationModel.Resources;

namespace MyWineCellar.Helpers
{
	internal sealed class Constants
	{
		internal static string[] WineColors { get; } =
		{
				ResourceLoader.GetForViewIndependentUse().GetString("AddNewWine_WineColorRed"),
				ResourceLoader.GetForViewIndependentUse().GetString("AddNewWine_WineColorWhite"),
				ResourceLoader.GetForViewIndependentUse().GetString("AddNewWine_WineColorRose")
		};

		internal static string ErrorMessageTheFieldCannotBeEmpty { get; } = ResourceLoader.GetForViewIndependentUse().GetString("ErrorMessage_TheFieldCannotBeEmpty.Text");
	}
}