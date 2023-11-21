using UntitledBankApp.Views.Ui;

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

    public override void HandlePresenter()
    {
        var user = GetUserFromCredentials();

        if (user != null)
        {
            RedirectUserBasedOnRole(user);
        }
        //TODO Presenter: Implement attempts. A null user is a failed login attempt
    }

    private User? GetUserFromCredentials()
    {
        var (username, password) = _loginView.GetCredentials();
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