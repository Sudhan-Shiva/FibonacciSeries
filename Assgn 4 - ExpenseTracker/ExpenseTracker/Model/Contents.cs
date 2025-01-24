namespace ExpenseTracker.Model
{
    public enum ApplicationOptions
    {
        ViewTransaction,
        AddTransaction,
        DeleteTransaction,
        EditTransaction,
        SearchTransaction,
        ViewTransactionSummary,
        Exit

    }

    public enum UserEditChoice
    {
        EditTransactionType,
        EditTransactionAmount,
        EditTransactionDate,
        EditTransactionDetails
    }
        
    public enum TransactionType
    {
        Income,
        Expense
    }
}
