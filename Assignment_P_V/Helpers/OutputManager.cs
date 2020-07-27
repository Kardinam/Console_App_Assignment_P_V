using Assignment_P_V.Models;
using Bam.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_P_V.Helpers
{
    public static class OutputManager
    {
        public static void Initialize()
        {
            string title = "Choose your output option";
            string[] menuChoices = new string[] {
            OutputChoices.AllStudents,
            OutputChoices.AllTrainers,
            OutputChoices.AllAssignments,
            OutputChoices.AllCourses,
            OutputChoices.StudentsPerCourse,
            OutputChoices.TrainersPerCourse,
            OutputChoices.AssignmentsPerCourse,
            OutputChoices.AssignmentsPerStudent,
            OutputChoices.StudentsInMoreThatOneCourse,
            OutputChoices.PendingAssignments,
            OutputChoices.ClearConsole
            };
            ConsoleMenuWrapper menuWrapper = new ConsoleMenuWrapper(title, menuChoices);
            InputHandler(menuWrapper.Menu.SelectedOption);
        }
        private static void InputHandler(string choice)
        {
            ConsoleMenuWrapper menuWrapper;
            Course selectedCourse;
            Student existingStudent;
            string fullName;
            string firstName;
            string lastName;
            switch (choice)
            {
                case OutputChoices.ClearConsole:
                    Console.Clear();
                    return;
                case OutputChoices.AllStudents:
                    EntityManager.Students.ForEach(student => PrintObject(student));
                    return;
                case OutputChoices.AllCourses:
                    EntityManager.Courses.ForEach(course => PrintObject(course));
                    return;
                case OutputChoices.AllTrainers:
                    EntityManager.Trainers.ForEach(trainer => PrintObject(trainer));
                    return;
                case OutputChoices.AllAssignments:
                    EntityManager.Assignments.ForEach(assignment => PrintObject(assignment));
                    return;
                case OutputChoices.StudentsPerCourse:
                    menuWrapper = new ConsoleMenuWrapper(null, EntityManager.Courses.Select(course => course.Title));
                    selectedCourse = EntityManager.Courses.Find(course => course.Title == menuWrapper.Menu.SelectedOption);
                    selectedCourse.Students.ForEach(student => PrintObject(student));
                    return;
                case OutputChoices.TrainersPerCourse:
                    menuWrapper = new ConsoleMenuWrapper(null, EntityManager.Courses.Select(course => course.Title));
                    selectedCourse = EntityManager.Courses.Find(course => course.Title == menuWrapper.Menu.SelectedOption);
                    selectedCourse.Trainers.ForEach(trainer => PrintObject(trainer));
                    return;
                case OutputChoices.AssignmentsPerCourse:
                    menuWrapper = new ConsoleMenuWrapper(null, EntityManager.Courses.Select(course => course.Title));
                    IEnumerable<Assignment> assignements = EntityManager.Assignments.Where(assignment => assignment.CourseName == menuWrapper.Menu.SelectedOption);
                    assignements.ToList().ForEach(assignment => PrintObject(assignment));
                    return;
                case OutputChoices.AssignmentsPerStudent:
                    menuWrapper = new ConsoleMenuWrapper(null, EntityManager.Students.Select(student => $"{student.FirstName} {student.LastName}"));
                    fullName = menuWrapper.Menu.SelectedOption;
                    firstName = fullName.Split(' ')[0];
                    lastName = fullName.Split(' ')[1];
                    existingStudent = EntityManager.Students.Find(student => student.FirstName == firstName && student.LastName == lastName);
                    existingStudent.Assignments.ForEach(assignment => PrintObject(assignment));
                    return;
                case OutputChoices.StudentsInMoreThatOneCourse:
                    List<Student> mergedStudentsPerCourse = new List<Student>();
                    foreach (Course course in EntityManager.Courses)
                    {
                        foreach (Student student in course.Students)
                        {
                            mergedStudentsPerCourse.Add(student);
                        }
                    }
                    var duplicates = mergedStudentsPerCourse.GroupBy(student => $"{student.FirstName} {student.LastName}").Where(g => g.Count() > 1);
                    duplicates.ToList().ForEach(student => PrintObject(student));
                    return;
                case OutputChoices.PendingAssignments:
                    Console.WriteLine("Please type the Date of the Calendar week you wish to search for. (dd/mm/yyyy)");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    int dayOfWeek = (int)date.DayOfWeek;
                    DateTime maxDate = date;
                    DateTime minDate = date;
                    while (maxDate.DayOfWeek != DayOfWeek.Friday)
                    {
                        if (maxDate.DayOfWeek == DayOfWeek.Saturday || maxDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            maxDate = maxDate.AddDays(-1);
                        }
                        else
                        {
                            maxDate = maxDate.AddDays(1);
                        }
                    }
                    while (minDate.DayOfWeek != DayOfWeek.Monday)
                    {
                        minDate = minDate.AddDays(-1);
                    }
                    List<Student> studentsWithPendingAssignments = new List<Student>();
                    foreach (Student student in EntityManager.Students)
                    {
                        foreach (Assignment assignment in student.Assignments)
                        {
                            if (assignment.SubDateTime > minDate && assignment.SubDateTime < maxDate)
                            {
                                studentsWithPendingAssignments.Add(student);
                                break;
                            }
                        }
                    }
                    studentsWithPendingAssignments.ForEach(student => PrintObject(student));
                    return;
            }
        }
        private static void PrintObject(Object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.MaxDepth = 1;
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            Console.Write(jsonString);
        }
    }
}
