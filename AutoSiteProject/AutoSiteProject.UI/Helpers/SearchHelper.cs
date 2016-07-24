using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Helpers
{
    public static class SearchHelper
    {
        public static MvcHtmlString Select2Search(this HtmlHelper html, string searchUrl, string imgLoadUrl,  string carItemUrl, object htmlAttributes)
        {
            var select = new TagBuilder("select");
            var attrDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var atr in attrDictionary)
            {
                select.Attributes[atr.Key] = atr.Value.ToString();
            }
            select.Attributes["data-search-url"] = searchUrl;
            select.Attributes["data-img-url"] = imgLoadUrl;
            select.Attributes["data-caritem-url"] = carItemUrl;

            var option = new TagBuilder("option");
            option.Attributes["value"] = "1111";
            option.Attributes["selected"] = "selected";
            option.SetInnerText("Search");

            select.InnerHtml += option.ToString();

            return new MvcHtmlString(select.ToString());
        }
    }
}