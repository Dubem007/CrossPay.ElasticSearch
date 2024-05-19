using AutoMapper;
using CrossPay.ElasticSearch.Configs.Mappers;
using CrossPay.ElasticSearch.Data;
using CrossPay.ElasticSearch.Entities;
using CrossPay.ElasticSearch.Entities.Documents;
using CrossPay.ElasticSearch.Entities.Dtos;
using CrossPay.ElasticSearch.Entities.Indexes;
using CrossPay.ElasticSearch.Repositories;
using CrossPay.ElasticSearch.Repositories.Interfaces;
using CrossPay.ElasticSearch.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CrossPay.ElasticSearch.Services
{
    public class ElastricSearchUpdaterService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IWalletTransactionRepository _walletRepo;
        private readonly ElasticClient _elasticClient;
        private readonly IMapper _mapper;
        private readonly ILoggerService _log;

        public ElastricSearchUpdaterService(IServiceProvider serviceProvider, IWalletTransactionRepository walletRepo, ILoggerService log, ElasticClient elasticClient, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _walletRepo = _walletRepo;
            _elasticClient = elasticClient;
            _mapper = mapper;
            _log = log;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<CrossBordaDbContext>();
                    DateTime thirtyDaysAgo = DateTime.Today.AddDays(-60);
                    await UpdateElasticSearchAsync(dbContext, thirtyDaysAgo, stoppingToken);
                }
                

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Adjust the delay as needed
            }
        }

        private async Task UpdateElasticSearchAsync(CrossBordaDbContext dbContext, DateTime thirtyDaysAgo, CancellationToken stoppingToken)
        {
            try
            {
                _log.LogInfo("About to process transaction status update ..");
                // await ClearAllIndicesAndDocuments();
                await UpdateWalletTransactionsAsync(dbContext, thirtyDaysAgo, stoppingToken);
                await UpdateTotalUsersAsync(dbContext, thirtyDaysAgo, stoppingToken);
                await GetSuccessfulRecord();
                await GetFailedRecord();
                await GetAllActiveUsersRecord();
                await GetInActiveUsersRecord();
                await GetAllUsersRecord();

            }
            catch (Exception ex)
            {
                _log.LogError($"Unhandled exception in transaction status update: {ex.Message}");
            }
            
        }

        private async Task UpdateWalletTransactionsAsync(CrossBordaDbContext dbContext, DateTime lastIndexTime, CancellationToken stoppingToken)
        {
            var allTransactions = new BulkResponse();
            var bulkDescriptor = new BulkDescriptor();
            try
            {
                Console.WriteLine("About to process transaction status update ..");
                var thetransactions = dbContext.WalletTransactions.Where(x => x.TransactionDate > lastIndexTime).AsQueryable();
                var transactions = await thetransactions.ToListAsync();
                if (transactions.Count() == 0)
                {
                    Console.WriteLine("No new record of wallet transaction  ..");
                }
                else 
                {
                    var successfulTrans = transactions.Where(x => x.TransactionStatus != null && x.TransactionStatus.ToLower() == "success").Select(x=>x.Map()).ToList();
                    if (successfulTrans.Count() != 0)
                    {
                        foreach (var transaction in successfulTrans)
                        {
                            bulkDescriptor.Index<SuccessfulTransactionDocument>(op => op
                                .Document(transaction)
                                .Id(transaction.Id)
                                .Index(Constants.SuccessfulTransactionIndex));
                        }
                        allTransactions = await _elasticClient.BulkAsync(bulkDescriptor);

                        if (!allTransactions.IsValid)
                        {
                            _log.LogError("Failed to index successful transactions: {ErrorReason}", allTransactions.DebugInformation);
                        }
                    }
                    else 
                    {
                        _log.LogInfo("No record of successful trnasactions");
                    }

                    var failedTrans = transactions.Where(x => x.TransactionStatus != null && x.TransactionStatus.ToLower() == "failed").Select(x => x.MapFailed()).ToList();
                    if (failedTrans.Count() != 0)
                    {
                       
                        foreach (var transaction in failedTrans)
                        {
                            bulkDescriptor.Index<FailedTransactionDocument>(op => op
                                .Document(transaction)
                                .Id(transaction.Id)
                                .Index(Constants.FailedTransactionIndex));
                        }
                        allTransactions = await _elasticClient.BulkAsync(bulkDescriptor);

                        if (!allTransactions.IsValid)
                        {
                            _log.LogError("Failed to index failed ransactions: {ErrorReason}", allTransactions.DebugInformation);
                        }
                       
                    }
                    else
                    {
                        _log.LogInfo("No record of failed trnasactions");
                    }

                    var userIds = transactions.Select(x => x.UserId).ToList();
                    List<long> nonNullableList = userIds.Where(x => x.HasValue).Select(x => x.Value).ToList();

                    await UpdateActiveUsersAsync(dbContext, nonNullableList, lastIndexTime, stoppingToken);
                    await UpdateInActiveUsersAsync(dbContext, nonNullableList, lastIndexTime, stoppingToken);

                }
            }
            catch (Exception ex)
            {
                _log.LogError($"Unhandled exception in wallet transaction update: {ex.Message}, with elastic search error {allTransactions.ServerError.Error}");
            }

        }


        public async Task UpdateTotalUsersAsync(CrossBordaDbContext dbContext, DateTime lastIndexTime, CancellationToken stoppingToken)
        {
            var allTransactions = new BulkResponse();
            var bulkDescriptor = new BulkDescriptor();
            try
            {
                var activeUsersrecords = dbContext.UserProfile.Where(x => x.CreatedDate > lastIndexTime).AsQueryable();
                var allUsersrecords = await activeUsersrecords.Select(x => x.MapAllUsersProfiles()).ToListAsync();
                if (allUsersrecords.Count() == 0)
                {
                    _log.LogInfo("No new acotive users on wallet transaction  ..");
                }
                else
                {
                    foreach (var transaction in allUsersrecords)
                    {
                        bulkDescriptor.Index<UserProfileDocument>(op => op
                            .Document(transaction)
                            .Id(transaction.Id)
                            .Index(Constants.UserProfile));
                    }
                    allTransactions = await _elasticClient.BulkAsync(bulkDescriptor);

                    if (!allTransactions.IsValid)
                    {
                        _log.LogError("Failed to index AllUserProfiles: {ErrorReason}", allTransactions.DebugInformation);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.LogError($"Unhandled exception in active users update: {ex.Message}, with elastic search error {allTransactions.ServerError.Error}");
            }

        }

        private async Task UpdateActiveUsersAsync(CrossBordaDbContext dbContext, List<long> activeUsers, DateTime lastIndexTime, CancellationToken stoppingToken)
        {
            var allTransactions = new BulkResponse();
            var bulkDescriptor = new BulkDescriptor();
            try
            {
                var activeUsersrecords = dbContext.UserProfile.Where(x => activeUsers.Contains(x.Id) && x.CreatedDate > lastIndexTime).Select(x => x.MapActiveUsersProfiles()).ToList();
                if (activeUsersrecords.Count() == 0)
                {
                    _log.LogInfo("No new acotive users on wallet transaction  ..");
                }
                else
                {
                    if (activeUsersrecords.Count() == 0)
                    {
                        _log.LogInfo("No new inacotive users on crosborda");
                    }
                    else
                    {
                        foreach (var transaction in activeUsersrecords)
                        {
                            bulkDescriptor.Index<ActiveUserProfileDocument>(op => op
                                .Document(transaction)
                                .Id(transaction.Id)
                                .Index(Constants.ActiveUserProfileIndex));
                        }
                        allTransactions = await _elasticClient.BulkAsync(bulkDescriptor);

                        if (!allTransactions.IsValid)
                        {
                            _log.LogError("Failed to index ActiveUserProfiles: {ErrorReason}", allTransactions.DebugInformation);
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                _log.LogError($"Unhandled exception in active users update: {ex.Message}, with elastic search error {allTransactions.ServerError.Error}");
            }

        }


        private async Task UpdateInActiveUsersAsync(CrossBordaDbContext dbContext, List<long> activeUsers, DateTime lastIndexTime, CancellationToken stoppingToken)
        {
            var allTransactions = new BulkResponse();
            var bulkDescriptor = new BulkDescriptor();
            try
            {
                var allUsersrecords = dbContext.UserProfile.ToList();
                if (allUsersrecords.Count() == 0)
                {
                    _log.LogInfo("No new acotive users on wallet transaction  ..");
                }
                else
                {
                    var activeUsersrecords = await GetInactiveUsers(allUsersrecords, activeUsers);
                    if (activeUsersrecords.Count() == 0)
                    {
                        _log.LogInfo("No new inacotive users on crosborda");
                    }
                    else 
                    {
                        foreach (var transaction in activeUsersrecords)
                        {
                            bulkDescriptor.Index<InActiveUserProfileDocument>(op => op
                                .Document(transaction)
                                .Id(transaction.Id)
                                .Index(Constants.InActiveUserProfileIndex));
                        }
                        allTransactions = await _elasticClient.BulkAsync(bulkDescriptor);

                        if (!allTransactions.IsValid)
                        {
                            _log.LogError("Failed to index InActiveUserProfiles: {ErrorReason}", allTransactions.DebugInformation);
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                _log.LogError($"Unhandled exception in active users update: {ex.Message}, with elastic search error {allTransactions.ServerError.Error}");
            }

        }

        public async Task<List<SuccessfulTransactionDocument>> GetSuccessfulRecord()
        {
            var query = await _elasticClient.SearchAsync<SuccessfulTransactionDocument>(s => s
                .Index(Constants.SuccessfulTransactionIndex)
                .Source(false) // Exclude the document source to improve performance
                .Size(10000)
                .MatchAll());

            if (!query.IsValid)
            {
                // Handle errors
                var debugInfo = query.DebugInformation;
                var error = query.ServerError?.Error;
            }

            var record = query.Hits.Select(hit => hit.Source).ToList();
            var resp = record.FirstOrDefault();
            return record;
        }

        public async Task<List<FailedTransactionDocument>> GetFailedRecord()
        {

            var query = await _elasticClient.SearchAsync<FailedTransactionDocument>(s => s
                .Index(Constants.FailedTransactionIndex)
                .Source(false)
                .Size(10000)
                .MatchAll());

            if (!query.IsValid)
            {
                // Handle errors
                var debugInfo = query.DebugInformation;
                var error = query.ServerError?.Error;
            }

            var record = query.Hits.Select(hit => hit.Source).ToList();
            var resp = record.FirstOrDefault();
            return record;
        }

        public async Task<List<UserProfileDocument>> GetAllUsersRecord()
        {
            var query = await _elasticClient.SearchAsync<UserProfileDocument>(s => s
                .Index(Constants.UserProfile)
                .Source(false)
                .Size(10000)
                .MatchAll());

            if (!query.IsValid)
            {
                // Handle errors
                var debugInfo = query.DebugInformation;
                var error = query.ServerError?.Error;
            }

            var record = query.Hits.Select(hit => hit.Source).ToList();
            var resp = record.FirstOrDefault();
            return record;
        }

        public async Task<List<ActiveUserProfileDocument>> GetAllActiveUsersRecord()
        {

            var query = await _elasticClient.SearchAsync<ActiveUserProfileDocument>(s => s
                .Index(Constants.ActiveUserProfileIndex)
                .Source(false)
                .Size(10000)
                .MatchAll());

            if (!query.IsValid)
            {
                // Handle errors
                var debugInfo = query.DebugInformation;
                var error = query.ServerError?.Error;
            }

            var record = query.Hits.Select(hit => hit.Source).ToList();
            var resp = record.FirstOrDefault();
            return record;
        }

        public async Task<List<InActiveUserProfileDocument>> GetInActiveUsersRecord()
        {

            var query = await _elasticClient.SearchAsync<InActiveUserProfileDocument>(s => s
                .Index(Constants.InActiveUserProfileIndex)
                .Source(false)
                .Size(10000)
                .MatchAll());

            if (!query.IsValid)
            {
                // Handle errors
                var debugInfo = query.DebugInformation;
                var error = query.ServerError?.Error;
            }

            var record = query.Hits.Select(hit => hit.Source).ToList();
            var resp = record.FirstOrDefault();
            return record;
        }

        public async Task<List<InActiveUserProfileDocument>> GetInactiveUsers(List<UserProfile> allUsers, List<long> activeUserIds)
        {
            // Using HashSet for faster lookup
            var activeUsersSet = new HashSet<long>(activeUserIds);

            // Using LINQ to filter out inactive users
            List<InActiveUserProfileDocument> inactiveUserIds = allUsers.Where(x => !activeUsersSet.Contains(x.Id)).Select(x => x.MapInActiveUsersProfiles()).ToList();

            return inactiveUserIds;
        }

        public async Task ClearAllIndicesAndDocuments()
        {
            // Get a list of all indices
            var allIndices = await _elasticClient.Cat.IndicesAsync(descriptor => descriptor);

            foreach (var index in allIndices.Records)
            {
                // Delete the index
                var deleteIndexResponse = await _elasticClient.Indices.DeleteAsync(index.Index);

                if (!deleteIndexResponse.IsValid)
                {
                    Console.WriteLine($"Failed to delete index '{index.Index}': {deleteIndexResponse.DebugInformation}");
                }
            }
        }

    }

}
