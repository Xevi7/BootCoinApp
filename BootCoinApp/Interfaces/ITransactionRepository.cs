using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsFromIdAsync(string id, string sortTypes);
        Task<IEnumerable<Transaction>> SearchTransactionsFromIdAsync(string id, string search, string sortTypes);
        Task<Transaction> GetLatestTransactionByIdAsync(string id);
        bool Add(Transaction transaction);
        bool Delete(Transaction transaction);
        bool save();
    }
}
