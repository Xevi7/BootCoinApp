namespace BootCoinApp.Interfaces
{
    public interface Transaction
    {
        IEnumerable<Transaction> GetTransactionsFromIdAsync(string id);

        bool save;
    }
}
