using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using DocumentFormat.OpenXml.Spreadsheet;
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

        public async Task<IEnumerable<Transaction>> GetTransactionsFromIdAsync(string id, string sortTypes)
        {
            var transactions = _context.Transactions
                .Where(i => i.UserId == id)
                .Include(i => i.User)
                .Include(i => i.Receiver)
                .ThenInclude(i => i.Group)
                .Include(i => i.Receiver)
                .ThenInclude(i => i.Position);

            if (sortTypes.Equals("BootCoin"))
            {
                return await transactions.OrderBy(i => i.Receiver.BootCoin)
                            .ThenByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
            else if (sortTypes.Equals("FullName ASC"))
            {
                return await transactions.OrderBy(i => i.Receiver.FullName)
                            .ThenByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
            else if (sortTypes.Equals("FullName DESC"))
            {
                return await transactions.OrderByDescending(i => i.Receiver.FullName)
                            .ThenByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
            else if(sortTypes.Equals("GroupId"))
            {
                return await transactions.OrderBy(i => i.Receiver.GroupId)
                            .ThenByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
            else
            {
                return await transactions.OrderByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
        }
        
        public async Task<IEnumerable<Transaction>> SearchTransactionsFromIdAsync(string id, string search, string sortTypes)
        {
            var transactions = _context.Transactions
                .Where(i => i.UserId == id)
                .Include(i => i.User)
                .Include(i => i.Receiver)
                .ThenInclude(i => i.Group)
                .Include(i => i.Receiver)
                .ThenInclude(i => i.Position)
                .Where(i => i.Receiver.FullName.Contains(search));

            if (sortTypes.Equals("BootCoin"))
            {
                return await transactions.OrderBy(i => i.Receiver.BootCoin)
                            .ThenByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
            else if (sortTypes.Equals("FullName ASC"))
            {
                return await transactions.OrderBy(i => i.Receiver.FullName)
                            .ThenByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
            else if (sortTypes.Equals("FullName DESC"))
            {
                return await transactions.OrderByDescending(i => i.Receiver.FullName)
                            .ThenByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
            else if (sortTypes.Equals("GroupId"))
            {
                return await transactions.OrderBy(i => i.Receiver.GroupId)
                            .ThenByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
            else
            {
                return await transactions.OrderByDescending(i => i.Date)
                            .ThenByDescending(i => i.Id)
                            .ToListAsync();
            }
        }

        public async Task<Transaction> GetLatestTransactionByIdAsync(string id) 
        {
            return await _context.Transactions
                .Include(i => i.Activeness)
                .OrderByDescending(i => i.Date)
                .ThenByDescending(i => i.Id)
                .FirstOrDefaultAsync(i => i.ReceiverId == id);
        }

        public bool Add(Transaction transaction)
        {
            _context.Add(transaction);
            return save();
        }
        
        public bool Delete(Transaction transaction)
        {
            _context.Remove(transaction);
            return save();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
