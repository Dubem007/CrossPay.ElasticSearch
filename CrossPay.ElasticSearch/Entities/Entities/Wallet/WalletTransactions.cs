using CrossPay.ElasticSearch.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossPay.ElasticSearch.Entities
{
    public class WalletTransaction : BaseEntity<Guid>
    {
        public Guid Id { get; set; }
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
        public string? TransactionTypeDescription { get; set; }
        public long? DestinationWalletId { get; set; }
        public string? ProcessingStatus { get; set; }
        public string? ProviderReference { get; set; }
        public string? ResponseMessage { get; set; }
        public string? Provider { get; set; }
        public string? ProviderResponseCode { get; set; }
        public string? ProviderResponseMessage { get; set; }

        //update
        [Column(TypeName = "decimal(18,3)")]
        public decimal? Rate { get; set; }
        [ConcurrencyCheck]
        [Column(TypeName = "decimal(18,4)")]
        public decimal? AvailableBalance { get; set; } = 0;
        [ConcurrencyCheck]
        [Column(TypeName = "decimal(18,4)")]
        public decimal? BookBalance { get; set; }
        [ConcurrencyCheck]
        [Column(TypeName = "decimal(18,4)")]
        public decimal? PreviousBalance { get; set; } = 0;
        //merge from with outbound transaction
        public long? UserId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DebitAmount { get; set; } = 0;
        [Required]
        public string? DebitCurrency { get; set; } = string.Empty;
        [Required]
        public double? ProviderRate { get; set; } = 0;
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal? Margin { get; set; } = 0;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CreditAmount { get; set; } = 0;
        [Required]
        public string? CreditCurrency { get; set; } = string.Empty;
        public string? DescriptionText { get; set; } = string.Empty;
        public string? BankAccountNumber { get; set; } = string.Empty;
        public string? SortCode { get; set; } = string.Empty;
        public string? BankName { get; set; } = string.Empty;
        public string? Banksubcode { get; set; } = string.Empty;
        public string? AccountType { get; set; } = string.Empty;
        public string? RecepientFirstname { get; set; } = string.Empty;
        public string? RecepientLastname { get; set; } = string.Empty;
        public string? RecepientPhoneNumber { get; set; } = string.Empty;
        public string? RecepientAddress { get; set; } = string.Empty;
        public string? RecepientDateOfBirth { get; set; } = string.Empty;
        public string? RecepientNationality { get; set; } = string.Empty;
        public string? RecepientCity { get; set; } = string.Empty;
        public string? RecepientCountry { get; set; } = string.Empty;
        public string? RecepientIdType { get; set; } = string.Empty;
        public string? RecepientIdNumber { get; set; } = string.Empty;
        public string? ReceivingCountry { get; set; } = string.Empty;
        public string? RemittancePurpose { get; set; } = string.Empty;
        public string? SourceOfFunds { get; set; } = string.Empty;
        public string? RelationshipSender { get; set; } = string.Empty;
        public string? QuoteId { get; set; } = string.Empty;
        public double? TransactionFee { get; set; }
        public string? CrossbordaTransactionReference { get; set; } = string.Empty;
        public string? RequestPayload { get; set; } = "";
        public DateTime? RequestTime { get; set; }
        public string? Response { get; set; }
        public DateTime? ResponseTime { get; set; }
        public string? RequeryResponse { get; set; }
    }

}
