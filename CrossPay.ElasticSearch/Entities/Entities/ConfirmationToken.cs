using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{
    public class ConfirmationToken : BaseEntity
    {
        public string TokenId { get; set; }
        public string SSOToken { get; set; }
    }
}
