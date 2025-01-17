using ExpenseTracker.UserDetails;

public class CalculateTotal
{
    public static int CalculateTotalIncome(List<Transaction> TrackerList, int toCalculate)
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
        if (toCalculate == 0)
        {
            return TotalIncome;
        }
        else if (toCalculate == 1)
        {
            return TotalExpense;
        }
        else
        {
            return (TotalIncome - TotalExpense);
        }
    }
}