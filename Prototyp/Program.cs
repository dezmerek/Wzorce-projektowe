using System;
using System.Collections.Generic;

public abstract class ProductPrototype
{

    public decimal Price;

    public ProductPrototype(decimal price)
    {
        Price = price;
    }

    public ProductPrototype Clone()
    {
        return (ProductPrototype)this.MemberwiseClone();
    }
}

public class Bread : ProductPrototype
{
    public Bread(decimal price) : base(price) { }
}

public class Butter : ProductPrototype
{

    public Butter(decimal price) : base(price) { }
}

public class Supermarket
{

    private Dictionary<string, ProductPrototype> _productList = new Dictionary<string, ProductPrototype>();

    public void AddProduct(string key, ProductPrototype productPrototype)
    {
        _productList.Add(key, productPrototype);
    }

    public ProductPrototype GetClonedProduct(string key)
    {
        ProductPrototype product = _productList[key];
        ProductPrototype clonedPrototype = product.Clone();

        return clonedPrototype;
    }

}

class MainClass
{
    public static void Main(string[] args)
    {
        Supermarket supermarket = new Supermarket();
        supermarket.AddProduct("Bread", new Butter(9.50m));
        supermarket.AddProduct("Butter", new Butter(5.30m));

        ProductPrototype product_discount = supermarket.GetClonedProduct("Bread");
        Console.WriteLine(String.Format("Bread - {0} zl > {1}", product_discount.Price, product_discount.Price * 0.9m));
        Console.WriteLine();

        ProductPrototype product = supermarket.GetClonedProduct("Bread");
        Console.WriteLine(String.Format("Bread - {0} zl", product.Price));
        Console.WriteLine();

        ProductPrototype productButter = supermarket.GetClonedProduct("Butter");
        Console.WriteLine(String.Format("Butter - {0} zl", productButter.Price));
        Console.WriteLine();
    }
}
