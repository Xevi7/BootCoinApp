using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCoinApp.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        [ForeignKey("AppUser")]
        public string ReceiverId { get; set; }
        public AppUser Receiver { get; set; }
        public DateTime Date { get; set; }
        public int amount { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [ForeignKey("Activeness")]
        public int ActivenessId { get; set; }
        public Activeness Activeness { get; set; }
    }
}
