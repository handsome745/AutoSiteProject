﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using AutoSiteProject.UI;
    using DevExpress.Utils;
    using DevExpress.Web;
    using DevExpress.Web.ASPxThemes;
    using DevExpress.Web.Mvc;
    using DevExpress.Web.Mvc.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CarOption/List.cshtml")]
    public partial class _Views_CarOption_List_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<AutoSiteProject.Models.ViewModels.CarOptionViewModel>>
    {
        public _Views_CarOption_List_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\CarOption\List.cshtml"
  
    ViewBag.Title = "List";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>List</h2>\r\n\r\n<p>\r\n");

WriteLiteral("    ");

            
            #line 10 "..\..\Views\CarOption\List.cshtml"
Write(Html.ActionLink("Create New", "Create"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>\r\n<table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n    <tr>\r\n        <th>\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Views\CarOption\List.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");

            
            #line 20 "..\..\Views\CarOption\List.cshtml"
 foreach (var item in Model) {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n        <td>\r\n");

WriteLiteral("            ");

            
            #line 23 "..\..\Views\CarOption\List.cshtml"
       Write(Html.DisplayFor(modelItem => item.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n        <td>\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Views\CarOption\List.cshtml"
       Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

            
            #line default
            #line hidden
WriteLiteral(" |\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\CarOption\List.cshtml"
       Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");

            
            #line 30 "..\..\Views\CarOption\List.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n</table>\r\n");

        }
    }
}
#pragma warning restore 1591
