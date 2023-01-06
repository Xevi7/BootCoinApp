using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser> GetByIdAsync(string id);
        bool save();
    }
}
