using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableScheduler.Model
{
    public class ScheduleEntry
    {
        public DateOnly Date { get; set; }
        public string Day { get; set; }
        public string Subject { get; set; }
        public string Faculty { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public ScheduleEntry(DateOnly Date, string Day, string Subject, string Faculty, string StartTime, string EndTime)
        {
            this.Date = Date;
            this.Day = Day;
            this.Subject = Subject;
            this.Faculty = Faculty;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}
