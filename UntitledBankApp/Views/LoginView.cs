using UntitledBankApp.Views.Ui;
using UntitledBankApp.Views.Utilities;

namespace UntitledBankApp.Views;

public class LoginView : View
{
    
    public (string username, string password) GetCredentials()
    {
        DisplayHeader();
        
        var username = InputUtils.GetNonEmptyString("Username");
        var password = InputUtils.GetNonEmptyString("Password");

        return (username, password);
    }
    
    protected override void DisplayHeader()
    {
        RunUi runUi = new RunUi();
        runUi.Run();
    }
}