using ExpenseTracker.DataValidation.DataTypeValidation;
using ExpenseTracker.UserDetails;
public class ApplicationFeatures
{
    int userLoginIndex = 0;
    private List<List<Transaction>> _trackerList = new List<List<Transaction>>();
    private List<Transaction> _transactionList = new List<Transaction>();
    //_trackerList[0].Add(_transactionList);
    //private List<Transaction> _trackerList[userLoginIndex] = new List<Transaction>();
    public void TransactionView(int userLoginIndex)
    {
        int count = _transactionList.Count ;
        foreach(Transaction transaction in _trackerList[userLoginIndex])
        {
            PrintTransactionInformation(transaction);
        }
    }
    public void TransactionAddition(int userLoginIndex)
    {
        Transaction transaction = new();
        List<Transaction> transactions = new List<Transaction>();
        Console.Write("Enter the Transaction Type (Income/Expense ) :  ");
        if (Console.ReadLine().ToUpper() == "INCOME")
        {
            Income income = new Income();
            income.Type = "INCOME";
            Console.Write("Enter the Transaction Amount :  ");
            income.Amount = DataTypeValidator.CheckInputAmountFormat(Console.ReadLine());
            Console.Write("Enter the Date of Transaction :  ");
            income.DateOfTransaction = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
            Console.Write("Enter the Source of Income : ");
            income.Source = Console.ReadLine();       
            _trackerList.Add(transactions);
            _trackerList[userLoginIndex].Add(income);
        }
        else 
        {
            Expense expense = new();
            expense.Type = "EXPENSE";
            Console.Write("Enter the Transaction Amount :  ");
            expense.Amount = DataTypeValidator.CheckInputAmountFormat(Console.ReadLine());
            Console.Write("Enter the Date of Transaction :  ");
            expense.DateOfTransaction = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
            Console.Write("Enter the Category of expense : ");
            expense.Category = Console.ReadLine();
            //List<Transaction> expenses = new List<Transaction>();
            _trackerList.Add(transactions);
            _trackerList[userLoginIndex].Add(expense);
        }
        Console.WriteLine("The Transaction Information has been successfully added.\n");
    }

    public void TransactionDeletion(int userLoginIndex)
    {
        Console.Write("Choose the date of transaction : ");
        DateOnly deleteChoiceDate = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
        int numberOfMatchingChoices = 0;
        foreach(Transaction transaction in _trackerList[userLoginIndex])
        {
            if(transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                Console.WriteLine($"[{numberOfMatchingChoices}]");
                PrintTransactionInformation(transaction);               
            }
        }
        Console.Write("Select the transaction index : ");
        string deleteChoiceIndex = Console.ReadLine();
        numberOfMatchingChoices = 0;
        foreach(Transaction transaction in _trackerList[userLoginIndex])
        {
            if(transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                if(numberOfMatchingChoices == int.Parse(deleteChoiceIndex))
                {
                    _trackerList[userLoginIndex].Remove(transaction);
                }
            }
        }        
    }

    public void TransactionModification(int userLoginIndex)
    {
        int transactionIndex = SelectTransaction(_trackerList, userLoginIndex);
        Console.WriteLine("[1] Transaction Type\n[2] Transaction Amount\n[3] Transaction Date\n[4] Transaction Details");
        Console.Write("Select the field to edit :");
        string fieldToEdit = Console.ReadLine();
        switch (fieldToEdit)
        {
            case "1":
                Console.Write("Enter the new transaction type :");
                _trackerList[userLoginIndex][transactionIndex].Type = Console.ReadLine().ToUpper();
                break;
            case "2":
                Console.Write("Enter the new transaction amount :");
                _trackerList[userLoginIndex][transactionIndex].Amount = DataTypeValidator.CheckInputAmountFormat(Console.ReadLine());
                break;
            case "3":
                Console.Write("Enter the new transaction date :");
                _trackerList[userLoginIndex][transactionIndex].DateOfTransaction = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
                break;
            case "4":
                if(_trackerList[userLoginIndex][transactionIndex].Type == "INCOME")
                {
                    Income income = (Income) _trackerList[userLoginIndex][transactionIndex];
                    Console.Write("Enter the new income source :");
                    income.Source = Console.ReadLine();
                    _trackerList[userLoginIndex][transactionIndex] = income;
                }
                else
                {
                    Expense expense = (Expense)_trackerList[userLoginIndex][transactionIndex];
                    Console.Write("Enter the new expense category :");
                    expense.Category = Console.ReadLine();
                    _trackerList[userLoginIndex][transactionIndex] = expense;
                }
                break;
        }


    }

    public void TransactionSearch(int userLoginIndex)
    {
        int matchedIndex = 0;
        Console.Write("Choose the date of transaction : ");
        DateOnly deleteChoiceDate = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
        int numberOfMatchingChoices = 0;
        foreach (Transaction transaction in _trackerList[userLoginIndex])
        {
            if (transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                Console.WriteLine($"[{numberOfMatchingChoices}]");
                PrintTransactionInformation(transaction);
            }
        }
    }

    public void TransactionSummary(int userLoginIndex)
    {
        CalculateTotal.CalculateTotalTransactionAmount(_trackerList[userLoginIndex]);
    } 

    public void PrintTransactionInformation(Transaction transaction)
    {
        Console.WriteLine("Transaction Type    : " + transaction.Type);
        Console.WriteLine("Transaction Amount  : " + transaction.Amount);
        Console.WriteLine("Transaction Date    : " + transaction.DateOfTransaction);
        if (transaction.Type == "INCOME")
        {
            Income income = (Income)transaction;
            Console.WriteLine("Transaction Source  : " + income.Source);
        }
        else
        {
            Expense expense = (Expense)transaction;
            Console.WriteLine("Transaction Source  : " + expense.Category);
        }
    }

    public int SelectTransaction(int userLoginIndex)
    {
        int matchedIndex = 0 ;
        Console.Write("Choose the date of transaction : ");
        DateOnly deleteChoiceDate = DataTypeValidator.CheckInputDateFormat(Console.ReadLine());
        int numberOfMatchingChoices = 0;
        foreach (Transaction transaction in _trackerList[userLoginIndex])
        {
            if (transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                Console.WriteLine($"[{numberOfMatchingChoices}]");
                PrintTransactionInformation(transaction);
            }
        }
        Console.Write("Select the transaction index : ");
        int deleteChoiceIndex = DataTypeValidator.CheckInputAmountFormat(Console.ReadLine());
        numberOfMatchingChoices = 0;
        foreach (Transaction transaction in _trackerList[userLoginIndex])
        {
            if (transaction.DateOfTransaction == deleteChoiceDate)
            {
                numberOfMatchingChoices++;
                if (numberOfMatchingChoices == deleteChoiceIndex)
                {
                    matchedIndex = _trackerList[userLoginIndex].IndexOf(transaction);
                }
            }
        }
        return matchedIndex;
    }
   



}
