using UntitledBankApp.Presenters;
using UntitledBankApp.Services;
using UntitledBankApp.Views;

namespace UntitledBankApp;

internal static class Program
{
    public static void Main()
    {
        var pseudoDb = new PseudoDb();
        var loginPresenter = new LoginPresenter(pseudoDb, new LoginService(pseudoDb), new LoginView());
        
        loginPresenter.RunView();
    }
}