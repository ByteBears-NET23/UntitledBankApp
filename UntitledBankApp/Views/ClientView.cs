namespace UntitledBankApp.Views;

public class ClientView : View
{
    private Client _client;

    public ClientView(Client client)
    {
        _client = client;
    }

    protected override void DisplayHeader()
    {
        Console.WriteLine($"LOGGED IN AS CLIENT {_client.Username}");
        var AdminmenuOptions1 = new[] { "CreateUser", "SetCurrencyRate", "Back" };
    }
}