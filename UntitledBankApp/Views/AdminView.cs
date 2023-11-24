public class AdminView : View
{
    private Admin admin;

    public AdminView(Admin admin)
    {
        this.admin = admin;
    }

    protected override void DisplayHeader()
    {
        Console.WriteLine("=== Admin Panel ===");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public int GetAdminChoice()
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Set Currency Rate");
        Console.WriteLine("3. Go Back");

        while (true)
        {
            string choiceString = Console.ReadLine();
            if (int.TryParse(choiceString, out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    public void GetUserInputForNewUser(out Role role, out string fullName, out string username, out string password)
    {
        Console.WriteLine("Enter user details:");
        role = GetRoleInput();
        fullName = GetFullNameInput();
        username = GetUsernameInput();
        password = GetPasswordInput();
    }

    public void GetUserInputForSettingCurrencyRate(out CurrencyCode currencyCode, out float rate)
    {
        Console.WriteLine("Enter currency details:");
        currencyCode = GetCurrencyCodeInput();
        rate = GetCurrencyRateInput();
    }

    private Role GetRoleInput()
    {
        Console.Write("Role (Admin/Client): ");
        return Enum.Parse<Role>(Console.ReadLine());
    }

    private string GetFullNameInput()
    {
        Console.Write("Full Name: ");
        return Console.ReadLine();
    }

    private string GetUsernameInput()
    {
        Console.Write("Username: ");
        return Console.ReadLine();
    }

    private string GetPasswordInput()
    {
        Console.Write("Password: ");
        return Console.ReadLine();
    }

    private CurrencyCode GetCurrencyCodeInput()
    {
        Console.Write("Currency Code: ");
        return Enum.Parse<CurrencyCode>(Console.ReadLine());
    }

    private float GetCurrencyRateInput()
    {
        Console.Write("Rate: ");
        return float.Parse(Console.ReadLine());
    }

    public void UpdateUserCreationResult(bool isSuccess)
    {
        if (isSuccess)
        {
            ShowMessage("User created successfully!");
        }
        else
        {
            ShowMessage("Failed to create user. Username already exists.");
        }
    }

    public void UpdateCurrencyRateResult(bool isSuccess)
    {
        if (isSuccess)
        {
            ShowMessage("Currency rate updated successfully!");
        }
        else
        {
            ShowMessage("Failed to update currency rate. Currency not found.");
        }
    }
}
