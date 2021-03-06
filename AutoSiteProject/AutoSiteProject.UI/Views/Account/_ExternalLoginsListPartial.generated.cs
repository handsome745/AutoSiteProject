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
    
    #line 2 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
    using Microsoft.Owin.Security;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/_ExternalLoginsListPartial.cshtml")]
    public partial class _Views_Account__ExternalLoginsListPartial_cshtml : System.Web.Mvc.WebViewPage<AutoSiteProject.Models.ViewModels.ExternalLoginListViewModel>
    {
        public _Views_Account__ExternalLoginsListPartial_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<h4>Use another service to log in.</h4>\r\n<hr />\r\n");

            
            #line 6 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
  
    var loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes();
    if (loginProviders.Count() == 0) {

            
            #line default
            #line hidden
WriteLiteral("        <div>\r\n            <p>\r\n                There are no external authenticat" +
"ion services configured. See <a");

WriteLiteral(" href=\"http://go.microsoft.com/fwlink/?LinkId=403804\"");

WriteLiteral(">this article</a>\r\n                for details on setting up this ASP.NET applica" +
"tion to support logging in via external services.\r\n            </p>\r\n        </d" +
"iv>\r\n");

            
            #line 15 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
    }
    else {
        using (Html.BeginForm("ExternalLogin", "Account", new { ReturnUrl = Model.ReturnUrl })) {
            
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
                                    

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" id=\"socialLoginList\"");

WriteLiteral(">\r\n                <p>\r\n");

            
            #line 21 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
                     foreach (AuthenticationDescription p in loginProviders) {

            
            #line default
            #line hidden
WriteLiteral("                        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteAttribute("id", Tuple.Create(" id=\"", 993), Tuple.Create("\"", 1019)
            
            #line 22 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
, Tuple.Create(Tuple.Create("", 998), Tuple.Create<System.Object, System.Int32>(p.AuthenticationType
            
            #line default
            #line hidden
, 998), false)
);

WriteLiteral(" name=\"provider\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1036), Tuple.Create("\"", 1065)
            
            #line 22 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
                                        , Tuple.Create(Tuple.Create("", 1044), Tuple.Create<System.Object, System.Int32>(p.AuthenticationType
            
            #line default
            #line hidden
, 1044), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 1066), Tuple.Create("\"", 1110)
, Tuple.Create(Tuple.Create("", 1074), Tuple.Create("Log", 1074), true)
, Tuple.Create(Tuple.Create(" ", 1077), Tuple.Create("in", 1078), true)
, Tuple.Create(Tuple.Create(" ", 1080), Tuple.Create("using", 1081), true)
, Tuple.Create(Tuple.Create(" ", 1086), Tuple.Create("your", 1087), true)
            
            #line 22 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
                                                                                       , Tuple.Create(Tuple.Create(" ", 1091), Tuple.Create<System.Object, System.Int32>(p.Caption
            
            #line default
            #line hidden
, 1092), false)
, Tuple.Create(Tuple.Create(" ", 1102), Tuple.Create("account", 1103), true)
);

WriteLiteral(">");

            
            #line 22 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
                                                                                                                                                                                       Write(p.AuthenticationType);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

            
            #line 23 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </p>\r\n            </div>\r\n");

            
            #line 26 "..\..\Views\Account\_ExternalLoginsListPartial.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
