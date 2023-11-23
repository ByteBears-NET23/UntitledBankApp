namespace UntitledBankApp.Models;

public class Client : User
{
    public decimal debt;
    public decimal loanCap;
    public List<Account> Accounts { get; set; }

    public Client(string fullName, string username, string password) : base(Role.Client, fullName, username, password)
    {
        Accounts = new List<Account>();
        loanCap = 0;
    }
}