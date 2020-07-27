using System;
using System.Collections.Generic;

namespace Assignment_P_V.Models
{
    public class Course
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Stream { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Student> Students { get; set; }
        public List<Trainer> Trainers { get; set; }
        public Course(string title, string type, string stream, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Type = type;
            Stream = stream;
            StartDate = startDate;
            EndDate = endDate;
            Students = new List<Student>();
            Trainers = new List<Trainer>();
        }
    }

}
