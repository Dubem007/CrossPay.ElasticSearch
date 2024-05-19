using System;
using System.Collections.Generic;
using System.Text;


namespace CrossPay.ElasticSearch.Entities
{
    public class TransactionConfiguration : BaseEntity<long>
    {
        public decimal MaxTransactionLimit { get; set; }
        public decimal MaxWalletLimit { get; set; }
    }
}
