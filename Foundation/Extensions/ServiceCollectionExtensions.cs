using EPiServer.Web;
using Foundation.Constants;
using Foundation.Infrastructure.Rendering;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFoundation(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new SiteViewEngineLocationExpander());
            });

            services.Configure<DisplayOptions>(displayOption =>
            {
               displayOption.Add("full", "/displayoptions/full", Global.ContentAreaTags.FullWidth, "", "epi-icon__layout--full");
               displayOption.Add("wide", "/displayoptions/wide", Global.ContentAreaTags.TwoThirdsWidth, "", "epi-icon__layout--two-thirds");
               displayOption.Add("narrow", "/displayoptions/narrow", Global.ContentAreaTags.OneThirdWidth, "", "epi-icon__layout--one-third");
            });

            services.AddDisplayResolutions();
            //services.AddDetection();
        }

        private static void AddDisplayResolutions(this IServiceCollection services)
        {
            //services.AddSingleton<StandardResolution>();
            //services.AddSingleton<IpadHorizontalResolution>();
            //services.AddSingleton<IphoneVerticalResolution>();
            //services.AddSingleton<AndroidVerticalResolution>();
        }
    }
}
