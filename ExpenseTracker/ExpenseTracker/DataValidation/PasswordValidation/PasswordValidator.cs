using ExpenseTracker.ApplicationFunction;

namespace ExpenseTracker.DataValidation.PasswordValidation
{
    public class PasswordValidator
    {
        //Conditions conditions = new Conditions();
        public static string CheckPasswordFormat(string password)
        {
            while (!Conditions.ConditionApprover(password))
            {
                Console.Write("The password is invalid !!\nProvide a Valid Password : ");
                password = Console.ReadLine();
            }
            return password;
        }

    public static string GetValidLoginPassword(string inputLoginPassword)
        {
            string validPassword = PasswordValidator.CheckPasswordFormat(inputLoginPassword);
            return validPassword;
        }
        public static string GetConfirmedPassword(string inputLoginPassword)
        {
            bool isPasswordConfirmed = false;
            while (!isPasswordConfirmed)
            {
                if (Console.ReadLine() == inputLoginPassword)
                {
                    isPasswordConfirmed = true;
                }
                else
                {
                    Console.WriteLine("The Password doesn't match the initial password !! ");
                    LoginCredentialsOperations.GetNewPassword();
                }
            }
            return inputLoginPassword;
        }
    }
}