using sportShop.ViewModels;

namespace sportShop.Views.GeneralPages;

public partial class AuthorizationView
{
    public AuthorizationView()
    {
        DataContext = new AuthorizationViewModel();

        InitializeComponent();
    }
}