using ConsoleTables;
using Pastel;

public class GenericQueue<T>
{
    Queue<T> inputQueue;

    public GenericQueue(Queue<T> inputQueue)
    { this.inputQueue = inputQueue; }
        
    public void CreateQueue()
    {
        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe Queue of {typeof(T).ToString().Replace("System.", "")} is successfully created !!".Pastel(ConsoleColor.Cyan));
    }

    public ConsoleTable ReturnQueueAsTable()
    {
        Console.WriteLine($"\nAll the items in the queue are : ".Pastel(ConsoleColor.Yellow));
        ConsoleTable queueTable = new ConsoleTable("S_No", "Item");
        for (int count = 1; count <= inputQueue.Count(); count++)
            queueTable.AddRow(count, inputQueue.ElementAt(count-1));
        return queueTable;
    }

    public void DequeueItem()
    {
        Console.WriteLine($"\n--------DEQUEUEING--------".Pastel(ConsoleColor.Magenta));

        T deletedItem = inputQueue.Dequeue();

        if ( deletedItem != null)
        {
            Console.WriteLine($"\n'{deletedItem}' is successfully deleted from the queue !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\nThe queue is empty !!".Pastel(ConsoleColor.Red));
        }
    }

    public void EnqueueItem(T input)
    {
        Console.WriteLine($"\n--------ENQUEUEING--------\n".Pastel(ConsoleColor.Magenta));

        inputQueue.Enqueue(input);

        Console.WriteLine($"\n'{input}' is successfully added to the queue !!".Pastel(ConsoleColor.Cyan));
    }
}
