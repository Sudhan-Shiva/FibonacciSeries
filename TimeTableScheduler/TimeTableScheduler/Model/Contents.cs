namespace TimeTableScheduler.Model
{
    public enum Subject
    {
        DigitalImageProcessing,
        MicrowaveEngineeringAndOpticalCommunication,
        WirelessCommunicationAndNetworks,
        Library,
        WirelessCommunicationAndNetworkingLaboratory,
        ProjectPhaseI,
        PEd,
        ElectiveVSensorsAndTransducers,
        ElectiveVIBiomedicalInstrumentation
    }
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
        CalendarView,
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
        Monthly
    }

    public enum CalendarChoice
    {
        Day,
        Month,
        Year
    }
}