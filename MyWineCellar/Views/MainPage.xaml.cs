using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyWineCellar.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationView.Loaded += this.NavigationView_Loaded;
            this.NavigationView.ItemInvoked += this.NavigationView_ItemInvoked;
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            this.ContentFrame.Navigate(typeof(WineListPage));
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            FrameNavigationOptions navOptions = new FrameNavigationOptions();
            navOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            Type pageType;
        }
    }
}