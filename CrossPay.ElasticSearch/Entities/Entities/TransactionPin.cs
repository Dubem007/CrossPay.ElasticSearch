using System.ComponentModel.DataAnnotations;

namespace CrossPay.ElasticSearch.Entities
{
    public class TransactionPin : BaseEntity 
    { 
        [Required]
        public long UserId { get; set; }
        [Required]
        public string Pin { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int RetryCount { get; set; } = 0;
    }
}
