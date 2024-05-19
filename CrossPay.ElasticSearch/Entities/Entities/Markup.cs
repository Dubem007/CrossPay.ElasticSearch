namespace CrossPay.ElasticSearch.Entities
{
    public class Markup : BaseEntity
    {
        public decimal Percentage { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public string Currency { get; set; }
    }
}
