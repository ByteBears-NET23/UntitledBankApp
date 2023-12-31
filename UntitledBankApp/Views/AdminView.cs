﻿namespace UntitledBankApp.Views;

public class AdminView : View
{
    private Admin admin;
    private SimpleMenu _menu;
    private BoxDrawer _boxDrawer;
    public AdminView(Admin admin)
    {
        this.admin = admin;

        // Initialize menu options
        var menuOptions = new string[] { "1:Create User", "2:Set Currency Rate", "3:Logout" };

        // Initialize SimpleMenu
        _menu = new SimpleMenu(menuOptions, top: 22, left: 55);

        // Initialize BoxDrawer
        _boxDrawer = new BoxDrawer(60, 19, 10, 32);
    }

    public int GetAdminChoice()
    {
        int choice = _menu.DisplayMenu();

        // Check if the user selected "3: Logout"
        if (choice == 3)
        {
            ConfirmLogout();
        }

        return choice;
    }
    //public bool ConfirmLogout()
    //{
    //    ShowMessage("Are you sure you want to logout? (Y/N): ", ConsoleColor.Yellow, 44, 16);
    //    var key = Console.ReadKey().Key;
    //    _shouldLogout = key == ConsoleKey.Y;
    //    return _shouldLogout;
    //}
    protected override void DisplayHeader()
    {
        _boxDrawer.DrawBox();
        Console.SetCursorPosition(40, 5);
    }

    public void GetUserInputForNewUser(out Role role, out string fullName, out string username, out string password)
    {
        DisplayHeader();
        ShowMessage("Enter user details", ConsoleColor.DarkGray, 49, 12);
        role = GetRoleInput();
        fullName = GetInput("Full Name: ", ConsoleColor.Gray, 49, 13);
        username = GetInput("Username: ", ConsoleColor.Gray, 49, 13);
        password = GetInput("Password: ", ConsoleColor.Gray, 49, 13);
    }

    public void GetUserInputForSettingCurrencyRate(out CurrencyCode currencyCode, out decimal rate)
    {
        DisplayHeader();
        ShowMessage("Enter currency details", ConsoleColor.DarkGray, 50, 12);
        currencyCode = GetCurrencyCodeInput();
        rate = GetFloatInput("Rate: ", ConsoleColor.Gray, 49, 17);
    }

    private Role GetRoleInput()
    {
        return Enum.Parse<Role>(GetInput("Role (Admin/Client): ", ConsoleColor.DarkGray, 49, 12));
    }

    private string GetFullNameInput()
    {
        return GetInput("Full Name: ", ConsoleColor.Gray, 49, 13);
    }

    private string GetUsernameInput()
    {
        return GetInput("Username: ", ConsoleColor.Gray, 49, 13);
    }

    private string GetPasswordInput()
    {
        return GetInput("Password: ", ConsoleColor.Gray, 49, 13);
    }

    private CurrencyCode GetCurrencyCodeInput()
    {
        return Enum.Parse<CurrencyCode>(GetInput("Currency Code: ", ConsoleColor.DarkGray, 49, 16));
    }

    private decimal GetCurrencyRateInput()
    {
        return GetFloatInput("Rate: ", ConsoleColor.Gray, 49, 17);
    }

    private string GetInput(string prompt, ConsoleColor color, int left, int top)
    {
        ShowMessage(prompt, color, left, top);
        int initialTop = Console.CursorTop; 
        Console.SetCursorPosition(left + prompt.Length, initialTop);
        string input = Console.ReadLine();
        Console.SetCursorPosition(left, initialTop);

        return input;
    }


    private decimal GetFloatInput(string prompt, ConsoleColor color, int left, int top)
    {
        ShowMessage(prompt, color, left, top);

        return decimal.Parse(Console.ReadLine());

    }

    public void UpdateUserCreationResult(bool isSuccess)
    {
        ShowMessage(isSuccess ? "User created successfully!" : "Failed to create user. Username already exists.",
                    isSuccess ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed, 49, 18);
    }

    public void UpdateCurrencyRateResult(bool isSuccess)
    {
        ShowMessage(isSuccess ? "Currency rate updated successfully!" : "Failed to update currency rate. Currency not found.",
                    isSuccess ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed, 49, 18);
    }

   
}
