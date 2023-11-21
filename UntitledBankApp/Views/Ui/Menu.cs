using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views.Ui
{
    public class Menu : IDisplayable
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public FrameProperties Frame { get; set; } = new FrameProperties();
        public List<string> Items { get; set; } = new List<string>();
        public int SelectedItemIndex { get; set; }

        public ConsoleColor BorderColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor SelectedTabColor = ConsoleColor.DarkGray;
        public ConsoleColor InactiveTabColor = ConsoleColor.Gray;

        public Menu(string name, int width, int height, int left, int top, ConsoleColor backgroundColor)
        {
            Name = name;
            Width = width;
            Height = height;
            Left = left;
            Top = top;
            BackgroundColor = backgroundColor;
        }

        public void AddItem(string item)
        {
            Items.Add(item);
        }

        public void MoveItemUp()
        {
            SelectedItemIndex = (SelectedItemIndex - 1 + Items.Count) % Items.Count;
            Display();
        }

        public void MoveItemDown()
        {
            SelectedItemIndex = (SelectedItemIndex + 1) % Items.Count;
            Display();
        }

        public void Draw()
        {
            Console.BackgroundColor = BackgroundColor;
            Console.Clear();
            Console.SetCursorPosition(Left, Top);
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ConsoleColor.White;

            // إضافة شعار البنك أعلى الإطار
            Console.WriteLine($"{FrameProperties.TopLeftBorder}{new string(FrameProperties.TopColumnBorder, Width - 2)}{FrameProperties.TopRightBorder}");
            Console.SetCursorPosition(Console.WindowWidth / 2, 2);
            var Edugrade = @"


                               ███████╗██████╗ ██╗   ██╗    ██████╗  █████╗ ███╗   ██╗██╗  ██╗
                               ██╔════╝██╔══██╗██║   ██║    ██╔══██╗██╔══██╗████╗  ██║██║ ██╔╝
                               █████╗  ██║  ██║██║   ██║    ██████╔╝███████║██╔██╗ ██║█████╔╝ 
                               ██╔══╝  ██║  ██║██║   ██║    ██╔══██╗██╔══██║██║╚██╗██║██╔═██╗ 
                               ███████╗██████╔╝╚██████╔╝    ██████╔╝██║  ██║██║ ╚████║██║  ██╗
                               ╚══════╝╚═════╝  ╚═════╝     ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝


";

            Console.WriteLine($"{$"{Edugrade}".PadRight(Width - 4)}");

            for (int i = 2; i < Height - 1; i++)
            {
                Console.SetCursorPosition(Left, Top + i);
                Console.WriteLine($"{FrameProperties.LeftRowBorder}{new string(' ', Width - 2)}{FrameProperties.RightRowBorder}");
            }

            Console.SetCursorPosition(Left, Top + Height - 1);
            Console.WriteLine($"{FrameProperties.BottomLeftBorder}{new string(FrameProperties.TopColumnBorder, Width - 2)}{FrameProperties.BottomRightBorder}");

            Console.SetCursorPosition(Left + 1, Top + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Name.PadRight(Width - 2));

            Display();
        }

        public void Display()
        {
            DisplayItems();
        }

        private void DisplayItems()
        {
            int itemWidth = Width - 2;
            int itemHeight = (Height - 2) / Items.Count;

            for (int i = 0; i < Items.Count; i++)
            {
                int itemLeft = Left + 1;
                int itemTop = Top + 1 + i * itemHeight;

                Console.SetCursorPosition(itemLeft, itemTop);
                if (i == SelectedItemIndex)
                {
                    Console.BackgroundColor = SelectedTabColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = InactiveTabColor;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write($"{Items[i].PadRight(itemWidth)}");
            }
        }
    }

}
