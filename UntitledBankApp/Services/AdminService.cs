using UntitledBankApp.Factories;

namespace UntitledBankApp.Services;

public class AdminService
{
    private PseudoDb _pseudoDb;
    private UserFactory _userFactory;
    
    public AdminService(PseudoDb pseudoDb, UserFactory userFactory)
    {
        _pseudoDb = pseudoDb;
        _userFactory = userFactory;
    }

    public bool CreateUser(Role role, string fullname, string username, string password)
    {

        UserFactory userFactory = new UserFactory(_pseudoDb.Users);

        return userFactory.CreateUser(role, fullname, username, password);
    }
    public void SetCurrencyRate(CurrencyCode currencyCode, float rate)
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