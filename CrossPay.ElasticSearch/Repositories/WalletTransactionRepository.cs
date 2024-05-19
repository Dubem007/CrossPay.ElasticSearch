using CrossPay.ElasticSearch.Data;
using CrossPay.ElasticSearch.Entities;
using CrossPay.ElasticSearch.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Repositories.Repositories
{
    public class WalletTransactionRepository: IWalletTransactionRepository
    {
        private readonly CrossBordaDbContext _dbContext;
        private readonly ILoggerService _log;
        public WalletTransactionRepository(CrossBordaDbContext dbContext, ILoggerService log)
        {
            _dbContext = dbContext;
            _log = log;
        }

        public async Task<List<WalletTransactions>> Get()
        {
            _log.LogInfo("About to get transaction on pending and processing status >> ");
            var transaction = await _dbContext.WalletTransactions.Where(x => x.TransactionStatus.ToLower() == "pending" || x.TransactionStatus.ToLower() == "processing").ToListAsync();
            return transaction;

        }
    }
}
