using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsFromIdAsync(string id);

        Task<Transaction> GetLatestTransactionByIdAsync(string id);

        bool save();
    }
}
