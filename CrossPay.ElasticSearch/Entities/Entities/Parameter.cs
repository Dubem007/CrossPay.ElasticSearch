using CrossPay.ElasticSearch;
using CrossPay.ElasticSearch.Entities;

namespace CrossPay.ElasticSearch.Entities 
{
    public class Parameter : BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Env { get; set; } 
    }

}
