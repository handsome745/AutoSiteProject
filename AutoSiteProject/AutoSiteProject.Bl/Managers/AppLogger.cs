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
            catch (Exception exception)
            {
                //asdasdas
                throw;
            }
        }


    }
}
