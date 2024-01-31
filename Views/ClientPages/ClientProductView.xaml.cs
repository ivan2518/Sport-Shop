using sportShop.Models;
using sportShop.ViewModels;

namespace sportShop.Views.ClientPages;

public partial class ClientProductView
{
    public ClientProductView(Client client)
    {
        InitializeComponent();

        DataContext = new ClientProductViewModel(client);
    }
}