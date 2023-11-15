namespace UntitledBankApp.Presenters;

public abstract class Presenter
{
    public abstract void RunView();

    protected void RunPresenter(Presenter presenter)
    {
        presenter.RunView();
    }
}