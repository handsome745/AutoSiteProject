using System.ComponentModel;
using AutoSiteProject.Models.Bl.Interfaces;
using NLog;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Code.Attributes
{
    public class ErrorHandlerAttribute : HandleErrorAttribute
    {
        private IAppLogger _appLogger;
        public override void OnException(ExceptionContext filterContext)
        {
            if (_appLogger == null)
            {
                _appLogger = DependencyResolver.Current.GetService<IAppLogger>();
            }
            switch (filterContext.Exception.GetType().ToString())
            {
                case "System.ComponentModel.WarningException":
                    _appLogger.WriteWarn(filterContext.Exception);
                    break;
                default:
                    _appLogger.WriteError(filterContext.Exception); break;
            }
            filterContext.ExceptionHandled = true;
        }

    }
}