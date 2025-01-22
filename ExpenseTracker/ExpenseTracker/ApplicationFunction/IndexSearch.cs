using ExpenseTracker.UserDetails;

namespace ExpenseTracker.ApplicationFunction
{
    public class IndexSearch
    {
        public static int ReturnIndex(List<LoginCredentials> loginCredentialsList, string searchUserName)
        {
            foreach (LoginCredentials loginCredentials in loginCredentialsList)
            {
                if (searchUserName == loginCredentials.Username)
                {
                    return loginCredentialsList.IndexOf(loginCredentials);
                }
            }
            return -1;
        }
    }
}
