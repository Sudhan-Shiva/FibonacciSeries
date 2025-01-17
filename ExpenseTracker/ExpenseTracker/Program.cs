
using ExpenseTracker.UserDetails;
using ExpenseTracker.ValidInput.PasswordValidation;

List<List<Transaction>> transactionsList = new List<List<Transaction>>();
List<LoginCredentials> loginCredentialsList = new List<LoginCredentials>();
List<Transaction> TrackerList = [];
//ApplicationFunctions.ExpenseAddition(TrackerList);
//ApplicationFunctions.ExpenseAddition(TrackerList);
//ApplicationFunctions.ExpenseAddition(TrackerList);
//Console.WriteLine(CalculateTotal.CalculateTotalIncome(TrackerList, 0));
//Console.WriteLine(CalculateTotal.CalculateTotalIncome(TrackerList, 1));
//Console.WriteLine(CalculateTotal.CalculateTotalIncome(TrackerList, 2));
Console.WriteLine("------WELCOME TO THE EXPENSE TRACKER-------");
Console.Write("Are you a new user ?\nY/N :");
if(Console.ReadLine().ToUpper() == "Y")
{
    Console.Write("Create a UserName : ");
    string loginUserName = Console.ReadLine();
    Console.Write("Create a Password : ");
    string loginPassword = PasswordValidator.CheckPasswordFormat(Console.ReadLine());
    Console.Write("ReConfirm your Password : ");
    bool isPasswordConfirmed = false;
    while(!isPasswordConfirmed)
    {
        if (Console.ReadLine() == loginPassword)
        {
            LoginCredentials loginCredentials = new LoginCredentials(loginUserName, loginPassword);
            loginCredentialsList.Add(loginCredentials);
            isPasswordConfirmed = true;
            Console.WriteLine("The password is successfully added !!");
        }
        else
        {
            Console.WriteLine("The Password doesn't match the initial password !! ");
            Console.Write("Create a Password : ");
            loginPassword = PasswordValidator.CheckPasswordFormat(Console.ReadLine());
            Console.Write("ReConfirm your Password : ");
        }
    }
}

Console.ReadKey();