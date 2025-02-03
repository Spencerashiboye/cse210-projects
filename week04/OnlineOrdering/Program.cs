using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Jane Doe", address1);
        Order order1 = new Order(customer1);

        Product product1 = new Product("Laptop", "A123", 1200m, 1);
        Product product2 = new Product("Mouse", "B456", 25m, 2);

        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\nTotal Price: " + order1.GetTotalPrice());
    }
}

class Product
{
    public string Name {get;}
    public string ProductId {get;}
    public decimal Price {get;}
    public int Quantity {get;}
    public Product(string name, string productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return Price * Quantity;
    }

    public string GetPackingLabel()
    {
        return $"{Name} (ID: {ProductId})";
    }
}

class Customer
{
    public string Name { get; }
    public Address Address { get; }

    public Customer(string name, Address address )
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{Name}\n{Address.GetFullAdress()}";
    }
}

class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.Trim().ToLower() == "usa";
    }

    public string GetFullAdress()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

class Order
{
     public Customer Customer { get; }
    private List<Product> Products { get; }

    public Order(Customer customer)
    {
        Customer = customer;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var product in Products)
        {
            total += product.GetTotalCost();
        }
        decimal shippingCost = Customer.IsInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", Products.ConvertAll(p => p.GetPackingLabel()));
    }

    public string GetShippingLabel() => Customer.GetShippingLabel();
}