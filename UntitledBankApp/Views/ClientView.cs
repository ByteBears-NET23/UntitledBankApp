using UntitledBankApp.Models;

namespace UntitledBankApp.Views;

public class ClientView : IView
{
    private Client _client;

    public ClientView(Client client)
    {
        _client = client;
    }

    public void DisplayHeader()
    {
        Console.WriteLine($"LOGGED IN AS CLIENT {_client.Username}");
    }
}