using System;

// The Product interface defines the behavior of the objects the factory method creates.
public interface IProduct
{
    void Operation();
}

// The ConcreteProduct class implements the Product interface.
public class ConcreteProduct : IProduct
{
    public void Operation()
    {
        Console.WriteLine("ConcreteProduct.Operation()");
    }
}

// The Creator abstract class declares the factory method, which returns an object of type Product.
// This class also provides an implementation of the factory method that creates a ConcreteProduct.
public abstract class Creator
{
    public abstract IProduct FactoryMethod();

    public void SomeOperation()
    {
        Console.WriteLine("Creator.SomeOperation()");
        IProduct product = FactoryMethod();
        product.Operation();
    }
}

// The ConcreteCreator class overrides the factory method to return a ConcreteProduct object.
public class ConcreteCreator : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct();
    }
}

// The Client class uses the Creator to create and use a Product object.
public class Client
{
    public void Run()
    {
        // Create a new ConcreteCreator object.
        ConcreteCreator creator = new ConcreteCreator();

        // Call the SomeOperation method, which creates and uses a ConcreteProduct.
        creator.SomeOperation();
    }
}
