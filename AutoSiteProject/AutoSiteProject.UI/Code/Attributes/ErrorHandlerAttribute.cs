using System.ComponentModel;
using AutoSiteProject.Models.Bl.Interfaces;
using NLog;
using System.Web.Mvc;
using System;

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
            if (filterContext.Exception is WarningException)
            {
                _appLogger.WriteWarn(filterContext.Exception);
            }
            else
            if (filterContext.Exception is Exception)
            {
                _appLogger.WriteError(filterContext.Exception);
            }
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult { ViewName= "~/Views/Error/Index.cshtml"};

        }

    }
}