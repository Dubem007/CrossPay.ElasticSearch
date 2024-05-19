using CrossPay.ElasticSearch.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Entities.Indexes
{
    public class FailedTransactionIndex
    {
        public long Id { get; set; }
        public Guid WalletId { get; set; }
        public string? SourceAccount { get; set; }
        public string? SourceAccountName { get; set; }
        public string? SourceCurrency { get; set; }
        public string? DestinationAccount { get; set; }
        public string? DestinationAccountName { get; set; }
        public string? DestinationInstitutionName { get; set; }
        public string? DestinationCurrency { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string? Narration { get; set; }
        public string? TransactionStatus { get; set; }
        public string? TransactionStatusDescription { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? DestinationBankCode { get; set; }
        public string? DestinationBankName { get; set; }
        public TransactionType? TransactionType { get; set; }
        public OperationType? OperationType { get; set; }
        public string? Provider { get; set; }
        public long? UserId { get; set; }
        public decimal? DebitAmount { get; set; } = 0;
        [Required]
        public string? DebitCurrency { get; set; } = string.Empty;
        public decimal? CreditAmount { get; set; } = 0;
        [Required]
        public string? CreditCurrency { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public string? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public UserProfile UserDetails { get; set; }
    }
}
