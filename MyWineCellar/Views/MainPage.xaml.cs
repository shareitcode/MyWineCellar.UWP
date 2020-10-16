using MyWineCellar.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MyWineCellar.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel MainViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this.MainViewModel;
            this.MainViewModel.Initialize(this.ContentFrame, this.NavigationView, this.KeyboardAccelerators);
        }
    }
}