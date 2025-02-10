using ConsoleTables;
using Pastel;

public class PersonQueue
{
    Queue<string> persons;

    public PersonQueue(Queue<string> persons)
    { this.persons = persons; }
        
    public void DoQueueOperations()
    {

        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe Queue of Persons is successfully created !!".Pastel(ConsoleColor.Cyan));

        AddPerson();

        RemovePerson();

        ReturnQueueAsTable().Write();

    }

    private ConsoleTable ReturnQueueAsTable()
    {
        Console.WriteLine($"\nAll the persons in the queue are : ".Pastel(ConsoleColor.Yellow));
        ConsoleTable personsTable = new ConsoleTable("S_No", "Person Name");
        for (int count = 1; count <= persons.Count(); count++)
            personsTable.AddRow(count, persons.ElementAt(count-1));
        return personsTable;
    }

    private void RemovePerson()
    {
        Console.WriteLine($"\n--------REMOVING PERSON--------".Pastel(ConsoleColor.Magenta));

        var deletedPerson = persons.Dequeue();

        if ( deletedPerson != null)
        {
            Console.WriteLine($"\nPerson named '{deletedPerson}' is successfully deleted from the queue !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\nThe queue is empty !!".Pastel(ConsoleColor.Red));
        }
    }

    private void AddPerson()
    {
        Console.WriteLine($"\n--------ADDING PERSONS--------\n".Pastel(ConsoleColor.Magenta));
        for (int count = 1; count <= 5; count++)
        {
            Console.Write($"\nProvide the name of the person to be added : ".Pastel(ConsoleColor.Yellow));
            string personName = GetValidString(Console.ReadLine());
            persons.Enqueue(personName);
        }

        ReturnQueueAsTable().Write();
    }

    private string GetValidString(string inputString)
    {
        while (inputString == "" || inputString == null)
        {
            Console.WriteLine($"The given string is either null or empty !!!".Pastel(ConsoleColor.Red));
            Console.Write($"Provide a valid string :".Pastel(ConsoleColor.Yellow));
            inputString = Console.ReadLine();
        }

        return inputString;
    }
}
