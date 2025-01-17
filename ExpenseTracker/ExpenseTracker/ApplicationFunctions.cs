
//Console.WriteLine("\nHello!\nWhat do you want to do?\n[V]iew the Expense Tracker List\n[S]earch the Expense Tracker List\n[A]dd new Expense/Income\n[M]odify the Expense Tracker List\n[D]elete any Expense/Income\n[E]xit the Expense Tracker List\n");
//Console.Write("Type your Choice: ");

using ExpenseTracker.UserDetails;
using ExpenseTracker.ValidInput;
public class ApplicationFunctions
{


    public static void ExpenseAddition(List<Transaction> TrackerList)
        
    {
        Transaction transaction = new();
        //  DataValidation dataValidation = new DataValidation();
        Console.Write("Enter the Transaction Type :  ");
        
        if (Console.ReadLine().ToUpper() == "INCOME")
        {
            Income income = new();
            income.Type = "INCOME";
            Console.Write("Enter the Transaction Amount :  ");
            DataValidation.CheckInputFormat(Console.ReadLine(), true, income);
            Console.Write("Enter the Date of Transaction :  ");
            DataValidation.CheckInputFormat(Console.ReadLine(), false, income);
            Console.Write("Enter the Source of Income : ");
            income.Source = Console.ReadLine();
            TrackerList.Add(income);
        }
        else 
        {
            Expense expense = new();
            expense.Type = "EXPENSE";
            Console.Write("Enter the Transaction Amount :  ");
            DataValidation.CheckInputFormat(Console.ReadLine(), true, expense);
            Console.Write("Enter the Date of Transaction :  ");
            DataValidation.CheckInputFormat(Console.ReadLine(), false, expense);
            Console.Write("Enter the Category of expense : ");
            expense.Category = Console.ReadLine();
            TrackerList.Add(expense);
        }
        Console.WriteLine("The Transaction Information has been successfully added.\n");
    }
    

}
