namespace TimeTracker.Model
{
    public enum InitialMenu
    {
        OldUser,
        NewUser,
        ExitApplication
    }

    public enum Dashboard
    {
        CreateTask,
        SelectTask,
        ExportToCsv,
        ViewTasks,
        LogOut
    }

    public enum TaskOperations
    {
        StartTask,
        StopTask,
        PauseTask,
        ResumeTask,
        EditTask,
        DeleteTask
    }

    public enum EditField
    {
        EditHeading,
        EditDescription,
        EditStartTime,
        EditEndTime,
        EditTimeExecuted
    }

    public enum UserTaskStatus
    {
        Created,
        Started,
        Paused,
        Stopped
    }
}
