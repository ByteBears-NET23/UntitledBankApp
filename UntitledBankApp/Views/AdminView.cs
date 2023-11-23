namespace UntitledBankApp.Views;

public class AdminView : View
{
    private Admin _admin;

    public AdminView(Admin admin)
    {
        _admin = admin;
    }

    protected override void DisplayHeader()
    {
        Console.WriteLine("************ Admin Dashboard ************");
        Console.WriteLine($"Welcome, {_admin.FullName}!");
        Console.WriteLine("****************************************\n");
    }

    public void ShowAdminMenu()
    {
        DisplayHeader();

        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Set Currency Rate");
        Console.WriteLine("3. Exit\n");

        Console.Write("Enter your choice: ");
    }

    public void HandleAdminInput(int choice, AdminService adminService)
    {
        switch (choice)
        {
            case 1:
                CreateUserMenu(adminService);
                break;
            case 2:
                SetCurrencyRateMenu(adminService);
                break;
            case 3:
                Console.WriteLine("Exiting Admin Dashboard. Goodbye!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.\n");
                break;
        }
    }

    private void CreateUserMenu(AdminService adminService)
    {
        Console.WriteLine("****** Create User ******");

        Console.Write("Enter Role (Admin/Client): ");
        string roleInput = Console.ReadLine();
        Role role;

        if (Enum.TryParse(roleInput, true, out role))
        {
            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            bool result = adminService.CreateUser(role, fullName, username, password);

            if (result)
                Console.WriteLine("User created successfully.");
            else
                Console.WriteLine("Failed to create user. Duplicate username found.");

        }
        else
        {
            Console.WriteLine("Invalid role. Please enter 'Admin' or 'Client'.\n");
        }
    }

    private void SetCurrencyRateMenu(AdminService adminService)
    {
        Console.WriteLine("****** Set Currency Rate ******");

        Console.Write("Enter Currency Code: ");
        string currencyCodeInput = Console.ReadLine();

        if (Enum.TryParse(currencyCodeInput, true, out CurrencyCode currencyCode))
        {
            Console.Write("Enter Currency Rate: ");
            if (float.TryParse(Console.ReadLine(), out float rate))
            {
                try
                {
                    adminService.SetCurrencyRate(currencyCode, rate);
                    Console.WriteLine($"Currency rate for {currencyCode} set successfully.");
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid rate. Please enter a valid floating-point number.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid currency code. Please enter a valid currency code.\n");
        }
    }
}
