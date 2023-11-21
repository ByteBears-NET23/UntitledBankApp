using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views.Ui
{
    public class DropdownMenu
    {
        private string[] options;
        private int selectedOptionIndex;
        private int left;
        private int top;

        public DropdownMenu(string[] options, int left, int top)
        {
            this.options = options;
            this.selectedOptionIndex = 0;
            this.left = left;
            this.top = top;
        }

        public void MoveSelectionUp()
        {
            selectedOptionIndex = (selectedOptionIndex - 1 + options.Length) % options.Length;
        }

        public void MoveSelectionDown()
        {

            selectedOptionIndex = (selectedOptionIndex + 1) % options.Length;
        }

        public void Display()
        {
            //Console.Clear(); // Clear the console before displaying the menu

            Console.ResetColor();

            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(left, top + i);
                if (i == selectedOptionIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();
            }

            Console.SetCursorPosition(left, top + options.Length);
        }
        public string GetSelectedOption()
        {
            return options[selectedOptionIndex];
        }
    }
}
