using AutoSiteProject.Models.Bl.Interfaces;
using NLog;
using System;

namespace AutoSiteProject.Bl.Managers
{
    public class AppLogger : IAppLogger
    {
        public void WriteError(Exception ex)
        {
            var appLogger = LogManager.GetCurrentClassLogger();
            appLogger.Log(LogLevel.Error, ex.Message);
        }
        public void WriteWarn(Exception ex)
        {
            var appLogger = LogManager.GetCurrentClassLogger();
            appLogger.Log(LogLevel.Warn, ex.Message);
        }
        public void WriteDebug(Exception ex)
        {
            var appLogger = LogManager.GetCurrentClassLogger();
            appLogger.Log(LogLevel.Debug, ex.Message);
        }
        public void WriteFatal(Exception ex)
        {
            var appLogger = LogManager.GetCurrentClassLogger();
            appLogger.Log(LogLevel.Fatal, ex.Message);
        }
        public void WriteInfo(Exception ex)
        {
            var appLogger = LogManager.GetCurrentClassLogger();
            appLogger.Log(LogLevel.Info, ex.Message);
        }

    }
}
