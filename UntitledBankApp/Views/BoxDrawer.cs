using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views
{
    public class BoxDrawer
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _top;
        private readonly int _left;

        public BoxDrawer(int width, int height, int top, int left)
        {
            _width = width;
            _height = height;
            _top = top;
            _left = left;
        }

        public void DrawBox()
        {
            Console.SetCursorPosition(_left, _top);
            Console.WriteLine("╔" + new string('═', _width - 2) + "╗");

            for (int i = 1; i < _height - 1; i++)
            {
                Console.SetCursorPosition(_left, _top + i);
                Console.WriteLine("║" + new string(' ', _width - 2) + "║");
            }

            Console.SetCursorPosition(_left, _top + _height - 1);
            Console.WriteLine("╚" + new string('═', _width - 2) + "╝");
        }
    }

}
