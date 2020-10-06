using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Input;
using MyWineCellar.Models;

namespace MyWineCellar.ViewModels
{
    internal sealed partial class AddNewWineViewModel : BaseViewModel
    {
        public Wine Wine = new Wine();

        public ICommand AddNewWineCommand => new RelayCommand(this.AddNewWine);

        public AddNewWineViewModel()
        {
        }

        public void AddNewWine()
        {
            Wine w = this.Wine;
        }
    }
}