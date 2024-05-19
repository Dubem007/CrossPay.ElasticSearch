using System;
using System.ComponentModel.DataAnnotations;

namespace CrossPay.ElasticSearch.Entities
{
    public class InAppNotification : BaseEntity
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public bool HasBeenRead { get; set; }
    }
}
