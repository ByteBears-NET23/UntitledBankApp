namespace UntitledBankApp.Models;

public enum Status
{
    Pending,
    Completed,
    Failed
}

public class Transfer
{
    public Status Status { get; set; }
    public Account From { get; set; }
    public Account To { get; set; }
    public Balance Balance { get; set; }

    public Transfer(Account from, Account to, Balance balance)
    {
        Status = Status.Pending;
        From = from;
        To = to;
        Balance = balance;
    }
}