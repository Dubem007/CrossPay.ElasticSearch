using System.ComponentModel.DataAnnotations;

namespace CrossPay.ElasticSearch.Entities
{
    public class AmlTransaction : BaseEntity 
    { 
        [Required]
        public string RequestPayloadString { get; set; }
        public string ResponseString { get; set; }
        public bool Status { get; set; }
        public string AmlReference { get; set; }
        public string TransactionReference { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

    }
}
