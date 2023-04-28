// The Facade design pattern is a structural pattern that provides a unified interface
// to a set of interfaces in a subsystem. It simplifies the complexity of a system by providing a higher-level interface
// that makes the subsystem easier to use.

// Step 1: Create a complex subsystem
class SubSystem1
{
    public void Method1()
    {
        Console.WriteLine("SubSystem1 Method1");
    }
}

class SubSystem2
{
    public void Method2()
    {
        Console.WriteLine("SubSystem2 Method2");
    }
}

class SubSystem3
{
    public void Method3()
    {
        Console.WriteLine("SubSystem3 Method3");
    }
}

// Step 2: Create a Facade class that provides a simple interface
class Facade
{
    private readonly SubSystem1 _subSystem1;
    private readonly SubSystem2 _subSystem2;
    private readonly SubSystem3 _subSystem3;

    public Facade()
    {
        _subSystem1 = new SubSystem1();
        _subSystem2 = new SubSystem2();
        _subSystem3 = new SubSystem3();
    }

    public void MethodA()
    {
        Console.WriteLine("\nMethodA() ---- ");
        _subSystem1.Method1();
        _subSystem2.Method2();
    }

    public void MethodB()
    {
        Console.WriteLine("\nMethodB() ---- ");
        _subSystem2.Method2();
        _subSystem3.Method3();
    }
}

// Step 3: Use the Facade to access the subsystem
class Program
{
    static void Main(string[] args)
    {
        Facade facade = new Facade();

        facade.MethodA();
        facade.MethodB();

        Console.ReadKey();
    }
}
