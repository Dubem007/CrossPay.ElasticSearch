using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Entities.Enums
{
    public enum RecordStatus
    {
        Active = 1,
        Inactive,
        Deleted,
        Archive,
        Pending
    }

    public enum TransactionType
    {
        Collection, PayOut, BillRecharge, Hold,
    }

    public enum OperationType
    {
        Credit = 1, Debit = 2, Reversal
    }
}
