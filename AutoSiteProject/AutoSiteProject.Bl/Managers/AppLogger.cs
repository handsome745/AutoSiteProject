using AutoSiteProject.Models.Bl.Interfaces;
using NLog;
using System;

namespace AutoSiteProject.Bl.Managers
{
    public class AppLogger : IAppLogger
    {
        public AppLogger()
        {

        }
        public void WriteError(Exception ex)
        {
            try
            {
                var appLogger = NLog.LogManager.GetCurrentClassLogger();
                appLogger.Log(LogLevel.Error, ex.Message);
            }
            catch 
            {
                throw;
            }
        }
        public void WriteWarn(Exception ex)
        {
            try
            {
                var appLogger = NLog.LogManager.GetCurrentClassLogger();
                appLogger.Log(LogLevel.Warn, ex.Message);
            }
            catch 
            {
                throw;
            }
        }
        public void WriteDebug(Exception ex)
        {
            try
            {
                var appLogger = NLog.LogManager.GetCurrentClassLogger();
                appLogger.Log(LogLevel.Debug, ex.Message);
            }
            catch
            {
                throw;
            }
        }
        public void WriteFatal(Exception ex)
        {
            try
            {
                var appLogger = NLog.LogManager.GetCurrentClassLogger();
                appLogger.Log(LogLevel.Fatal, ex.Message);
            }
            catch
            {
                throw;
            }
        }
        public void WriteInfo(Exception ex)
        {
            try
            {
                var appLogger = NLog.LogManager.GetCurrentClassLogger();
                appLogger.Log(LogLevel.Info, ex.Message);
            }
            catch
            {
                throw;
            }
        }

    }
}
