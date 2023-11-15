namespace UntitledBankApp.Models;

public class Client : User
{
    public List<Account> Accounts { get; set; }

    public Client(string fullName, string username, string password) : base(Role.Client, fullName, username, password)
    {
        Accounts = new List<Account>();
    }
}