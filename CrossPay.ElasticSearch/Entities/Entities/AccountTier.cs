using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrossPay.ElasticSearch.Entities
{
    public class AccountTier : BaseEntity 
    {  
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? MinAmount { get; set; } = 0;
        [Required]
        public decimal? MaxAmount { get; set; } = 0;
        [Required]
        public string RequiredDocuments { get; set; }
        //[Required]
        //public AccountTierEnum EnumValue { get; set; }

    }
}
