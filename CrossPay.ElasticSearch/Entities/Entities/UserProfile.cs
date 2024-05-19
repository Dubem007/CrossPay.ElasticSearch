using System;

namespace CrossPay.ElasticSearch.Entities

{
    public class UserProfile : BaseEntity
    {       
        public string? SSOUserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }


    }
}
