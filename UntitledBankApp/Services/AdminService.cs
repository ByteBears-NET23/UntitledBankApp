using UntitledBankApp.Factories;

namespace UntitledBankApp.Services;

public class AdminService
{
    private PseudoDb _pseudoDb;
    
    public AdminService(PseudoDb pseudoDb)
    {
        _pseudoDb = pseudoDb;
    }

    public bool CreateUser(Role role, string fullname, string username, string password)
    {

        UserFactory userFactory = new UserFactory();

        bool checkUsername = _pseudoDb.Users.Exists(u => u.Username == username);
        if (checkUsername)
        {
            return false;
        }
        else
        {
            CreateUser(role,fullname,username,password);
            _pseudoDb.Users.Add();
            return true;
        }

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