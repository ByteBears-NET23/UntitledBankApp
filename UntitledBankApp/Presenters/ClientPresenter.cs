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
        PseudoDb pseudoDb = new PseudoDb(); // 
        Client client = new Client("ClientFullName", "ClientUsername", "ClientPassword");

       
        ClientService clientService = new ClientService(pseudoDb);
        ClientView clientView = new ClientView(client, clientService);

        clientView.DisplayClientMenu();
    }
}
