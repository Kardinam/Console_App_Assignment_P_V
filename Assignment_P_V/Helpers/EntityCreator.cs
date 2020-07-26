using System;
using Assignment_P_V.Models;

namespace Assignment_P_V.Helpers
{
    public static class EntityCreator
    {
        public static void CreateEntity(string entityType)
        {
            switch (entityType)
            {
                case EntityTypes.Student:
                    Console.WriteLine("You chose to create a student");
                    return;
                case EntityTypes.Course:
                    Console.WriteLine("You chose to create a course");
                    return;
                case EntityTypes.Assignment:
                    Console.WriteLine("You chose to create an assignment");
                    return;
                case EntityTypes.Trainer:
                    Console.WriteLine("You chose to create a trainer");
                    return;
            }
        }
    }
}
