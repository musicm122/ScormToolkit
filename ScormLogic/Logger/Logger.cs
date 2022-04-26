using HackerFerretLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Core;
using System.Threading.Tasks;
using System.Reflection;


namespace ScormLogic.Log
{
    public class Logger : HackerFerretLogger.ILogger
    {
        private readonly ILog _internalLogger;


        public Logger(ILog internalLogger)
        {
            if (internalLogger == null)
                throw new ArgumentNullException("internalLogger");
            _internalLogger = internalLogger;
        }

        public bool IsDebugEnabled
        {
            get { return _internalLogger.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return _internalLogger.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return _internalLogger.IsFatalEnabled;
            }
        }

        public bool IsInformationalEnabled
        {
            get
            {
                return _internalLogger.IsInfoEnabled;
            }
        }

        public bool IsVerboseEnabled
        {
            get
            {
                return _internalLogger.IsInfoEnabled;
            }
        }

        public bool IsWarningEnabled
        {
            get
            {
                return _internalLogger.IsWarnEnabled;
            }
        }




        public void Write(string message, EventSeverity severity)
        {
            Write(message, null, severity);
        }

        public void Write(string message, Exception exception, EventSeverity severity)
        {
            var level = GetLevelFromSeverity(severity);

            _internalLogger.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType,
                level, message, exception);
        }

        private static Level GetLevelFromSeverity(EventSeverity severity)
        {
            switch (severity)
            {
                case EventSeverity.Informational:
                    return Level.Info;
                case EventSeverity.Warning:
                    return Level.Warn;
                case EventSeverity.Error:
                    return Level.Error;
                case EventSeverity.Fatal:
                    return Level.Fatal;
                case EventSeverity.Debug:
                    return Level.Debug;
                case EventSeverity.Verbose:
                    return Level.Verbose;
                default:
                    return Level.Info;
            }

        }
    }
}