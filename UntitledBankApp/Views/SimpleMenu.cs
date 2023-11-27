using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views
{
    public class SimpleMenu
    {
        private readonly string[] _options;
        private readonly int _top;
        private readonly int _left;

        public SimpleMenu(string[] options, int top, int left)
        {
            _options = options;
            _top = top;
            _left = left;
        }

        public int DisplayMenu()
        {
            Console.CursorVisible = false;

            int selectedIndex = 0;

            ConsoleKey key;
            do
            {
                for (int i = 0; i < _options.Length; i++)
                {
                    Console.SetCursorPosition(_left, _top + i);

                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine($"{_options[i]}");

                    Console.ResetColor();
                }

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = Math.Max(0, selectedIndex - 1);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = Math.Min(_options.Length - 1, selectedIndex + 1);
                }
                else if (key == ConsoleKey.Enter)
                {
                    return selectedIndex + 1; // 1-based index to represent user choice
                }
            } while (key != ConsoleKey.Escape);

            return 0; // Default value, indicating no valid selection
        }
    }

}
