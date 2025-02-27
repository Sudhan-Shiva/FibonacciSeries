using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using TimeTableScheduler.Model;

internal class TimeTableCreator
{
    public void CreateTimeTableFile()
    {
        // List of schedule entries
        var schedule = new List<ScheduleEntry>
        {
            new ScheduleEntry(DateOnly.Parse("03/03/2025"), "Monday", "Digital Image Processing", "Dr. A", "09:00:00", "09:55:00"),
            new ScheduleEntry(DateOnly.Parse("03/03/2025"), "Monday", "Microwave Engineering and Optical Communication", "Dr. B", "09:55:00", "10:50:00"),
            new ScheduleEntry(DateOnly.Parse("03/03/2025"), "Monday", "Wireless Communication and Networks", "Dr. C", "11:05:00", "12:00:00"),
            new ScheduleEntry(DateOnly.Parse("03/03/2025"), "Monday", "Wireless Communication and Networks", "Dr. C", "12:00:00", "12:55:00"),
            new ScheduleEntry(DateOnly.Parse("03/03/2025"), "Monday", "Library", "Dr. D", "02:00:00", "02:55:00"),
            new ScheduleEntry(DateOnly.Parse("03/03/2025"), "Monday", "Wireless Communication and Networking Laboratory/High Frequency Laboratory", "Dr. E", "02:55:00", "03:50:00"),
            new ScheduleEntry(DateOnly.Parse("03/03/2025"), "Monday", "Project Phase I", "Dr. F", "03:50:00", "04:45:00"),
            new ScheduleEntry(DateOnly.Parse("04/03/2025"), "Tuesday", "Wireless Communication and Networks", "Dr. C", "09:00:00", "09:55:00"),
            new ScheduleEntry(DateOnly.Parse("04/03/2025"), "Tuesday", "Digital Image Processing", "Dr. A", "09:55:00", "10:50:00"),
            new ScheduleEntry(DateOnly.Parse("04/03/2025"), "Tuesday", "Library", "Dr. D", "11:05:00", "12:00:00"),
            new ScheduleEntry(DateOnly.Parse("04/03/2025"), "Tuesday", "Microwave Engineering and Optical Communication", "Dr. B", "12:00:00", "12:55:00"),
            new ScheduleEntry(DateOnly.Parse("04/03/2025"), "Tuesday", "Digital Image Processing", "Dr. A", "02:00:00", "02:55:00"),
            new ScheduleEntry(DateOnly.Parse("04/03/2025"), "Tuesday", "Wireless Communication and Networking Laboratory/High Frequency Laboratory", "Dr. E", "02:55:00", "03:50:00"),
            new ScheduleEntry(DateOnly.Parse("04/03/2025"), "Tuesday", "P.Ed", "Dr. G", "03:50:00", "04:45:00"),
            new ScheduleEntry(DateOnly.Parse("05/03/2025"), "Wednesday", "Digital Image Processing", "Dr. A", "09:00:00", "09:55:00"),
            new ScheduleEntry(DateOnly.Parse("05/03/2025"), "Wednesday", "Microwave Engineering and Optical Communication", "Dr. B", "09:55:00", "10:50:00"),
            new ScheduleEntry(DateOnly.Parse("05/03/2025"), "Wednesday", "Library", "Dr. D", "11:05:00", "12:00:00"),
            new ScheduleEntry(DateOnly.Parse("05/03/2025"), "Wednesday", "Elective V: Sensors and Transducers/Elective VI: Biomedical Instrumentation", "Dr. H", "12:00:00", "12:55:00"),
            new ScheduleEntry(DateOnly.Parse("05/03/2025"), "Wednesday", "Digital Image Processing", "Dr. A", "02:00:00", "02:55:00"),
            new ScheduleEntry(DateOnly.Parse("05/03/2025"), "Wednesday", "Library", "Dr. D", "02:55:00", "03:50:00"),
            new ScheduleEntry(DateOnly.Parse("05/03/2025"), "Wednesday", "Project Phase I", "Dr. F", "03:50:00", "04:45:00"),
            new ScheduleEntry(DateOnly.Parse("06/03/2025"), "Thursday", "Microwave Engineering and Optical Communication", "Dr. B", "09:00:00", "09:55:00"),
            new ScheduleEntry(DateOnly.Parse("06/03/2025"), "Thursday", "Digital Image Processing", "Dr. A", "09:55:00", "10:50:00"),
            new ScheduleEntry(DateOnly.Parse("06/03/2025"), "Thursday", "Wireless Communication and Networks", "Dr. C", "11:05:00", "12:00:00"),
            new ScheduleEntry(DateOnly.Parse("06/03/2025"), "Thursday", "Elective V: Sensors and Transducers", "Dr. H", "12:00:00", "12:55:00"),
            new ScheduleEntry(DateOnly.Parse("06/03/2025"), "Thursday", "Elective VI: Biomedical Instrumentation", "Dr. I", "02:00:00", "02:55:00"),
            new ScheduleEntry(DateOnly.Parse("06/03/2025"), "Thursday", "Library", "Dr. D", "02:55:00", "03:50:00"),
            new ScheduleEntry(DateOnly.Parse("06/03/2025"), "Thursday", "Project Phase I", "Dr. F", "03:50:00", "04:45:00"),
            new ScheduleEntry(DateOnly.Parse("07/03/2025"), "Friday", "Elective V: Sensors and Transducers/Elective VI: Biomedical Instrumentation", "Dr. H", "09:00:00", "09:55:00"),
            new ScheduleEntry(DateOnly.Parse("07/03/2025"), "Friday", "Wireless Communication and Networks", "Dr. C", "09:55:00", "10:50:00"),
            new ScheduleEntry(DateOnly.Parse("07/03/2025"), "Friday", "Microwave Engineering and Optical Communication", "Dr. B", "11:05:00", "12:00:00"),
            new ScheduleEntry(DateOnly.Parse("07/03/2025"), "Friday", "Digital Image Processing", "Dr. A", "12:00:00", "12:55:00"),
            new ScheduleEntry(DateOnly.Parse("07/03/2025"), "Friday", "-", "-", "02:00:00", "02:55:00"),
            new ScheduleEntry(DateOnly.Parse("07/03/2025"), "Friday", "Project Phase I (Project Presentation)", "Dr. F", "02:55:00", "03:50:00"),
            new ScheduleEntry(DateOnly.Parse("07/03/2025"), "Friday", "-", "-", "03:50:00", "04:45:00"),
        };

        // Write to CSV
        using (var writer = new StreamWriter("GeneratedSchedule.csv"))
        {
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(schedule);
            }
        }

        Console.WriteLine("CSV file 'GeneratedSchedule.csv' has been generated successfully!");
    }
}