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
        var menuOptions = new string[] { "1:Create User", "2:Set Currency Rate", "3:Go Back" };

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
        Console.Clear();

        _boxDrawer.DrawBox();
        Console.SetCursorPosition(40, 5);
        //Console.WriteLine("=== Admin Panel ===");
    }

    public void ShowMessage(string message)
    {

        Console.Clear();
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
        Console.Write("Role (Admin/Client): ");
        return Enum.Parse<Role>(Console.ReadLine());
    }

    private string GetFullNameInput()
    {
        Console.SetCursorPosition(49, 13);
        Console.Write("Full Name: ");
        return Console.ReadLine();
    }

    private string GetUsernameInput()
    {
        Console.SetCursorPosition(49, 14);
        Console.Write("Username: ");
        return Console.ReadLine();
    }

    private string GetPasswordInput()
    {
        Console.SetCursorPosition(49, 15);
        Console.Write("Password: ");
        return Console.ReadLine();
    }

    private CurrencyCode GetCurrencyCodeInput()
    {
        Console.SetCursorPosition(49, 16);
        Console.Write("Currency Code: ");
        return Enum.Parse<CurrencyCode>(Console.ReadLine());
    }

    private float GetCurrencyRateInput()
    {
        Console.SetCursorPosition(49, 17);
        Console.Write("Rate: ");
        return float.Parse(Console.ReadLine());
    }

    public void UpdateUserCreationResult(bool isSuccess)
    {
        if (isSuccess)
        {
            Console.SetCursorPosition(49, 18);

            ShowMessage("\u001b[32mUser created successfully!\u001b[0m");
        }
        else
        {
            Console.SetCursorPosition(43, 18);
            ShowMessage("\u001b[31mFailed to create user. Username already exists.\u001b[0m");
        }
    }

    public void UpdateCurrencyRateResult(bool isSuccess)
    {
        if (isSuccess)
        {
            Console.SetCursorPosition(47, 18);

            ShowMessage("\u001b[32mCurrency rate updated successfully!\u001b[0m");
        }
        else
        {
            Console.SetCursorPosition(43, 18);
            
            ShowMessage("\u001b[31mFailed to update currency rate. Currency not found.\u001b[0m");
        }
    }
}
