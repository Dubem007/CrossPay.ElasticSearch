using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Entities
{
    public class ResponseModel<T>
    {
        public bool Status { get; set; }
        public bool RequestSuccessful { get; set; }
        public T ResponseData { get; set; }
        public string Message { get; set; }
        public string ResponseCode { get; set; }
    }

}
