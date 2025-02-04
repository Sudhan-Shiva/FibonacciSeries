using ToDoList.DataValidation;
using ToDoList.ConsoleUI;
using ToDoList.Utility;
using ToDoList.FileManager;
using ToDoList.Model;

InputValidation inputValidation = new InputValidation();
PasswordValidation passwordValidation = new PasswordValidation();
InputManager inputManager = new InputManager(inputValidation, passwordValidation);
OutputManager outputManager = new OutputManager();
DataHandler dataHandler = new DataHandler();
UserManager userManager = new UserManager(inputManager, outputManager, dataHandler);
TaskManager taskManager = new TaskManager(inputManager, outputManager, dataHandler);
int userChoice;
int userAction;
do
{
    userAction = userManager.UserValidation();
    if (userAction != 5 && userAction != -1)
    {
        User user = dataHandler.ReadFile($"{userAction}.json");
        do
        {
            user = dataHandler.ReadFile($"{userAction}.json");
            taskManager.PrintRecentTask(user.UserTask);
            userChoice = taskManager.GetUserOption(userAction, inputManager.GetUserOption());
            outputManager.PrintEnterKeyToExit();
            Console.ReadKey();
            Console.Clear();
        } while (userChoice != 5);
        Console.Clear();
    }
} while (userAction != 5);
outputManager.PrintEnterKeyToExit();
Console.ReadKey();