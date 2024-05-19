using System;
using System.Collections.Generic;
using System.Text;


namespace CrossPay.ElasticSearch.Entities
{
    public class WalletConversion : BaseEntity<Guid>
    {
        public string FromWalletID { get; set; }
        public string SourceAccountName { get; set; }
        public string ToWalletID { get; set; }
        public string DestinationAccountName { get; set; }
        public decimal SourceAmount { get; set; }
        public string SourceCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public decimal PrevalentConversion { get; set; }
        public bool IsConfirmed { get; set; }
        public string ConfirmationID { get; set; }
    }
}
