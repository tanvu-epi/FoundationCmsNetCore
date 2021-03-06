using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Constants
{
    [GroupDefinitions]
    public static class GroupNames
    {
        [Display(Name = "Content", Order = 510)]
        public const string Content = "Content";

        [Display(Order = 530)]
        public const string Account = "Account";

        [Display(Order = 540)]
        public const string Blog = "Blog";

        [Display(Name = "Calendar", Order = 550)]
        public const string Calendar = "Calendar";

        [Display(Order = 570)]
        public const string Forms = "Forms";

        [Display(Order = 580)]
        public const string Multimedia = "Multimedia";

        [Display(Order = 600)]
        public const string SocialMedia = "Social media";

        [Display(Order = 620)]
        public const string Syndication = "Syndication";
    }
}
