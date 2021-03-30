using Microsoft.AspNetCore.Http;
using System.Web;

namespace Foundation.Extensions
{
    public static class WebPHelper
    {
        /// <summary>
        /// Does the requesting browser support WebP
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public static bool SupportsWebP(HttpRequest httpRequest)
        {
            try
            {
                var acceptHeader = httpRequest.Headers["ACCEPT"];
                return acceptHeader.ToString().Contains("image/webp");
            }
            catch
            {
                return false;
            }
        }
    }
}