using System;
using SingletonSample;

class Program
{
    static void Main()
    {
        // Get the Singleton instance.
        Singleton singleton = Singleton.Instance;

        // Call the DoSomething method on the Singleton instance.
        singleton.DoSomething();

        // Get another reference to the Singleton instance.
        Singleton anotherSingleton = Singleton.Instance;

        // Check that the two references point to the same instance.
        if (singleton == anotherSingleton)
        {
            Console.WriteLine("The two Singleton references are the same instance.");
        }
        else
        {
            Console.WriteLine("The two Singleton references are not the same instance.");
        }

        Console.ReadLine();
    }
}
