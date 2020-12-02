using MyWineCellar.ViewModels;
using Windows.UI.Xaml;
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
			this.Loading += this.WineListPage_Loading;
		}

		private async void WineListPage_Loading(FrameworkElement sender, object args) => await this.WineListViewModel.InitializeAsync();
	}
}