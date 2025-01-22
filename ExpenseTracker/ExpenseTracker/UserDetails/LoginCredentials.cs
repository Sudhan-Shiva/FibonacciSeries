namespace ExpenseTracker.UserDetails
{
    public class LoginCredentials
    {
        private string _username;
        private string _password;
        public LoginCredentials(string username, string password)
        {
            _username = username;
            _password = password;
        }
        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }
    }

    
}

