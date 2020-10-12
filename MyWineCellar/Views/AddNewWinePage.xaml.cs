using MyWineCellar.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI.Controls;

namespace MyWineCellar.Views
{
    internal sealed partial class AddNewWinePage : Page
    {
        private AddNewWineViewModel AddNewWineViewModel { get; } = new AddNewWineViewModel();

        public AddNewWinePage()
        {
            this.InitializeComponent();
            this.DataContext = this.AddNewWineViewModel;
            SystemNavigationManager.GetForCurrentView().BackRequested += this.AddNewWineView_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void AddNewWineView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                e.Handled = true;
            }
        }

        private void InAppNotification_OnClosed(object sender, InAppNotificationClosedEventArgs e)
        {
            this.AddNewWineViewModel.ErrorMessageIsVisible = false;
        }
    }
}