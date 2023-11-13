namespace UntitledBankApp.Models;

public class Account
{
    public Client Owner { get; set; }
    public Balance Balance { get; set; }
    public List<Transfer> Transfers { get; set; }
    public float InterestRate { get; set; }

    public Account(Client client, Balance balance, float interestRate)
    {
        Owner = client;
        Balance = balance;
        Transfers = new List<Transfer>();
        InterestRate = interestRate;
    }
}