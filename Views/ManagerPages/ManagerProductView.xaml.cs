using sportShop.ViewModels;

namespace sportShop.Views.ManagerPages;

public partial class ManagerProductView
{
    public ManagerProductView()
    {
        DataContext = new ProductViewModel();

        InitializeComponent();
    }
}