using sportShop.Models;
using sportShop.ViewModels;

namespace sportShop.Views.ClientPages;

public partial class ClientBasketView
{
    public ClientBasketView(Client client)
    {
        DataContext = new ClientBasketViewModel(client);

        InitializeComponent();
    }
}