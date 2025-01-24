using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using ExpenseTracker.Model;

namespace ExpenseTracker.ConsoleUI
{
    public class OutputManager
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("---------WELCOME----------");
            Console.WriteLine("EXPENSE TRACKER");
        }
        public void PrintSuccessfulAddition()
        {
            Console.WriteLine("The Transaction Information has been successfully added.\n");
        }

        public void PrintSuccessfulDeletion()
        {
            Console.WriteLine("The Transaction Information has been successfully deleted.\n");
        }

        public void PrintSuccessfulModification()
        {
            Console.WriteLine("The Transaction Information has been successfully edited.\n");
        }

        public void PrintListIsEmpty()
        {
            Console.WriteLine("The transaction list is empty !!");
        }
        public void PrintTable(List<Transaction> trackerList)
        {
            ConsoleTable transactionTable = new ConsoleTable("Transaction Type", "Transaction Amount", "Transaction Date", "Source/Category");
            foreach (Transaction transaction in trackerList)
            {
                if (transaction is Income income)
                    transactionTable.AddRow(transaction.Type, transaction.Amount, transaction.DateOfTransaction, income.Source);
                else if (transaction is Expense expense)
                    transactionTable.AddRow(transaction.Type, transaction.Amount, transaction.DateOfTransaction, expense.Category);
            }
            transactionTable.Write();
        }

        public void PrintSpecificTransactionInformation(Transaction transaction)
        {
            ConsoleTable transactionTable = new ConsoleTable("Transaction Type", "Transaction Amount", "Transaction Date", "Source/Category");
            if (transaction is Income income)
            {
                transactionTable.AddRow(transaction.Type, transaction.Amount, transaction.DateOfTransaction, income.Source);
            }
            else if (transaction is Expense expense)
            {
                transactionTable.AddRow(transaction.Type, transaction.Amount, transaction.DateOfTransaction, expense.Category);
            }
            transactionTable.Write();
        }

        public void PrintTransactionSummary(int totalIncome, int totalExpense)
        {
            Console.WriteLine("Total Income : " + totalIncome);
            Console.WriteLine("Total Expense : " + totalExpense);
            Console.WriteLine("Net Balance : " + (totalIncome - totalExpense));
        }

        public void PrintExitMessage()
        {
            Console.WriteLine("--------EXITING--------");
            Console.WriteLine("Press any key to exit");
        }

        public void PrintNoMatches()
        {
            Console.WriteLine("There are no matches found !!");
        }
    }
}
