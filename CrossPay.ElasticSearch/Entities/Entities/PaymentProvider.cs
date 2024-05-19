using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{
    public class PaymentProvider : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
