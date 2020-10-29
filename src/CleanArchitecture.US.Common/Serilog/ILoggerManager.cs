using System;

namespace CleanArchitecture.US.Common.Serilog
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
