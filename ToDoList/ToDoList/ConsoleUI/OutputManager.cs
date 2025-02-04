using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ConsoleTables;
using ToDoList.Model;
using Task = ToDoList.Model.Task;

namespace ToDoList.ConsoleUI
{
    public class OutputManager
    {
        public void PrintSuccessfulLogin()
        {
            Console.WriteLine("User Login Successful !! ", Console.ForegroundColor = ConsoleColor.Green);
            Console.ResetColor();
        }

        public void PrintFailedLogin()
        {
            Console.WriteLine("User Login Failure !!!\nReturning to Main Menu",Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
        }

        public void PrintSpecificTaskInformation(Task task)
        {
            ConsoleTable taskTable = new ConsoleTable("Heading","Description","TargetDate","Recurrence");
            taskTable.AddRow(task.Heading,task.Description, task.TargetDate.ToString("MM/dd/yyyy"), task.Recurrence);
            taskTable.Write();
        }

        public void PrintSuccessfulDeletion()
        {
            Console.WriteLine("The Task has been successfully deleted.\n");
        }

        public void PrintNoMatches()
        {
            Console.WriteLine("There are no matches found !!");
        }

        public void PrintTasks(List<Task> tasks)
        {
            ConsoleTable consoleTable = new ConsoleTable("Heading", "Description", "TargetDate", "Recurrence");
            foreach(Task task in tasks)
            {
                consoleTable.AddRow(task.Heading, task.Description, task.TargetDate.ToString("MM/dd/yyyy"), task.Recurrence);
            }
            consoleTable.Write();
        }

        public void PrintUserAlreadyPresent()
        {
            Console.Beep();
            Console.WriteLine("User Id ias already present !!", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
        }

        public void PrintEnterKeyToExit()
        {
            Console.WriteLine("Press any key to Exit !!");
        }
    }
}
