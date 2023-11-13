namespace UntitledBankApp.Models;

public class Client : User
{
    public List<Account> Accounts { get; set; }

    public Client(string fullName, string username, string password, decimal startBalance, Currency startCurrency) :
        base(Role.Client, fullName, username, password)
    {
        Accounts = new List<Account> { new(this, new Balance(startBalance, startCurrency), 1.1f) };
    }
}