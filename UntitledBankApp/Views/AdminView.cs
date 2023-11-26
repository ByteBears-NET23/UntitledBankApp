namespace UntitledBankApp.Views;

public class AdminView : View
{
    private Admin admin;
    private SimpleMenu _menu;
    private BoxDrawer _boxDrawer;

    public AdminView(Admin admin)
    {
        this.admin = admin;

        // Initialize menu options
        var menuOptions = new string[] { "1:Create User", "2:Set Currency Rate", "3:Go Back", "Logout" };
        Console.WriteLine(Tital);

        // Initialize SimpleMenu
        _menu = new SimpleMenu(menuOptions, top: 22, left: 55);

        // Initialize BoxDrawer
        _boxDrawer = new BoxDrawer(60, 19, 10, 32);
    }

    public int GetAdminChoice()
    {
        int choice = _menu.DisplayMenu();

        // Check if the user selected "3: Go Back"
        if (choice == 3)
        {
            return 0; // Special value to indicate going back
        }

        return choice;
    }


    protected override void DisplayHeader()
    {
        //Console.Clear();

        _boxDrawer.DrawBox();
        Console.SetCursorPosition(40, 5);
        //Console.WriteLine("=== Admin Panel ===");
    }

    public void ShowMessage(string message, ConsoleColor darkGray)
    {

        //Console.Clear();

        _boxDrawer.DrawBox();
        Console.SetCursorPosition(49, 12);

        Console.WriteLine(message);
    }

    public void GetUserInputForNewUser(out Role role, out string fullName, out string username, out string password)
    {
        DisplayHeader();
        Console.SetCursorPosition(49, 12);
        Console.WriteLine("\u001b[32mEnter user details\u001b[0m");
        Console.ResetColor();
        role = GetRoleInput();
        fullName = GetFullNameInput();
        username = GetUsernameInput();
        password = GetPasswordInput();
    }

    public void GetUserInputForSettingCurrencyRate(out CurrencyCode currencyCode, out float rate)
    {
        DisplayHeader();
        Console.SetCursorPosition(50, 12);
        Console.WriteLine("\u001b[32mEnter currency details\u001b[0m");
        currencyCode = GetCurrencyCodeInput();
        rate = GetCurrencyRateInput();
    }

    private Role GetRoleInput()
    {
        Console.SetCursorPosition(49, 12);
        Console.Write("\u001b[32mRole (Admin/Client): \u001b[0m");
        return Enum.Parse<Role>(Console.ReadLine());
    }

    private string GetFullNameInput()
    {
        Console.SetCursorPosition(49, 13);
        Console.Write("\u001b[32mFull Name: \u001b[0m");
        return Console.ReadLine();
    }

    private string GetUsernameInput()
    {
        Console.SetCursorPosition(49, 14);
        Console.Write("\u001b[32mUsername: \u001b[0m");
        return Console.ReadLine();
    }

    private string GetPasswordInput()
    {
        Console.SetCursorPosition(49, 15);
        Console.Write("\u001b[32mPassword: \u001b[0m");
        return Console.ReadLine();
    }

    private CurrencyCode GetCurrencyCodeInput()
    {
        Console.SetCursorPosition(49, 16);
        Console.Write("\u001b[32mCurrency Code: \u001b[0m");
        return Enum.Parse<CurrencyCode>(Console.ReadLine());
    }

    private float GetCurrencyRateInput()
    {
        Console.SetCursorPosition(49, 17);
        Console.Write("\u001b[32mRate: \u001b[0m");
        return float.Parse(Console.ReadLine());
    }

    public void UpdateUserCreationResult(bool isSuccess)
    {
        if (isSuccess)
        {
            Console.SetCursorPosition(49, 18);

            ShowMessage("User created successfully!", ConsoleColor.DarkGreen);
        }
        else
        {
            Console.SetCursorPosition(43, 18);
            ShowMessage("Failed to create user. Username already exists.", ConsoleColor.DarkGreen);
        }
    }

    public void UpdateCurrencyRateResult(bool isSuccess)
    {
        if (isSuccess)
        {
            Console.SetCursorPosition(47, 18);

            ShowMessage("Currency rate updated successfully!", ConsoleColor.DarkGreen);
        }
        else
        {
            Console.SetCursorPosition(43, 18);

            ShowMessage("Failed to update currency rate. Currency not found.", ConsoleColor.DarkGreen);
    }

}

    public bool ConfirmLogout()
    {
        //Console.Clear();
        DisplayHeader();
        Console.SetCursorPosition(47, 16);
        Console.Write("Are you sure you want to logout? (Y/N): ");
        var key = Console.ReadKey().Key;
        return key == ConsoleKey.Y;
    }
}