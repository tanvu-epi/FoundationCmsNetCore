using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foundation.Constants
{
    public class Global
    {
        public static class ContentAreaTags
        {
            public const string FullWidth = "span12";
            public const string TwoThirdsWidth = "span8";
            public const string HalfWidth = "span6";
            public const string OneThirdWidth = "span4";
            public const string NoRenderer = "norenderer";
        }

        public static class ContentAreaWidths
        {
            public const int FullWidth = 12;
            public const int TwoThirdsWidth = 8;
            public const int HalfWidth = 6;
            public const int OneThirdWidth = 4;
        }

        public static Dictionary<string, int> ContentAreaTagWidths = new Dictionary<string, int>
        {
            { ContentAreaTags.FullWidth, ContentAreaWidths.FullWidth },
            { ContentAreaTags.TwoThirdsWidth, ContentAreaWidths.TwoThirdsWidth },
            { ContentAreaTags.HalfWidth, ContentAreaWidths.HalfWidth },
            { ContentAreaTags.OneThirdWidth, ContentAreaWidths.OneThirdWidth }
        };
    }
}
