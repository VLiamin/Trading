using DTO;
using DTO.MarketBrokerObjects;
using DTO.RestRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace GUI.Scripts
{
    public static class BrokerManager
    {
        public static async Task<IEnumerable<Instrument>> GetInstruments(
            BrokerType broker,
            string token,
            InstrumentType instrument)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            string devUrl = $"http://194.67.103.237:5008/operations/instruments/get?bank={broker}&token={token}&instrument={instrument}";
            string url = $"https://localhost:5009/operations/instruments/get?bank={broker}&token={token}&instrument={instrument}";

            HttpClient client2 = new HttpClient(clientHandler);
            string content =
                client2.GetStringAsync(devUrl).Result;

            return JsonSerializer.Deserialize<IEnumerable<Instrument>>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        public static async Task<bool> Trade(TradeRequest request)
        {
            string url = "https://localhost:5009/operations/trade";
            string devUrl = "http://194.67.103.237:5008/operations/trade";

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            HttpResponseMessage response = await client.PostAsJsonAsync(
                devUrl, request);

            var r = await response.Content.ReadFromJsonAsync<bool>();

            return true;
        }

        public static async Task<Instrument> GetInstrumentFromPortfolio(Guid userId, string figi)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            string devUrl = $"http://194.67.103.237:5008/operations/instrument/getFromPortfolio?userId={userId}&figi={figi}";
            string url = $"https://localhost:5009/operations/instrument/getFromPortfolio?userId={userId}&figi={figi}";

            HttpClient client2 = new HttpClient(clientHandler);
            string content =
                client2.GetStringAsync(devUrl).Result;

            return JsonSerializer.Deserialize<Instrument>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        public static async Task<UserBalance> GetUserBalance(Guid userId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            string devUrl = $"http://194.67.103.237:5008/operations/userBalance/get?userId={userId}";
            string url = $"https://localhost:5009/operations/userBalance/get?userId={userId}";

            HttpClient client2 = new HttpClient(clientHandler);
            string content =
                client2.GetStringAsync(devUrl).Result;

            return JsonSerializer.Deserialize<UserBalance>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        public static async Task<bool> UpdateUserBalance(UpdateUserBalanceRequest request)
        {
            string url = "https://localhost:5009/operations/userBalance/update";
            string devUrl = "http://194.67.103.237:5008/operations/userBalance/update";

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            HttpResponseMessage response = await client.PutAsJsonAsync(
                devUrl, request);

            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}