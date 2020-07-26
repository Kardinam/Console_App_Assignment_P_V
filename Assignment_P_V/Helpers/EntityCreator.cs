using System;
using System.Collections.Generic;
using Assignment_P_V.Models;

namespace Assignment_P_V.Helpers
{
    public static class EntityManager
    {
        public static List<Student> Students = new List<Student>();
        public static List<Course> Courses = new List<Course>();
        public static List<Assignment> Assignments = new List<Assignment>();
        public static List<Trainer> Trainers = new List<Trainer>();

        public static void CreateEntity(string entityType)
        {
            switch (entityType)
            {
                case EntityTypes.Student:
                    CreateStudent();
                    return;
                case EntityTypes.Course:
                    CreateCourse();
                    return;
                case EntityTypes.Assignment:
                    Console.WriteLine("You chose to create an assignment");
                    return;
                case EntityTypes.Trainer:
                    Console.WriteLine("You chose to create a trainer");
                    return;
            }
            Console.Write(Courses);
        }

        private static void CreateStudent()
        {
            Console.WriteLine("Please type the First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please type the last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please type the Date of Birth");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please type the Tuition Fees");
            decimal tuitionFees = Convert.ToDecimal(Console.ReadLine());
            Student newStudent = new Student(firstName, lastName, dateOfBirth, tuitionFees);
            Students.Add(newStudent);
            addCourseToStudent(newStudent);
        }
        private static void addCourseToStudent(Student newStudent)
        {
            Console.WriteLine("Please type a Course that the Student Belongs to");
            string courseName = Console.ReadLine();
            Course existingCourse = Courses.Find(course => course.Title == courseName);
            if (existingCourse != null)
            {
                existingCourse.Students.Add(newStudent);
            }
            else
            {
                Console.WriteLine("Course Not Found");
            }
            Console.WriteLine("Do you want to type another course? (y/n)");
            string res = Console.ReadLine();
            if (res == "y")
            {
                addCourseToStudent(newStudent);
            }
            else
            {
                return;
            }
        }
        private static void CreateCourse()
        {
            Console.WriteLine("Please type the Title");
            string title = Console.ReadLine();
            Console.WriteLine("Please type the Type");
            string type = Console.ReadLine();
            Console.WriteLine("Please type the Stream");
            string stream = Console.ReadLine();
            Console.WriteLine("Please type the Start Date");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please type the End Date");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());
            Course newCourse = new Course(title, type, stream, startDate, endDate);
            Courses.Add(newCourse);
        }
    }
}
