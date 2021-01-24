using MyWineCellar.Helpers;
using MyWineCellar.Models;
using MyWineCellar.Repository;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyWineCellar.ViewModels
{
	internal sealed class WineListViewModel : BaseViewModel
	{
		private ObservableCollection<WineListModel> _wines;
		public ObservableCollection<WineListModel> Wines
		{
			get => this._wines;
			set => this.Set(ref this._wines, value);
		}

		private bool _showLoader;
		public bool ShowLoader
		{
			get => this._showLoader;
			set => this.Set(ref this._showLoader, value);
		}

		public async Task InitializeAsync()
		{
			this.ShowLoader = true;
			if (Session.Instance.IsExist("Wines"))
				this.Wines = Session.Instance.Get<ObservableCollection<WineListModel>>("Wines");
			else
			{
				this.Wines = MapModels.Map<ObservableCollection<WineListModel>>(await WineRepository.GetAll());
				Session.Instance.Add(nameof(this.Wines), this.Wines);
			}
			this.ShowLoader = false;
		}
	}
}