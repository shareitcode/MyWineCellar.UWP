using MyWineCellar.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar.Views
{
	public sealed partial class WineListPage : Page
	{
		private WineListViewModel WineListViewModel { get; } = new WineListViewModel();

		public WineListPage()
		{
			this.InitializeComponent();
			this.DataContext = this.WineListViewModel;
			SystemNavigationManager.GetForCurrentView().BackRequested += this.WineListView_BackRequested;
		}

		private void WineListView_BackRequested(object sender, BackRequestedEventArgs e)
		{
			if (this.Frame.CanGoBack)
			{
				SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
				this.Frame.GoBack();
				e.Handled = true;
			}
		}
	}
}