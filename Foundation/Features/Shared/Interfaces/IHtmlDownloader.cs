using System.Threading.Tasks;

namespace Foundation.Features.Shared.Interfaces
{
    public interface IHtmlDownloader
    {
        Task<string> DownloadAsync(string baseUrl, string relativeUrl);
    }
}