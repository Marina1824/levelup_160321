using System;
using System.Windows.Input;

namespace Bill.Management.Windows.ViewModels.Factories
{
    public interface ICommandFactory
    {
        ICommand Create(string commandName, Action<object> execute, Func<object, bool> canExecute = null);
    }
}