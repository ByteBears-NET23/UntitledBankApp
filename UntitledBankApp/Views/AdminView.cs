using UntitledBankApp.Models;

namespace UntitledBankApp.Views;

public class AdminView : IView
{
    private Admin _admin;

    public AdminView(Admin admin)
    {
        _admin = admin;
    }

    public void DisplayHeader()
    {
        Console.WriteLine($"LOGGED IN AS ADMIN {_admin.Username}");
    }
}