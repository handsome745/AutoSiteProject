using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AutoSiteProject.UI.Helpers
{
    public static class AllFieldSearchHelper
    {
        public static MvcHtmlString SearchFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var propertyName = ModelMetadata.FromLambdaExpression(expression, html.ViewData).PropertyName;
            var model = ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model;
            var input = new TagBuilder("input");
            var attrDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var atr in attrDictionary)
            {
                input.Attributes[atr.Key] = atr.Value.ToString();
            }
            input.Attributes["name"] = propertyName;
            input.Attributes["type"] = "text";
            if (model!=null) input.Attributes["value"] = model.ToString();

            return new MvcHtmlString(input.ToString());
        }
    }
}