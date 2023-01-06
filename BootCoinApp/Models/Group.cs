using System.ComponentModel.DataAnnotations;

namespace BootCoinApp.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<AppUser> users { get; set; }
    }
}
