using Task4;

public class Program
{
    static void Main()
    {
        for (int i = 0;i<1000;i++)
        {
            Logger.LogError(i + "lOGGED ERROR  ");
            Console.Write(i);
        }

        Console.WriteLine("Press any key to exit....");
        Console.ReadKey();
    }
}