namespace UntitledBankApp.Views;

public abstract class View
{
    private bool _returnToLoginView;

    public bool ReturnToLoginView => _returnToLoginView;

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
    public bool ConfirmLogout()
    {
        Console.SetCursorPosition(44, 14);
        Console.Write("Do you want to return to LoginView? (Y/N): ");
        var key = Console.ReadKey().Key;
        _returnToLoginView = key == ConsoleKey.Y;
        return _returnToLoginView;
    }

}