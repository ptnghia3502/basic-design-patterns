// The Mediator pattern is a behavioral design pattern that allows for communication between objects
// in a system without them having to know about each other directly.
// It reduces the coupling between objects by centralizing their communication through a mediator object.

using System;
using System.Collections.Generic;

// Step 1: Create the Mediator interface
interface IMediator
{
    void SendMessage(string message, IColleague colleague);
}

// Step 2: Create the Colleague interface
interface IColleague
{
    void ReceiveMessage(string message);
}

// Step 3: Create the ConcreteMediator class
class ConcreteMediator : IMediator
{
    private readonly List<IColleague> _colleagues = new List<IColleague>();

    public void AddColleague(IColleague colleague)
    {
        _colleagues.Add(colleague);
    }

    public void SendMessage(string message, IColleague colleague)
    {
        foreach (IColleague c in _colleagues)
        {
            if (c != colleague)
            {
                c.ReceiveMessage(message);
            }
        }
    }
}

// Step 4: Create the ConcreteColleague classes
class ConcreteColleague1 : IColleague
{
    private readonly IMediator _mediator;

    public ConcreteColleague1(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Send(string message)
    {
        _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine("ConcreteColleague1 received message: " + message);
    }
}

class ConcreteColleague2 : IColleague
{
    private readonly IMediator _mediator;

    public ConcreteColleague2(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Send(string message)
    {
        _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine("ConcreteColleague2 received message: " + message);
    }
}

// Step 5: Use the Mediator to facilitate communication between the Colleagues
class Program
{
    static void Main(string[] args)
    {
        ConcreteMediator mediator = new ConcreteMediator();

        ConcreteColleague1 colleague1 = new ConcreteColleague1(mediator);
        ConcreteColleague2 colleague2 = new ConcreteColleague2(mediator);

        mediator.AddColleague(colleague1);
        mediator.AddColleague(colleague2);

        colleague1.Send("Hello, ConcreteColleague2!");
        colleague2.Send("Hello, ConcreteColleague1!");

        Console.ReadKey();
    }
}
