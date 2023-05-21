using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using DTO;

namespace GUI.Scripts
{
    public static class NewsGetter
    {
        public static IEnumerable<NewsItem> GetNews(string feedUrl)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            string devUrl = $"http://194.67.103.237:5006/news/getnews?feedUrl={feedUrl}";
            string url = $"https://localhost:5007/news/getnews?feedUrl={feedUrl}";

            HttpClient client2 = new HttpClient(clientHandler);
            string content = 
                client2.GetStringAsync(devUrl).Result;

            return JsonSerializer.Deserialize<IEnumerable<NewsItem>>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }
    }
}
