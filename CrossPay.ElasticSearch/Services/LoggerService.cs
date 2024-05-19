using CrossPay.ElasticSearch.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WatchDog;

namespace CrossPay.ElasticSearch.Services
{
    public class LoggerService : ILoggerService
    {
        public void LogError(string error, string eventId = "", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            WatchLogger.LogError(message: error, eventId: eventId, callerName: callerName, filePath: filePath, lineNumber: lineNumber);
        }
        public void LogExceptionWithStackTrace(Exception ex, string eventId = "", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            WatchLogger.LogError(message: string.IsNullOrEmpty(ex.StackTrace) ? ex.Message : $"Stack Trace Details: {ex.StackTrace} ======= Error Message: {ex.Message}", eventId: eventId, callerName: callerName, filePath: filePath, lineNumber: lineNumber);
        }
        public void LogInfo(string message, string eventId = "", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, string level = "Info")
        {
            WatchLogger.Log(message: message, eventId: eventId, callerName: callerName, filePath: filePath, lineNumber: lineNumber);
        }

        public void LogWarning(string message, string eventId = "", [CallerMemberName] string callerName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            WatchLogger.LogWarning(message: message, eventId: eventId, callerName: callerName, filePath: filePath, lineNumber: lineNumber);
        }
    }
}
