using CrossPay.ElasticSearch.Entities.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Repositories.Interfaces
{
    public interface IElasticSearchService
    {
        Task<bool> AddRecord(IndexModel model);
        Task<IndexModel?> GetRecord(string key);
        Task<bool> UpdateRecord(IndexModel model);
        Task<bool> DeleteRecord(string key);
    }
}
