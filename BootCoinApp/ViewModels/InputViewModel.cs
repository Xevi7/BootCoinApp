using BootCoinApp.Models;

namespace BootCoinApp.ViewModels
{
    public class InputViewModel
    {
        public AppUser currentUser { get; set; }
        public IEnumerable<AppUser> users { get; set; }
        public int usersCount;
        //form
        public IEnumerable <Group> groups { get; set; }
        public IEnumerable<Event> events { get; set; }
        public IEnumerable<Activeness> activenesses { get; set; }
    }
}
