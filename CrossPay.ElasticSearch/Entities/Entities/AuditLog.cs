using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPay.ElasticSearch.Entities
{
    public class AuditLog : BaseEntity
    {
        public string Email { get; set; }
        public string ControllerName { get; set; }
        public string Action { get; set; }
        public string Entity { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string AffectedColumn { get; set; }
        //public string Username { get; set; }
        //public string Details { get; set; }
        //public int Auditgroup { get; set; }
        //public string IPAddress { get; set; }
        //public int AuditAction { get; set; }
        //public string Country { get; set; }
        //public long EntityId { get; set; }
        //public string EntityName { get; set; }


    }
}
