namespace UntitledBankApp; // TODO: Figure out a name for the app. Be it bear themed or something else.

internal static class Program
{
    public static void Main()
    {
        var pseudoDb = new PseudoDb();
        var loginPresenter = new LoginPresenter(pseudoDb, new LoginService(pseudoDb), new LoginView());
        
        loginPresenter.HandlePresenter();
    }
}