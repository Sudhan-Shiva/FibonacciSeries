using ExpenseTracker.UserDetails;

namespace ExpenseTracker.ValidInput
{
    public class DataValidation
    {
        public static void CheckInputFormat(string inputField, bool isAmount, Transaction transactionDetails)
        {
            int parsedAmount = 0;
            DateOnly parsedDate = DateOnly.MinValue;
            bool isInputCorrectFormat = (isAmount) ? int.TryParse(inputField, out parsedAmount) : DateOnly.TryParse(inputField, out parsedDate);
            while (!isInputCorrectFormat)
            {
                Console.Write("The Input is Invalid !!\nType the Input Again : ");
                isInputCorrectFormat = (isAmount) ? int.TryParse(Console.ReadLine(), out parsedAmount) : DateOnly.TryParse(Console.ReadLine(), out parsedDate);
            }
            if (isAmount)
            {
                transactionDetails.Amount = parsedAmount;
            }
            else
            {
                transactionDetails.DateOfTransaction = parsedDate;
            }
        }
    }
}
