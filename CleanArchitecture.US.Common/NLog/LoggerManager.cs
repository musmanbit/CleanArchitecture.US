using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CleanArchitecture.US.Common.NLog
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger Logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {
        }
        /// <summary>
        /// Log debug mode messages
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            if (Logger.IsDebugEnabled) Logger.Debug(message);
        }
        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            if (Logger.IsErrorEnabled) Logger.Error(message);
        }
        /// <summary>
        /// Log Information message
        /// </summary>
        /// <param name="message"></param>
        public void LogInformation(string message)
        {
            if (Logger.IsInfoEnabled) Logger.Info(message);
        }
        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message"></param>
        public void LogWarning(string message)
        {
            if (Logger.IsInfoEnabled) Logger.Info(message);
        }
        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="ex"></param>
        public void LogException(Exception ex)
        {
            if (Logger.IsErrorEnabled) Logger.Error(ex);
        }
        /// <summary>
        /// Log exception with source
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="source"></param>
        public void LogExceptionWithSource(Exception ex, string source)
        {
            if (Logger.IsErrorEnabled) Logger.Error(ex, source);
        }
        /// <summary>
        /// Log start time of a process
        /// </summary>
        public void LogEnter()
        {
            if (!Logger.IsDebugEnabled) return;
            var trace = new StackTrace();
            if (trace.FrameCount <= 1) return;
            var declaringType = trace.GetFrame(1).GetMethod().DeclaringType;
            if (declaringType != null)
                Logger.Debug($"Entering {declaringType.Name}.{trace.GetFrame(1).GetMethod().Name}");
        }
        /// <summary>
        /// log end time of a process
        /// </summary>
        public void LogExit()
        {
            if (!Logger.IsDebugEnabled) return;

            var trace = new StackTrace();
            if (trace.FrameCount <= 1) return;
            var declaringType = trace.GetFrame(1).GetMethod().DeclaringType;
            if (declaringType != null)
                 Logger.Debug($"Exiting {declaringType.Name}.{trace.GetFrame(1).GetMethod().Name}");
        }
    }
}
