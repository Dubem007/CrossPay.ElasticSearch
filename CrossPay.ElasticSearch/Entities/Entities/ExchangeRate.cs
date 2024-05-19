using System.ComponentModel.DataAnnotations.Schema;

namespace CrossPay.ElasticSearch.Entities
{
    public class ExchangeRate : BaseEntity
    {
        public string BaseCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal ProviderRate { get; set; } // black 1000
        [Column(TypeName = "decimal(18,3)")]
        public decimal Margin { get; set; } // --> this is our margin 02
    }
}
