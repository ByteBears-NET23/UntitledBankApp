using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Views.Ui
{
public class TabContainer : IDisplayable
{
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    public List<Tab> Tabs { get; set; } = new List<Tab>();
    public int SelectedTabIndex { get; set; }

    public ConsoleColor BorderColor { get; set; } = ConsoleColor.Gray;
    public ConsoleColor SelectedTabColor = ConsoleColor.DarkGray;
    public ConsoleColor InactiveTabColor = ConsoleColor.Gray;

    public TabContainer(string name, int width, int height, int left, int top, ConsoleColor backgroundColor)
    {
        Name = name;
        Width = width;
        Height = height;
        Left = left;
        Top = top;
        BackgroundColor = backgroundColor;
    }

    public void AddTab(Tab tab)
    {
        Tabs.Add(tab);
        CalculateTabPositions();
    }

    public void MoveTabRight()
    {
        SelectedTabIndex = (SelectedTabIndex + 1) % Tabs.Count;
        Display();
    }

    public void MoveTabLeft()
    {
        SelectedTabIndex = (SelectedTabIndex - 1 + Tabs.Count) % Tabs.Count;
        Display();
    }

    public void Draw()
    {
        Console.BackgroundColor = BackgroundColor;
        Console.Clear();
        Console.SetCursorPosition(Left, Top);
        Console.BackgroundColor = BackgroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{FrameProperties.TopLeftBorder}{new string(FrameProperties.TopColumnBorder, Width - 2)}{FrameProperties.TopRightBorder}");

        for (int i = 1; i < Height - 1; i++)
        {
            Console.SetCursorPosition(Left, Top + i);
            Console.WriteLine($"{FrameProperties.LeftRowBorder}{new string(' ', Width - 2)}{FrameProperties.RightRowBorder}");
        }

        Console.SetCursorPosition(Left, Top + Height - 1);
        Console.WriteLine($"{FrameProperties.BottomLeftBorder}{new string(FrameProperties.TopColumnBorder, Width - 2)}{FrameProperties.BottomRightBorder}");

        Console.SetCursorPosition(Left + 1, Top - 1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(Name.PadRight(Width - 2));

        Display();
    }

    public void Display()
    {
        DisplayTabs();
        DisplayBoxContent();
    }

    private void DisplayBoxContent()
    {
        Tab selectedTab = Tabs[SelectedTabIndex];
        Console.SetCursorPosition(selectedTab.TextLeft, selectedTab.TextTop);

        Console.ForegroundColor = ConsoleColor.White;

        DisplayContentWithinBox(selectedTab.Text, selectedTab.TextLeft, selectedTab.TextTop, selectedTab.Width, selectedTab.Height);

        Console.ResetColor();
    }

    private void DisplayTabs()
    {
        int tabWidth = (Width - 2) / Tabs.Count;

        for (int i = 0; i < Tabs.Count; i++)
        {
            int tabLeft = Left + 1 + i * tabWidth;
            int tabTop = Top - 1;

            Console.SetCursorPosition(tabLeft, tabTop);

            if (i == SelectedTabIndex)
            {
                Console.BackgroundColor = ConsoleColors.SelectedTab;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColors.InactiveTab;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write($"{Tabs[i].Name.PadRight(tabWidth)}");
        }
    }

    public void CalculateTabPositions()
    {
        int tabWidth = (Width - 2) / Tabs.Count;

        for (int i = 0; i < Tabs.Count; i++)
        {
            int tabLeft = Left + 1 + i * tabWidth;
            int tabTop = Top;

            Tabs[i].Left = tabLeft;
            Tabs[i].Top = tabTop;
            Tabs[i].Width = tabWidth;
            Tabs[i].Height = Height - 1;
        }
    }

    public void DisplayContentWithinBox(object content, int left, int top, int width, int height)
    {
        Console.BackgroundColor = BackgroundColor;
        Console.ForegroundColor = ConsoleColor.White;

        if (content is string)
        {
            string text = content as string;
            int contentWidth = Math.Min(text.Length, width - 2);
            int contentHeight = Math.Min(1, height - 2);

            for (int i = 0; i < contentHeight; i++)
            {
                Console.SetCursorPosition(left + 1, top + i + 1);
                Console.Write(text.Substring(0, contentWidth).PadRight(width - 2));
            }
        }
        else if (content is int || content is double || content is bool || content is char)
        {
            Console.SetCursorPosition(left + 1, top + 1);
            Console.Write(content.ToString().PadRight(width - 2));
        }
        else if (content is Array)
        {
            Array array = content as Array;
            int rows = Math.Min(array.GetLength(0), height - 2);
            int cols = Math.Min(array.GetLength(1), width - 2);

            for (int i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(left + 1, top + i + 1);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array.GetValue(i, j) + " ");
                }
            }
        }
        else if (content is List<object>)
        {
            List<object> list = content as List<object>;
            int rows = Math.Min(list.Count, height - 2);

            for (int i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(left + 1, top + i + 1);
                Console.Write(list[i].ToString().PadRight(width - 2));
            }
        }
        else
        {
            Console.Write("Unknown content type");
        }
    }
}

}
