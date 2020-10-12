using MyWineCellar.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar.Views
{
    public sealed partial class WineListPage : Page
    {
        private readonly WineListViewModel WineListViewModel = new WineListViewModel();

        public WineListPage()
        {
            InitializeComponent();
            this.DataContext = WineListViewModel;
            SystemNavigationManager.GetForCurrentView().BackRequested += WineListView_BackRequested;
        }

        private void WineListView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void AddNewWineButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNewWinePage));
        }
    }
}