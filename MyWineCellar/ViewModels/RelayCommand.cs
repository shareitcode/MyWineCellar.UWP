using System;
using System.Windows.Input;

namespace MyWineCellar.ViewModels
{
    internal sealed partial class AddNewWineViewModel
    {
        internal sealed class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;
            public event EventHandler CanExecuteChanged;

            public RelayCommand(Action execute) : this(execute, null)
            {
            }

            public RelayCommand(Action execute, Func<bool> canExecute)
            {
                this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
                this._canExecute = canExecute;
            }

            public bool CanExecute(object parameter) => this._canExecute?.Invoke() != false;

            public void Execute(object parameter) => this._execute();

            public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
