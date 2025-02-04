using ToDoList.DataValidation;
using ToDoList.Model;

namespace ToDoList.ConsoleUI
{
    public class InputManager
    {
        private InputValidation _inputValidation;
        private PasswordValidation _passwordValidation;
        public InputManager(InputValidation mainInputValidation, PasswordValidation mainPasswordValidation)
        {
            _inputValidation = mainInputValidation;
            _passwordValidation = mainPasswordValidation;
        }

        public int GetUserType()
        {
            Console.WriteLine("\n---------WELCOME----------");
            Console.WriteLine($"\n[0] {UserType.OldUser}\n[1] {UserType.NewUser}\n[2] {UserType.ExitApplication}");
            Console.Write("Provide the UserType : ");
            return GetChoiceWithinBounds(2);
        }

        public int GetUserOption()
        {
            Console.WriteLine($"\n[0] {UserOptions.AddTasks}\n[1] {UserOptions.DeleteTasks}\n[2] {UserOptions.ViewTasks}\n[3] {UserOptions.EditTasks}\n[4] {UserOptions.CalenderView}\n[5] {UserOptions.LogOut}");
            Console.Write("Provide the UserOption: ");
            return GetChoiceWithinBounds(5);
        }

        public int GetEditField()
        {
            Console.WriteLine($"\n[0] {EditField.EditHeading}\n[1] {EditField.EditDescription}\n[2] {EditField.EditTargetDate}\n[3] {EditField.EditRecurrence}");
            Console.Write("Provide the UserOption: ");
            return GetChoiceWithinBounds(3);
        }
        public string GetValidString(string inputString)
        {
            while(_inputValidation.IsValidInput(inputString))
            {
                inputString = ReplaceEmptyInput();
            }
            return inputString;
        }

        private string ReplaceEmptyInput()
        {
            Console.WriteLine("The given input is empty");
            Console.Write("Provide a valid Input :");
            return Console.ReadLine();
        }

        public int GetUserId()
        {
            Console.Write("Enter the User ID : ");
            string inputId = Console.ReadLine();
            while(!_inputValidation.IsValidInteger(inputId))
            {
                inputId = ReplaceInvalidId();
            }
            return int.Parse(inputId);
        }

        private string ReplaceInvalidId()
        {
            Console.Beep();
            Console.WriteLine("The input ID is invalid ", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            Console.Write("Give a valid ID :");
            return Console.ReadLine();
        }

        public string GetPassword()
        {
            Console.Write("Enter the User Password : ");
            string inputPassword = Console.ReadLine();
            while (!_passwordValidation.IsPasswordValid(inputPassword))
            {
                inputPassword = ReplaceInvalidPassword();
            }
            return inputPassword;
        }

        private string ReplaceInvalidPassword()
        {
            Console.Beep();
            Console.WriteLine("The input password is invalid", Console.ForegroundColor = ConsoleColor.Red);
            Console.ResetColor();
            Console.WriteLine("The password must be of minimum length 6,\nMust contain atleast one number,\nMust contain atleast one uppercase alphabet,\nMust contain atleast one lowercase Alphabet,\nMust contain atleast one special Character", Console.ForegroundColor = ConsoleColor.Red);
            Console.Write("Enter a valid Password :");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public DateTime GetTargetDate()
        {
            Console.Write("Give the Target Date of the Task (DD/MM/YYYY) : ");
            string targetDate = Console.ReadLine();
            while(!_inputValidation.IsValidDate(targetDate))
            {
                targetDate = ReplaceInvalidDate();
            }
            return DateTime.Parse(targetDate);
        }

        private string ReplaceInvalidDate()
        {
            Console.Beep();
            Console.WriteLine("The input Date is invalid or is of the past !!", Console.ForegroundColor = ConsoleColor.Red);
            Console.Write("Give a valid date : ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        private int GetChoiceWithinBounds(int maxEnumLength)
        {
            int enumChoice = GetValidInteger(Console.ReadLine());
            while (enumChoice < 0 || enumChoice > maxEnumLength)
            {
                enumChoice = GetValidInteger(ReplaceInvalidInput());
            }
            return enumChoice;
        }

        public int GetValidInteger(string inputParameter)
        {
            while (!_inputValidation.IsValidInteger(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            int.TryParse(inputParameter, out int validData);
            return validData;
        }
        public string ReplaceInvalidInput()
        {
            Console.Write("The Provided input is invalid !!\nProvide the Input again :", Console.ForegroundColor = ConsoleColor.Red);
            string inputParameter = Console.ReadLine();
            Console.ResetColor();
            return inputParameter;
        }

        public string GetUserName()
        {
            Console.Write("Provide the User Name :");
            return Console.ReadLine();
        }

        public bool ValidatePassword(string correctPassword)
        {
            string inputPassword = GetPassword();
            int noOfTries = 0;
            while(noOfTries < 2)
            {
                if (correctPassword == inputPassword)
                    return true;
                else
                {
                    Console.Beep();
                    Console.WriteLine("The input passsword is wrong !!", Console.ForegroundColor = ConsoleColor.Red);
                    Console.Write("Give the Correct Password :");
                    inputPassword = Console.ReadLine();
                    Console.ResetColor();
                }
                noOfTries++;
            }
            return false;
        }

        public string GetTaskHeading()
        {
            Console.Write("Provide the heading of the Task: ");
            return GetValidString(Console.ReadLine());
        }

        public string GetTaskDescription()
        {
            Console.Write("Provide the description: ");
            return GetValidString(Console.ReadLine());
        }

        public int GetTaskRecurrence()
        {
            Console.WriteLine($"[0] {RecurrenceField.Daily}\n[1] {RecurrenceField.Weekly}\n[2] {RecurrenceField.Monthly}\n[3] {RecurrenceField.Yearly}");
            Console.Write("Provide the Recurrence of the Task: ");
            return GetChoiceWithinBounds(3);
        }

        public int GetCalenderOption()
        {
            Console.WriteLine($"[0] {CalenderChoice.Day}\n[1] {CalenderChoice.Month}\n[2] {CalenderChoice.Year}");
            Console.Write("Provide the field of the calender : ");
            return GetChoiceWithinBounds(2);
        }

        public int GetTaskIndex(int maxValue)
        {
            Console.Write("Select the task index : ");
            int userSelectedIndex = GetValidInteger(Console.ReadLine());
            while(userSelectedIndex <= 0||userSelectedIndex > maxValue)
            {
                userSelectedIndex = GetValidInteger(ReplaceInvalidInput());
            }
            return userSelectedIndex;
        }
    }
}
