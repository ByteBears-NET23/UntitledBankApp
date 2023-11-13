using UntitledBankApp.Models;

namespace UntitledBankApp;

public static class PseudoDb
{
    public static Dictionary<CurrencyCode, Currency> Currencies = new()
    {
        { CurrencyCode.EUR, new Currency(CurrencyCode.EUR, 1.1f) },
        { CurrencyCode.SEK, new Currency(CurrencyCode.SEK, 1.2f) },
        { CurrencyCode.USD, new Currency(CurrencyCode.USD, 1.3f) }
    };

    public static List<User> Users = new()
    {
        new Admin("Admin", "admin", "password"),
        new Client("Client", "username", "password", 1000, Currencies[CurrencyCode.SEK])
    };
}