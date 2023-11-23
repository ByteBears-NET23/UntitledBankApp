namespace UntitledBankApp.Models;

public enum CurrencyCode
{
    SEK,
    EUR,
    USD
}

public class Currency
{
    public CurrencyCode Code { get; set; }
    public decimal Rate { get; set; }

    public Currency(CurrencyCode currencyCode, decimal rate)
    {
        Code = currencyCode;
        Rate = rate;
    }
}