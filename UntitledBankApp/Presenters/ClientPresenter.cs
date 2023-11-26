namespace UntitledBankApp.Presenters;

public class ClientPresenter : Presenter
{
    private PseudoDb _pseudoDb;
    private ClientService _clientService;
    private ClientView _clientView;
    private Client _client; // Add a field to store the Client instance

    // Modify the constructor to accept Client instance
    public ClientPresenter(PseudoDb pseudoDb, ClientService clientService, ClientView clientView, Client client)
    {
        _pseudoDb = pseudoDb;
        _clientService = clientService;
        _clientView = clientView;
        _client = client; // Store the Client instance
    }

    public ClientPresenter(PseudoDb pseudoDb, ClientService clientService, ClientView clientView)
    {
        _pseudoDb = pseudoDb;
        _clientService = clientService;
        _clientView = clientView;
    }

    public override void HandlePresenter()
    {
        while (true)
        {
            _clientView.DisplayClientMenu();

            int choice = _clientView.GetClientMenuChoice();

            switch (choice)
            {
                case 1:
                    HandleCreateAccount();
                    break;
                case 2:
                    HandleViewAccounts();
                    break;
                case 3:
                    HandleRequestLoan();
                    break;
                case 4:
                    HandleTransferMoney();
                    break;
                case 5:
                    return;

                case 6: // Logout option
                    if (_clientView.ConfirmLogout())
                        return; // Exit the method, effectively logging out
                    break;
                default:
                    _clientView.ShowMessage("Invalid choice. Please try again.", ConsoleColor.Red);
                    break;
            }
        }
    }

    private void HandleCreateAccount()
    {
        // Implement the logic for creating a new account
        // You can call methods from _clientService and interact with _clientView
        string accountInfo = _clientView.GetAccountInfo();
        // Further processing...
        _clientView.ShowMessage("Account created successfully!", ConsoleColor.Green);
    }

    private void HandleViewAccounts()
    {
        // Implement the logic for viewing accounts
        // You can call methods from _clientService and interact with _clientView
        _clientView.ShowMessage("Viewing accounts...", ConsoleColor.DarkGray);
    }

    private void HandleRequestLoan()
    {
        // Implement the logic for requesting a loan
        // You can call methods from _clientService and interact with _clientView
        string loanAmount = _clientView.GetLoanAmount();
        // Further processing...
        _clientView.ShowMessage("Loan requested successfully!", ConsoleColor.Green);
    }

    private void HandleTransferMoney()
    {
        // Implement the logic for transferring money
        // You can call methods from _clientService and interact with _clientView
        _clientView.ShowMessage("Money transferred successfully!", ConsoleColor.Green);
    }
}