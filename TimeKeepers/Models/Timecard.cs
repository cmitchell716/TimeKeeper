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
        public bool Done { get; set; } 
        public string Id { get; set; }
        public virtual Person Person { get; set; }

       public void Begin()
        {
            Start = DateTime.Now;
            Done = false;
        }

        public void Close()
        {
            End = DateTime.Now;
            Hours = End.Subtract(Start).TotalHours;
            Done = true;
        }
        public override string ToString()
        {
            if (Done)
                return $"Date: {Start.Date.ToString().Substring(0,9)} Hours: {Hours}\n";
            else return "";
        }
    }
}
