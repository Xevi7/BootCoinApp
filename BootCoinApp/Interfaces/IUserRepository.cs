using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<IEnumerable<AppUser>> GetAllInternExceptIdAsync(string id);
        Task<AppUser> GetByIdAsync(string id);
        bool save();
    }
}
