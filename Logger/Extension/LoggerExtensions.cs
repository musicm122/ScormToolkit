using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerretLogger.Extension
{

    public static class LoggerExtensions
    {

        public static void Informational(this ILogger logger, string message)
        {
            if (logger.IsInformationalEnabled)
                logger.Write(message, EventSeverity.Informational);
        }

        public static void Informational(this ILogger logger, string format, params object[] args)
        {
            if (logger.IsInformationalEnabled)
                logger.Write(String.Format(format, args), EventSeverity.Informational);
        }

        public static void Warning(this ILogger logger, string message)
        {
            if (logger.IsWarningEnabled)
                logger.Write(message, EventSeverity.Warning);
        }

    }
}
