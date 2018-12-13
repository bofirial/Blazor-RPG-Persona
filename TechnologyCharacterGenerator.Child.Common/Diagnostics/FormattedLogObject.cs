using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace TechnologyCharacterGenerator.Child.Common.Diagnostics
{
    public class FormattedLogObject
    {
        private readonly LogLevel logLevel;
        private readonly object data;
        private readonly Exception exception;

        public FormattedLogObject(LogLevel logLevel, object data, Exception exception)
        {
            this.logLevel = logLevel;
            this.data = data;
            this.exception = exception;
        }

        public override string ToString()
        {
            if (this.data == null)
            {
                return string.Empty;
            }

            var logObject = default(LogObject);

            if (this.data is string stringData)
            {
                logObject = new LogObject
                {
                    LogLevel = logLevel,
                    Type = LogObjectType.String,
                    Payload = stringData,
                };
            }
            else
            {
                var isDataEnumerable = IsDataEnumerable(this.data);

                logObject = new LogObject
                {
                    LogLevel = logLevel,
                    Type = isDataEnumerable ? LogObjectType.Table : LogObjectType.Object,
                    Payload = data
                };
            }

            if (this.exception != null)
            {
                logObject.Exception = this.exception.ToString();
            }

            return Json.Serialize(logObject);
        }

        private bool IsDataEnumerable(object data)
        {
            if (data == null || data is string)
            {
                return false;
            }

            if (data as IEnumerable != null)
            {
                return true;
            }

            return false;
        }
    }
}
