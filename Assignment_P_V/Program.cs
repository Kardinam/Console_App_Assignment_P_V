using System;
using System.Collections.Generic;
using Assignment_P_V.Helpers;

namespace Assignment_P_V
{
    class Program
    {
        public static void Main(string[] args)
        {
            string title = "Which Entity do you want to create?";
            List<string> menuChoices = new List<string>() {"Student", "Trainer", "Course", "Assignment"};
            ConsoleMenuWrapper menuWrapper = new ConsoleMenuWrapper(title, menuChoices);
            EntityCreator.CreateEntity(menuWrapper.Menu.SelectedOption);
            Console.ReadKey();
        }
    }
}
