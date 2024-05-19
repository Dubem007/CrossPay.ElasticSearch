using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Entities.Dtos
{
    public class LoginResDto
    {
        public AccessTokenDto LoginResponse { get; set; }
    }

    public class AccessTokenDto
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; }
        [JsonProperty("expires_in")]
        public double expires_in { get; set; }
        [JsonProperty("token_type")]
        public string token_type { get; set; }
        [JsonProperty("refresh_token")]
        public string refresh_token { get; set; }

    }

    public class TransactionResponse
    {
        public string amount { get; set; } = string.Empty;
        public string currency { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public DateTimeOffset requestDate { get; set; }
        public string transactionStatus { get; set; } = string.Empty;
        public string transactionReference { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; }
        public string ResponseCode { get; set; }




    }
}
