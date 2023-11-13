using UntitledBankApp.Services;
using UntitledBankApp.Views;

namespace UntitledBankApp.Presenters;

public class ClientPresenter : IPresenter
{
    private ClientService _clientService;
    private ClientView _clientView;

    public ClientPresenter(ClientService clientService, ClientView clientView)
    {
        _clientService = clientService;
        _clientView = clientView;
    }

    public void RunView()
    {
        _clientView.DisplayHeader();
    }
}