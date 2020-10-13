using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace MyWineCellar.Views
{
    public sealed partial class MainPage : Page
    {
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("AddNewWine", typeof(AddNewWinePage)),
            ("WineList", typeof(WineListPage))
        };

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationView.Loaded += this.NavigationView_Loaded;
            this.NavigationView.ItemInvoked += this.NavigationView_ItemInvoked;
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigationView.SelectedItem = this.NavigationView.MenuItems[0];
            this.ContentFrame.Navigate(typeof(WineListPage));
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                this.NavigationView_NavigateTo("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                string navItemTag = args.InvokedItemContainer.Tag.ToString();
                this.NavigationView_NavigateTo(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavigationView_NavigateTo(string navigationItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navigationItemTag != "settings")
            {
                (string Tag, Type Page) item = this._pages.SingleOrDefault(p => p.Tag.Equals(navigationItemTag));
                _page = item.Page;
            }
            Type preNavPageType = this.ContentFrame.CurrentSourcePageType;

            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                this.ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }
    }
}