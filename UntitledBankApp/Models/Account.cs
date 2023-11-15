namespace UntitledBankApp.Models;

public class Account
{
    public int Number { get; }
    public Client Owner { get; }
    public Balance Balance { get; set; }
    public List<Transfer> Transfers { get; set; }
    public float InterestRate { get; set; }

    public Account(int number, Client client, Balance balance, float interestRate)
    {
        Number = number;
        Owner = client;
        Balance = balance;
        Transfers = new List<Transfer>();
        InterestRate = interestRate;
    }
}