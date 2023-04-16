using System;
using System.Windows.Input;

namespace ViewModel
{
    //implementacja interfejsu ICommand
    internal class Sygnal : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public Sygnal(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute();
        
        public void Execute(object parameter) => this.execute();

        internal void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
