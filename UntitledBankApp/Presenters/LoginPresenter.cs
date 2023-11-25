using UntitledBankApp.Factories;

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
                Console.SetCursorPosition(44, 27);
                Console.WriteLine("\u001b[31mInvalid credentials. Please try again.\u001b[0m");
            }
        }

        if (user != null)
        {
            RedirectUserBasedOnRole(user);
        }
        else
        {
            Console.SetCursorPosition(44, 27);

            Console.WriteLine("\u001b[31mMaximum login attempts reached. Exiting...\u001b[0m");
        }
    }

    private void RedirectUserBasedOnRole(User user)
    {
        if (user is Client client)
        {
            var clientPresenter = new ClientPresenter(_pseudoDb);
            clientPresenter.HandlePresenter();
        }
        else if (user is Admin admin)
        {
            RunPresenter(new AdminPresenter(_pseudoDb, new AdminService(_pseudoDb), new AdminView(admin)));
        }
        else
        {
            Console.SetCursorPosition(44, 27);
            Console.WriteLine("\u001b[31mUnsupported user role.\u001b[0m");
        }
    }

}