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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/ResetPassword.cshtml")]
    public partial class _Views_Account_ResetPassword_cshtml : System.Web.Mvc.WebViewPage<AutoSiteProject.Models.ViewModels.ResetPasswordViewModel>
    {
        public _Views_Account_ResetPassword_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Account\ResetPassword.cshtml"
  
    ViewBag.Title = "Reset password";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>");

            
            #line 6 "..\..\Views\Account\ResetPassword.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h2>\r\n\r\n");

            
            #line 8 "..\..\Views\Account\ResetPassword.cshtml"
 using (Html.BeginForm("ResetPassword", "Account", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Account\ResetPassword.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Account\ResetPassword.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <h4>Reset your password.</h4>\r\n");

WriteLiteral("    <hr />\r\n");

            
            #line 13 "..\..\Views\Account\ResetPassword.cshtml"
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Account\ResetPassword.cshtml"
Write(Html.ValidationSummary("", new { @class = "text-danger" }));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Account\ResetPassword.cshtml"
                                                               
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\ResetPassword.cshtml"
Write(Html.HiddenFor(model => model.Code));

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\ResetPassword.cshtml"
                                        

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 16 "..\..\Views\Account\ResetPassword.cshtml"
   Write(Html.LabelFor(m => m.Email, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 18 "..\..\Views\Account\ResetPassword.cshtml"
       Write(Html.TextBoxFor(m => m.Email, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\Account\ResetPassword.cshtml"
   Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\Account\ResetPassword.cshtml"
       Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 28 "..\..\Views\Account\ResetPassword.cshtml"
   Write(Html.LabelFor(m => m.ConfirmPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 30 "..\..\Views\Account\ResetPassword.cshtml"
       Write(Html.PasswordFor(m => m.ConfirmPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" value=\"Reset\"");

WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n");

            
            #line 38 "..\..\Views\Account\ResetPassword.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
