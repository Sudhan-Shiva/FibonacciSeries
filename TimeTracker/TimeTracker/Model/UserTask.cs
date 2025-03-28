﻿using System.Diagnostics;
using CsvHelper.Configuration.Attributes;

namespace TimeTracker.Model
{
    public class UserTask
    {
        public string Heading { get; set; }
        public string? Description { get; set; }
        public Dictionary<string, string> TimeIntervals { get; set; }
        public UserTaskStatus Status { get; set; }
        public TimeSpan? TimeExecuted { get; set; } = TimeSpan.Zero;
    }
}
