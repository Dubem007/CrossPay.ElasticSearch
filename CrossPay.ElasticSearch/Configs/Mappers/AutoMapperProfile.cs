
using CrossPay.ElasticSearch.Entities;
using CrossPay.ElasticSearch.Entities.Indexes;

namespace CrossPay.ElasticSearch.Services.Configs.Mappers
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserProfile, ActiveUserProfileIndex>().ReverseMap();
            CreateMap<UserProfile, InActiveUserProfileIndex>().ReverseMap(); 
            CreateMap<UserProfile, UserProfileIndex>().ReverseMap();
            CreateMap<WalletTransactions, SuccessfulTransactionIndex>().ReverseMap();
            CreateMap<WalletTransactions, FailedTransactionIndex>().ReverseMap();
        }
    }
}
