using MyWineCellar.DTO;
using MyWineCellar.Helpers;
using MyWineCellar.Repository;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyWineCellar.ViewModels
{
	internal sealed class WineListViewModel : BaseViewModel
	{
		private ObservableCollection<WineDto> _wines;
		public ObservableCollection<WineDto> Wines
		{
			get => this._wines;
			set => this.Set(ref this._wines, value);
		}

		public async Task InitializeAsync()
		{
			if (Session.Instance.IsExist("Wines"))
			{
				this.Wines = new ObservableCollection<WineDto>(Session.Instance.Get<ObservableCollection<WineDto>>("Wines"));
			}
			else
			{
				this.Wines = new ObservableCollection<WineDto>(await WineRepository.GetAllWines());
				Session.Instance.Add(nameof(this.Wines), this.Wines);
			}
		}
	}
}