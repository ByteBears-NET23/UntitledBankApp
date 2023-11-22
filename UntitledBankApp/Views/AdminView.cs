namespace UntitledBankApp.Views;

public class AdminView : View
{
    private Admin _admin;

    public AdminView(Admin admin)
    {
        _admin = admin;
    }

    protected override void DisplayHeader()
    {
        Console.WriteLine($"LOGGED IN AS ADMIN {_admin.Username}");
        var AdminmenuOptions1 = new[] { "CreateUser", "SetCurrencyRate", "Back" };
    }
}