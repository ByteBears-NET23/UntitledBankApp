namespace UntitledBankApp.Models;

public enum Role
{
    Client,
    Admin
}

public abstract class User
{
    public Role Role { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    protected User(Role role, string fullName, string username, string password)
    {
        Role = role;
        FullName = fullName;
        Username = username;
        Password = password;
    }
}