// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, August 14, 2020 10:32:42 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Windows.Input;
using nGratis.Cop.Olympus.Contract;

public class RelayCommand : ICommand
{
    private readonly Action _execute;

    private readonly Func<bool> _canExecute;

    private RelayCommand(Action execute, Func<bool> canExecute)
    {
        Guard
            .Require(execute, nameof(execute))
            .Is.Not.Null();

        this._execute = execute;
        this._canExecute = canExecute;
    }

    public static RelayCommand Create(Action execute, Func<bool> canExecute = null)
    {
        return new(execute, canExecute);
    }

    public event EventHandler CanExecuteChanged
    {
        add
        {
            if (this._canExecute != null)
            {
                CommandManager.RequerySuggested += value;
            }
        }

        remove
        {
            if (this._canExecute != null)
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }

    public bool CanExecute(object parameter)
    {
        return
            this._canExecute == null ||
            this._canExecute();
    }

    public void Execute(object parameter)
    {
        this._execute();
    }
}