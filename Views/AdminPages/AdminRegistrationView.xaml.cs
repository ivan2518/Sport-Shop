using sportShop.ViewModels;

namespace sportShop.Views.AdminPages;

public partial class AdminRegistrationView
{
    public AdminRegistrationView()
    {
        DataContext = new AdminRegistrationViewModel();

        InitializeComponent();
    }
}