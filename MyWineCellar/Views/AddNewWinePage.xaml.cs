using Microsoft.Toolkit.Uwp.Helpers;
using MyWineCellar.Extensions;
using MyWineCellar.ViewModels;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
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

		private void WineImage_OnDragOver(object sender, DragEventArgs dragEventArgs) => dragEventArgs.AcceptedOperation = DataPackageOperation.Copy;

		private async void WineImage_OnDrop(object sender, DragEventArgs dragEventArgs)
		{
			StorageFile storageFile = await dragEventArgs.DataView.GetStorageFileAsync();
			if (storageFile != null && storageFile.IsImageFileType())
			{
				this.WineImage.Source = (await storageFile.OpenAsync(FileAccessMode.Read)).ToBitmapImage();
				await this.SetImageAddWineModel(storageFile);
			}
		}

		private async Task SetImageAddWineModel(StorageFile storageFile)
		{
			this.AddNewWineViewModel.Wine.Image = await storageFile.ReadBytesAsync();
			this.AddNewWineViewModel.Wine.ImageNameWithExtension = storageFile.Name;
		}
	}
}