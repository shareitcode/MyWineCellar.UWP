using Microsoft.Toolkit.Uwp.UI.Controls;
using MyWineCellar.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar.Views
{
    internal sealed partial class AddNewWinePage : Page
    {
        private AddNewWineViewModel AddNewWineViewModel { get; } = new AddNewWineViewModel();

        public AddNewWinePage()
        {
            this.InitializeComponent();
            this.DataContext = this.AddNewWineViewModel;
        }

        private void InAppNotification_OnClosed(object sender, InAppNotificationClosedEventArgs e)
        {
            this.AddNewWineViewModel.ErrorMessageIsVisible = false;
        }
    }
}