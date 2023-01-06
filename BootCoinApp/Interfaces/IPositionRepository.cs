using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAll();
        bool save();
    }
}
