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
            _appLogger.WriteError(filterContext.Exception);
        }
    }
}