using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.View;
using TimeTracker.Services;
using System.Diagnostics;

namespace TimeTracker.Controller
{
    internal class TaskController
    {
        private InputManager _inputManager;
        private OutputManager _outputManager;
        private FileHandler _fileHandler;
        private Stopwatch _stopwatch;

        public TaskController(InputManager inputManager, OutputManager outputManager, FileHandler fileHandler)
        {
            _inputManager = inputManager;
            _outputManager = outputManager;
            _fileHandler = fileHandler;
            _stopwatch = new Stopwatch();
        }

        public Dashboard GetDashboardChoice(int inputUserId, Dashboard dashboardChoice)
        {
            var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
            User user = _fileHandler.ReadJsonFile($"{fileFolderPath}\\{inputUserId}.json");
            switch (dashboardChoice)
            {
                case Dashboard.CreateTask:
                    CreateTask(user);
                    break;
                case Dashboard.SelectTask:
                    SelectTask(user);
                    break;
                case Dashboard.ExportToCsv:
                    ExportToCsvFile(user);
                    break;
                case Dashboard.ViewTasks:
                    _outputManager.PrintTasks(user.UserTasks);
                    break;
                case Dashboard.LogOut:
                    break;

            }
            return dashboardChoice;
        }

        private void ExportToCsvFile(User user)
        {
            var fileFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "TimeTracker",
                "CsvData"
            );

            string filePath = Path.Combine(fileFolderPath, $"{user.UserId}.csv");

            Directory.CreateDirectory(fileFolderPath);

            _fileHandler.CreateCsvFile(filePath);
            _fileHandler.WriteToCsvFile(filePath, user.UserTasks);
            _outputManager.PrintExportedToCsv();
        }

        public void CreateTask(User user)
        {
            UserTask newTask = new UserTask();
            newTask.Heading = _inputManager.GetTaskHeading();
            newTask.Description = _inputManager.GetTaskDescription();
            newTask.Status = UserTaskStatus.Created;
            newTask.StartTime = null;
            newTask.EndTime = null;
            user.UserTasks.Add(newTask);
            var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
            _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
            _outputManager.PrintSuccessfulTaskCreation();
            _outputManager.PrintSpecificTaskInformation(newTask);
        }

        public void StartTask(User user, int taskIndex)
        {
            if (user.UserTasks.Where(i => i.Status == UserTaskStatus.Started).Count() == 0)
            {
                if (user.UserTasks[taskIndex].Status == UserTaskStatus.Created)
                {
                    user.UserTasks[taskIndex].Status = UserTaskStatus.Started;
                    user.UserTasks[taskIndex].StartTime = DateTime.Now;
                    _stopwatch.Restart();
                }
                else if (user.UserTasks[taskIndex].Status == UserTaskStatus.Stopped)
                {
                    UserTask userTask = new UserTask();
                    userTask.Heading = user.UserTasks[taskIndex].Heading;
                    userTask.Description = user.UserTasks[taskIndex].Description;
                    userTask.Status = UserTaskStatus.Started;
                    userTask.StartTime = DateTime.Now;
                    userTask.EndTime = null;
                    user.UserTasks.Add(userTask);
                    _stopwatch.Restart();
                }
                else
                {
                    _outputManager.PrintInvalidTaskOperation();
                    return;
                }

                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
                _outputManager.PrintTaskStarted();
            }
            else
            {
                _outputManager.PrintTaskAlreadyRunning();
            }
        }

        public void PauseTask(User user, int taskIndex)
        {
            if (user.UserTasks[taskIndex].Status == UserTaskStatus.Started)
            {
                user.UserTasks[taskIndex].Status = UserTaskStatus.Paused;
                _stopwatch.Stop();
                user.UserTasks[taskIndex].TimeExecuted += _stopwatch.Elapsed;
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
                _outputManager.PrintTaskPaused();
            }
            else
            {
                _outputManager.PrintInvalidTaskOperation();
            }
        }

        public void StopTask(User user, int taskIndex)
        {
            if (user.UserTasks[taskIndex].Status == UserTaskStatus.Started)
            {
                user.UserTasks[taskIndex].Status = UserTaskStatus.Stopped;
                user.UserTasks[taskIndex].EndTime = DateTime.Now;
                _stopwatch.Stop();
                user.UserTasks[taskIndex].TimeExecuted += _stopwatch.Elapsed;
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
                _outputManager.PrintTaskStopped();
            }
            else
            {
                _outputManager.PrintInvalidTaskOperation();
            }
        }

