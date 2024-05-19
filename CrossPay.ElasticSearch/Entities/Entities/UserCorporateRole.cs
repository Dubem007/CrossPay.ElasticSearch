using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{
    public class UserCorporateRole : BaseEntity
    {
        public string UserId { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; } = true;
        [ForeignKey("RoleId")]
        public UserRole Role { get; set; }
    }
}
