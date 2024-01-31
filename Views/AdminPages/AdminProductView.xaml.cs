using sportShop.ViewModels;

namespace sportShop.Views.AdminPages;

public partial class AdminProductView
{
    public AdminProductView()
    {
        DataContext = new AdminProductViewModel();

        InitializeComponent();
    }
}