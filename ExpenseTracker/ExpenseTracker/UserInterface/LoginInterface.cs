using ExpenseTracker.UserDetails;
using ExpenseTracker.ApplicationFunction;

namespace ExpenseTracker.UserInterface
{
    public class LoginInterface
    {

        public static string bootUpInterface(List<LoginCredentials> loginCredentialsList)
        {
            Console.WriteLine("HELLO !!\n[1] Enter the application \n[2] Exit the application ");
            string enterChoice = Console.ReadLine();
            if( enterChoice == "1")
            {
                CheckNewUser(loginCredentialsList);
                return "1";
            }
            else
            {
                Console.WriteLine("-----PRESS ANY KEY TO EXIT-----");
                return "2";
            }
        }
        public static int CheckNewUser(List<LoginCredentials> loginCredentialsList)
        {
            Console.WriteLine("------WELCOME TO THE EXPENSE TRACKER-------");
            Console.Write("Are you a new user ?\nY/N :");
            string userChoice = Console.ReadLine();
            if (userChoice.ToUpper() == "Y")
            {
                LoginCredentialsOperations.AddLoginCredentials(loginCredentialsList);
                return -1;
                
            }
            else if (userChoice.ToUpper() == "N")
            {
                return LoginCredentialsOperations.CheckLoginCredentials(loginCredentialsList);
            }
            else
            {
                return -1;
            }
        }
    }
}
