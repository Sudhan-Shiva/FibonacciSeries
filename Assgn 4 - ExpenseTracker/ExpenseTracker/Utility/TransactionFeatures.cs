using ExpenseTracker.Model;

namespace ExpenseTracker.Utility
{
    public class TransactionFeatures
    {
        TransactionsManager transactionsManager;
        public TransactionFeatures(TransactionsManager mainTransactionsManager)
        {
            transactionsManager = mainTransactionsManager;
        }
        public int ApplicationFunctions(int userChoice)
        {
            ApplicationOptions options = (ApplicationOptions) userChoice;
            switch (options)
            {
                case ApplicationOptions.ViewTransaction:
                    transactionsManager.ViewTransactions();
                    break;
                case ApplicationOptions.AddTransaction:
                    transactionsManager.AddTransaction();
                    break;
                case ApplicationOptions.DeleteTransaction:
                    transactionsManager.DeleteTransaction();
                    break;
                case ApplicationOptions.EditTransaction:
                    transactionsManager.ModifyTransaction();
                    break;
                case ApplicationOptions.SearchTransaction:
                    transactionsManager.SearchTransaction();
                    break;
                case ApplicationOptions.ViewTransactionSummary:
                    transactionsManager.GetSummaryOfTransaction();
                    break;
                case ApplicationOptions.Exit:
                    break;
                default:
                    break;
            }
            return userChoice;
        }
    }
}