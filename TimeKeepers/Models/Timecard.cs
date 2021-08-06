using System;
using System.Collections.Generic;
using System.Text;

namespace TimeKeepers.Models
{
    public class Timecard
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Hours { get; set; }

       public void Begin()
        {
            Start = DateTime.Now;
        }

        public void Close()
        {
            End = DateTime.Now;
            Hours = End.Subtract(Start).TotalHours;
        }
    }
}
