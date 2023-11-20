using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views.Ui
{
    public class RunUi
    {
        public void Run()
        {
 Console.OutputEncoding = System.Text.Encoding.UTF8;
        TabContainer myBox = new TabContainer("My Bank App", 116, 20, 2, 8, ConsoleColors.Background);
        myBox.BorderColor = ConsoleColors.Border;

        Tab tab1 = new Tab("Main Menu", 28, 13, ConsoleColors.InactiveTab);
        tab1.Text = @"
";

        tab1.TextLeft = 25;
        tab1.TextTop = 2;
        myBox.AddTab(tab1);

        Menu myMenu = new Menu("", 20, 5, 53, 12, ConsoleColors.Background);
        myMenu.AddItem("Login");
        myMenu.AddItem("Exit");

        myBox.Draw();
        myMenu.Draw();

        myBox.MoveTabRight();
        myBox.Draw();

        myMenu.MoveItemDown();
        myMenu.Draw();

        do
        {
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    myBox.MoveTabRight();
                    myBox.Draw();
                    break;
                case ConsoleKey.LeftArrow:
                    myBox.MoveTabLeft();
                    myBox.Draw();
                    break;
                case ConsoleKey.DownArrow:
                    myMenu.MoveItemDown();
                    myMenu.Draw();
                    break;
                case ConsoleKey.UpArrow:
                    myMenu.MoveItemUp();
                    myMenu.Draw();
                    break;
                case ConsoleKey.Enter:
                    switch (myMenu.SelectedItemIndex)
                    {
                        case 0:
                            Tab newTab = new Tab("Login", 28, 13, ConsoleColors.InactiveTab);
                            newTab.Text = "log in";
                            newTab.TextLeft = 25;
                            newTab.TextTop = 15;
                            myBox.AddTab(newTab);
                            myBox.SelectedTabIndex = myBox.Tabs.Count - 1;
                            myBox.CalculateTabPositions();
                            myBox.Draw();
                            break;
                        case 1:
                            Console.SetCursorPosition(45, 5);
                            Console.WriteLine("Selected: About. Implement this functionality.");
                            break;
                        case 2:
                            Console.WriteLine("Selected: Exit. Implement this functionality.");
                            break;
                    }
                    break;
            }

        } while (true);
        }
    }
}
