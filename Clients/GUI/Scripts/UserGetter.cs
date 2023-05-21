using DTO;
using DTO.RestRequests;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GUI.Scripts
{
    public static class UserGetter
    {
        public static async Task<UserInfoRequest> GetUserById(UserToken userToken)
        {
            if (userToken.UserId == Guid.Empty)
            {
                return null;
            }

            string url = "https://localhost:5011/users/get";
            string devUrl = "http://194.67.103.237:5010/users/get";

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client2 = new HttpClient(clientHandler);
            client2.DefaultRequestHeaders.Add("token", userToken.Body);
            client2.DefaultRequestHeaders.Add("userId", userToken.UserId.ToString());
            string content =
                client2.GetStringAsync(devUrl).Result;

            return JsonSerializer.Deserialize<UserInfoRequest>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }
    }
}
