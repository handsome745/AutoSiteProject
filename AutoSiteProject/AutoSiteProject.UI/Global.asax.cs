﻿using System.Web.Mvc;
using System.Web.Routing;
using AutoSiteProject.UI.Utils;

namespace AutoSiteProject.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
