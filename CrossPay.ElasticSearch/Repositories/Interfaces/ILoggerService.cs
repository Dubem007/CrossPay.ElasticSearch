using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossPay.ElasticSearch.Repositories.Interfaces
{
    public interface ILoggerService
    {
        void LogError(string error, string eventId = "", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
        void LogExceptionWithStackTrace(Exception ex, string eventId = "", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
        void LogInfo(string message, string eventId = "", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, string level = "Info");
        void LogWarning(string message, string eventId = "", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);
    }
}
