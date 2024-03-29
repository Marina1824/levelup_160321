﻿using System;
using System.Windows.Input;

namespace Bill.Management.Windows.ViewModels.Commands
{
    public sealed class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(string commandName, Action<object> execute, Func<object, bool> canExecute = null)
        {
            Name = commandName;
            _execute = execute;
            _canExecute = canExecute;
        }

        public string Name { get; internal set; }

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}