using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.US.Common.NLog
{
    public interface ILoggerManager
    {
       
        void LogInformation(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogException(Exception ex);
        void LogExceptionWithSource(Exception ex, string source);
        void LogEnter();
        void LogExit();


    }
}
