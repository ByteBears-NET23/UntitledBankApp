using UntitledBankApp;
using UntitledBankApp.Views;

public class AdminPresenter : Presenter
{
    private PseudoDb _pseudoDb;
    private AdminService _adminService;
    private AdminView _adminView;

    public AdminPresenter(PseudoDb pseudoDb, AdminService adminService, AdminView adminView)
    {
        _pseudoDb = pseudoDb;
        _adminService = adminService;
        _adminView = adminView;
    }

    public override void HandlePresenter()
    {
        _adminView.ShowMessage("Welcome to the Admin Panel!");

        int adminChoice;
        do
        {
            adminChoice = _adminView.GetAdminChoice();

            // Perform the selected action
            switch (adminChoice)
            {
                case 1:
                    HandleCreateUser();
                    break;
                case 2:
                    HandleSetCurrencyRate();
                    break;
                case 3:
                    _adminView.ShowMessage("Going back...");
                    break;
                default:
                    _adminView.ShowMessage("Invalid choice. Please select a valid option.");
                    break;
            }
        } while (adminChoice != 3);
    }

    private void HandleCreateUser()
    {
        try
        {
            _adminView.GetUserInputForNewUser(out Role role, out string fullName, out string username, out string password);
            bool createUserResult = _adminService.CreateUser(role, fullName, username, password);
            _adminView.UpdateUserCreationResult(createUserResult);
        }
        catch (Exception ex)
        {
            _adminView.ShowMessage($"Error: {ex.Message}");
        }
    }

    private void HandleSetCurrencyRate()
    {
        try
        {
            _adminView.GetUserInputForSettingCurrencyRate(out CurrencyCode currencyCode, out float rate);
            _adminService.SetCurrencyRate(currencyCode, rate);
            _adminView.UpdateCurrencyRateResult(true);
        }
        catch (KeyNotFoundException ex)
        {
            _adminView.ShowMessage($"Error: {ex.Message}");
            _adminView.UpdateCurrencyRateResult(false);
        }
    }
}
