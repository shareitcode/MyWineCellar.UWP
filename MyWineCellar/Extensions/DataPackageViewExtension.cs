using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace MyWineCellar.Extensions
{
	internal static class DataPackageViewExtension
	{
		internal static async Task<StorageFile> GetStorageFileAsync(this DataPackageView dataPackageView)
		{
			if (dataPackageView.Contains(StandardDataFormats.StorageItems))
			{
				IReadOnlyList<IStorageItem> items = await dataPackageView.GetStorageItemsAsync();

				if (items.IsNotNullOrNotEmpty() && items.FirstOrDefault() is StorageFile storageFile)
					return storageFile;
			}
			return default;
		}
	}
}