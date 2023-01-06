using System.ComponentModel.DataAnnotations;

namespace BootCoinApp.Models
{
    public class Activeness
    {
        [Key]
        public int Id { get; set; }
        public string ActivenessName { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
