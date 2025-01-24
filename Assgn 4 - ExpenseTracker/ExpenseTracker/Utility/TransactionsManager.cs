using ExpenseTracker.InputValidation;
using ExpenseTracker.Model;
using ExpenseTracker.ConsoleUI;


public class TransactionsManager
{
    private List<Transaction> _trackerList = new ();
    InputManager inputManager;
    OutputManager outputManager;

    public TransactionsManager(InputManager mainInputManager, OutputManager mainOutputManager)
    {
        inputManager = mainInputManager;
        outputManager = mainOutputManager;
    }

    public void ViewTransactions()
    {
        if (!isListEmpty())
            outputManager.PrintTable(_trackerList);
        else
            outputManager.PrintListIsEmpty();
    }

    public bool isListEmpty()
    {
        return (_trackerList.Count == 0);
    }
    public void AddTransaction()
    {
        Transaction transaction = new Transaction();
        int transactionChoice = inputManager.GetTransactionType() ;
        TransactionType transactionType = (TransactionType) transactionChoice;
        switch(transactionType)
        {
            case TransactionType.Income:
                Income income = new ();
                income.Type = "INCOME";
                income.Amount = inputManager.GetTransactionAmount();
                income.DateOfTransaction = inputManager.GetTransactionDate();
                income.Source = inputManager.GetIncomeSource();
                _trackerList.Add(income);
                break;
            case TransactionType.Expense:
                Expense expense = new ();
                expense.Type = "EXPENSE";
                expense.Amount = inputManager.GetTransactionAmount();
                expense.DateOfTransaction = inputManager.GetTransactionDate();
                expense.Category = inputManager.GetExpenseCategory();
                _trackerList.Add(expense);
                break;
            default:
                inputManager.ReplaceInvalidInput();
                break;
        }
        outputManager.PrintSuccessfulAddition();
    }

    public void DeleteTransaction()
    {
        if (!isListEmpty())
        {
            DateOnly deleteChoiceDate = inputManager.GetTransactionDate();
            int deleteChoiceIndex = SelectTransactionIndex();
            if(deleteChoiceIndex > -1)
            {
                _trackerList.RemoveAt(deleteChoiceIndex);
                outputManager.PrintSuccessfulDeletion();
            }
            else
            {
                outputManager.PrintNoMatches();
            }            
        }
        else
        {
            outputManager.PrintListIsEmpty();
        }
    }
    public void ModifyTransaction()
    {
        if (!isListEmpty())
        {
            int transactionIndex = SelectTransactionIndex();
            if (transactionIndex > -1)
            {
                int fieldToEdit = inputManager.GetModifyChoice();
                UserEditChoice userEditChoice = (UserEditChoice)fieldToEdit;
                switch (userEditChoice)
                {
                    case UserEditChoice.EditTransactionType:
                        string transactionType = (inputManager.GetTransactionType() == 0) ? "INCOME" : "EXPENSE";
                        if (_trackerList[transactionIndex] is Income income && transactionType == "EXPENSE")
                        {
                            Expense expenseTransaction = new Expense();
                            expenseTransaction.Type = transactionType;
                            expenseTransaction.Amount = _trackerList[transactionIndex].Amount;
                            expenseTransaction.DateOfTransaction = _trackerList[transactionIndex].DateOfTransaction;
                            expenseTransaction.Category = inputManager.GetExpenseCategory();
                            _trackerList.RemoveAt(transactionIndex);
                            _trackerList.Insert(transactionIndex, expenseTransaction);
                            outputManager.PrintSuccessfulModification();
                        }
                        else if (_trackerList[transactionIndex] is Expense expense && transactionType == "INCOME")
                        {
                            Income incomeTransaction = new Income();
                            incomeTransaction.Type = transactionType;
                            incomeTransaction.Amount = _trackerList[transactionIndex].Amount;
                            incomeTransaction.DateOfTransaction = _trackerList[transactionIndex].DateOfTransaction;
                            incomeTransaction.Source = inputManager.GetIncomeSource();
                            _trackerList.RemoveAt(transactionIndex);
                            _trackerList.Insert(transactionIndex, incomeTransaction);
                            outputManager.PrintSuccessfulModification();
                        }
                        else if((_trackerList[transactionIndex] is Expense && transactionType == "EXPENSE") || (_trackerList[transactionIndex] is Income && transactionType == "INCOME"))
                        {
                            Console.WriteLine("The provided transaction is already of the same type.");
                        }
                        break;
                    case UserEditChoice.EditTransactionAmount:
                        _trackerList[transactionIndex].Amount = inputManager.GetTransactionAmount();
                        outputManager.PrintSuccessfulModification();
                        break;
                    case UserEditChoice.EditTransactionDate:
                        _trackerList[transactionIndex].DateOfTransaction = inputManager.GetTransactionDate();
                        outputManager.PrintSuccessfulModification();
                        break;
                    case UserEditChoice.EditTransactionDetails:
                        if (_trackerList[transactionIndex] is Income incomeType)
                        {
                            incomeType.Source = inputManager.GetIncomeSource();
                        }
                        else if (_trackerList[transactionIndex] is Expense expenseType)
                        {
                            expenseType.Category = inputManager.GetExpenseCategory();
                        }
                        outputManager.PrintSuccessfulModification();
                        break;
                }
            }
            else
            {
                outputManager.PrintNoMatches();
            }
        }
        else
        {
            outputManager.PrintListIsEmpty();
        }
    }

