namespace UntitledBankApp.Services;

public class AdminService
{
    private PseudoDb _pseudoDb;
    
    public AdminService(PseudoDb pseudoDb)
    {
        _pseudoDb = pseudoDb;
    }
}