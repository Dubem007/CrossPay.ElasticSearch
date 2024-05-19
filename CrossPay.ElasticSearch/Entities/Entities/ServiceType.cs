namespace CrossPay.ElasticSearch.Entities
{
    public class ServiceType : BaseEntity
    {
        public string ServiceTypes { get; set; }
        public string Currency { get; set; }
        public string Provider { get; set; }
        public string Country { get; set; }
    }
   
}
