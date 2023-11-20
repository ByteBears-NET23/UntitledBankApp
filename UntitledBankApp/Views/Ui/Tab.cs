using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views.Ui
{
public class Tab : IDisplayable
{
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    public List<object> Contents { get; set; } = new List<object>();

    public string Text { get; set; } = "";
    public int TextLeft { get; set; }
    public int TextTop { get; set; }

    public Tab(string name, int width, int height, ConsoleColor backgroundColor)
    {
        Name = name;
        Width = width;
        Height = height;
        BackgroundColor = backgroundColor;
    }

    public void Display()
    {
        Console.WriteLine($"Displaying Tab: {Name}");
    }
}

}
