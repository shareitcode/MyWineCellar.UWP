using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using MyWineCellar.ViewModels;

namespace MyWineCellar.Views
{
    public sealed partial class AddNewWineView : Page
    {
        private readonly AddNewWineViewModel AddNewWineViewModel = new AddNewWineViewModel();

        public AddNewWineView()
        {
            InitializeComponent();
            this.DataContext = this.AddNewWineViewModel;
            SystemNavigationManager.GetForCurrentView().BackRequested += AddNewWineView_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void AddNewWineView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
    }
}
