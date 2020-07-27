using System;
using System.Collections.Generic;
using Assignment_P_V.Helpers;

namespace Assignment_P_V
{
    class Program
    {
        public static void Main(string[] args)
        {
            string createEntityMenuTitle = "Do you want to create your entities?";
            List<string> choices = new List<string>() { "Yes", "No" };
            ConsoleMenuWrapper creationMenuWrapper = new ConsoleMenuWrapper(createEntityMenuTitle, choices);
            if (creationMenuWrapper.Menu.SelectedOption == "Yes")
            {
                bool finished = false;
                while (!finished)
                {
                    string title = "Which Entity do you want to create?";
                    List<string> menuChoices = new List<string>() { "Student", "Trainer", "Course", "Assignment" };
                    ConsoleMenuWrapper menuWrapper = new ConsoleMenuWrapper(title, menuChoices);
                    EntityManager.CreateEntity(menuWrapper.Menu.SelectedOption);
                    string title2 = "Do you want to create another Entity?";
                    List<string> menuChoices2 = new List<string>() { "Yes", "No" };
                    ConsoleMenuWrapper menuWrapper2 = new ConsoleMenuWrapper(title2, menuChoices2);
                    if (menuWrapper2.Menu.SelectedOption == "No")
                    {
                        finished = true;
                    }
                }
            }
            else
            {
                EntityManager.CreateSyntheticData();
            }
        }
    }
}
