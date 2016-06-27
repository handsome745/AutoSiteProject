using System.Web.Mvc;
using AutoSiteProject.UI.Code.Attributes;

namespace AutoSiteProject.UI.Utils
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new ErrorHandlerAttribute());
        }
    }
}