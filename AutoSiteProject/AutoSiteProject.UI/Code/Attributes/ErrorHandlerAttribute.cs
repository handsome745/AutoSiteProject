using System.ComponentModel;
using System.Security;
using AutoSiteProject.Models.Bl.Interfaces;
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
            var exc = filterContext.Exception;
            //log exception
            if (exc is WarningException)
            {
                _appLogger.WriteWarn(exc);
            }
            else
            {
                _appLogger.WriteError(exc);
            }


            if (exc is SecurityException)
            {
                filterContext.Result = new ViewResult { ViewName = "~/Views/Error/Security.cshtml" };
            }
            else filterContext.Result = new ViewResult { ViewName = "~/Views/Error/Index.cshtml" };

            filterContext.ExceptionHandled = true;
        }

    }
}