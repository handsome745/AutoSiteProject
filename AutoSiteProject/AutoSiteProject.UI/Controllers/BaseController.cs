using System;
using AutoSiteProject.Models.Bl.Interfaces;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        public IAppLogger AppLogger { get; set; }

        public BaseController()
        {
            AppLogger = DependencyResolver.Current.GetService<IAppLogger>();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            AppLogger.WriteDebug(new Exception($"Controller = {filterContext.Controller}, Message = {filterContext.Exception.Message}"));
            filterContext.ExceptionHandled = true;
        }
    }
}