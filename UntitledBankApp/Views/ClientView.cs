using System.Drawing;

namespace UntitledBankApp.Views;


public class ClientView : View
{
    private SimpleMenu _menu;
    private BoxDrawer _boxDrawer;

    public ClientView()
    {
        // Initialize menu options
        var menuOptions = new string[] { "Create Account", "View Accounts", "Request Loan", "Transfer Money", "Exit" };

        // Initialize SimpleMenu
        _menu = new SimpleMenu(menuOptions, top: 22, left: 55);

        // Initialize BoxDrawer
        _boxDrawer = new BoxDrawer(60, 19, 10, 32);
    }

    public int GetClientMenuChoice()
    {
        return _menu.DisplayMenu();
    }

    public void DisplayClientMenu()
    {
        DisplayHeader();
        int choice = _menu.DisplayMenu();

        switch (choice)
        {
            case 1:
                CreateAccount();
                break;
            case 2:
                ViewAccounts();
                break;
            case 3:
                RequestLoan();
                break;
            case 4:
                TransferMoney();
                break;
            case 5:
                Environment.Exit(0); // Exit the application
                break;
            default:
                ShowMessage("Invalid choice. Please try again.", ConsoleColor.DarkRed);
                break;
        }
    }

    public string GetAccountInfo()
    {
        DisplayHeader();
        Console.SetCursorPosition(52, 14);
        Console.Write("Enter account information: ", ConsoleColor.DarkYellow);
        return Console.ReadLine();
    }

    public string GetLoanAmount()
    {
        DisplayHeader();
        Console.SetCursorPosition(52, 15);
        Console.Write("Enter loan amount: ", ConsoleColor.DarkYellow);
        return Console.ReadLine();
    }

    public void ShowMessage(string message,ConsoleColor color)
    {
        Console.SetCursorPosition(52, 18);
        Console.WriteLine(message);
    }

    protected override void DisplayHeader()
    {
        Console.Clear();
        _boxDrawer.DrawBox();
        Console.SetCursorPosition(51, 12);
        Console.WriteLine($"\u001b[33mWelcome To Client Panel\u001b[0m");
    }

    private void CreateAccount()
    {
        DisplayHeader();
        Console.SetCursorPosition(52, 13);
        Console.WriteLine("\u001b[33mChoose account type: \u001b[0m");
        Console.ResetColor();
        Console.SetCursorPosition(52, 14);
        Console.WriteLine("1. Savings Account");
        Console.SetCursorPosition(52, 15);
        Console.WriteLine("2. Checking Account");

        int accountTypeChoice;

        while (true)
        {
            Console.SetCursorPosition(52, 16);
            Console.Write("Enter your choice (1 or 2): ", ConsoleColor.Green);

            if (int.TryParse(Console.ReadLine(), out accountTypeChoice))
            {
                if (accountTypeChoice == 1 || accountTypeChoice == 2)
                {
                    // Valid input, break the loop
                    break;
                }
                else
                {
                    ShowMessage("Invalid choice. Please enter 1 or 2.", ConsoleColor.DarkRed);
                }
            }
            else
            {
                ShowMessage("Invalid input. Please enter a number.", ConsoleColor.DarkRed);
            }
        }

        // Further processing based on accountTypeChoice...
        ShowMessage("Account created successfully!", ConsoleColor.Green);
    }

    private void ViewAccounts()
    {
        Console.SetCursorPosition(52, 13);

        // Implement logic for viewing accounts...
        ShowMessage("Viewing accounts...", ConsoleColor.DarkYellow);
    }

    private void RequestLoan()
    {
        DisplayHeader();
        Console.SetCursorPosition(52, 13);
        Console.WriteLine("Enter loan amount:");
        Console.SetCursorPosition(52, 14);
        string loanAmount = Console.ReadLine();

        // Further processing based on loanAmount...
        ShowMessage("Loan requested successfully!", ConsoleColor.Green);
    }

    private void TransferMoney()
    {
        // Implement logic for transferring money...
        ShowMessage("Money transferred successfully!", ConsoleColor.Green);
    }
}