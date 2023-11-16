namespace UntitledBankApp.Services;

public class ClientService
{
    private PseudoDb _pseudoDb;
    
    public ClientService(PseudoDb pseudoDb)
    {
        _pseudoDb = pseudoDb;
    }
}