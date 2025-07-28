class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException
        // This will throw a NullReferenceException
        manager.AddItem("Apple");
        manager.AddItem("Banana");

        Console.WriteLine("Print All:");
        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");
        Console.WriteLine("\nAfter Remove Item:");
        manager.PrintAllItems();

        // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
        // TODO: Implement this part three.
        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();
        fruitManager.AddItem(new Fruit("Durian"));
        fruitManager.AddItem(new Fruit("Mango"));
        fruitManager.AddItem(new Fruit("Papaya"));

        Console.WriteLine("\nPrint All - Fruit Manager:");
        fruitManager.PrintAllItems();

        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
    }
}

public class ItemManager : IItemManager<string>
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Part Two: Implement the RemoveItem method
    // TODO: Implement this method
    public void RemoveItem(string item)
    {
        items.Remove(item);
    }

    public void ClearAllItems()
    {
        items = [];
    }
}

public class ItemManager<T> : IItemManager<T>
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void RemoveItem(T item)
    {
        items.Remove(item);
    }

    public void ClearAllItems()
    {
        items = [];
    }
}

public interface IItemManager<T>
{
    void AddItem(T item);
    void RemoveItem(T item);
    void PrintAllItems();
    void ClearAllItems();
}

public class Fruit
{
    public string FruitName { get; set; }

    public Fruit(string name)
    {
        FruitName = name;
    }

    public override string ToString()
    {
        return FruitName;
    }
}