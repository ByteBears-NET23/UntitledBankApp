namespace UntitledBankApp.Presenters;

public abstract class Presenter
{
    public abstract void HandlePresenter();

    protected void RunPresenter(Presenter presenter)
    {
        presenter.HandlePresenter();
    }
}