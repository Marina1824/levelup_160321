using System;
using System.Windows.Input;
using Bill.Management.Windows.ViewModels.Commands;

namespace Bill.Management.Windows.ViewModels.Factories
{
    internal sealed class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName, Action<object> execute, Func<object, bool> canExecute = null)
        {
            return new RelayCommand(execute, canExecute) { Name = commandName };
        }
    }
}