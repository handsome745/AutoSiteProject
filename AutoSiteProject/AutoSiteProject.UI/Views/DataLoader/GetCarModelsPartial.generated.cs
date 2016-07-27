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
    
    #line 1 "..\..\Views\DataLoader\GetCarModelsPartial.cshtml"
    using System.Web.UI.WebControls;
    
    #line default
    #line hidden
    using System.Web.WebPages;
    using AutoSiteProject.UI;
    using DevExpress.Utils;
    using DevExpress.Web;
    using DevExpress.Web.ASPxThemes;
    using DevExpress.Web.Mvc;
    using DevExpress.Web.Mvc.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DataLoader/GetCarModelsPartial.cshtml")]
    public partial class _Views_DataLoader_GetCarModelsPartial_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<AutoSiteProject.Models.ViewModels.CarModelViewModel>>
    {
        public _Views_DataLoader_GetCarModelsPartial_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\DataLoader\GetCarModelsPartial.cshtml"
Write(Html.DevExpress().GridView(settings =>
{
    settings.Name = "carModelsGridView";
    settings.CallbackRouteValues = new { Controller = "DataLoader", Action = "GetCarModelsPartial" };
    settings.Width = Unit.Percentage(100);
    settings.Columns.Add(column =>
    {
        column.Caption = "#";
        column.SetDataItemTemplateContent(c =>
        {
            ViewContext.Writer.Write(
                Html.ActionLink("Edit", "Edit", "CarModel", routeValues: new { Id = DataBinder.Eval(c.DataItem, "Id") }, htmlAttributes: new { })
                + "&nbsp;" +
                Html.ActionLink("Delete", "Delete", "CarModel", routeValues: new { Id = DataBinder.Eval(c.DataItem, "Id") }, htmlAttributes: new { })
                );
        });
        column.SetHeaderTemplateContent(c =>
        {
            ViewContext.Writer.Write(
                Html.ActionLink("New", "Create", "CarModel").ToHtmlString()
                );
        });
        column.Settings.AllowDragDrop = DefaultBoolean.False;
        column.Settings.AllowSort = DefaultBoolean.False;
        column.Width = 70;
    });
    settings.Columns.Add("Id");
    settings.Columns.Add("Name");
    settings.Columns.Add("Manufacturer");
    settings.KeyFieldName = "Id";
    settings.SettingsPager.PageSize = 25;

}).Bind(Model).GetHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
