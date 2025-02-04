namespace ToDoList.Model
{
    public enum UserType
    {
        OldUser,
        NewUser,
        ExitApplication
    }

    public enum UserOptions
    {
        AddTasks,
        DeleteTasks,
        ViewTasks,
        EditTasks,
        CalenderView,
        LogOut
    }

    public enum EditField
    {
        EditHeading,
        EditDescription,
        EditTargetDate,
        EditRecurrence
    }

    public enum RecurrenceField
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum CalenderChoice
    {
        Day,
        Month,
        Year
    }
}
