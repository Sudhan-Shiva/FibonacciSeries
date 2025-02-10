using ConsoleTables;
using Pastel;

public class GenericStack<T>
{
    Stack<T> genericStack;

    public GenericStack(Stack<T> genericStack)
    { this.genericStack = genericStack ; }

    public void CreateStack()
    {
        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe Stack of {typeof(T).ToString().Replace("System.", "")} is successfully created !!".Pastel(ConsoleColor.Cyan));
    }

    public ConsoleTable ReturnStackAsTable(Stack<T> inputStack)
    {
        Console.WriteLine($"\nAll the items in the stack are : ".Pastel(ConsoleColor.Yellow));

        ConsoleTable stackTable = new ConsoleTable("S_No", "Item");
        for (int count = 1; count <= inputStack.Count(); count++)
            stackTable.AddRow(count, inputStack.ElementAt(count - 1));

        return stackTable;
    }

    public void PopItem()
    {
        Console.WriteLine($"\n--------POPPING--------".Pastel(ConsoleColor.Magenta));

        T deletedItem = genericStack.Pop();

        if (deletedItem != null)
        {
            Console.WriteLine($"\n'{deletedItem}' is successfully popped from the Stack !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\nThe stack is empty !!".Pastel(ConsoleColor.Red));
        }
        
    }

    public void ReverseContent()
    {
        Stack<T> reversedStack = new Stack<T> ();

        while (genericStack.Count > 0)
        {
            reversedStack.Push (genericStack.Pop());
        }

        Console.WriteLine($"\nReversed Stack : ".Pastel(ConsoleColor.Yellow));

        ReturnStackAsTable(reversedStack).Write();
    }
    public void PushItem(T input)
    {
        Console.WriteLine($"\n--------PUSHING--------\n".Pastel(ConsoleColor.Magenta));

        genericStack.Push(input);

        Console.WriteLine($"\n'{input}' is successfully added to the stack !!".Pastel(ConsoleColor.Cyan));
        
    }
}
