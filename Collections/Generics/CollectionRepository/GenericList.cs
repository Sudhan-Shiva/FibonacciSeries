using ConsoleTables;
using Pastel;

public class GenericList<T>
{
    List<T> inputList;

    public GenericList(List<T> inputList)
    { this.inputList = inputList; }
        
    public void CreateList()
    {
        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe List of {typeof(T).ToString().Replace("System.", "")} is successfully created !!".Pastel(ConsoleColor.Cyan));
    }

    public void CheckItem(T input)
    {
        Console.WriteLine($"\n--------CHECKING--------".Pastel(ConsoleColor.Magenta));

        if (inputList.Contains(input))
        {
            Console.WriteLine($"\n{input} is present in the list !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\n{input} is not present in the list !!".Pastel(ConsoleColor.Red));
        }
    }

    public ConsoleTable ReturnListAsTable()
    {
        Console.WriteLine($"\nAll the items in the list are : ".Pastel(ConsoleColor.Yellow));

        ConsoleTable listTable = new ConsoleTable("S_No", "Item");

        for (int count = 1; count <= inputList.Count(); count++)
            listTable.AddRow(count, inputList[count - 1]);

        return listTable;
    }

    public void RemoveItem(T input)
    {
        Console.WriteLine($"\n--------REMOVING--------".Pastel(ConsoleColor.Magenta));

        if (inputList.Remove(input))
        {
            Console.WriteLine($"\n'{input}' is successfully deleted from the list !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\n'{input}' is not present in the list !!".Pastel(ConsoleColor.Red));
        }
    }

    public void AddItem(T input)
    {
        Console.WriteLine($"\n--------ADDING--------".Pastel(ConsoleColor.Magenta));

        inputList.Add(input);

        Console.WriteLine($"\n'{input}' is successfully added to the list !!".Pastel(ConsoleColor.Cyan));
    }
}
