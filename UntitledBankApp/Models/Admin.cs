namespace UntitledBankApp.Models;

public class Admin : User
{
    public Admin(string fullName, string username, string password) : base(Role.Admin, fullName, username, password)
    {
    }
    public AdminService AdminService { get; internal set; }
}
