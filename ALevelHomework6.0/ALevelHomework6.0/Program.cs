using System;

internal class Products
{
    public int Number { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

internal class ShopCart
{
    public Products[] Components { get; set; }

    public ShopCart(int ability)
    {
        Components = new Products[ability];
    }
}

internal class PurchasingProducts
{
    private Products[] products = new Products[]
    {
        new Products { Number = 1, Name = "Cat", Price = 200.0M },
        new Products { Number = 2, Name = "Dog", Price = 150.0M },
        new Products { Number = 3, Name = "Mouse", Price = 50.0M },
        new Products { Number = 4, Name = "Cow", Price = 180.0M },
        new Products { Number = 5, Name = "Horse", Price = 220.0M },
    };

    public Products[] GetProducts()
    {
        return products;
    }
}

internal class ShopServices
{
    private ShopCart cart;

    public ShopServices(int cartCapacity)
    {
        cart = new ShopCart(cartCapacity);
    }

    private int itemCount = 0;

    public void AddAnimal(Products product)
    {
        if (itemCount < cart.Components.Length)
        {
            cart.Components[itemCount] = product;
            itemCount++;
        }
        else
        {
            Console.WriteLine("Your cart is overflowing with animals");
        }
    }

    public ShopCart GetCart()
    {
        return cart;
    }

    public static void FinishPurchase()
    {
        Console.WriteLine("Order placed with an order number: " + Guid.NewGuid()); // creates 32-symbols identifier
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        PurchasingProducts purchProducts = new PurchasingProducts();
        ShopServices shopServices = new ShopServices(10);

        Console.WriteLine("Available Animals in the Shop:");

        Products[] products = purchProducts.GetProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Number}. {product.Name} - ${product.Price}");
        }

        ShopCart cart = shopServices.GetCart();

        while (true)
        {
            Console.Write("Enter the product number to add it to the cart (0 to finish purchasing): ");
            if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber >= 0 && productNumber <= products.Length)
            {
                if (productNumber == 0)
                {
                    ShopServices.FinishPurchase();
                    break;
                }
                else
                {
                    Products selectedAnimals = products.FirstOrDefault(p => p.Number == productNumber);
                    if (selectedAnimals != null)
                    {
                        shopServices.AddAnimal(selectedAnimals);
                        Console.WriteLine($"{selectedAnimals.Name} was added to cart.");
                    }
                    else
                    {
                        Console.WriteLine("This number is not in the list.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number from the list.");
            }
        }
    }
}