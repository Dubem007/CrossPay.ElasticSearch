using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossPay.ElasticSearch.Entities
{
  public class OutboundTransaction : BaseEntity
  {
    [Required]
    public long UserId { get; set; }
    [Required]
    public Guid WalletId { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal DebitAmount { get; set; }
    [Required]
    public string DebitCurrency { get; set; } = string.Empty;
    [Required]
    public double ProviderRate { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,3)")]
    public decimal Margin { get; set; } //crossborda margin
    [Required]
    [Column(TypeName = "decimal(18,3)")]
    public decimal Rate { get; set; } //crossborda margin
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal CreditAmount { get; set; }
    [Required]
    public string CreditCurrency { get; set; } = string.Empty;
    public string DescriptionText { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string BankAccountNumber { get; set; } = string.Empty;
    public string SortCode { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string Banksubcode { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public string RecepientFirstname { get; set; } = string.Empty;
    public string RecepientLastname { get; set; } = string.Empty;
    public string RecepientPhoneNumber { get; set; } = string.Empty;
    public string RecepientAddress { get; set; } = string.Empty;
    public string RecepientDateOfBirth { get; set; } = string.Empty;
    public string RecepientNationality { get; set; } = string.Empty;
    public string RecepientCity { get; set; } = string.Empty;
    public string RecepientCountry { get; set; } = string.Empty;
    public string RecepientIdType { get; set; } = string.Empty;
    public string RecepientIdNumber { get; set; } = string.Empty;
    public string ReceivingCountry { get; set; } = string.Empty;
    public string RemittancePurpose { get; set; } = string.Empty;
    public string SourceOfFunds { get; set; } = string.Empty;
    public string RelationshipSender { get; set; } = string.Empty;
    public string QuoteId { get; set; } = string.Empty;
    public double TransactionFee { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.Now;
    public string CrossbordaTransactionReference { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty;
    public string TransactionStatus { get; set; } = string.Empty;
    [Required]
    public string TransactionReference { get; set; } = string.Empty;
    [Required]
    public string RequestPayload { get; set; }
    [Required]
    public DateTime RequestTime { get; set; }
    public string Response { get; set; }
    public DateTime ResponseTime { get; set; }
  }
}
