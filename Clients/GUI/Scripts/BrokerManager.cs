﻿using DTO;
using DTO.MarketBrokerObjects;
using DTO.RestRequests;
using Kernel;
using Kernel.Enums;
using System;
using System.Collections.Generic;
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
            const string url = "https://localhost:5009/operations/instruments/get";

            Dictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "bank", broker.ToString() },
                { "token", token },
                { "instrument", instrument.ToString() }
            };

            RestClient<object, IEnumerable<Instrument>> client = new RestClient<object, IEnumerable<Instrument>>
                (url, 
                RestRequestType.GET, 
                queryParams: queryParams);

            return await client.ExecuteAsync();
        }

        public static async Task<bool> Trade(TradeRequest request)
        {
            const string url = "https://localhost:5009/operations/trade";

            var client = new RestClient<object, bool>(url, RestRequestType.POST);

            return await client.ExecuteAsync(request);
        }

        public static async Task<Instrument> GetInstrumentFromPortfolio(Guid userId, string figi)
        {
            const string url = "https://localhost:5009/operations/instrument/getFromPortfolio";

            Dictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "userId",userId.ToString() },
                { "figi", figi },
            };

            RestClient<object, Instrument> client = new RestClient<object, Instrument>(
                url,
                RestRequestType.GET, 
                queryParams: queryParams);

            return await client.ExecuteAsync();
        }

        public static async Task<UserBalance> GetUserBalance(Guid userId)
        {
            const string url = "https://localhost:5009/operations/userBalance/get";

            Dictionary<string, string> queryParams = new Dictionary<string, string>
            {
                { "userId", userId.ToString() }
            };

            RestClient<object, UserBalance> client = new RestClient<object, UserBalance>(url, RestRequestType.GET, queryParams: queryParams);

            return await client.ExecuteAsync();
        }

        public static async Task<bool> UpdateUserBalance(UpdateUserBalanceRequest request)
        {
            const string url = "https://localhost:5009/operations/userBalance/update";

            RestClient<object, bool> client = new RestClient<object, bool>(url, RestRequestType.PUT);

            return await client.ExecuteAsync(request);
        }
    }
}