using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foundation.Infrastructure.Rendering
{

    public class SiteViewEngineLocationExpander : IViewLocationExpander
    {
        private static readonly string[] AdditionalPartialViewFormats = new[]
            {
                TemplateCoordinator.BlockFolder + "{0}.cshtml",
                TemplateCoordinator.PagePartialsFolder + "{0}.cshtml",
                "~/Features/%0/{0}.cshtml",
                "~/Features/%0/{1}/{0}.cshtml",
                "~/Features/{1}/{0}.cshtml",
    };

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (var location in viewLocations)
            {
                yield return location;
            }

            for (int i = 0; i < AdditionalPartialViewFormats.Length; i++)
            {
                yield return AdditionalPartialViewFormats[i].Replace("%0", GetFeatureName(context.ActionContext.ActionDescriptor));
            }
        }

        private string GetFeatureName(ActionDescriptor descriptor)
        {
            var tokens = descriptor.DisplayName?.Split('.');
            if (!tokens?.Any(t => t == "Features") ?? true)
            {
                return "";
            }

            return tokens
                .SkipWhile(t => !t.Equals("features",
                    StringComparison.CurrentCultureIgnoreCase))
                .Skip(1)
                .Take(1)
                .FirstOrDefault();
        }

        public void PopulateValues(ViewLocationExpanderContext context) { }
    }
}