    public void SearchTransaction()
    {
        if (!isListEmpty())
        {
            string deleteChoiceType = (inputManager.GetTransactionType() == 0) ? "INCOME" : "EXPENSE";
            DateOnly deleteChoiceDate = inputManager.GetTransactionDate();
            int numberOfMatchingChoices = 0;
            int matchedIndex = 0;
            foreach (Transaction transaction in _trackerList)
            {
                if (transaction.DateOfTransaction == deleteChoiceDate && transaction.Type == deleteChoiceType)
                {
                    numberOfMatchingChoices++;
                    Console.WriteLine($"[{numberOfMatchingChoices}]");
                    outputManager.PrintSpecificTransactionInformation(transaction);
                }
            }
            if (numberOfMatchingChoices == 0)
            {
                outputManager.PrintNoMatches();
            }
        }
        else
        {
            outputManager.PrintListIsEmpty();
        }
    }

    public void GetSummaryOfTransaction()
    {
        if (!isListEmpty())
        {
            int totalIncome = 0;
            int totalExpense = 0;
            foreach (Transaction transaction in _trackerList)
            {
                if (transaction is Income income)
                {
                    totalIncome += transaction.Amount;
                }
                else if (transaction is Expense expense)
                {
                    totalExpense += transaction.Amount;
                }
            }
            outputManager.PrintTransactionSummary(totalIncome, totalExpense);
        }
        else
        {
            outputManager.PrintListIsEmpty();
        }
    }

    public int SelectTransactionIndex()
    {
        string deleteChoiceType = (inputManager.GetTransactionType()==0) ? "INCOME" : "EXPENSE";
        DateOnly deleteChoiceDate = inputManager.GetTransactionDate();
        int numberOfMatchingChoices = 0;
        int matchedIndex = 0;
        foreach (Transaction transaction in _trackerList)
        {
            if (transaction.DateOfTransaction == deleteChoiceDate && transaction.Type == deleteChoiceType)
            {
                numberOfMatchingChoices++;
                Console.WriteLine($"[{numberOfMatchingChoices}]");
                outputManager.PrintSpecificTransactionInformation(transaction);
            }
        }

        if (numberOfMatchingChoices > 0)
        {
            int deleteChoiceIndex = inputManager.GetTransactionIndex();
            numberOfMatchingChoices = 0;
            foreach (Transaction transaction in _trackerList)
            {
                if (transaction.DateOfTransaction == deleteChoiceDate && transaction.Type == deleteChoiceType)
                {
                    numberOfMatchingChoices++;
                    if (transaction.DateOfTransaction == deleteChoiceDate && transaction.Type == deleteChoiceType)
                    {
                        matchedIndex = _trackerList.IndexOf(transaction);
                    }
                }
            }
            return matchedIndex;
        }
        return -1;
    }
}