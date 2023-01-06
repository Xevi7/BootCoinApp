using System.ComponentModel.DataAnnotations;

namespace BootCoinApp.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string EventName { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
