// The Observer pattern is a behavioral design pattern that allows objects to subscribe to
// and receive notifications about events occurring in other objects.
// It decouples the sender (or subject) from the receiver (or observer) and allows for flexible and reusable systems.

using System;
using System.Collections.Generic;

// Step 1: Define the Subject interface
interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Step 2: Define the Observer interface
interface IObserver
{
    void Update(ISubject subject);
}

// Step 3: Create the ConcreteSubject class
class ConcreteSubject : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    private int _state;

    public int State
    {
        get { return _state; }
        set
        {
            _state = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }
}

// Step 4: Create the ConcreteObserver class
class ConcreteObserver : IObserver
{
    private readonly string _name;

    public ConcreteObserver(string name)
    {
        _name = name;
    }

    public void Update(ISubject subject)
    {
        Console.WriteLine("{0} received notification: Subject's state is {1}", _name, ((ConcreteSubject)subject).State);
    }
}

// Step 5: Use the Subject and Observer to send and receive notifications
class Program
{
    static void Main(string[] args)
    {
        ConcreteSubject subject = new ConcreteSubject();

        ConcreteObserver observer1 = new ConcreteObserver("Observer 1");
        ConcreteObserver observer2 = new ConcreteObserver("Observer 2");

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.State = 123;

        subject.Detach(observer1);

        subject.State = 456;

        Console.ReadKey();
    }
}
