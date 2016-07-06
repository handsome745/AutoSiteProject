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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Layout.cshtml")]
    public partial class _Views_Shared__Layout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Layout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0\"");

WriteLiteral(">\r\n    <title>");

            
            #line 6 "..\..\Views\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(" - My ASP.NET Application</title>\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 208), Tuple.Create("\"", 233)
, Tuple.Create(Tuple.Create("", 215), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Site.css")
, 215), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 281), Tuple.Create("\"", 315)
, Tuple.Create(Tuple.Create("", 288), Tuple.Create<System.Object, System.Int32>(Href("~/Content/bootstrap.min.css")
, 288), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 365), Tuple.Create("\"", 399)
, Tuple.Create(Tuple.Create("", 371), Tuple.Create<System.Object, System.Int32>(Href("~/scripts/modernizr-2.7.2.js")
, 371), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 423), Tuple.Create("\"", 458)
, Tuple.Create(Tuple.Create("", 429), Tuple.Create<System.Object, System.Int32>(Href("~/scripts/jquery-3.0.0.min.js")
, 429), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 482), Tuple.Create("\"", 520)
, Tuple.Create(Tuple.Create("", 488), Tuple.Create<System.Object, System.Int32>(Href("~/scripts/jquery.validate.min.js")
, 488), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 544), Tuple.Create("\"", 594)
, Tuple.Create(Tuple.Create("", 550), Tuple.Create<System.Object, System.Int32>(Href("~/scripts/jquery.validate.unobtrusive.min.js")
, 550), false)
);

WriteLiteral("></script>\r\n");

WriteLiteral("    ");

            
            #line 13 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.DevExpress().GetScripts(
        new Script { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
        new Script { ExtensionSuite = ExtensionSuite.HtmlEditor },
        new Script { ExtensionSuite = ExtensionSuite.GridView },
        new Script { ExtensionSuite = ExtensionSuite.PivotGrid },
        new Script { ExtensionSuite = ExtensionSuite.Editors },
        new Script { ExtensionSuite = ExtensionSuite.Chart },
        new Script { ExtensionSuite = ExtensionSuite.Report },
        new Script { ExtensionSuite = ExtensionSuite.Scheduler },
        new Script { ExtensionSuite = ExtensionSuite.TreeList },
        new Script { ExtensionSuite = ExtensionSuite.Spreadsheet },
        new Script { ExtensionSuite = ExtensionSuite.RichEdit },
        new Script { ExtensionSuite = ExtensionSuite.SpellChecker }
    ));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 27 "..\..\Views\Shared\_Layout.cshtml"
Write(Html.DevExpress().GetStyleSheets(
        new StyleSheet { ExtensionSuite = ExtensionSuite.NavigationAndLayout },
        new StyleSheet { ExtensionSuite = ExtensionSuite.Editors },
        new StyleSheet { ExtensionSuite = ExtensionSuite.HtmlEditor },
        new StyleSheet { ExtensionSuite = ExtensionSuite.GridView },
        new StyleSheet { ExtensionSuite = ExtensionSuite.PivotGrid },
        new StyleSheet { ExtensionSuite = ExtensionSuite.Chart },
        new StyleSheet { ExtensionSuite = ExtensionSuite.Report },
        new StyleSheet { ExtensionSuite = ExtensionSuite.Scheduler },
        new StyleSheet { ExtensionSuite = ExtensionSuite.TreeList },
        new StyleSheet { ExtensionSuite = ExtensionSuite.Spreadsheet },
        new StyleSheet { ExtensionSuite = ExtensionSuite.RichEdit },
        new StyleSheet { ExtensionSuite = ExtensionSuite.SpellChecker }
    ));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n<body>\r\n    <div");

WriteLiteral(" class=\"navbar navbar-inverse navbar-fixed-top\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"navbar-toggle\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\".navbar-collapse\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                </button>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"navbar-collapse collapse\"");

WriteLiteral(">\r\n                <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 55 "..\..\Views\Shared\_Layout.cshtml"
               Write(Html.ActionLink("Home", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 56 "..\..\Views\Shared\_Layout.cshtml"
               Write(Html.ActionLink("Cars", "List", "CarItem", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 57 "..\..\Views\Shared\_Layout.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\Shared\_Layout.cshtml"
                     if (User.IsInRole("Admin"))
                    {
                        
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Car models", "List", "CarModel", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                              
                        
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Car body types", "List", "CarBodyType", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                                     
                        
            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Car options", "List", "CarOption", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
            
            #line 61 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                                
                        
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Manufacturers", "List", "Manufacturer", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                                     
                        
            
            #line default
            #line hidden
            
            #line 63 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Countries", "List", "Country", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
            
            #line 63 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                            
                        
            
            #line default
            #line hidden
            
            #line 64 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Users", "List", "User", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
            
            #line 64 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                     
                        
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\Shared\_Layout.cshtml"
                   Write(Html.ActionLink("Roles", "List", "Role", new { area = "" }, new { @class = "navbar-brand" }));

            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                     
                    }

            
            #line default
            #line hidden
WriteLiteral("                </ul>\r\n");

WriteLiteral("                ");

            
            #line 68 "..\..\Views\Shared\_Layout.cshtml"
           Write(Html.Partial("_LoginPartial"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"container body-content\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 74 "..\..\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        <hr />\r\n        <footer>\r\n            <p>&copy; ");

            
            #line 77 "..\..\Views\Shared\_Layout.cshtml"
                 Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral(" - My ASP.NET Application</p>\r\n        </footer>\r\n    </div>\r\n</body>\r\n</html>");

        }
    }
}
#pragma warning restore 1591