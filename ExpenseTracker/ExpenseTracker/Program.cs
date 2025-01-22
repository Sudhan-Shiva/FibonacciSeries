
using ExpenseTracker.UserDetails;
using ExpenseTracker.UserInterface;


List<LoginCredentials> loginCredentialsList = new List<LoginCredentials>();

string userChoice = "1";
while (userChoice != "2")
{
    userChoice = LoginInterface.bootUpInterface(loginCredentialsList);
}
Console.ReadKey();