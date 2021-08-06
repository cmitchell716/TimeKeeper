using System;
using System.Collections.Generic;
using System.Text;

namespace TimeKeepers.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<Timecard> Records { get; set; }

        public double GetHours(DateTime start, DateTime end)
        {
            double hours = 0.0;
            foreach (var record in Records)
            {
                if (record.Start >= start && record.Start <= end)
                    hours += record.Hours;
            }
            return hours;
        }
    }
}
