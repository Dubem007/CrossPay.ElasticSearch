using System;
using System.ComponentModel.DataAnnotations;

namespace CrossPay.ElasticSearch.Entities

{
    public class ResetToken : BaseEntity
    {
        [Required]
        public string SSOUserId { get; set; }
         [Required]
        public string Token { get; set; }
        [Required]
        public DateTime Expiry { get; set; }
    }
}
