using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views.Ui
{
    public class Application
    {
        private Box myBox;
        private DropdownMenu dropdownMenu;

        public Application()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            myBox = new Box { Width = 117, Height = 22, Left = 2, Top = 8 };

            string[] menuOptions = { "Login", "Exit " };
            dropdownMenu = new DropdownMenu(menuOptions, myBox.Width / 2, myBox.Top + 10);
        }

        public void Run()
        {
            Console.CursorVisible = false;

            myBox.Draw(); // Move the box drawing code outside the loop

            do
            {
                dropdownMenu.Display();

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        dropdownMenu.MoveSelectionDown();
                        break;
                    case ConsoleKey.UpArrow:
                        dropdownMenu.MoveSelectionUp();
                        break;
                    case ConsoleKey.Enter:
                        HandleEnterKey();
                        break;
                }

            } while (true);
        }

        private void HandleEnterKey()
        {
            //if (selectedOption == "Exit")
            //{
            //    Environment.Exit(0);
            //}

            string selectedOption = dropdownMenu.GetSelectedOption();

            switch (selectedOption)
            {
                case "Login":
                    HandleLoginOption();
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
                default:
                    // Handle other options if needed
                    break;
            }
        }

        private void HandleLoginOption()
        {
            // Add your login logic here
            //Console.Clear();
            Console.WriteLine("Login selected. Logging in...");
            // ...
            Console.ReadLine();
        }
    }

}
