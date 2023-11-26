namespace UntitledBankApp.Views;

public abstract class View
{
   
    public string Tital = @"

                                ╔══════════════════════════════════════════════════════════╗
                                ║███╗   ███╗██╗   ██╗    ██████╗  █████╗ ███╗   ██╗██╗  ██╗║
                                ║████╗ ████║╚██╗ ██╔╝    ██╔══██╗██╔══██╗████╗  ██║██║ ██╔╝║
                                ║██╔████╔██║ ╚████╔╝     ██████╔╝███████║██╔██╗ ██║█████╔╝ ║
                                ║██║╚██╔╝██║  ╚██╔╝      ██╔══██╗██╔══██║██║╚██╗██║██╔═██╗ ║
                                ║██║ ╚═╝ ██║   ██║       ██████╔╝██║  ██║██║ ╚████║██║  ██╗║
                                ║╚═╝     ╚═╝   ╚═╝       ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝║
                                ╚══════════════════════════════════════════════════════════╝
";
    private readonly BoxDrawer _boxDrawer = new BoxDrawer(60, 19, 10, 32);
    protected abstract void DisplayHeader();
    public void ShowMessage(string message, ConsoleColor color, int left = 0, int top = 0)
    {

        _boxDrawer.DrawBox();
        Console.SetCursorPosition(left, top);
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
    
}