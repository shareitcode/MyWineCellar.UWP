using MyWineCellar.Helpers;
using System.Text.RegularExpressions;
using Windows.Storage;

namespace MyWineCellar.Extensions
{
	internal static class StorageFileExtension
	{
		/// <summary>
		/// Storage file type end by .jpg, .jpeg or .png
		/// </summary>
		/// <param name="storageFile"></param>
		/// <returns></returns>
		internal static bool IsImageFileType(this StorageFile storageFile)
		{
			return storageFile != null && Regex.IsMatch(storageFile.FileType, Constants.RegexPatternImage, RegexOptions.IgnoreCase);
		}
	}
}