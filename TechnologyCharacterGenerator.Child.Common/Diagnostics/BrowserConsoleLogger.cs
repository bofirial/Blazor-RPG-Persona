using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using System;
using Microsoft.JSInterop;

namespace TechnologyCharacterGenerator.Child.Common.Diagnostics
{
    public class BrowserConsoleLogger : ILogger
    {
        private const string LoggerFunctionName = "BlazorExtensions.Logging.BrowserConsoleLogger.Log";

        private Func<string, LogLevel, bool> filter;

        public BrowserConsoleLogger(string name, Func<string, LogLevel, bool> filter)
        {
            this.filter = filter ?? ((category, logLevel) => true);
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (!(state is FormattedLogObject))
            {
                var internalFormatter = new FormattedLogObject(logLevel, message, exception);

                message = internalFormatter.ToString();
            }

            if (null != JSRuntime.Current)
            {
                try
                {
                    JSRuntime.Current.InvokeAsync<object>(LoggerFunctionName, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel == LogLevel.None)
            {
                return false;
            }

            return this.Filter(this.Name, logLevel);
        }

        public Func<string, LogLevel, bool> Filter
        {
            get => this.filter;
            set
            {
                this.filter = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public string Name { get; }

        public IDisposable BeginScope<TState>(TState state) => NullScope.Instance;
    }
}