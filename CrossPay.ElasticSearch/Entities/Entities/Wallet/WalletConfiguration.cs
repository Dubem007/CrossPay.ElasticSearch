using System;
using System.Collections.Generic;
using System.Text;


namespace CrossPay.ElasticSearch.Entities
{
    public class WalletConfiguration : BaseEntity<Guid>
    {
        public decimal MaximumBalance { get; set; }
        public decimal MinimumBalance { get; set; }
        public bool Overdraft { get; set; }
    }
}
