using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Utilities
{
    public static class Constants
    {
        public const string ActiveUserProfileIndex = "activeuserprofile";
        public const string InActiveUserProfileIndex = "inactiveuserprofile";
        public const string UserProfile = "userprofile";
        public const string FailedTransactionIndex = "failedtransaction";
        public const string SuccessfulTransactionIndex = "successfultransaction";
        public const string Index = "indexmodel";
        public const string BankTransaction = "banktransaction";

    }
}
