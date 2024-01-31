using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using sportShop.Models;
using sportShop.Views.GeneralPages;

namespace sportShop.ViewModels;

public class ProductViewModel : BaseViewModel
{
    readonly protected DbContext DbContext;

    public RelayCommand NavigateAuthorisationPage { get; private set; }

    private readonly ObservableCollection<Product> _products;

    public ObservableCollection<Product> Products
    {
        get => _products;
        protected init
        {
            _products = value;
            OnPropertyChanged();
        }
    }

    public ProductViewModel()
    {
        DbContext = new DbContext();
        _products = new ObservableCollection<Product>(DbContext.Products.Include(c => c.Fabric).Include(c => c.ProductType));

        NavigateAuthorisationPage = new RelayCommand(NavigateAuthorisationPageExecute);
    }

    private void NavigateAuthorisationPageExecute()
    {
        DbContext.SaveChanges();

        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.NavigationService.Navigate(new AuthorizationView());
    }
}