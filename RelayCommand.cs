using System;
using System.Windows.Input;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

namespace sportShop;

/// <summary>
/// Класс описывающий команды
/// </summary>
public class RelayCommand : ICommand
{
    public Action Action { get; set; }

    public void Execute(object parameter)
    {
        Action?.Invoke();
    }

    public bool CanExecute(object parameter)
    {
        return IsEnabled;
    }

    private bool _isEnabled = true;

    public bool IsEnabled
    {
        get { return _isEnabled; }
        set
        {
            _isEnabled = value;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler CanExecuteChanged;

    public RelayCommand(Action action)
    {
        Action = action;
    }
}

public class RelayCommand<T> : ICommand
{
    public Action<T> Action { get; set; }

    public void Execute(object parameter)
    {
        if (Action != null && parameter is T)
            Action((T) parameter);
    }

    public bool CanExecute(object parameter)
    {
        return IsEnabled;
    }

    private bool _isEnabled = true;

    public bool IsEnabled
    {
        get { return _isEnabled; }
        set
        {
            _isEnabled = value;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler CanExecuteChanged;

    public RelayCommand(Action<T> action)
    {
        Action = action;
    }
}