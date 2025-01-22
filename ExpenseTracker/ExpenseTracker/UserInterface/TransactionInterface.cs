using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.UserDetails;
using ExpenseTracker.ApplicationFunction;

namespace ExpenseTracker.UserInterface
{
    public class TransactionInterface
    {
        public static void UserTransactionInterface(List<List<Transaction>> trackerList, List<LoginCredentials> loginCredentialsList, int userLoginIndex)
        {
            Console.WriteLine("\n[1]View all previous transaction\n[2] Add new transcation\n[3] Delete older transaction\n[4] Edit Older transaction\n[5] Search the Tracker List\n[6] View Transacton Summary\n[7] Exit ");
            Console.Write("Select the action to be performed :");
            string userAction = Console.ReadLine();
            ApplicationFeatures applicationFeatures = new ApplicationFeatures();
            do
            {
                switch (userAction)
                {
                    case "1":
                        applicationFeatures.TransactionView(userLoginIndex);
                        break;
                    case "2":
                        applicationFeatures.TransactionAddition(userLoginIndex);
                        break;
                    case "3":
                        applicationFeatures.TransactionDeletion(userLoginIndex);
                        break;
                    case "4":
                        applicationFeatures.TransactionModification(userLoginIndex);
                        break;
                    case "5":
                        applicationFeatures.TransactionSearch(userLoginIndex);
                        break;
                    case "6":
                        applicationFeatures.TransactionSummary(userLoginIndex);
                        break;
                    case "7":
                        LoginInterface.CheckNewUser(loginCredentialsList);
                        break;
                    default:
                        UserTransactionInterface(trackerList, loginCredentialsList, userLoginIndex);
                        break;
                }
                Console.WriteLine("\n[1]View all previous transaction\n[2] Add new transcation\n[3] Delete older transaction\n[4] Edit Older transaction\n[5] Search the Tracker List\n[6] View Transacton Summary\n[7] Exit ");
                Console.Write("Select the action to be performed :");
                userAction = Console.ReadLine();
            } while (userAction != "7");
        }
    }
}
