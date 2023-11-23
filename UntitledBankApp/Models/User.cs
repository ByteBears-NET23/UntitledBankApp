namespace UntitledBankApp.Models;

public enum Role
{
    Client,
    Admin
}

public abstract class User
{
    public Role Role { get; set; }
    private string _fullName = null!;
    private string _username = null!;
    private string _password = null!;
    public string FullName
    {
        get => _fullName;

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("value assigned to name cannot be null or white space.");
            _fullName = value;
        }
    }
    public string Username
    {
        get => _username;

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("value assigned to name cannot be null or white space.");
            _username = value;
        }
    }
    public string Password
    {
        get => _password;

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("value assigned to name cannot be null or white space.");
            _password = value;
        }
    }

    protected User(Role role, string fullName, string username, string password)
    {
        Role = role;
        FullName = fullName;
        Username = username;
        Password = password;
    }
}