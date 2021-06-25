
namespace Springall.Core
{
    using System;
    using System.Windows.Input;
    public class RouteCommands : ICommand
    {
        private Action mAction = null;

        public event EventHandler CanExecuteChanged = (sender,e) => { };


        public RouteCommands(Action action)
        {
            mAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
