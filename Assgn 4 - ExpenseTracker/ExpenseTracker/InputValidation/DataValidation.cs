namespace ExpenseTracker.InputValidation
{
    public class DataValidation
    {
        public bool IsInputInt(string inputField)
        {
            return int.TryParse(inputField, out int parsedAmount);
        }

        public bool IsInputDate(string inputField)
        {
            return DateOnly.TryParse(inputField, out DateOnly parsedDate);
        }

        /// <summary>
        /// To check whether the given input is null or empty string
        /// </summary>
        /// <param name="inputProductField">The input that must be checked</param>
        /// <returns>True if the input is null or empty string, else false</returns>
        public bool IsDataEmpty(string inputProductField)
        {
            return (inputProductField == null || inputProductField == "");
        }
    }
}
