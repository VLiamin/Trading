using System.Collections.Generic;
using System.Net.Http;
using DTO;
using Kernel;
using Kernel.Enums;

namespace GUI.Scripts
{
    public static class NewsGetter
    {
        public static IEnumerable<NewsItem> GetNews(string feedUrl)
        {
            const string url = "https://localhost:5007/news/getnews";

            var queryParams = new Dictionary<string, string>
            {
                { "feedUrl", feedUrl }
            };

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            RestClient<string, IEnumerable<NewsItem>> client = new RestClient<string, IEnumerable<NewsItem>>(url, RestRequestType.GET, queryParams: queryParams);

            return client.Execute();
        }
    }
}
