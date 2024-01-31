using sportShop.ViewModels;

namespace sportShop.Views.ClientPages;

public partial class ClientRegistrationView
{
    public ClientRegistrationView()
    {
        InitializeComponent();

        DataContext = new RegistrationViewModel();
    }
}