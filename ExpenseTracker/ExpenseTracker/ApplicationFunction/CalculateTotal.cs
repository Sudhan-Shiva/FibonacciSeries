using ExpenseTracker.UserDetails;

public class CalculateTotal
{
    public static void CalculateTotalTransactionAmount(List<Transaction> TrackerList)
    {
        int TotalIncome = 0;
        int TotalExpense = 0;
        foreach (Transaction transaction in TrackerList)
        {
            if (transaction.Type == "INCOME")
            {
                TotalIncome += transaction.Amount;
            }
            else
            {
                TotalExpense += transaction.Amount;
            }
        }
        Console.WriteLine("Total Income  : "+ TotalIncome);
        Console.WriteLine("Total Expense : "+ TotalExpense);
        Console.WriteLine("Net Balance   : " + (TotalIncome - TotalExpense));
    }
}