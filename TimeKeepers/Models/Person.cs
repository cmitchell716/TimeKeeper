using System;
using System.Collections.Generic;
using System.Text;

namespace TimeKeepers.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsPike { get; set; } 
        public virtual ICollection<Timecard> Records { get; set; }

        public double GetHours(DateTime start, DateTime end)
        {
            double hours = 0.0;
            foreach (var record in Records)
            {
                if (record.Start.Date >= start.Date && record.Start.Date <= end.Date)
                    hours += record.Hours;
            }
            return hours;
        }
    }
}
