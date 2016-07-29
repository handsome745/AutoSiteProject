using System.Web.Mvc;

namespace AutoSiteProject.UI.Helpers
{
    public static class SearchHelper
    {
        public static MvcHtmlString Select2Search(this HtmlHelper html,  object htmlAttributes)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var searchUrl = urlHelper.Action("GetCars", "DataLoader",null,null);
            var imgLoadUrl = urlHelper.Action("LoadImg", "DataLoader",null,null);
            var carItemUrl = urlHelper.Action("Details", "CarItem",new { id = (int?)null },null);
            var select = new TagBuilder("select");
            var attrDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var atr in attrDictionary)
            {
                select.Attributes[atr.Key] = atr.Value.ToString();
            }
            select.Attributes["class"] += " js-need-init";
            select.Attributes["data-search-url"] = searchUrl;
            select.Attributes["data-img-url"] = imgLoadUrl;
            select.Attributes["data-caritem-url"] = carItemUrl;
            select.Attributes["data-init-script"] = "select2SearchControl.init";
            select.Attributes["multiple"] = "multiple";

            var option = new TagBuilder("option");
            option.Attributes["value"] = "1111";
            option.SetInnerText("Search");

            select.InnerHtml += option.ToString();

            return new MvcHtmlString(select.ToString());
        }
    }
}