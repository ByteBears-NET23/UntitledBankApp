using UntitledBankApp.Models;
using UntitledBankApp.Services;
using UntitledBankApp.Views;

namespace UntitledBankApp.Presenters;

public class LoginPresenter : Presenter
{
    private PseudoDb _pseudoDb;
    private LoginService _loginService;
    private LoginView _loginView;

    public LoginPresenter(PseudoDb pseudoDb, LoginService loginService, LoginView loginView)
    {
        _pseudoDb = pseudoDb;
        _loginService = loginService;
        _loginView = loginView;
    }

    public override void RunView()
    {
        _loginView.DisplayHeader();

        var user = GetUserFromCredentials();

        if (user != null)
        {
            RedirectUserBasedOnRole(user);
        }
    }

    private User? GetUserFromCredentials()
    {
        var username = _loginView.GetUsername();
        var password = _loginView.GetPassword();
        var user = _loginService.GetUser(username, password);

        return user;
    }
    
    private void RedirectUserBasedOnRole(User user)
    {
        switch (user)
        {
            case Client client:
                RunPresenter(new ClientPresenter(_pseudoDb, new ClientService(_pseudoDb), new ClientView(client)));
                break;
            case Admin admin:
                RunPresenter(new AdminPresenter(_pseudoDb, new AdminService(_pseudoDb), new AdminView(admin)));
                break;
        }
    }
}