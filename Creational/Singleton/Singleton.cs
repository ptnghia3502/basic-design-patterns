// Singleton is a creational design pattern that ensures a class has only one instance,
// and provides a global point of access to that instance.
// This pattern is useful in situations where there should be only one instance of a class in a program,
// such as a database connection or a configuration manager.

namespace SingletonSample
{
    public class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();

        private Singleton()
        {
            // Private constructor to prevent other classes from creating instances.
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Singleton instance is doing something.");
        }
    }
}
