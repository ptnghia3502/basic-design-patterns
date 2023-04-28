// The Proxy pattern is a structural design pattern that allows for controlled access to an object.
// It is used when you need to provide a surrogate or placeholder for another object to control access to it.

// Step 1: Define the interface for the RealSubject and Proxy
interface ISubject
{
    void Request();
}

// Step 2: Create the RealSubject class
class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request.");
    }
}

// Step 3: Create the Proxy class
class Proxy : ISubject
{
    private readonly RealSubject _realSubject;

    public Proxy()
    {
        _realSubject = new RealSubject();
    }

    public void Request()
    {
        if (CheckAccess())
        {
            _realSubject.Request();
            LogAccess();
        }
    }

    private bool CheckAccess()
    {
        Console.WriteLine("Proxy: Checking access prior to firing a real request.");
        return true;
    }

    private void LogAccess()
    {
        Console.WriteLine("Proxy: Logging the time of the request.");
    }
}

// Step 4: Use the Proxy to access the RealSubject
class Program
{
    static void Main(string[] args)
    {
        Proxy proxy = new Proxy();
        proxy.Request();

        Console.ReadKey();
    }
}
