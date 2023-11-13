using UntitledBankApp.Views.Utilities;

namespace UntitledBankApp.Views;

public class LoginView : IView
{
    public void DisplayHeader()
    {
        Console.WriteLine("LOGIN SCREEN");
    }

    public string GetUsername()
    {
        return InputUtils.GetNonEmptyString("Username");
    }

    public string GetPassword()
    {
        return InputUtils.GetNonEmptyString("Password");
    }
}