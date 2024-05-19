using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{
    public class TransferRate : BaseEntity
    {
        public string BaseCurrency { get; set; }
        public string Currency { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal BlackMarketRate { get; set; }
        public decimal MarkUp { get; set; }
        public decimal FinalRate { get; set; }
    }
}
