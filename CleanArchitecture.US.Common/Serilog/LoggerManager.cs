using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Fluentd;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CleanArchitecture.US.Common.Serilog
{
    public class LoggerManager : ILoggerManager
    {
        public LoggerManager()
        {
            InitializeLogger();
        }

        private void InitializeLogger()
        {
            var config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                .Build();
            FluentdSinkOptions sinkOptions = new FluentdSinkOptions("localhost", 8080);
            sinkOptions.Tag = "myapp.access";
            Log.Logger = new LoggerConfiguration()
                  .ReadFrom.Configuration(config)
                 .WriteTo.Fluentd(sinkOptions, LogEventLevel.Debug)
                 .CreateLogger();
        }

        /// <summary>
        /// Log debug mode messages
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            if (Log.IsEnabled(LogEventLevel.Debug)) Log.Debug(message);
            
        }
        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            if (Log.IsEnabled(LogEventLevel.Error)) Log.Error(message);
        }
        /// <summary>
        /// Log Information message
        /// </summary>
        /// <param name="message"></param>
        public void LogInformation(string message)
        {
            if (Log.IsEnabled(LogEventLevel.Information)) Log.Information(message);
        }
        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message"></param>
        public void LogWarning(string message)
        {
            if (Log.IsEnabled(LogEventLevel.Warning)) Log.Warning(message);
        }
        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="ex"></param>
        public void LogException(Exception ex)
        {
            Log.Error(ex,ex.Message);
        }
        /// <summary>
        /// Log exception with source
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="source"></param>
        public void LogExceptionWithSource(Exception ex, string source)
        {
           Log.Error(ex, source);
        }
        /// <summary>
        /// Log start time of a process
        /// </summary>
        public void LogEnter()
        {
            if (!Log.IsEnabled(LogEventLevel.Debug)) return;
            var trace = new StackTrace();
            if (trace.FrameCount <= 1) return;
            var declaringType = trace.GetFrame(1).GetMethod().DeclaringType;
            if (declaringType != null)
                Log.Debug($"Entering {declaringType.Name}.{trace.GetFrame(1).GetMethod().Name}");
        }
        /// <summary>
        /// log end time of a process
        /// </summary>
        public void LogExit()
        {
            if (!Log.IsEnabled(LogEventLevel.Debug)) return;

            var trace = new StackTrace();
            if (trace.FrameCount <= 1) return;
            var declaringType = trace.GetFrame(1).GetMethod().DeclaringType;
            if (declaringType != null)
                Log.Debug($"Exiting {declaringType.Name}.{trace.GetFrame(1).GetMethod().Name}");
        }
    }
}
