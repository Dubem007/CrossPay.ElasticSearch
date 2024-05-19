using System;
using System.Collections.Generic;
using System.Text;


namespace CrossPay.ElasticSearch.Entities
{
    public class WalletTransactionConfigurations : BaseEntity<Guid>
    {
        public long WalletId { get; set; }
        public long WalletConfigurationId { get; set; }
        public WalletConfiguration WalletConfiguration { get; set; }
        public long WalletTransactionConfigurationId { get; set; }
        public TransactionConfiguration WalletTransactionConfiguration { get; set; }
    }
}
