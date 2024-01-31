using System.Collections.Generic;
using System.ComponentModel;

namespace sportShop.Models;

public class Client
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class Manager
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}

public class Administrator
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
}

sealed public class Product : INotifyPropertyChanged
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int ProductTypeId { get; set; }
    public required ProductTypes ProductType { get; set; }
    public required int ProductCount { get; set; }

    private double _price;

    public required double Price
    {
        get => _price;
        set
        {
            _price = value;
            DiscountedPrice = GetDiscountedPrice();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DiscountedPrice)));
        }
    }

    private int _sale;

    public required int Sale
    {
        get => _sale;
        set
        {
            _sale = value switch
            {
                < 0 => 0,
                > 100 => 100,
                _ => value
            };

            DiscountedPrice = GetDiscountedPrice();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sale)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DiscountedPrice)));
        }
    }

    public double DiscountedPrice { get; private set; }

    public double GetDiscountedPrice()
    {
        var discount = (double) _sale / 100;
        var discountedPrice = _price - _price * discount;
        return discountedPrice;
    }

    public required int FabricId { get; set; }
    public required Fabric Fabric { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
}

public class Fabric
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class ProductTypes
{
    public int Id { get; set; }
    public required string Name { get; set; }
}