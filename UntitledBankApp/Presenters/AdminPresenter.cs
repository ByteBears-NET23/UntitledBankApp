using UntitledBankApp.Services;
using UntitledBankApp.Views;

namespace UntitledBankApp.Presenters;

public class AdminPresenter : Presenter
{
    private AdminService _adminService;
    private AdminView _adminView;

    public AdminPresenter(AdminService adminService, AdminView adminView)
    {
        _adminService = adminService;
        _adminView = adminView;
    }

    public override void RunView()
    {
        _adminView.DisplayHeader();
    }
}