using UntitledBankApp.Views.Utilities;

namespace UntitledBankApp.Views;

public class LoginView : View
{
    private SimpleMenu _menu;
    private BoxDrawer _boxDrawer;
    private BoxDrawer _boxDrawerA;

    public LoginView()
    {

        Console.WriteLine(Tital);

        // Initialize menu options
        var menuOptions = new string[] { "Login", "About ", "Exit " };

        // Initialize SimpleMenu
        _menu = new SimpleMenu(menuOptions, top: 22, left: 59);

        // Initialize BoxDrawer
        _boxDrawer = new BoxDrawer(35, 12, top: 14, left: 44);
        _boxDrawerA = new BoxDrawer(60, 19, 10, 32);

    }

    internal string GenerateRandomCaptchaValue()
    {
        Random random = new Random();
        const string chars = "0123456789";
        return new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public (string username, string password, string captcha) GetCredentials()
    {

        //Console.Clear();
        DisplayHeader();
        _boxDrawerA.DrawBox();
        Console.SetCursorPosition(44, 11);
        Console.WriteLine("Use the up and down arrows to select");
        var option = _menu.DisplayMenu();
     
        if (option == 1) // Use == for string comparison
        {
            //Console.Clear();
            DisplayHeader();

            _boxDrawer.DrawBox(); // Use BoxDrawer to draw a box

            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.SetCursorPosition(47, 16);
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.SetCursorPosition(47, 17);
            Console.Write("Password: ");
            var password = GetMaskedInput();

            Console.ResetColor();

            Console.SetCursorPosition(47, 18);
            var captcha = GenerateRandomCaptchaValue();
            Console.WriteLine($"Captcha: {captcha}");

            Console.SetCursorPosition(47, 19);
            Console.Write("Enter Captcha: ");
            var userCaptcha = Console.ReadLine();
            return (username, password, userCaptcha);
        }
        else
        {
            if (option == 2)
            {
                var aboutNames = new string[] { "Adrian Moreno", "Alexander Doja", "Erik Berglund", "Theodor Hägg", "Yarub Adnan" };
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                DisplayAboutNames(aboutNames);
            }
            return ("", "", ""); // Indicate exit option
        }
       
    }

    private string GetMaskedInput()
    {
        var input = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                input += key.KeyChar;
                Console.Write('*');
            }
            else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Substring(0, input.Length - 1);
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        return input;
    }

    protected override void DisplayHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(47, 13);
        Console.WriteLine("Enter your login information");
        Console.ResetColor();
    }

    public void Show()
    {

        //Console.Clear();
        DisplayHeader();
        var selectedOption = _menu.DisplayMenu();
        // Process the selected option as needed
    }

    void DisplayAboutNames(string[] names)
    {

        int boxTop = 10;
        int boxLeft = 55;
        int boxHeight = 6;
        int boxWidth = 35;
        int currentTop = boxTop + boxHeight - 2;

        foreach (var name in names)
        {
            Console.SetCursorPosition(boxLeft + 1, currentTop);
            Console.WriteLine(name);
            currentTop++;
            System.Threading.Thread.Sleep(1000);
        }
        Console.ReadKey();
    }
}