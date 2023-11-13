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
    public float Rate { get; set; }

    public Currency(CurrencyCode currencyCode, float rate)
    {
        Code = currencyCode;
        Rate = rate;
    }
}