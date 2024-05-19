using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{
    public class Relationships: BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
