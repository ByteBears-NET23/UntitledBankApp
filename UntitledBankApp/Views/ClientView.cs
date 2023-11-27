namespace UntitledBankApp.Views;


public class ClientView : View
{
    private SimpleMenu _menu;
    private BoxDrawer _boxDrawer;
    private List<Account> accounts;

    public ClientView(Client client)
    {

        // Initialize menu options
        var menuOptions = new string[] { "Create Account", "View Accounts", "Request Loan", "Transfer Money", "Logout" };

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
                ViewAccounts(accounts);
                break;
            case 3:
                RequestLoan();
                break;
            case 4:
                TransferMoney();
                break;
            case 5:
                if (ConfirmLogout())
                {
                    return; // Exit the loop, effectively logging out
                }
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


    protected override void DisplayHeader()
    {
        _boxDrawer.DrawBox();
        ShowMessage("Welcome To Client Panel", ConsoleColor.Yellow, 51, 12);
    }

    private void CreateAccount()
    {
        DisplayHeader();
        ShowMessage("Choose account type: ", ConsoleColor.Yellow, 52, 13);
        Console.SetCursorPosition(52, 14);
        Console.WriteLine("1. Savings Account");
        Console.SetCursorPosition(52, 15);
        Console.WriteLine("2. Checking Account");

        int accountTypeChoice;

        while (true)
        {
            Console.SetCursorPosition(52, 16);
            Console.Write("Enter your choice (1 or 2): ", ConsoleColor.Green);

            ConsoleKeyInfo key = Console.ReadKey(); // Read a single key
            if (char.IsDigit(key.KeyChar) && (key.KeyChar == '1' || key.KeyChar == '2'))
            {
                accountTypeChoice = int.Parse(key.KeyChar.ToString());
                break; // Valid input, exit the loop
            }
            else
            {
                ShowMessage("Invalid choice. Please enter 1 or 2.", ConsoleColor.DarkRed);
            }
        }

        // Further processing based on accountTypeChoice...
        ShowMessage("Account created successfully!", ConsoleColor.Green, 50, 13);
    }
    private void ViewAccounts(List<Account> accounts)
    {
        //Console.SetCursorPosition(52, 13);
        ShowMessage("Viewing accounts...", ConsoleColor.DarkYellow, 54, 13);

        // Check if there are accounts to display
        if (accounts != null && accounts.Any())
        {
            int startingTop = 15; // Adjust the starting top position as needed

            foreach (var account in accounts)
            {
                Console.SetCursorPosition(52, startingTop);
                //Console.WriteLine($"Account ID: {account.Id}");
                Console.SetCursorPosition(52, startingTop + 1);
                //Console.WriteLine($"Account Type: {account.Type}");
                Console.SetCursorPosition(52, startingTop + 2);
                Console.WriteLine($"Balance: {account.Balance:C}");
                Console.SetCursorPosition(52, startingTop + 3);
                Console.WriteLine(new string('-', 30)); // Separator line

                // Adjust the top position for the next account
                startingTop += 5; // Adjust as needed
            }
        }
        else
        {
            Console.SetCursorPosition(52, 15);
            ShowMessage("No accounts to display.", ConsoleColor.DarkGray, 52, 15);
        }
    }

    private void RequestLoan()
    {
        DisplayHeader();
        ShowMessage("Enter loan amount:", ConsoleColor.Green, 52, 12);
        Console.SetCursorPosition(52, 13);
        string loanAmount = Console.ReadLine();

        // Further processing based on loanAmount...
        if (decimal.TryParse(loanAmount, out decimal amount))
        {
            // Loan amount is valid, proceed with further processing
            ShowMessage("Loan requested successfully!", ConsoleColor.Green, 52, 13);
        }
        else
        {
            ShowMessage("Invalid loan amount. Please enter a valid number.", ConsoleColor.DarkRed);
        }
    }
    private void TransferMoney()
    {
        // Implement logic for transferring money...
        ShowMessage("Money transferred successfully!", ConsoleColor.Green, 50, 13);
    }
   
}