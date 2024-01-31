using System.Linq;
using System.Windows;
using sportShop.Models;
using sportShop.Views.AdminPages;

namespace sportShop.ViewModels;

public class AdminProductViewModel : ProductViewModel
{
    public RelayCommand AddProductCommand { get; private set; }
    public RelayCommand NavigateAdminRegistrationPage { get; private set; }
    public RelayCommand<Product> DeleteProductCommand { get; private set; }

    public AdminProductViewModel()
    {
        NavigateAdminRegistrationPage = new RelayCommand(NavigateAdminRegistrationPageExecute);
        AddProductCommand = new RelayCommand(AddProductCommandExecute);
        DeleteProductCommand = new RelayCommand<Product>(DeleteProductCommandExecute);
    }

    private void NavigateAdminRegistrationPageExecute()
    {
        DbContext.SaveChanges();

        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.NavigationService.Navigate(new AdminRegistrationView());
    }

    private void DeleteProductCommandExecute(Product product)
    {
        DbContext.Products.Remove(product);

        Products.Remove(product);
    }

    private void AddProductCommandExecute()
    {
        var product = new Product
        {
            Name = $"Product{Products.Count}", ProductTypeId = DbContext.ProductTypes.First().Id,
            ProductType = DbContext.ProductTypes.First(),
            Fabric = DbContext.Fabrics.First(), FabricId = DbContext.Fabrics.First().Id, Price = 0, Sale = 0, ProductCount = 1
        };

        var fabric = DbContext.Fabrics.Find(product.FabricId);

        fabric?.Products.Add(product);
        DbContext.Products.Add(product);

        Products.Add(product);
    }
}