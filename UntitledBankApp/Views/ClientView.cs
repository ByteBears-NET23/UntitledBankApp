namespace UntitledBankApp.Views
{
    public class ClientView : View
    {
        private Client _client;
        private ClientService _clientService;
        private Client client;

        public ClientView(Client client, ClientService clientService)
        {
            _client = client;
            _clientService = clientService;
        }

        public ClientView(Client client)
        {
            this.client = client;
        }

        protected override void DisplayHeader()
        {
            Console.WriteLine($"Welcome, {_client.FullName}!");
            Console.WriteLine("*************************");
        }

        public void DisplayClientMenu()
        {
            bool exitMenu = false;

            while (!exitMenu)
            {
                DisplayHeader();
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Request Loan");
                Console.WriteLine("3. View Accounts");
                Console.WriteLine("4. Transfer Funds");
                Console.WriteLine("5. Exit");

                Console.Write("Select an option (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        RequestLoan();
                        break;
                    case "3":
                        ViewAccounts();
                        break;
                    case "4":
                        TransferFunds();
                        break;
                    case "5":
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("****** Create Account ******");

            // Assuming you have a way to select the currency code.
            Console.Write("Enter Currency Code (e.g., USD): ");
            string currencyCodeStr = Console.ReadLine();

            if (Enum.TryParse(currencyCodeStr, out CurrencyCode currencyCode))
            {
                bool result = _clientService.CreateAccount(_client, currencyCode);
                Console.WriteLine(result ? "Account created successfully." : "Failed to create account.");
            }
            else
            {
                Console.WriteLine("Invalid currency code.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private void RequestLoan()
        {
            Console.WriteLine("****** Request Loan ******");

            // Assuming you have a way to select an account for the loan.
            Console.Write("Enter Account Number: ");
            if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                var account = _client.Accounts.FirstOrDefault(a => a.Number == accountNumber);

                if (account != null)
                {
                    bool result = _clientService.Loan(account);
                    Console.WriteLine(result ? "Loan request successful." : "Loan request failed.");
                }
                else
                {
                    Console.WriteLine("Account not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private void ViewAccounts()
        {
            Console.WriteLine("****** View Accounts ******");

            // Assuming you have a way to display the client's accounts.
            var accounts = _clientService.GetAccounts(_client);
            if (accounts != null)
            {
                foreach (var account in accounts)
                {
                    Console.WriteLine($"Account Number: {account.Number}, Balance: {account.Balance.Amount} {account.Balance.Currency.Code}");
                }
            }
            else
            {
                Console.WriteLine("No accounts found for the client.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        private void TransferFunds()
        {
            Console.WriteLine("****** Transfer Funds ******");

            // Assuming you have a way to select an account for the transfer.
            Console.Write("Enter From Account Number: ");
            if (int.TryParse(Console.ReadLine(), out int fromAccountNumber))
            {
                var fromAccount = _client.Accounts.FirstOrDefault(a => a.Number == fromAccountNumber);

                if (fromAccount != null)
                {
                    Console.Write("Enter Amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        Console.Write("Enter To Account Number: ");
                        if (int.TryParse(Console.ReadLine(), out int toAccountNumber))
                        {
                            bool result = _clientService.Transfer(fromAccount, amount, toAccountNumber);
                            Console.WriteLine(result ? "Transfer successful." : "Transfer failed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid to account number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                }
                else
                {
                    Console.WriteLine("From account not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid from account number.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
