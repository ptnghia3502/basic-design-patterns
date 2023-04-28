// Prototype is a creational design pattern that allows you to create new objects by cloning existing ones.
// This pattern is useful when creating new objects is expensive or complex,
// and when you want to avoid the overhead of creating new objects from scratch.


// The Prototype interface defines the clone method.
public interface IPrototype<T>
{
    T Clone();
}

// The ConcretePrototype class implements the Prototype interface and defines its own clone method.
public class ConcretePrototype : IPrototype<ConcretePrototype>
{
    private string name;

    public ConcretePrototype(string name)
    {
        this.name = name;
    }

    public ConcretePrototype Clone()
    {
        return new ConcretePrototype(name);
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void PrintName()
    {
        Console.WriteLine("Name: " + name);
    }
}

// The Client class demonstrates the use of the Prototype pattern.
public class Client
{
    public void Run()
    {
        // Create a new ConcretePrototype object.
        ConcretePrototype prototype = new ConcretePrototype("Original Name");

        // Clone the prototype to create a new object.
        ConcretePrototype clone = prototype.Clone();

        // Change the name of the original object.
        prototype.SetName("New Name");

        // Print the name of both objects.
        prototype.PrintName();
        clone.PrintName();
    }
}