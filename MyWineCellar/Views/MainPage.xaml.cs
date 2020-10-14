using MyWineCellar.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar.Views
{
    public sealed partial class MainPage : Page
    {
        //private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        //{
        //    ("AddNewWine", typeof(AddNewWinePage)),
        //    ("WineList", typeof(WineListPage))
        //};

        private MainViewModel MainViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this.MainViewModel;
            this.MainViewModel.Initialize(this.ContentFrame, this.NavigationView, this.KeyboardAccelerators);
            //this.NavigationView.Loaded += this.NavigationView_Loaded;
            //this.NavigationView.ItemInvoked += this.NavigationView_ItemInvoked;
            //this.NavigationView.BackRequested += this.NavigationView_BackRequested;
        }

        //private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        //{
        //    this.ContentFrame.Navigated += this.On_Navigated;
        //    this.NavigationView.SelectedItem = this.NavigationView.MenuItems[0];
        //    this.NavigationView_NavigateTo("WineList", new EntranceNavigationTransitionInfo());
        //}

        //private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        //{
        //    if (args.IsSettingsInvoked)
        //    {
        //        this.NavigationView_NavigateTo("settings", args.RecommendedNavigationTransitionInfo);
        //    }
        //    else if (args.InvokedItemContainer != null)
        //    {
        //        this.NavigationView_NavigateTo(args.InvokedItemContainer.Tag.ToString(), args.RecommendedNavigationTransitionInfo);
        //    }
        //}

        //private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        //{
        //    this.On_BackRequested();
        //}

        //private void NavigationView_NavigateTo(string navigationItemTag, NavigationTransitionInfo transitionInfo)
        //{
        //    Type _page = null;
        //    if (navigationItemTag != "settings") _page = this.GetPage(navigationItemTag);
        //    if (navigationItemTag != "WineList")
        //    {
        //        this.NavigationView.IsBackEnabled = true;
        //    }

        //    Type preNavPageType = this.ContentFrame.CurrentSourcePageType;

        //    if (!(_page is null) && !Equals(preNavPageType, _page))
        //    {
        //        this.ContentFrame.Navigate(_page, null, transitionInfo);
        //    }
        //}

        //private Type GetPage(string navigationItemTag) => this._pages.SingleOrDefault(p => p.Tag.Equals(navigationItemTag)).Page;

        //private void On_Navigated(object sender, NavigationEventArgs e)
        //{
        //    this.NavigationView.IsBackEnabled = this.ContentFrame.CanGoBack;

        //    // TODO: Create setting page
        //    //if (ContentFrame.SourcePageType == typeof(SettingsPage))
        //    //{
        //    //    // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
        //    //    NavigationView.SelectedItem = (NavigationViewItem)NavigationView.SettingsItem;
        //    //    NavigationView.Header = "Settings";
        //    //}
        //    if (this.ContentFrame.SourcePageType != null)
        //    {
        //        (string Tag, Type Page) item = this._pages.FirstOrDefault(p => p.Page == e.SourcePageType);
        //        this.NavigationView.SelectedItem = this.NavigationView.MenuItems.OfType<NavigationViewItem>().First(n => n.Tag.Equals(item.Tag));
        //        this.NavigationView.Header = ((NavigationViewItem)this.NavigationView.SelectedItem)?.Content?.ToString();
        //    }
        //}

        //private bool On_BackRequested()
        //{
        //    if (!this.ContentFrame.CanGoBack)
        //        return false;

        //    if (this.NavigationView.IsPaneOpen && (this.NavigationView.DisplayMode == NavigationViewDisplayMode.Compact || this.NavigationView.DisplayMode == NavigationViewDisplayMode.Minimal))
        //        return false;

        //    this.ContentFrame.GoBack();
        //    return true;
        //}

    }
}