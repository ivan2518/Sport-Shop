using sportShop.Models;
using sportShop.Views.GeneralPages;

namespace sportShop;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.NavigationService.Navigate(new AuthorizationView());
        AddSDf();
        AddMembers();
        ASDASD();
    }

    public void AddMembers()
    {
        var dbContext = new DbContext();
    
        dbContext.ProductTypes.Add(new ProductTypes() { Name = "Tapok" });
        dbContext.SaveChanges();
    }
    //
    private void AddSDf()
    {
        var dbContext = new DbContext();
    
        dbContext.Administrators.Add(new Administrator() { Login = "Admin", Password = "Admin" });
        dbContext.SaveChanges();
    }
    //
    private void ASDASD()
    {
        var dbContext = new DbContext();
    
        dbContext.Fabrics.Add(new Fabric() { Name = "Fabrik" });
        dbContext.SaveChanges();
    }
}