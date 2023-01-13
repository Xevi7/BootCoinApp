using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BootCoinApp.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsFromIdAsync(string id)
        {
            return await _context.Transactions
                .Where(i => i.UserId == id)
                .Include(i => i.User)
                .Include(i => i.Receiver)
                .ThenInclude(i => i.Group)
                .Include(i => i.Receiver)
                .ThenInclude (i => i.Position)
                .OrderByDescending(i => i.Date)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Transaction>> SearchTransactionsFromIdAsync(string id, string search)
        {
            return await _context.Transactions
                .Where(i => i.UserId == id)
                .Include(i => i.User)
                .Include(i => i.Receiver)
                .ThenInclude(i => i.Group)
                .Include(i => i.Receiver)
                .ThenInclude (i => i.Position)
                .Where(i => i.Receiver.UserName.Contains(search))
                .OrderByDescending(i => i.Date)
                .ToListAsync();

        }

        public async Task<Transaction> GetLatestTransactionByIdAsync(string id) 
        {
            return await _context.Transactions
                .Include(i => i.Activeness)
                .OrderByDescending(i => i.Date)
                .FirstOrDefaultAsync(i => i.ReceiverId == id);
        }

        public bool save()
        {
            throw new NotImplementedException();
        }
    }
}
