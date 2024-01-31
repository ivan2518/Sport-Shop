using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using sportShop.Models;
using sportShop.Views.ClientPages;

namespace sportShop.ViewModels;

public class ClientProductViewModel : ProductViewModel
{
    public RelayCommand<Product> AddToBucketCommand { get; private set; }
    public RelayCommand NavigateClientBasket { get; private set; }

    private readonly Client _client;

    public ClientProductViewModel(Client client)
    {
        _client = client;

        NavigateClientBasket = new RelayCommand(NavigateClientBasketExecute);
        AddToBucketCommand = new RelayCommand<Product>(AddToBucketCommandExecute);

        Products = new ObservableCollection<Product>(DbContext.Products.Where(product => product.ProductCount > 0)
            .Include(c => c.Fabric).Include(c => c.ProductType));
    }

    private void NavigateClientBasketExecute()
    {
        DbContext.SaveChanges();

        var mainWindow = Application.Current.MainWindow as MainWindow;
        var clientBasketView = new ClientBasketView(DbContext.Clients.First(c => c.Id == _client.Id));

        mainWindow?.MainFrame.NavigationService.Navigate(clientBasketView);
    }

    private void AddToBucketCommandExecute(Product product)
    {
        DbContext.Clients.First(c => c.Id == _client.Id).Products.Add(product);
    }
}