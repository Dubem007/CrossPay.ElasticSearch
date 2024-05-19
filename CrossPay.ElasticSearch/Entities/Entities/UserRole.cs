using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{

    public partial class UserRole : BaseEntity
    {
        public UserRole()
        {
            RolePermissionMappings = new HashSet<RolePermissionMapping>();
        }

        public string Name { get; set; }
        public string VggroleName { get; set; }
        //public bool IsActive { get; set; }
        public virtual ICollection<RolePermissionMapping> RolePermissionMappings { get; set; }
    }

}
