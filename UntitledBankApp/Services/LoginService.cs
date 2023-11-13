using UntitledBankApp.Models;

namespace UntitledBankApp.Services;

public class LoginService
{
    public User? GetUser(string username, string password)
    {
        return PseudoDb.Users.Find(u => u.Username == username && u.Password == password);
    }
}