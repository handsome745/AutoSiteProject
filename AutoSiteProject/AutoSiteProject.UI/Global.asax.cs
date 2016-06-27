using System;
using System.Web.Routing;
using AutoSiteProject.UI.Utils;
using System.Web.Mvc;
using AutoSiteProject.Models.Bl.Interfaces;

namespace AutoSiteProject.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private IAppLogger _appLogger;

        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (_appLogger == null)
            {
                _appLogger = DependencyResolver.Current.GetService<IAppLogger>();
            }
            var error = Server.GetLastError();
            _appLogger.WriteFatal(error);
        }
    }
}
