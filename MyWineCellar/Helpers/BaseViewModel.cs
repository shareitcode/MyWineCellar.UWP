using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyWineCellar.Helpers
{
	internal class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		protected void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(storage, value))
				return;

			storage = value;
			this.OnPropertyChanged(propertyName);
		}

		public void OnPropertyChanged([CallerMemberName] string propertyName = null) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}