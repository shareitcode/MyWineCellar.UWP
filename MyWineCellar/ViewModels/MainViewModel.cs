using MyWineCellar.Helpers;
using MyWineCellar.Services;
using MyWineCellar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace MyWineCellar.ViewModels
{
	internal sealed class MainViewModel : BaseViewModel
	{
		private WinUI.NavigationView _navigationView;
		private IList<KeyboardAccelerator> _keyboardAccelerators;

		private bool _isBackEnabled;
		public bool IsBackEnabled
		{
			get => this._isBackEnabled;
			set => this.Set(ref this._isBackEnabled, value);
		}

		private bool _isBackVisible;
		public bool IsBackVisible
		{
			get => this._isBackVisible;
			set => this.Set(ref this._isBackVisible, value);
		}

		private WinUI.NavigationViewItem _selected;
		public WinUI.NavigationViewItem Selected
		{
			get => this._selected;
			set => this.Set(ref this._selected, value);
		}

		private ICommand _loadedCommand;
		public ICommand LoadedCommand => this._loadedCommand ?? (this._loadedCommand = new RelayCommand(this.OnLoaded));

		private ICommand _itemInvokedCommand;
		public ICommand ItemInvokedCommand => this._itemInvokedCommand
											  ?? (this._itemInvokedCommand = new RelayCommand<WinUI.NavigationViewItemInvokedEventArgs>(this.OnItemInvoked));

		private async void OnLoaded() => await Task.CompletedTask;

		private void OnItemInvoked(WinUI.NavigationViewItemInvokedEventArgs args)
		{
			if (args.IsSettingsInvoked)
				NavigationService.Navigate(typeof(SettingsPage), null, args.RecommendedNavigationTransitionInfo);
			else if (args.InvokedItemContainer is WinUI.NavigationViewItem selectedItem)
			{
				Type pageType = selectedItem.GetValue(NavigationHelper.NavigateToProperty) as Type;
				NavigationService.Navigate(pageType, null, args.RecommendedNavigationTransitionInfo);
			}
		}

		internal void Initialize(Frame contentFrame, WinUI.NavigationView navigationView, IList<KeyboardAccelerator> keyboardAccelerators)
		{
			this._navigationView = navigationView;
			this._keyboardAccelerators = keyboardAccelerators;
			NavigationService.Frame = contentFrame;
			NavigationService.NavigationFailed += this.NavigationService_NavigationFailed;
			NavigationService.Navigated += this.NavigationService_Navigated;
			this._navigationView.BackRequested += this.NavigationView_BackRequested;
		}

		// TODO: Manage with UI interaction (popup, dedicated page, etc.)
		private void NavigationService_NavigationFailed(object sender, Windows.UI.Xaml.Navigation.NavigationFailedEventArgs e) => throw e.Exception;

		private void NavigationService_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
		{
			this.IsBackEnabled = NavigationService.CanGoBack;
			this.IsBackVisible = this.IsBackEnabled;

			if (e.SourcePageType == typeof(SettingsPage))
			{
				this.Selected = this._navigationView.SettingsItem as WinUI.NavigationViewItem;
				return;
			}

			WinUI.NavigationViewItem selectedItem = this.GetSelectedItem(this._navigationView.MenuItems, e.SourcePageType);
			if (selectedItem != null)
				this.Selected = selectedItem;
		}

		private WinUI.NavigationViewItem GetSelectedItem(IEnumerable<object> menuItems, Type pageType)
		{
			foreach (WinUI.NavigationViewItem item in menuItems.OfType<WinUI.NavigationViewItem>())
			{
				if (this.IsMenuItemForPageType(item, pageType))
					return item;
				WinUI.NavigationViewItem selectedChild = this.GetSelectedItem(item.MenuItems, pageType);
				if (selectedChild != null)
					return selectedChild;
			}
			return null;
		}

		private bool IsMenuItemForPageType(WinUI.NavigationViewItem menuItem, Type sourcePageType) => menuItem.GetValue(NavigationHelper.NavigateToProperty)
																									  as Type == sourcePageType;

		private void NavigationView_BackRequested(WinUI.NavigationView sender, WinUI.NavigationViewBackRequestedEventArgs args) => NavigationService.GoBack();
	}
}