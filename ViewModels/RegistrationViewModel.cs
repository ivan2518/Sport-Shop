using System;
using System.Windows;
using sportShop.Models;
using sportShop.Views.GeneralPages;

namespace sportShop.ViewModels;

sealed public class RegistrationViewModel : BaseViewModel
{
    private readonly DbContext _dbContext;

    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private string _login;

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged();
        }
    }

    private string _age;

    public string Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged();
        }
    }

    private string _password;

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    private string _submitPassword;

    public string SubmitPassword
    {
        get => _submitPassword;
        set
        {
            _submitPassword = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand RegistrationClientCommand { get; }
    public RelayCommand NavigateToAuthorizationCommand { get; }

    public RegistrationViewModel()
    {
        _dbContext = new DbContext();

        _name = string.Empty;
        _login = string.Empty;
        _age = string.Empty;
        _password = string.Empty;
        _submitPassword = string.Empty;

        RegistrationClientCommand = new RelayCommand(RegistrationClientCommandExecute);
        NavigateToAuthorizationCommand = new RelayCommand(NavigateToAuthorizationCommandExecute);
    }
    private void NavigateToAuthorizationCommandExecute()
    {
        _dbContext.SaveChanges();

        var mainWindow = Application.Current.MainWindow as MainWindow;

        mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
    }
    private void RegistrationClientCommandExecute()
    {
        var newClient = new Client
        {
            Name = _name,
            Login = _login,
            Age = Convert.ToInt32(_age),
            Password = _password
        };

        _dbContext.Clients.Add(newClient);

        MessageBox.Show("Регистрация прошла успешно!");
    }
}