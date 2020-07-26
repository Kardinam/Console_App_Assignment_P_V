using System;
using System.Collections.Generic;
using System.Linq;
namespace Assignment_P_V.Helpers
{
    //  logic for selecting specific option
    public class Menu
    {
        public Menu(IEnumerable<string> items)
        {
            Items = items.ToArray();
        }


        public IReadOnlyList<string> Items { get; }

        public int SelectedIndex { get; private set; } = -1; // nothing selected

        public string SelectedOption => SelectedIndex != -1 ? Items[SelectedIndex] : null;


        public void MoveUp() => SelectedIndex = Math.Max(SelectedIndex - 1, 0);

        public void MoveDown() => SelectedIndex = Math.Min(SelectedIndex + 1, Items.Count - 1);
    }


    // logic for drawing menu list
    public class ConsoleMenuPainter
    {
        readonly Menu menu;

        public ConsoleMenuPainter(Menu menu)
        {
            this.menu = menu;
        }

        public void Paint(int x, int y)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);

                var color = menu.SelectedIndex == i ? ConsoleColor.Yellow : ConsoleColor.Gray;

                Console.ForegroundColor = color;
                Console.WriteLine(menu.Items[i]);
            }
        }
    }

    public class ConsoleMenuWrapper
    {
        public Menu Menu { get; set; }
        public ConsoleMenuPainter MenuPainter { get; set; }
        public ConsoleMenuWrapper(string title, IEnumerable<string> menuChoices)
        {
            Console.WriteLine(title);
            Menu = new Menu(menuChoices);
            MenuPainter = new ConsoleMenuPainter(Menu);

            bool done = false;

            do
            {
                MenuPainter.Paint(8, 5);

                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: Menu.MoveUp(); break;
                    case ConsoleKey.DownArrow: Menu.MoveDown(); break;
                    case ConsoleKey.Enter: done = true; break;
                }
            }
            while (!done);

        }
    }

}