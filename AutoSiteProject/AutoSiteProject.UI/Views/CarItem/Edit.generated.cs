﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CarItem/Edit.cshtml")]
    public partial class _Views_CarItem_Edit_cshtml : System.Web.Mvc.WebViewPage<AutoSiteProject.Models.ViewModels.CarItemViewModel>
    {
        public _Views_CarItem_Edit_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\CarItem\Edit.cshtml"
  
    ViewBag.Title = "Edit";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>Edit</h2>\r\n\r\n\r\n");

            
            #line 10 "..\..\Views\CarItem\Edit.cshtml"
 using (Html.BeginForm())
{
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\CarItem\Edit.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\CarItem\Edit.cshtml"
                            


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <h4>CarItemViewModel</h4>\r\n");

WriteLiteral("        ");

            
            #line 16 "..\..\Views\CarItem\Edit.cshtml"
   Write(Html.Partial("_CarItem", Model));

            
            #line default
            #line hidden
WriteLiteral(";\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 23 "..\..\Views\CarItem\Edit.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 26 "..\..\Views\CarItem\Edit.cshtml"
Write(Html.ActionLink("Back to List", "List"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n\r\n \r\n \r\n");

        }
    }
}
#pragma warning restore 1591
