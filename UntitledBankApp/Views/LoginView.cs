namespace UntitledBankApp.Views;

public class LoginView : View
{
    private SimpleMenu _menu;
    private BoxDrawer _boxDrawer;
    private BoxDrawer _boxDrawerA;

    private int loginAttempts = 3; //

    public LoginView()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(Tital);

        // Initialize menu options
        var menuOptions = new string[] { "» Login", "» About", "» Exit " };

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
        DisplayHeader();
        _boxDrawerA.DrawBox();
        Console.SetCursorPosition(44, 11);
        Console.WriteLine("Use the up and down arrows to select");

        var option = _menu.DisplayMenu();

        if (option == 1)
        {
            return GetLoginCredentials();
        }
        else if (option == 2)
        {
            DisplayAbout();
            return ("", "", ""); // Indicate exit option
        }
        else
        {
            Environment.Exit(0);
            return ("", "", ""); // Indicate exit option
        }
    }

    private (string username, string password, string captcha) GetLoginCredentials()
    {
        DisplayHeader();
        _boxDrawer.DrawBox(); // Use BoxDrawer to draw a box

        Console.BackgroundColor = ConsoleColor.DarkRed;

        //Console.SetCursorPosition(47, 16);
        SetCursorPositionAndWrite(47, 16,"Username: ");
        var username = Console.ReadLine();

        //Console.SetCursorPosition(47, 17);
        SetCursorPositionAndWrite(47, 17,"Password: ");
        var password = GetMaskedInput();

        Console.ResetColor();

        //Console.SetCursorPosition(47, 18);
        var captcha = GenerateRandomCaptchaValue();
        SetCursorPositionAndWrite(47, 18,$"Captcha: {captcha}");

        //Console.SetCursorPosition(47, 19);
        SetCursorPositionAndWrite(47, 19,"Enter Captcha: ");
        var userCaptcha = Console.ReadLine();

        if (userCaptcha != captcha)
        {
            //Console.SetCursorPosition(47, 20);
            SetCursorPositionAndWrite(47, 20,"Invalid Captcha. Login failed.");
            Console.ReadKey();
            return ("", "", "");
        }

        if (!IsValidLogin(username, EncryptPassword(password)))
        {
            loginAttempts--;

            if (loginAttempts <= 0)
            {
                //Console.SetCursorPosition();
                SetCursorPositionAndWrite(47, 20,"Login attempts exceeded. Exiting.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            //Console.SetCursorPosition(47, 20);
            SetCursorPositionAndWrite(47, 20,$"Invalid login. Remaining attempts: {loginAttempts}");
            Console.ReadKey();
            return ("", "", "");
        }

        return (username, password, userCaptcha);
    }

    private bool IsValidLogin(string username, string encryptedPassword)
    {
       
        return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(encryptedPassword);
    }

    private string EncryptPassword(string password)
    {
        //XOR
        
        char[] passwordChars = password.ToCharArray();
        for (int i = 0; i < passwordChars.Length; i++)
        {
            passwordChars[i] = (char)(passwordChars[i] ^ 'X');
        }
        return new string(passwordChars);
    }

    private void DisplayAbout()
    {
        var aboutNames = new string[] { "Adrian Moreno", "Alexander Doja", "Erik Berglund", "Theodor Hägg", "Yarub Adnan" };
        Console.ForegroundColor = ConsoleColor.Yellow;
        DisplayAboutNames(aboutNames);
        Console.ResetColor();
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
        SetCursorPositionAndWrite(47, 13,"Enter your login information");
        Console.ResetColor();
    }

    public void Show()
    {
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
    private void SetCursorPosition(int left, int top)
    {
        Console.SetCursorPosition(left, top);
    }

    private void SetCursorPositionAndWrite(int left, int top, string text)
    {
        SetCursorPosition(left, top);
        Console.Write(text);
    }
}