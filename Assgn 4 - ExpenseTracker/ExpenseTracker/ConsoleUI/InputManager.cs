using ExpenseTracker.InputValidation;

namespace ExpenseTracker.ConsoleUI
{
    public class InputManager
    {
        DataValidation dataValidation;
        public InputManager(DataValidation mainDataValidation)
        {
            dataValidation = mainDataValidation;
        }
        public int GetUserChoice()
        {
            Console.WriteLine("\n[0] View all previous transaction\n[1] Add new transcation\n[2] Delete older transaction\n[3] Edit Older transaction\n[4] Search the Tracker List\n[5] View Transacton Summary\n[6] Exit ");
            Console.Write("Select the action to be performed :");
            int userChoice = GetValidInteger(Console.ReadLine());
            while (!(userChoice >= 0 && userChoice <= 6))
            {
                userChoice = GetValidInteger(ReplaceInvalidInput());
            }
            return userChoice;
        }

        public int GetTransactionType()
        {
            Console.Write("[0] INCOME\n[1] EXPENSE\nEnter the Transaction Type :  ");
            int transactionType = GetValidInteger(Console.ReadLine());
            while (transactionType != 0 && transactionType != 1)
            {
                transactionType = GetValidInteger(ReplaceInvalidInput());
            }
            return transactionType;
        }

        public int GetTransactionAmount()
        {
            Console.Write("Enter the Transaction Amount :  ");
            int transactionAmount = GetValidInteger(Console.ReadLine());
            return transactionAmount;
        }

        public DateOnly GetTransactionDate()
        {
            Console.Write("Enter the Date of Transaction :  ");
            DateOnly transactionDate = GetValidDate(Console.ReadLine());
            return transactionDate;
        }

        public string GetIncomeSource()
        {
            Console.Write("Enter the Source of Income : ");
            string incomeSource = GetValidInput(Console.ReadLine());
            return incomeSource;
        }

        public string GetExpenseCategory()
        {
            Console.Write("Enter the Category of expense : ");
            string expenseCategory = GetValidInput(Console.ReadLine());
            return expenseCategory;
        }

        /// <summary>
        /// To get another input when the given input is invalid
        /// </summary>
        /// <returns>The input for replacing the invalid input</returns>
        public string ReplaceInvalidInput()
        {
            Console.Write("The Provided input is invalid !!\nProvide the Input again :");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        /// <summary>
        /// To get another input when the given input is null or empty string
        /// </summary>
        /// <returns>The input for replacing the null or empty string input</returns>
        public string ReplaceEmptyInput()
        {
            Console.Write("The Provided input is empty !!\nProvide the Input again :");
            string inputParameter = Console.ReadLine();
            return inputParameter;
        }

        /// <summary>
        /// To get a valid input which is not null or empty string
        /// </summary>
        /// <param name="inputParameter">The input that is validated</param>
        /// <returns>A valid input which is not null or empty string</returns>
        public string GetValidInput(string inputParameter)
        {
            while (dataValidation.IsDataEmpty(inputParameter))
            {
                inputParameter = ReplaceEmptyInput();
            }
            return inputParameter;
        }
        /// <summary>
        /// To get a valid input which is of the required datatype integer.
        /// </summary>
        /// <param name="inputParameter">The input that is validated for the datatype</param>
        /// <returns>A valid input which is integer</returns>
        public int GetValidInteger(string inputParameter)
        {
            while (!dataValidation.IsInputInt(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            int.TryParse(inputParameter, out int validData);
            return validData;
        }

        /// <summary>
        /// To get a valid input which is of the required datatype integer.
        /// </summary>
        /// <param name="inputParameter">The input that is validated for the datatype</param>
        /// <returns>A valid input which is integer</returns>
        public DateOnly GetValidDate(string inputParameter)
        {
            while (!dataValidation.IsInputDate(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            DateOnly.TryParse(inputParameter, out DateOnly validData);
            return validData;
        }

        public int GetModifyChoice()
        {
            Console.WriteLine("[0] Transaction Type\n[1] Transaction Amount\n[2] Transaction Date\n[3] Transaction Details");
            Console.Write("Select the field to edit :");
            int fieldToEdit = GetValidInteger(Console.ReadLine());
            while(!(fieldToEdit>=0 && fieldToEdit <=3))
            {
                fieldToEdit = GetValidInteger(ReplaceInvalidInput());
            }
            return fieldToEdit;
        }

        public int GetTransactionIndex()
        {
            Console.Write("Select the transaction index : ");
            int deleteChoiceIndex = GetValidInteger(Console.ReadLine());
            return deleteChoiceIndex;
        }

    }
}
