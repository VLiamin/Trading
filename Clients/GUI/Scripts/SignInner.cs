using DTO;
using DTO.NewsRequests.Currency;
using DTO.RestRequests;
using Kernel;
using Kernel.Enums;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GUI.Scripts
{
    public static class SignInner
    {
        public static async Task<UserToken> SignIn(LoginRequest request)
        {
            const string url = "https://localhost:5001/authentication/login";
            const string devUrl = "https://194.67.103.237:5001/authentication/login";

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            HttpResponseMessage response = await client.PostAsJsonAsync(
                devUrl, request);

            return await response.Content.ReadFromJsonAsync<UserToken>();
        }
    }
}
