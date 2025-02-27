using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using TimeTableScheduler.Model;
using ConsoleTables;

namespace TimeTableScheduler.Utility
{
    internal class TimeTableManager
    {
        List<string> subjects = new List<string> { "Digital Image Processing", "Microwave Engineering and Optical Communication", "Wireless Communication and Networks", "Library", "Wireless Communication and Networking Laboratory/High Frequency Laboratory", "Project Phase I", "P.Ed", "Elective V: Sensors and Transducers/Elective VI: Biomedical Instrumentation", "Elective V: Sensors and Transducers", "Elective VI: Biomedical Instrumentation", "Project Phase I (Project Presentation)" };
        public void ViewTimeTable()
        {
            Console.WriteLine("\nOpening the timetable...");

            List<ScheduleEntry> scheduleEntries;
            using (var streamReader = new StreamReader("GeneratedSchedule.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    scheduleEntries = csvReader.GetRecords<ScheduleEntry>().ToList();
                }
            }

            ConsoleTable.From(scheduleEntries).Write();
        }

        public void GenerateNextWeekTimeTable()
        {
            Console.WriteLine("\nGenerating next week's timetable...");
            List<ScheduleEntry> scheduleEntries;
            using (var streamReader = new StreamReader("GeneratedSchedule.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    scheduleEntries = csvReader.GetRecords<ScheduleEntry>().ToList();
                }
            }

            scheduleEntries.ForEach(entry => entry.Date = entry.Date.AddDays(7));

            using (var streamWriter = new StreamWriter("GeneratedSchedule.csv"))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(scheduleEntries);
                }
            }

            Console.WriteLine("\nNext week's timetable has been generated successfully!");
            ViewTimeTable();
        }

        public void TimeTableModifier()
        {
            Console.Write("Provide the Date to be modified : ");
            var modifyingDate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("[0] 09:00:00"
                              +"[1] 09:55:00"
                              +"[2] 10:50:00"
                              +"[3] 11:05:00"
                              +"[4] 12:00:00"
                              +"[5] 12:55:00"
                              +"[6] 02:00:00"
                              +"[7] 02:55:00"
                              +"[8] 03:50:00");
            Console.Write("Provide the Start Time of the period to be modified : ");
            var modifyingPeriodNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("[0] Digital Image Processing"
                                + "[1] Microwave Engineering and Optical Communication"
                                + "[2] Wireless Communication and Networks"
                                + "[3] Library"
                                + "[4] Wireless Communication and Networking Laboratory/High Frequency Laboratory"
                                + "[5] Project Phase I"
                                + "[6] P.Ed"
                                + "[7] Elective V: Sensors and Transducers/Elective VI: Biomedical Instrumentation"
                                + "[8] Elective V: Sensors and Transducers"
                                + "[9] Elective VI: Biomedical Instrumentation"
                                + "[10] Project Phase I (Project Presentation)");
            var modifyingSubject = int.Parse(Console.ReadLine());
            Console.Write("Provide the Subject : ");
            List<ScheduleEntry> scheduleEntries;
            using (var streamReader = new StreamReader("GeneratedSchedule.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    scheduleEntries = csvReader.GetRecords<ScheduleEntry>().ToList();
                }
            }
            
        }
    }
}
