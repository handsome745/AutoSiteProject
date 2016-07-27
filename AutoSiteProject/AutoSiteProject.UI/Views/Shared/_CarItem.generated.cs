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
    
    #line 1 "..\..\Views\Shared\_CarItem.cshtml"
    using AutoSiteProject.Models.ViewModels;
    
    #line default
    #line hidden
    using AutoSiteProject.UI;
    using DevExpress.Utils;
    using DevExpress.Web;
    using DevExpress.Web.ASPxThemes;
    using DevExpress.Web.Mvc;
    using DevExpress.Web.Mvc.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_CarItem.cshtml")]
    public partial class _Views_Shared__CarItem_cshtml : System.Web.Mvc.WebViewPage<CarItemViewModel>
    {
        public _Views_Shared__CarItem_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<link");

WriteAttribute("href", Tuple.Create(" href=\"", 74), Tuple.Create("\"", 99)
, Tuple.Create(Tuple.Create("", 81), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Site.css")
, 81), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 127), Tuple.Create("\"", 158)
, Tuple.Create(Tuple.Create("", 134), Tuple.Create<System.Object, System.Int32>(Href("~/Content/chosen.min.css")
, 134), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 188), Tuple.Create("\"", 234)
, Tuple.Create(Tuple.Create("", 194), Tuple.Create<System.Object, System.Int32>(Href("~/scripts/jquery.unobtrusive-ajax.min.js")
, 194), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 254), Tuple.Create("\"", 290)
, Tuple.Create(Tuple.Create("", 260), Tuple.Create<System.Object, System.Int32>(Href("~/scripts/chosen.jquery.min.js")
, 260), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 310), Tuple.Create("\"", 348)
, Tuple.Create(Tuple.Create("", 316), Tuple.Create<System.Object, System.Int32>(Href("~/scripts/AutoSite/DataLoader.js")
, 316), false)
);

WriteLiteral("></script>\r\n\r\n<hr />\r\n<div");

WriteLiteral(" class=\"filter-section\"");

