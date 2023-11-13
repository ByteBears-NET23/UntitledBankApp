using UntitledBankApp.Presenters;
using UntitledBankApp.Services;
using UntitledBankApp.Views;

namespace UntitledBankApp;

internal static class Program
{
    public static void Main()
    {
        var loginPresenter = new LoginPresenter(new LoginService(), new LoginView());
        loginPresenter.RunView();
    }
}