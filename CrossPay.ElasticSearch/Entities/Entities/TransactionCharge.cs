using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{
    public class TransactionCharge : BaseEntity
    {
        public string Currency { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Charge { get; set; }
        public string DestinationCurrency { get; set; }

    }
}
