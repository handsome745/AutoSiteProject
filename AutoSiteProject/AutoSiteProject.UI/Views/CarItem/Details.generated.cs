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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CarItem/Details.cshtml")]
    public partial class _Views_CarItem_Details_cshtml : System.Web.Mvc.WebViewPage<AutoSiteProject.Models.ViewModels.CarItemViewModel>
    {
        public _Views_CarItem_Details_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<link");

WriteAttribute("href", Tuple.Create(" href=\"", 64), Tuple.Create("\"", 111)
, Tuple.Create(Tuple.Create("", 71), Tuple.Create<System.Object, System.Int32>(Href("~/Content/MyCss/CarItemDetailsStyles.css")
, 71), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<div>\r\n    <hr />\r\n    <div");

WriteLiteral(" class=\"width100\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"imageSliderContainer\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 7 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DevExpress().ImageSlider(
            settings =>
            {
                settings.Name = "imageSlider";
                settings.EnableTheming = false;

                settings.SettingsAutoGeneratedImages.ImageCacheFolder = "~\\Content\\ImageSlider\\Thumb";
                settings.ImageContentBytesField = "Data";
                settings.NameField = "Id";
                settings.SettingsNavigationBar.ThumbnailsModeNavigationButtonVisibility = ElementVisibilityMode.None;

            }).Bind(Model.Images).GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <hr />\r\n    <dl");

WriteLiteral(" class=\"dl-horizontal\"");

WriteLiteral(">\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Country));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 28 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.Country));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 32 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Manufacturer));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 36 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.Manufacturer));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CarModel));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 44 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.CarModel));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 48 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CarBodyType));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 52 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.CarBodyType));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 55 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FuelType));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 59 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.FuelType));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 62 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TransmitionType));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 66 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.TransmitionType));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 69 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 73 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.Price));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 76 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ReleaseYear));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 80 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.ReleaseYear));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 83 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Volume));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 87 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.Volume));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 90 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OptionsNamesString));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 94 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.OptionsNamesString));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 97 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 101 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n");

WriteLiteral("            ");

            
            #line 104 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EditDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");

WriteLiteral("            ");

            
            #line 108 "..\..\Views\CarItem\Details.cshtml"
       Write(Html.DisplayFor(model => model.EditDate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<p>\r\n");

WriteLiteral("    ");

            
            #line 113 "..\..\Views\CarItem\Details.cshtml"
Write(Html.ActionLink("Back to previous page", null, null, null, new { href = Request.UrlReferrer }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</p>\r\n");

        }
    }
}
#pragma warning restore 1591
