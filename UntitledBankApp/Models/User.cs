namespace UntitledBankApp.Models;

public enum Role
{
    Client,
    Admin
}

public abstract class User
{
    public Role Role { get; set; }
    public string FullName
    {
        get => FullName;

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("value assigned to name cannot be null or white space.");
            FullName = value;
        }
    }
    public string Username
    {
        get => Username;

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("value assigned to name cannot be null or white space.");
            Username = value;
        }
    }
    public string Password
    {
        get => Password;

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("value assigned to name cannot be null or white space.");
            Password = value;
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