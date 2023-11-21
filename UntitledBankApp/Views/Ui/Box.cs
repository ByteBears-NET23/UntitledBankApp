using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views.Ui
{
    public class Box
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }

        public void Draw()
        {
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine($"{FrameProperties.TopLeftBorder}{new string(FrameProperties.TopColumnBorder, Width - 2)}{FrameProperties.TopRightBorder}");

            for (int i = 1; i < Height - 1; i++)
            {
                Console.SetCursorPosition(Left, Top + i);
                Console.WriteLine($"{FrameProperties.LeftRowBorder}{new string(' ', Width - 2)}{FrameProperties.LeftRowBorder}");
            }

            Console.SetCursorPosition(Left, Top + Height - 1);
            Console.WriteLine($"{FrameProperties.BottomLeftBorder}{new string(FrameProperties.TopColumnBorder, Width - 2)}{FrameProperties.BottomRightBorder}");
        }
    }
}
