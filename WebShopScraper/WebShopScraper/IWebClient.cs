using RestSharp;

namespace WebShopScraper
{
    public interface IWebClient
    {
        RestResponse GetPageHtmlContent();
        void SetBaseUri(string baseUri);
        void SetPath(string path);
    }
}