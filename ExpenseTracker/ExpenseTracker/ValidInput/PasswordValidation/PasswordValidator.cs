namespace ExpenseTracker.ValidInput.PasswordValidation
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
    }
}