        public void ResumeTask(User user, int taskIndex)
        {
            if (user.UserTasks[taskIndex].Status == UserTaskStatus.Paused)
            {
                user.UserTasks[taskIndex].Status = UserTaskStatus.Started;
                _stopwatch.Restart();
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
                _outputManager.PrintTaskResumed();
            }
            else
            {
                _outputManager.PrintInvalidTaskOperation();
            }
        }


        public void DeleteTask(User user, int deleteChoiceIndex)
        {
            if (deleteChoiceIndex > -1)
            {
                user.UserTasks.RemoveAt(deleteChoiceIndex);
                _outputManager.PrintSuccessfulTaskDeletion();
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
            }
            else
            {
                _outputManager.PrintNoMatches();
            }
        }

        public void EditTask(User user, int editChoiceIndex)
        {
            if (editChoiceIndex > -1)
            {
                EditField editField = (EditField) Enum.Parse (typeof(EditField), _inputManager.GetEditField());
                switch (editField)
                {
                    case EditField.EditHeading:
                        user.UserTasks[editChoiceIndex].Heading = _inputManager.GetTaskHeading();
                        break;
                    case EditField.EditDescription:
                        user.UserTasks[editChoiceIndex].Description = _inputManager.GetTaskDescription();
                        break;
                    case EditField.EditStartTime:
                        user.UserTasks[editChoiceIndex].StartTime = _inputManager.GetDateTime();
                        break;
                    case EditField.EditEndTime:
                        user.UserTasks[editChoiceIndex].EndTime = _inputManager.GetDateTime();
                        break;
                    case EditField.EditTimeExecuted:
                        user.UserTasks[editChoiceIndex].TimeExecuted = _inputManager.GetTimeExecuted();
                        break;
                }

                _outputManager.PrintTaskUpdated();
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
            }
            else
            {
                _outputManager.PrintNoMatches();
            }
        }

        public int SelectTaskIndex(User user)
        {
            string taskHeading = _inputManager.GetTaskHeading();
            string inputTaskStatus = _inputManager.GetTaskStatus();
            UserTaskStatus taskStatus = (UserTaskStatus) Enum.Parse(typeof(UserTaskStatus), inputTaskStatus);
            int numberOfMatchingChoices = 0;
            int matchedIndex = 0;
            foreach (UserTask task in user.UserTasks)
            {
                if (task.Status == taskStatus && task.Heading.Contains(taskHeading))
                {
                    numberOfMatchingChoices++;
                    Console.WriteLine($"[{numberOfMatchingChoices}]");
                    _outputManager.PrintSpecificTaskInformation(task);
                }
            }

            if (numberOfMatchingChoices > 0)
            {
                int deleteChoiceIndex = _inputManager.GetTaskIndex(numberOfMatchingChoices);
                numberOfMatchingChoices = 0;
                foreach (UserTask userTask in user.UserTasks)
                {
                    if (userTask.Status == taskStatus && userTask.Heading.Equals(taskHeading))
                    {
                        numberOfMatchingChoices++;
                        if (deleteChoiceIndex == numberOfMatchingChoices)
                        {
                            matchedIndex = user.UserTasks.IndexOf(userTask);
                        }
                    }
                }

                return matchedIndex;
            }

            return -1;
        }

        public void SelectTask(User user)
        {
            int taskIndex = SelectTaskIndex(user);
            if (taskIndex < 0)
                _outputManager.PrintNoMatches();
            else
            {
                var currentTask = Enum.Parse(typeof(TaskOperations), _inputManager.GetTaskOperation());
                switch(currentTask)
                {
                    case TaskOperations.StartTask:
                        StartTask(user, taskIndex);
                        break;
                    case TaskOperations.StopTask:
                        StopTask(user, taskIndex);
                        break ;
                    case TaskOperations.PauseTask:
                        PauseTask(user, taskIndex);
                        break;
                    case TaskOperations.ResumeTask:
                        ResumeTask(user, taskIndex);
                        break ;
                    case TaskOperations.DeleteTask:
                        DeleteTask(user, taskIndex);
                        break ;
                    case TaskOperations.EditTask:
                        EditTask(user, taskIndex);
                        break ;
                }
            }
        }
    }
}
