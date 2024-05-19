using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrossPay.ElasticSearch.Entities
{
    public class Wallet : BaseEntity<Guid>
    {
        // public long? MifosClientId { get; set; }
        // public string MifosExternalId { get; set; }
        // public long? MifosWalletId { get; set; }
        public string AccountName { get; set; }
        // public string AccountNumber { get; set; }
        public string AccountOpeningDate { get; set; }
        public string AccountType { get; set; }
        public string LastTransactionDate { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string KYCLevel { get; set; }
        public bool KYCValidated { get; set; }
        public long UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public UserProfile UserProfile { get; set; }
        public bool Active { get; set; }


        [ConcurrencyCheck]
        [Column(TypeName = "decimal(18,4)")]
        public decimal AvailableBalance { get; set; } = 0;

        [ConcurrencyCheck]
        [Column(TypeName = "decimal(18,4)")]
        public decimal BookBalance { get; set; }


        [ConcurrencyCheck]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PreviousBalance { get; set; } = 0;

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
