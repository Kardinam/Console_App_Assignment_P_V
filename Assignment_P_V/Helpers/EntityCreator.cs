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
        public static void CreateSyntheticData()
        {
            Student student1 = new Student("Panos", "Varamentis", new DateTime(1991, 10, 10), 2000);
            Student student2 = new Student("Antonis", "Pantelakis", new DateTime(1992, 2, 19), 200);
            Student student3 = new Student("George", "Bouznian", new DateTime(1991, 10, 10), 2000);
            Student student4 = new Student("Kostas", "Vasillis", new DateTime(1996, 3, 21), 45000);
            Students.AddRange(new List<Student>() { student1, student2, student3, student4 });

            Course course1 = new Course("Introduction to Web", "Part-Time", "Yes", new DateTime(2020, 2, 19), new DateTime(2020,7,20));
            Course course2 = new Course("Advanced Web Programming", "Full-Time", "no", new DateTime(2020, 6, 11), new DateTime(2020,6,10));
            Courses.AddRange(new List<Course>() { course1, course2 });

            Assignment assignment1 = new Assignment("Create a Console App", "Application that manages an e-Class", new DateTime(2020, 8, 4), 3000, 3000);
            Assignment assignment2 = new Assignment("Create a Web App", "Create a simple website", new DateTime(2019, 12, 10), 900, 100);
            Assignment assignment3 = new Assignment("Create a Desktop App", "Create a simple desktop App", new DateTime(2020, 7, 24), 70, 100);
            Assignments.AddRange(new List<Assignment>() { assignment1, assignment2, assignment3 });

            Trainer trainer1 = new Trainer("Takis", "Tsoukalas", "Podosfairo");
            Trainer trainer2 = new Trainer("Nikos", "Alefantos", "Podosfairo");
            Trainers.AddRange(new List<Trainer>() { trainer1, trainer2 });

            // Relate students with assignments and Courses
            course1.Students.Add(student1);
            course2.Students.AddRange(new List<Student>() { student2, student3, student1 });

            course1.Trainers.Add(trainer1);
            course2.Trainers.Add(trainer2);

            assignment1.CourseName = course1.Title;
            assignment3.CourseName = course1.Title;
            assignment2.CourseName = course2.Title;

            //assignment1.Assignees.AddRange(new List<Student>() { student1 });
            //assignment3.Assignees.AddRange(new List<Student>() { student1 });
            //assignment2.Assignees.AddRange(new List<Student>() { student2, student3 });

            student1.Assignments.AddRange(new List<Assignment>() { assignment1, assignment3 });
            student2.Assignments.Add(assignment2);
            student3.Assignments.Add(assignment2);
        }
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
                    CreateAssignment();
                    return;
                case EntityTypes.Trainer:
                    CreateTrainer();
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
            Console.WriteLine("Please type the Date of Birth. (dd/mm/yyyy)");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please type the Tuition Fees");
            decimal tuitionFees = Convert.ToDecimal(Console.ReadLine());
            Student newStudent = new Student(firstName, lastName, dateOfBirth, tuitionFees);
            Students.Add(newStudent);
            AddCoursesToStudent(newStudent);
        }
        private static void AddCoursesToStudent(Student newStudent)
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
                AddCoursesToStudent(newStudent);
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
            Console.WriteLine("Please type the Start Date. (dd/mm/yyyy)");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please type the End Date. (dd/mm/yyyy)");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());
            Course newCourse = new Course(title, type, stream, startDate, endDate);
            Courses.Add(newCourse);
        }
        private static void CreateTrainer()
        {
            Console.WriteLine("Please type the First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please type the last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please type the Subject");
            string subject = Console.ReadLine();
            Trainer newTrainer = new Trainer(firstName, lastName, subject);
            Trainers.Add(newTrainer);
            AddTrainersToCourse(newTrainer);
        }
        private static void AddTrainersToCourse(Trainer newTrainer)
        {
            Console.WriteLine("Please type a Course Name that the Trainer Belongs to");
            string courseName = Console.ReadLine();
            Course existingCourse = Courses.Find(course => course.Title == courseName);
            if (existingCourse != null)
            {
                existingCourse.Trainers.Add(newTrainer);
            }
            else
            {
                Console.WriteLine("Course Not Found");
            }
            Console.WriteLine("Do you want to type another course? (y/n)");
            string res = Console.ReadLine();
            if (res == "y")
            {
                AddTrainersToCourse(newTrainer);
            }
            else
            {
                return;
            }
        }
        private static void CreateAssignment()
        {
            Console.WriteLine("Please type the Title");
            string title = Console.ReadLine();
            Console.WriteLine("Please type the Description");
            string description = Console.ReadLine();
            Console.WriteLine("Please type the Subscription Date. (dd/mm/yyyy)");
            DateTime subDateTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please type the Oral Mark");
            int oralMark = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please type the Total Mark");
            int totalMark = Convert.ToInt32(Console.ReadLine());

            Assignment newAssignment = new Assignment(title, description, subDateTime, oralMark, totalMark);

            Assignments.Add(newAssignment);
            AddCourseToAssignment(newAssignment);
            AddStudentsToAssignment(newAssignment);
        }
        private static void AddCourseToAssignment(Assignment newAssignment)
        {
            Console.WriteLine("Please type the Course name that the Assignment belongs to");
            string courseName = Console.ReadLine();
            Course existingCourse = Courses.Find(course => course.Title == courseName);
            if (existingCourse == null)
            {
                Console.WriteLine($"Course with name {courseName} was not found. Please type another course name.");
                AddCourseToAssignment(newAssignment);
            }
            return;
        }
        private static void AddStudentsToAssignment(Assignment newAssignment)
        {
            Console.WriteLine("Please type a student Full Name has to submit this assignment");
            string studentName = Console.ReadLine();
            string[] nameArr = studentName.Split(' ');
            Student existingStudent = Students.Find(student => student.FirstName == nameArr[0] && student.LastName == nameArr[1]);
            if (existingStudent != null)
            {
                //newAssignment.Assignees.Add(existingStudent);
                existingStudent.Assignments.Add(newAssignment);
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
            Console.WriteLine("Do you want to type another student to this assignment? (y/n)");
            string res = Console.ReadLine();
            if (res == "y")
            {
                AddStudentsToAssignment(newAssignment);
            }
            else
            {
                return;
            }
        }
    }
}
