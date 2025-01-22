using ExpenseTracker.UserDetails;
using ExpenseTracker.DataValidation.UserNameValidation;
using ExpenseTracker.DataValidation.PasswordValidation;
using ExpenseTracker.UserInterface;
using ExpenseTracker.ApplicationFunction;

namespace ExpenseTracker.ApplicationFunction
{

    public class LoginCredentialsOperations
    {
       
        public static string GetNewUserName(List<LoginCredentials> loginCredentialsList)
        {
            Console.Write("Create a UserName : ");
            string loginUserName = Console.ReadLine();
            return UserNameValidator.GetUniqueLoginUserName(loginCredentialsList, loginUserName);
        }
        public static string GetNewPassword()
        {
            Console.Write("Create a Password : ");
            string validPassword = PasswordValidator.GetValidLoginPassword(Console.ReadLine());
            Console.Write("ReConfirm your Password : ");
            string setPassword = PasswordValidator.GetConfirmedPassword(validPassword);
            Console.WriteLine("The password is successfully added !!");
            return setPassword;
        }

        public static int GetOldUserName(List<LoginCredentials> loginCredentialsList)
        {
            Console.Write("Type the Username : ");
            int inputIndex = IndexSearch.ReturnIndex(loginCredentialsList, Console.ReadLine());
            if (inputIndex == -1)
            {
                Console.WriteLine("The Username is not present !!");
                return LoginInterface.CheckNewUser(loginCredentialsList);
            }
            else
            {
                return GetOldPassword(loginCredentialsList, inputIndex);
            }
        }

        public static int GetOldPassword(List<LoginCredentials> loginCredentialsList, int inputIndex)
        {
            Console.Write("Type the password : ");
            string inputPassword = Console.ReadLine();
            if (inputPassword == loginCredentialsList[inputIndex].Password)
            {
                List<List<Transaction>> transactionsList = new List<List<Transaction>>();
                Console.WriteLine("You're successfully logged in !! ");
                Console.WriteLine(inputIndex);
                TransactionInterface.UserTransactionInterface(transactionsList, loginCredentialsList, inputIndex);
                return inputIndex;
            }
            else
            {
                int passwordAttempt = 0;
                while (passwordAttempt < 2)
                {
                    Console.WriteLine("You've entered the wrong password !! ");
                    Console.Write("Type the password : ");
                    inputPassword = Console.ReadLine();
                    if (inputPassword == loginCredentialsList[inputIndex].Password)
                    {
                        Console.WriteLine("You're successfully logged in !! ");
                        return inputIndex;
                    }    
                    passwordAttempt++;
                }
                Console.WriteLine("Wrong password attempts have exceeded 3 times !!!");
                Console.WriteLine("------------EXITING---------");
                return inputIndex;
            }
        }


        public static void AddLoginCredentials(List<LoginCredentials> loginCredentialsList)
        {
            string inputUserName = GetNewUserName(loginCredentialsList);
            string inputPassword = GetNewPassword();
            LoginCredentials loginCredentials = new LoginCredentials(inputUserName, inputPassword);
            loginCredentialsList.Add(loginCredentials);
        }

        public static int CheckLoginCredentials(List<LoginCredentials> loginCredentialsList)
        {
            return GetOldUserName(loginCredentialsList);
        }
    }
}
