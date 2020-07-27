using System;
using System.Collections.Generic;

namespace Assignment_P_V.Models
{
    public class Assignment
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubDateTime { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }
        public string CourseName { get; set; }

        public Assignment(string title, string description, DateTime subDateTime, int oralMark, int totalMark)
        {
            Title = title;
            Description = description;
            SubDateTime = subDateTime;
            OralMark = oralMark;
            TotalMark = totalMark;
        }

    }
}
