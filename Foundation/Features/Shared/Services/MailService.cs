using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using Foundation.Features.Shared.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Foundation.Features.Shared.Services
{
    public class MailService : IMailService
    {
        private readonly IContentLoader _contentLoader;
        private readonly IHtmlDownloader _htmlDownloader;
        private readonly HttpContext _httpContextBase;
        private readonly UrlResolver _urlResolver;

        public MailService(HttpContext httpContextBase,
            UrlResolver urlResolver,
            IContentLoader contentLoader,
            IHtmlDownloader htmlDownloader)
        {
            _httpContextBase = httpContextBase;
            _urlResolver = urlResolver;
            _contentLoader = contentLoader;
            _htmlDownloader = htmlDownloader;
        }

        public async Task SendAsync(ContentReference mailReference, NameValueCollection nameValueCollection, string toEmail, string language)
        {
            var body = await GetHtmlBodyForMailAsync(mailReference, nameValueCollection, language);
            //var mailPage = _contentLoader.Get<MailBasePage>(mailReference);

            await SendAsync(new MailMessage
            {
                Subject = /*mailPage.Subject*/ "",
                Body = body,
                IsBodyHtml = true
            });
        }

        public async Task<string> GetHtmlBodyForMailAsync(ContentReference mailReference, NameValueCollection nameValueCollection,
            string language)
        {
            var urlBuilder = new UrlBuilder(_urlResolver.GetUrl(mailReference, language))
            {
                QueryCollection = nameValueCollection
            };

            var basePath = _httpContextBase.Request.Host.Value/*.GetLeftPart(UriPartial.Authority)*/;
            var relativePath = urlBuilder.ToString();

            if (relativePath.StartsWith(basePath))
            {
                relativePath = relativePath.Substring(basePath.Length);
            }

            return await _htmlDownloader.DownloadAsync(basePath, relativePath);
        }

        public void Send(string subject, string body, string toEmail)
        {
            var message = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(toEmail);

            Send(message);
        }

        public void Send(MailMessage message)
        {
            using (var client = new SmtpClient())
            {
                // The SMTP host, port and sender e-mail address are configured
                // in the system.net section in web.config.
                client.Send(message);
            }
        }

        public async Task SendAsync(MailMessage message)
        {
            using (var client = new SmtpClient())
            {
                await client.SendMailAsync(message);
            }
        }

        public async Task SendAsync(IdentityMessage message)
        {
            var msg = new MailMessage
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            msg.To.Add(message.Destination);
            await SendAsync(msg);
        }
    }
}