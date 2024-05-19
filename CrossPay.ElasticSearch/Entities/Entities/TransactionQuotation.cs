using System;

namespace CrossPay.ElasticSearch.Entities
{
    public class TransactionQuotation : BaseEntity
    {
        public string QuoteId { get; set; } = string.Empty;
        public string QuotationStatus { get; set; } = string.Empty;
        public string QuotationExpiryTime { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public decimal DebitAmount { get; set; }
        public string DebitCurrency { get; set; } = string.Empty;
        public decimal CreditAmount { get; set; }
        public string CreditCurrency { get; set; } = string.Empty;
        public Guid WalletId { get; set; }
        public string RequestDate { get; set; } = string.Empty;
        public decimal TransactionFee { get; set; }
    }
}
