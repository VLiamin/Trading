using DTO.RestRequests;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GUI.Scripts
{
    public static class SignUpper
    {
        public static async Task SignUp(CreateUserRequest user)
        {
            const string url = "https://localhost:5011/users/create";
            const string devUrl = "http://194.67.103.237:5010/users/create";

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            HttpResponseMessage response = await client.PostAsJsonAsync(
                devUrl, user);
        }
    }
}
