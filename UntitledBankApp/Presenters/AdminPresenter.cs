using UntitledBankApp.Services;
using UntitledBankApp.Views;

namespace UntitledBankApp.Presenters;

public class AdminPresenter : IPresenter
{
    private AdminService _adminService;
    private AdminView _adminView;

    public AdminPresenter(AdminService adminService, AdminView adminView)
    {
        _adminService = adminService;
        _adminView = adminView;
    }

    public void RunView()
    {
        _adminView.DisplayHeader();
    }
}