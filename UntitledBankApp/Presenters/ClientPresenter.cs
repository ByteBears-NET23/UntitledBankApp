using UntitledBankApp.Services;
using UntitledBankApp.Views;

namespace UntitledBankApp.Presenters;

public class ClientPresenter : Presenter
{
    private PseudoDb _pseudoDb;
    private ClientService _clientService;
    private ClientView _clientView;

    public ClientPresenter(PseudoDb pseudoDb, ClientService clientService, ClientView clientView)
    {
        _pseudoDb = pseudoDb;
        _clientService = clientService;
        _clientView = clientView;
    }

    public override void HandlePresenter()
    {
        throw new NotImplementedException();
    }
}