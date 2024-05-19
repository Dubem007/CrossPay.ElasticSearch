using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{
    public class AppConfig : BaseEntity
    {

        [Required]
        [StringLength(100)]
        public string ItemKey { get; set; }

        [Required]
        [StringLength(400)]
        public string ItemValue { get; set; }

        [StringLength(800)]
        public string Description { get; set; }
    }
}
