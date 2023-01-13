using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsFromIdAsync(string id);
        Task<IEnumerable<Transaction>> SearchTransactionsFromIdAsync(string id, string search);

        Task<Transaction> GetLatestTransactionByIdAsync(string id);

        bool save();
    }
}
