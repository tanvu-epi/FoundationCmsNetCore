using EPiServer.Core;
using EPiServer.Web.Mvc.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Foundation.Infrastructure.Rendering
{
    public class FoundationContentAreaRenderer : ContentAreaRenderer
    {
        protected override string GetContentAreaItemCssClass(IHtmlHelper htmlHelper, ContentAreaItem contentAreaItem)
        {
            var baseClass = base.GetContentAreaItemCssClass(htmlHelper, contentAreaItem);
            var tag = GetContentAreaItemTemplateTag(htmlHelper, contentAreaItem);
            if (!string.IsNullOrEmpty(baseClass))
            {
                return baseClass;
            }

            return $"block {tag} {GetCssClassForTag(tag)}";
        }

        private static string GetCssClassForTag(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                return "";
            }
            switch (tagName.ToLower())
            {
                case "span12":
                    return "full";
                case "span8":
                    return "wide";
                case "span6":
                    return "half";
                default:
                    return string.Empty;
            }
        }
    }
}
