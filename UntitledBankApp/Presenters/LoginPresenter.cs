using UntitledBankApp.Models;
using UntitledBankApp.Services;
using UntitledBankApp.Views;

namespace UntitledBankApp.Presenters;

public class LoginPresenter : IPresenter
{
    private LoginService _loginService;
    private LoginView _loginView;

    public LoginPresenter(LoginService loginService, LoginView loginView)
    {
        _loginService = loginService;
        _loginView = loginView;
    }

    public void RunView()
    {
        _loginView.DisplayHeader();

        var username = _loginView.GetUsername();
        var password = _loginView.GetPassword();
        var user = _loginService.GetUser(username, password);

        if (user != null)
        {
            switch (user)
            {
                case Client client:
                    var clientPresenter = new ClientPresenter(new ClientService(), new ClientView(client));
                    clientPresenter.RunView();
                    break;
                case Admin admin:
                    var adminPresenter = new AdminPresenter(new AdminService(), new AdminView(admin));
                    adminPresenter.RunView();
                    break;
            }
        }
    }
}