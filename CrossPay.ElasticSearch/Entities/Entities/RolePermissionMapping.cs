namespace CrossPay.ElasticSearch.Entities
{
    public partial class RolePermissionMapping : BaseEntity
    {
        public long UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
        public long PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanRead { get; set; }
        public bool CanDelete { get; set; }

    }
}
