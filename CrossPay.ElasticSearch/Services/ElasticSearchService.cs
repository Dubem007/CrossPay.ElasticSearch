using CrossPay.ElasticSearch.Entities.Indexes;
using CrossPay.ElasticSearch.Exceptions;
using CrossPay.ElasticSearch.Repositories.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Services
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly ElasticClient _elasticClient;
        public ElasticSearchService(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<bool> AddRecord(IndexModel model)
        {
            if (string.IsNullOrEmpty(model.Key) || string.IsNullOrEmpty(model.Value))
            {
                throw new NotSuccessfulException("Invalid Payload");
            }
            var query = await _elasticClient.IndexDocumentAsync(model);

            if (!query.IsValid)
            {
                // Handle errors
                var debugInfo = query.DebugInformation;
                var error = query.ServerError?.Error;
            }
            return query.IsValid;
        }

        public async Task<bool> DeleteRecord(string key)
        {
            var record = await GetRecord(key);
            if (record != null)
            {
                var query = await _elasticClient.DeleteAsync<IndexModel>(record);

                if (!query.IsValid)
                {
                    // Handle errors
                    var debugInfo = query.DebugInformation;
                    var error = query.ServerError?.Error;
                }
                return query.IsValid;
            }
            return false;
        }

        public async Task<IndexModel?> GetRecord(string key)
        {
            var query = await _elasticClient.SearchAsync<IndexModel>(s => s
                                            .Index("index")
                                            .Query(q => q.Term(t => t.Key, key) ||
                                                      q.Match(m => m
                                            .Field(f => f.Key)
                                            .Query(key))));

            if (!query.IsValid)
            {
                // Handle errors
                var debugInfo = query.DebugInformation;
                var error = query.ServerError?.Error;
            }

            var record = query.Documents?.FirstOrDefault(x => x.Key.Equals(key));
            return record;
        }

        public async Task<bool> UpdateRecord(IndexModel model)
        {

            if (string.IsNullOrEmpty(model.Key) || string.IsNullOrEmpty(model.Value))
            {
                throw new NotSuccessfulException("Invalid Payload");
            }
            var record = await GetRecord(model.Key);
            if (record != null)
            {
                record.Value = model.Value;
                var query = await _elasticClient.UpdateAsync<IndexModel>(record.Id, u => u.Index("index").Doc(record));

                if (!query.IsValid)
                {
                    // Handle errors
                    var debugInfo = query.DebugInformation;
                    var error = query.ServerError?.Error;
                }
                return query.IsValid;
            }
            return false;
        }
    }
}
