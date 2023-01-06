using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface IActivenessRepository
    {
        Task<IEnumerable<Activeness>> GetAll();
        bool save();
    }
}
