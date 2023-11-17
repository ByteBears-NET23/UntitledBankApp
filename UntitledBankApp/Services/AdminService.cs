using UntitledBankApp.Models;

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
        /*
         * TODO Service: Create User objects.
         *
         * Use the parameters to:
         * 
         * Search the pseudoDb Users List. Find any duplicate usernames.
         * Usernames must be unique, since they're used during login.
         * If there is another User object with the same name, return false to the method caller.
         * Otherwise, create a User object: Client or Admin depending on the value of "role".
         * Add this object to the Users List in pseudoDb and return true.
         *
         */

        return true;
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