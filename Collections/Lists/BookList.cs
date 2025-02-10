using ConsoleTables;
using Pastel;

public class BookList
{
    List<string> books;

    public BookList(List<string> books)
    { this.books = books; }
        
    public void DoListOperations()
    {

        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe List of books is successfully created !!".Pastel(ConsoleColor.Cyan));

        AddBooks();

        DeleteBooks();

        CheckBooks();

        ReturnListAsTable().Write();

    }

    private void CheckBooks()
    {

        Console.WriteLine($"\n--------CHECKING BOOKS--------".Pastel(ConsoleColor.Magenta));

        Console.Write($"\nProvide the title of the book to be checked : ".Pastel(ConsoleColor.Yellow));
        string checkingBookTitle = GetValidString(Console.ReadLine());

        if (books.Contains(checkingBookTitle))
        {
            Console.WriteLine($"\nThe Book titled {checkingBookTitle} is present in the list !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\nThe Book titled {checkingBookTitle} is not present in the list !!".Pastel(ConsoleColor.Red));
        }
    }

    private ConsoleTable ReturnListAsTable()
    {
        Console.WriteLine($"All the books in the list are : ".Pastel(ConsoleColor.Yellow));

        ConsoleTable booksTable = new ConsoleTable("S_No", "Book Title");

        for (int count = 1; count <= books.Count(); count++)
            booksTable.AddRow(count, books[count - 1]);

        return booksTable;
    }

    private void DeleteBooks()
    {
        Console.WriteLine($"\n--------REMOVING BOOKS--------".Pastel(ConsoleColor.Magenta));

        Console.Write($"\nProvide the title of the book to be deleted : ".Pastel(ConsoleColor.Yellow));
        string deletingBookTitle = GetValidString(Console.ReadLine());

        if (books.Remove(deletingBookTitle))
        {
            Console.WriteLine($"\nThe Book titled {deletingBookTitle} is successfully deleted from the list !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\nThe Book titled {deletingBookTitle} is not present in the list !!".Pastel(ConsoleColor.Red));
        }
    }

    private void AddBooks()
    {
        Console.WriteLine($"\n--------ADDING BOOKS--------\n".Pastel(ConsoleColor.Magenta));

        for (int count = 1; count <= 5; count++)
        {
            Console.Write($"\nProvide the title of the book to be added : ".Pastel(ConsoleColor.Yellow));
            string addingBookTitle = GetValidString(Console.ReadLine());
            books.Add(addingBookTitle);
        }

        ReturnListAsTable().Write();
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
