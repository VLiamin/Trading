using DTO;
using DTO.BrokerRequests;
using DTO.MarketBrokerObjects;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GUI.Scripts
{
    public static class HubConnector
    {
        public static async Task<IEnumerable<Candle>> SubscribeOnCandle(Action<Candle> OnReceivedAction, BrokerType broker, string figi, string token)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "broker", broker.ToString() },
                { "token", token },
                { "figi", figi }
            };

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            string devUrl = $"http://194.67.103.237:5008/operations/candles/get?bank=TinkoffBroker&token=t.8uALbj_cTXfAKh1LKm32L71ozCgcoW5C9we1EOOVgiv4AsPljD2t8AdWLxCP9qFlVzmnB4DhXv9MtF8ODvAO2Q&figi=TCS0013HRTL0";
            string url = $"https://localhost:5009/operations/candles/get?bank={broker}&token={token}&figi={figi}";

            HttpClient client2 = new HttpClient(clientHandler);
            string content =
                client2.GetStringAsync(devUrl).Result;

            List<Candle> subscribeOnCandle = JsonSerializer.Deserialize<IEnumerable<Candle>>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }).ToList();

            if (subscribeOnCandle.Count == 0)
            {
                return subscribeOnCandle;
            }

            var hubConnection = new HubConnectionBuilder()
                .WithUrl("http://194.67.103.237:5008/CandleHub",
                options =>
                {
                    options.WebSocketConfiguration = conf =>
                    {
                        conf.RemoteCertificateValidationCallback = (message, cert, chain, errors) => { return true; };
                    };
                    options.HttpMessageHandlerFactory = factory => new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
                    };
                })
                .Build();

            hubConnection.On<Candle>("ReceiveMessage", OnReceivedAction.Invoke);

            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception e)
            {

            }

            await hubConnection.SendAsync("Subscribe", new GetCandlesRequest
            {
                Token = token,
                Broker = BrokerType.TinkoffBroker,
                Figi = figi
            });

            return subscribeOnCandle;
        }
    }
}
