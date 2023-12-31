namespace UntitledBankApp;

public class PseudoDb
{
    public Dictionary<CurrencyCode, Currency> Currencies = new()
    {
        // TODO: Base currency rates on USD or EUR
        // This is not how currency rates work AFK 
        { CurrencyCode.EUR, new Currency(CurrencyCode.EUR, 0.9m) },
        { CurrencyCode.SEK, new Currency(CurrencyCode.SEK, 10.41m) },
        { CurrencyCode.USD, new Currency(CurrencyCode.USD, 1) }
    };

    public List<User> Users = new()
    {
        new Admin("AdminFullName", "admin", "password"),
        new Client( "ClientFullName", "username", "password")
    };
}