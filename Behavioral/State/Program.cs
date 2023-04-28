// The State pattern is a behavioral design pattern that allows
// an object to alter its behavior when its internal state changes.
// It achieves this by defining a State interface that encapsulates the behavior associated with
// a particular state of the object, and concrete state classes that implement this interface.

// Step 1: Define the State interface
interface IState
{
    void Handle(Context context);
}

// Step 2: Create the ConcreteState classes
class ConcreteStateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("ConcreteStateA handles the request.");
        context.State = new ConcreteStateB();
    }
}

class ConcreteStateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("ConcreteStateB handles the request.");
        context.State = new ConcreteStateA();
    }
}

// Step 3: Create the Context class that uses the State interface
class Context
{
    private IState _state;

    public Context(IState state)
    {
        _state = state;
    }

    public IState State
    {
        get { return _state; }
        set { _state = value; }
    }

    public void Request()
    {
        _state.Handle(this);
    }
}

// Step 4: Use the Context to change its state and behavior
class Program
{
    static void Main(string[] args)
    {
        Context context = new Context(new ConcreteStateA());

        context.Request();
        context.Request();
        context.Request();
        context.Request();

        Console.ReadKey();
    }
}
