using System.ComponentModel.DataAnnotations;

namespace CrossPay.ElasticSearch.Entities
{
    public class EmailHistory : BaseEntity
    {
        [Required]
        public string MailFrom { get; set; }
        [Required]
        public string MailTo { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public bool WasSent { get; set; }
    }
}
