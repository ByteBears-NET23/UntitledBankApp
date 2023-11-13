namespace UntitledBankApp.Models;

public class Balance
{
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }

    public Balance(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }
}