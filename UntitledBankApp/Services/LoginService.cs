namespace UntitledBankApp.Services;

public class LoginService
{
    private readonly PseudoDb _pseudoDb;
    
    public LoginService(PseudoDb pseudoDb)
    {
        _pseudoDb = pseudoDb;
    }
    
    public User? GetUser(string username, string password)
    {
        return _pseudoDb.Users.Find(u => u.Username == username && u.Password == password);
    }
}