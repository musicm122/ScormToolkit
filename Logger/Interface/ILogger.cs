using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerretLogger
{
    public enum EventSeverity
    {
        Informational,
        Warning,
        Error,
        Fatal,
        Debug,
        Verbose
    }


    public interface ILogger
    {

        bool IsDebugEnabled { get; }
        bool IsVerboseEnabled { get; }
        bool IsInformationalEnabled { get; }
        bool IsWarningEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsErrorEnabled { get; }

        void Write(string message, EventSeverity severity);
        void Write(string message, Exception exception, EventSeverity severity);

    }

}
