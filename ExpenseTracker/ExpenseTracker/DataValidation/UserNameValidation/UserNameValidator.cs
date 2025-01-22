using System.Reflection.Metadata.Ecma335;
using ExpenseTracker.ApplicationFunction;
using ExpenseTracker.UserDetails;

namespace ExpenseTracker.DataValidation.UserNameValidation
{
    public class UserNameValidator
    {
        public static string GetUniqueLoginUserName(List<LoginCredentials> loginCredentialsList, string inputLoginUserName)
        {
            bool isUniqueUserName = false;
            while (!isUniqueUserName)
            {
                if(IndexSearch.ReturnIndex(loginCredentialsList,inputLoginUserName) == -1)
                {
                    isUniqueUserName = true;
                }
                else
                {
                    Console.Write("The Login UserName is already present !!\nProvide a new UserName :");
                    inputLoginUserName = Console.ReadLine();
                }
            }
            return inputLoginUserName;
        }
    }
}
