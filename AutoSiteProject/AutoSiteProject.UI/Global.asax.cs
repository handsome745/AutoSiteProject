using System.Web.Routing;
using AutoSiteProject.UI.Utils;
using System.Web.Mvc;
using AutoSiteProject.UI.Code.Attributes;

namespace AutoSiteProject.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new ErrorHandlerAttribute());
        }
    }
}
