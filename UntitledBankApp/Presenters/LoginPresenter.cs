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
        User? user = null;

        // Keep track of login attempts
        for (int attempts = 0; attempts < 3; attempts++)
        {
            var credentials = _loginView.GetCredentials();
            user = _loginService.GetUser(credentials.username, credentials.password);

            if (user != null)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid credentials. Please try again.");
            }
        }

        if (user != null)
        {
            RedirectUserBasedOnRole(user);
        }
        else
        {
            Console.WriteLine("Maximum login attempts reached. Exiting...");
        }
    }

    private void RedirectUserBasedOnRole(User user)
    {
        if (user is Client client)
        {
            RunPresenter(new ClientPresenter(_pseudoDb, new ClientService(_pseudoDb), new ClientView(client)));
        }
        else if (user is Admin admin)
        {
            RunPresenter(new AdminPresenter(_pseudoDb, new AdminService(_pseudoDb), new AdminView(admin)));
        }
        else
        {
            Console.WriteLine("Unsupported user role");
        }
    }
}
