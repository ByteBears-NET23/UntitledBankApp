using UntitledBankApp.Factories;

namespace UntitledBankApp.Services;

public class AdminService
{
    private PseudoDb _pseudoDb;
    private UserFactory _userFactory;

    public AdminService(PseudoDb pseudoDb,UserFactory userFactory)
    {
        _pseudoDb = pseudoDb;
        _userFactory = userFactory;
    }

    public bool CreateUser(Role role, string fullname, string username, string password)
    {
        bool checkUsername = _pseudoDb.Users.Exists(u => u.Username == username);
        if (checkUsername)
        {
            return false;
        }
        else
        {
            var user = _userFactory.CreateUser(role, fullname, username, password);
            _pseudoDb.Users.Add(user);
            return true;
        }
    }
    public void SetCurrencyRate(CurrencyCode currencyCode, decimal rate)
    {
        if (_pseudoDb.Currencies.ContainsKey(currencyCode))
        {
            _pseudoDb.Currencies[currencyCode].Rate = rate;   
        }
        else
        {
            throw new KeyNotFoundException($"Currency '{currencyCode}' not found.");
        }
    }
}