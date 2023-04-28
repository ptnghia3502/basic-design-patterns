using System;

// The Product class represents the complex object being built.
public class Product
{
    public string PartA { get; set; }
    public string PartB { get; set; }
    public string PartC { get; set; }

    public void Show()
    {
        Console.WriteLine("PartA: " + PartA);
        Console.WriteLine("PartB: " + PartB);
        Console.WriteLine("PartC: " + PartC);
    }
}

// The Builder interface defines the steps for building the Product.
public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Product GetResult();
}

// The ConcreteBuilder class implements the Builder interface and provides the implementation for the steps.
public class ConcreteBuilder : IBuilder
{
    private Product product = new Product();

    public void BuildPartA()
    {
        product.PartA = "PartA";
    }

    public void BuildPartB()
    {
        product.PartB = "PartB";
    }

    public void BuildPartC()
    {
        product.PartC = "PartC";
    }

    public Product GetResult()
    {
        return product;
    }
}

// The Director class defines the steps for building the Product using the Builder interface.
public class Director
{
    public void Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
    }
}

// The Client class uses the Director to build a Product using a ConcreteBuilder.
public class Client
{
    public void Run()
    {
        // Create a new ConcreteBuilder object.
        ConcreteBuilder builder = new ConcreteBuilder();

        // Create a new Director object and pass in the ConcreteBuilder.
        Director director = new Director();
        director.Construct(builder);

        // Get the result from the builder.
        Product product = builder.GetResult();

        // Show the product.
        product.Show();
    }
}
