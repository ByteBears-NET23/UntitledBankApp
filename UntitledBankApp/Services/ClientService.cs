namespace UntitledBankApp.Services;

public class ClientService
{
    private PseudoDb _pseudoDb;
    
    public ClientService(PseudoDb pseudoDb)
    {
        _pseudoDb = pseudoDb;
    }
    
    public bool CreateAccount(Client client, CurrencyCode code)
    {
        const int minAccountValue = 1000000000;
        const int maxAccountValue = 2147483646; // 32-bit int limit -1
        const int diffAccountValue = maxAccountValue - minAccountValue; // Possible accounts (1147483646) 
        
        if (MaxAccountsReached(diffAccountValue))
        {
            return false;
        }
        
        var number = GenerateAccountNumber(minAccountValue, maxAccountValue);
        
        var currency = _pseudoDb.Currencies[code];
        // TODO: InterestRate should probably use a simple algorithm based of Balance.Amount and Balance.Currency.Code. And not be a required parameter.
        // 1.1f also gives decimal rounding error 
        var account = new Account(number, client, new Balance(0, currency), 1.1f);

        client.Accounts.Add(account);

        return true;
    }

    private bool MaxAccountsReached(int diffAccountValue)
    {
        var currentAccountCount = _pseudoDb.Users.OfType<Client>().SelectMany(client => client.Accounts).Count();

        return currentAccountCount >= diffAccountValue;
    }

    private int GenerateAccountNumber(int minAccountValue, int maxAccountValue)
    {
        int number;
        
        do
        {
            var random = new Random();
            number = random.Next(minAccountValue, maxAccountValue + 1); // +1 because maxValue is exclusive
        } while (CheckIfNumberIsUnique(number));

        return number;
    }

    private bool CheckIfNumberIsUnique(int number)
    {
        return _pseudoDb.Users.OfType<Client>().Any(client => client.Accounts.Any(account => account.Number == number));
    }

    public bool Loan(Account account)
    {
        /*
         * TODO Service: Loan balance amount from the bank
         *
         *
         * Use the parameters to:
         *
         * Use the Account's Owner property to find the Client who owns it.
         * Determine if the Client's Loan Property is less than 5.
         * If it is 5 or greater (should be impossible, but still), return false.
         * Otherwise, find the Currency Code used for the Account's Balance.
         * 
         * Use the Currency Code to determine a sufficient "amount" to grant the Account Balance.
         * For example, we don't want to give an account using vietnamese dong, "100" (0,044 SEK) and give someone
         * using EUR "100" (1151 SEK).
         *
         * Add the value to the Balance's Amount property.
         * Update the Owner's Loan property with +1.
         *
         * Return true.
         */
        
        throw new NotImplementedException();
    }

    public List<Account>? GetAccounts(Client client)
    {
        /*
         * TODO IGNORE: This should not be a service. But I leave it here as a reminder for later.
         *
         * Use the parameter to:
         *
         * return the Client's Account List property.
         */

        throw new NotImplementedException();
    }

    public bool Transfer(Account account, decimal amount, int toAccountNumber)
    {
        /*
         * TODO Service: Transfer Balance from one account to another.
         *
         * NOTE: Might be difficult to figure out the conversions. I may also have forgotten steps in this process. Proceed with caution!
         * 
         * Use the parameters to:
         *
         * Check if the Account's Balance.Amount is equal or greater than the parameter "amount".
         * If this is false, the Account has insufficient funds and this method will return false.
         * If this is true, the Account's Currency.Balance.Code will be used to make a currency conversion later.
         *
         * Find an Account instance whose property "Number" is equal to the toAccountNumber in the List of Users in pseudoDb.
         * If it doesn't exist, return false.
         * Otherwise, find the Currency.Balance.Code used for this account.
         *
         * Convert the parameter "amount" from the "From Account"'s Currency.Balance.Code, to the "To Account"'s Currency.Balance.Code.
         * To figure out the conversion rate multiplier that needs to be used, Find the Currency Rate values of the two used Currency.Balance.Code(s),
         * and the Currency Rate of USD from pseudoDb.
         *
         * Compare the "To" and "From" currencies against the USD and figure out what multiplier needs to be used to correctly convert the amount.
         *
         * When the correct multiplier has been found, remove the "amount" from the "From Account's balance".
         * Multiply the "amount" with this multiplier and add it to the Queue of transfers in PseudoDb.
         * If the queue is not implemented, make the transfer by adding the now converted amount to the "To" Account's balance.
         *
         * Create two Transfer objects, one for the sender and one for the receiver, and add them to their account's TransferHistory List.
         * On failed transfers, where this method returns false, create only a Transfer object for the sender with the correct details and
         * "Failed" Status.
         *
         * return true.
         */
        
        return true;
    }
}