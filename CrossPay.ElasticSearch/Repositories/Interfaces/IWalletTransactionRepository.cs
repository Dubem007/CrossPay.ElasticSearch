using CrossPay.ElasticSearch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Repositories.Interfaces
{
    public interface IWalletTransactionRepository
    {
        Task<List<WalletTransactions>> Get();
    }
}
