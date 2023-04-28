// The Iterator pattern is a behavioral design pattern that provides a way to access
// the elements of an aggregate object sequentially without exposing its underlying representation.
// It decouples the client code from the internal representation of the collection.

using System;
using System.Collections;

// Step 1: Define the Iterator interface
interface IIterator
{
    object First();
    object Next();
    bool IsDone();
    object CurrentItem();
}

// Step 2: Define the Aggregate interface
interface IAggregate
{
    IIterator CreateIterator();
}

// Step 3: Create the ConcreteAggregate class
class ConcreteAggregate : IAggregate
{
    private readonly ArrayList _items = new ArrayList();

    public void AddItem(object item)
    {
        _items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count
    {
        get { return _items.Count; }
    }

    public object this[int index]
    {
        get { return _items[index]; }
        set { _items.Insert(index, value); }
    }
}

// Step 4: Create the ConcreteIterator class
class ConcreteIterator : IIterator
{
    private readonly ConcreteAggregate _aggregate;
    private int _current = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    public object First()
    {
        return _aggregate[0];
    }

    public object Next()
    {
        object ret = null;
        if (_current < _aggregate.Count - 1)
        {
            ret = _aggregate[++_current];
        }
        return ret;
    }

    public bool IsDone()
    {
        return _current >= _aggregate.Count;
    }

    public object CurrentItem()
    {
        return _aggregate[_current];
    }
}

// Step 5: Use the Iterator to access the elements of the Aggregate
class Program
{
    static void Main(string[] args)
    {
        ConcreteAggregate aggregate = new ConcreteAggregate();
        aggregate[0] = "Item 1";
        aggregate[1] = "Item 2";
        aggregate[2] = "Item 3";
        aggregate[3] = "Item 4";

        IIterator iterator = aggregate.CreateIterator();

        Console.WriteLine("Iterating over collection:");
        object item = iterator.First();
        while (item != null)
        {
            Console.WriteLine(item);
            item = iterator.Next();
        }

        Console.ReadKey();
    }
}
