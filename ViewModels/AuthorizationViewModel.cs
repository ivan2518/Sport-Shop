using System.Linq;
using System.Windows;
using sportShop.Views.AdminPages;
using sportShop.Views.ClientPages;
using sportShop.Views.ManagerPages;

namespace sportShop.ViewModels;

sealed public class AuthorizationViewModel : BaseViewModel
{
    private readonly MainWindow? _mainWindow;
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

    public RelayCommand SubmitAuthCommand { get; }
    public RelayCommand NavigateToRegistrationCommand { get; }

    public AuthorizationViewModel()
    {
        _mainWindow = Application.Current.MainWindow as MainWindow;

        _password = string.Empty;
        _login = string.Empty;
        SubmitAuthCommand = new RelayCommand(SubmitAuthCommandExecute);
        NavigateToRegistrationCommand = new RelayCommand(NavigateToRegistrationCommandExecute);
    }
    private void NavigateToRegistrationCommandExecute()
    {
        _mainWindow?.MainFrame.NavigationService.Navigate(new ClientRegistrationView());
    }

    private void SubmitAuthCommandExecute()
    {
        var dbContext = new DbContext();

        if (dbContext.Clients.Any(client => client.Password == _password && client.Login == _login))
            _mainWindow?.MainFrame.NavigationService.Navigate(new ClientProductView(dbContext.Clients.First(client => client.Password == _password && client.Login == _login)));

        else if (dbContext.Managers.Any(manager => manager.Password == _password && manager.Login == _login))
            _mainWindow?.MainFrame.NavigationService.Navigate(new ManagerProductView());

        else if (dbContext.Administrators.Any(administrator => administrator.Password == _password && administrator.Login == _login))
            _mainWindow?.MainFrame.NavigationService.Navigate(new AdminProductView());
        else
            MessageBox.Show("Пользователь не зарегестрирован!");

    }
}