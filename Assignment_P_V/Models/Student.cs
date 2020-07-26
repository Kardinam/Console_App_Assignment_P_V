using System;

namespace Assignment_P_V.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal  Fees { get; set; }

        public Student(string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Fees = tuitionFees;
        }
    }
}
