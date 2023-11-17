using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
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


     
        
        bool checkUsername = _pseudoDb.Users.Exists(u => u.Username == username);
        if (checkUsername)
        {
            return false;
        }
        else if(Role.Admin is Role)
        {
            Admin newAdmin = new Admin("NewFullName", username,"NewPassword");
            _pseudoDb.Users.Add(newAdmin);
            return true;
        }
        else
        {
            Client newClient = new Client("NewFullName", username, "NewPassword");
            _pseudoDb.Users.Add(newClient);
            return true;
        }
        

    }

    public void SetCurrencyRate(CurrencyCode currencyCode, float rate)
    {
        /*
         * TODO Service: Set currency rate.
         *
         * Use the parameters to:
         *
         * Search the pseudoDb Currencies Dictionary.
         * Use currencyCode as a key to find the Currency Object value.
         * Update the Currency Object's "Rate" Property with the "rate" from the parameter.
         *
         *
         * Note: It's undecided how we deal with currency exchange rates. (Doesn't imply you can't work on this method.)
         *
         * Assume that we use USD as the standard to compare currency rates to. So that 100 SEK, 9.47 in USD,
         * is represented as 0,0947:1. And if you were to update SEK with the rate "0.05", it would become 0.05:1 or 100 SEK = 5 USD.
         *
         * How currency conversions are made is not a concern for this method.
         */
    }
}