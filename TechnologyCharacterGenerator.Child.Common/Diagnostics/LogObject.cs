﻿using Microsoft.Extensions.Logging;

namespace TechnologyCharacterGenerator.Child.Common.Diagnostics
{
    public class LogObject
    {
        public LogLevel LogLevel { get; set; }
        public LogObjectType Type { get; set; }
        public object Payload { get; set; }
        public string Exception { get; set; }
    }
}