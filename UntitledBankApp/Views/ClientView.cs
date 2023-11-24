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
            //Console.WriteLine($"Welcome, {_client.Name}!");
        }

        public void DisplayClientMenu()
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. View Accounts");
            Console.WriteLine("3. Request Loan");
            Console.WriteLine("4. Transfer Money");
            Console.WriteLine("5. Exit");
        }

        public string GetClientMenuChoice()
        {
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        public string GetAccountInfo()
        {
            Console.Write("Enter account information: ");
            return Console.ReadLine();
        }

        public string GetLoanAmount()
        {
            Console.Write("Enter loan amount: ");
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

}
