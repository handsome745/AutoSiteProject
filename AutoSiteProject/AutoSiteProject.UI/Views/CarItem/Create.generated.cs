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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CarItem/Create.cshtml")]
    public partial class _Views_CarItem_Create_cshtml : System.Web.Mvc.WebViewPage<AutoSiteProject.Models.ViewModels.CarItemViewModel>
    {
        public _Views_CarItem_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\CarItem\Create.cshtml"
  
    ViewBag.Title = "Create";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>Create</h2>\r\n\r\n");

            
            #line 9 "..\..\Views\CarItem\Create.cshtml"
 using (Html.BeginForm("CreateCar","CarItem",FormMethod.Post)) 
{
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\CarItem\Create.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\CarItem\Create.cshtml"
                            
    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <h4>CarItemViewModel</h4>\r\n");

            
            #line 15 "..\..\Views\CarItem\Create.cshtml"
        
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\CarItem\Create.cshtml"
           Html.RenderPartial("_CarItem", Model); 
            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Create\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 22 "..\..\Views\CarItem\Create.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 25 "..\..\Views\CarItem\Create.cshtml"
Write(Html.ActionLink("Back to List", "List"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n\r\n \r\n \r\n");

        }
    }
}
#pragma warning restore 1591
