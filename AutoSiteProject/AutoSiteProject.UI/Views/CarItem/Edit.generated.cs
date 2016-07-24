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
WriteLiteral("\r\n\r\n<h2>Edit</h2>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 121), Tuple.Create("\"", 160)
, Tuple.Create(Tuple.Create("", 127), Tuple.Create<System.Object, System.Int32>(Href("~/scripts/AutoSite/ImageLoader.js")
, 127), false)
);

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 178), Tuple.Create("\"", 217)
, Tuple.Create(Tuple.Create("", 185), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MyCss/WidthClasses.css")
, 185), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n");

            
            #line 10 "..\..\Views\CarItem\Edit.cshtml"
 using (Html.BeginForm("Edit", "CarItem", FormMethod.Post, new { enctype = "multipart/form-data" }))
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

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\CarItem\Edit.cshtml"
        
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\CarItem\Edit.cshtml"
           Html.RenderPartial("_CarItem", Model);
            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"images-container\"");

WriteLiteral(">\r\n");

            
            #line 19 "..\..\Views\CarItem\Edit.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\CarItem\Edit.cshtml"
                     if (Model.Images != null)
                    {
                        for (var i = 0; i < Model.Images.Count; i++)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" class=\"image-block\"");

WriteAttribute("id", Tuple.Create(" id=\"", 819), Tuple.Create("\"", 843)
            
            #line 23 "..\..\Views\CarItem\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 824), Tuple.Create<System.Object, System.Int32>(Model.Images[i].Id
            
            #line default
            #line hidden
, 824), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                                ");

            
            #line 24 "..\..\Views\CarItem\Edit.cshtml"
                           Write(Html.HiddenFor(model => model.Images[i].Id, htmlAttributes: new { @class = "existImageIdField", @id = @Model.Images[i].Id }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=", 1042), Tuple.Create("", 1115)
            
            #line 25 "..\..\Views\CarItem\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1047), Tuple.Create<System.Object, System.Int32>(Url.Action("LoadImg", "DataLoader", new {id = @Model.Images[i].Id})
            
            #line default
            #line hidden
, 1047), false)
);

WriteLiteral(" class=\"image-viewer\"");

WriteLiteral(" data-content-length=\"");

            
            #line 25 "..\..\Views\CarItem\Edit.cshtml"
                                                                                                                                                   Write(Model.Images[i].ContentLength);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" data-content-type=\"");

            
            #line 25 "..\..\Views\CarItem\Edit.cshtml"
                                                                                                                                                                                                      Write(Model.Images[i].ContentType);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("/>\r\n                                <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" name=\"Delete\"");

WriteLiteral(" class=\"existImageDeleteButton\"");

WriteLiteral(" value=\"Delete\"");

WriteAttribute("id", Tuple.Create(" id=\"", 1354), Tuple.Create("\"", 1378)
            
            #line 26 "..\..\Views\CarItem\Edit.cshtml"
                                     , Tuple.Create(Tuple.Create("", 1359), Tuple.Create<System.Object, System.Int32>(Model.Images[i].Id
            
            #line default
            #line hidden
, 1359), false)
);

WriteLiteral(" />\r\n                            </div>\r\n");

            
            #line 28 "..\..\Views\CarItem\Edit.cshtml"
                        }
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"add-image\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" name=\"files\"");

WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 48 "..\..\Views\CarItem\Edit.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 51 "..\..\Views\CarItem\Edit.cshtml"
Write(Html.ActionLink("Back to previous page", null, null, null, new { href = Request.UrlReferrer }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