WriteLiteral(" \r\n     data-countries-url=\"");

            
            #line 12 "..\..\Views\Shared\_CarItem.cshtml"
                    Write(Url.Action("GetCountries", "DataLoader"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n     data-manufacturers-url=\"");

            
            #line 13 "..\..\Views\Shared\_CarItem.cshtml"
                        Write(Url.Action("GetManufacturersOfCountry", "DataLoader"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n     data-carmodels-url=\"");

            
            #line 14 "..\..\Views\Shared\_CarItem.cshtml"
                    Write(Url.Action("GetCarModelsOfManufacturer", "DataLoader"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n     data-carbodytype-url=\"");

            
            #line 15 "..\..\Views\Shared\_CarItem.cshtml"
                      Write(Url.Action("GetBodyTypes", "DataLoader"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n     data-caroptions-url=\"");

            
            #line 16 "..\..\Views\Shared\_CarItem.cshtml"
                     Write(Url.Action("GetCarOptions", "DataLoader"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n     data-carfueltype-url=\"");

            
            #line 17 "..\..\Views\Shared\_CarItem.cshtml"
                      Write(Url.Action("GetFuelTypes", "DataLoader"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n     data-cartransmitiontype-url=\"");

            
            #line 18 "..\..\Views\Shared\_CarItem.cshtml"
                             Write(Url.Action("GetTransmitionTypes","DataLoader"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("\r\n     >\r\n");

WriteLiteral("    ");

            
            #line 20 "..\..\Views\Shared\_CarItem.cshtml"
Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 21 "..\..\Views\Shared\_CarItem.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"form-group \"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 23 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.CountryId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 25 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.DropDownListFor(m => m.CountryId, new SelectList(new List<CountryViewModel>(), "Id", "Name", Model.CountryId), "Select country", htmlAttributes: new { @class = "form-control country-picker", @data_initId = @Model.CountryId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.CountryId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group widht50\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 30 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.ManufacturerId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10 \"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 32 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.DropDownListFor(m => m.ManufacturerId, new SelectList(new List<ManufacturerViewModel>(), "Id", "Name", Model.ManufacturerId), "Select manufacturer", htmlAttributes: new { @class = "form-control manufacturer-picker", @data_initId = @Model.ManufacturerId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.ManufacturerId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 37 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.ModelId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 39 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.DropDownListFor(m => m.ModelId, new SelectList(new List<CarModelViewModel>(), "Id", "Name", Model.ModelId), "Select car model", htmlAttributes: new { @class = "form-control carmodel-picker", @data_initId = @Model.ModelId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 40 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.ModelId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 44 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.BodyTypeId, htmlAttributes: new {@class = "control-label col-md-2"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 46 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.DropDownListFor(m => m.BodyTypeId, new SelectList(new List<CarBodyTypeViewModel>(), "Id", "Name", Model.BodyTypeId), "Select car body type", htmlAttributes: new {@class = "form-control carbodytype-picker", @data_initId = @Model.BodyTypeId}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 47 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.BodyTypeId, "", new {@class = "text-danger"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 51 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.FuelTypeId, htmlAttributes: new {@class = "control-label col-md-2"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 53 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.DropDownListFor(m => m.FuelTypeId, new SelectList(new List<FuelTypeViewModel>(), "Id", "Name", Model.FuelTypeId), "Select car fuel type", htmlAttributes: new {@class = "form-control carfueltype-picker", @data_initId = @Model.FuelTypeId}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 54 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.FuelTypeId, "", new {@class = "text-danger"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 58 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.TransmitionTypeId, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 60 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.DropDownListFor(m => m.TransmitionTypeId, new SelectList(new List<TransmitionTypeViewModel>(), "Id", "Name", Model.TransmitionTypeId), "Select car transmition type", htmlAttributes: new { @class = "form-control cartransmitiontype-picker", @data_initId = @Model.TransmitionTypeId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 61 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.TransmitionTypeId, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 65 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.SelectedCarOptions, htmlAttributes: new {@class = "control-label col-md-2"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 67 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ListBoxFor(m => m.SelectedCarOptions, new SelectList(Model.AvalibleCarOptions, "Id", "Name"), htmlAttributes: new {@class = "form-control caroptions-picker"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 71 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.ReleaseYear, htmlAttributes: new {@class = "control-label col-md-2"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 73 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.EditorFor(m => m.ReleaseYear, new {htmlAttributes = new {@class = "form-control"}}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 74 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.ReleaseYear, "", new {@class = "text-danger"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 78 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.Volume, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 80 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.EditorFor(m => m.Volume, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 81 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.Volume, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 86 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.Price, htmlAttributes: new {@class = "control-label col-md-2"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 88 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.EditorFor(m => m.Price, new {htmlAttributes = new {@class = "form-control"}}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 89 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.Price, "", new {@class = "text-danger"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 93 "..\..\Views\Shared\_CarItem.cshtml"
   Write(Html.LabelFor(m => m.Description, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 95 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.EditorFor(m => m.Description, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 96 "..\..\Views\Shared\_CarItem.cshtml"
       Write(Html.ValidationMessageFor(model => model.Description, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"images-container\"");

WriteLiteral(">\r\n");

            
            #line 102 "..\..\Views\Shared\_CarItem.cshtml"
                
            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\Shared\_CarItem.cshtml"
                 if (Model.Images != null)
                {
                    for (var i = 0; i < Model.Images.Count; i++)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"image-block\"");

WriteAttribute("id", Tuple.Create(" id=\"", 6701), Tuple.Create("\"", 6725)
            
            #line 106 "..\..\Views\Shared\_CarItem.cshtml"
, Tuple.Create(Tuple.Create("", 6706), Tuple.Create<System.Object, System.Int32>(Model.Images[i].Id
            
            #line default
            #line hidden
, 6706), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 107 "..\..\Views\Shared\_CarItem.cshtml"
                       Write(Html.HiddenFor(model => model.Images[i].Id, htmlAttributes: new { @class = "existImageIdField", @id = @Model.Images[i].Id }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <img");

WriteAttribute("src", Tuple.Create(" src=", 6916), Tuple.Create("", 6989)
            
            #line 108 "..\..\Views\Shared\_CarItem.cshtml"
, Tuple.Create(Tuple.Create("", 6921), Tuple.Create<System.Object, System.Int32>(Url.Action("LoadImg", "DataLoader", new {id = @Model.Images[i].Id})
            
            #line default
            #line hidden
, 6921), false)
);

WriteLiteral(" class=\"image-viewer\"");

WriteLiteral(" data-content-length=\"");

            
            #line 108 "..\..\Views\Shared\_CarItem.cshtml"
                                                                                                                                               Write(Model.Images[i].ContentLength);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" data-content-type=\"");

            
            #line 108 "..\..\Views\Shared\_CarItem.cshtml"
                                                                                                                                                                                                  Write(Model.Images[i].ContentType);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" />\r\n                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" name=\"Delete\"");

WriteLiteral(" class=\"existImageDeleteButton\"");

WriteLiteral(" value=\"Delete\"");

WriteAttribute("id", Tuple.Create(" id=\"", 7225), Tuple.Create("\"", 7249)
            
            #line 109 "..\..\Views\Shared\_CarItem.cshtml"
                                 , Tuple.Create(Tuple.Create("", 7230), Tuple.Create<System.Object, System.Int32>(Model.Images[i].Id
            
            #line default
            #line hidden
, 7230), false)
);

WriteLiteral(" />\r\n                        </div>\r\n");

            
            #line 111 "..\..\Views\Shared\_CarItem.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"add-image\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" name=\"files\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
