namespace UntitledBankApp.Presenters;

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
        new AdminView(new Admin("AdminFullName", "AdminUsername", "AdminPassword"))
               .ShowAdminMenu();

        Console.WriteLine("Enter your choice: ");
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            new AdminView(new Admin("AdminFullName", "AdminUsername", "AdminPassword"))
                .HandleAdminInput(choice, new AdminService(new PseudoDb()));
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.\n");
        }
    }
}
