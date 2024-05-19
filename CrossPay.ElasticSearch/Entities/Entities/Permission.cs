using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{ 
    public partial class Permission : BaseEntity
    {
        public Permission()
        {
             
            RolePermissionMappings = new HashSet<RolePermissionMapping>();
        }

        public string Name { get; set; }
        public string VggRoleName { get; set; }
     
        public virtual ICollection<RolePermissionMapping> RolePermissionMappings { get; set; }
    }
}
