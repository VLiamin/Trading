using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DTO;
using DTO.RestRequests;
using Kernel;
using Kernel.Enums;

namespace GUI.Scripts
{
    public static class UserEditor
    {
        /// <summary>
        /// Edits information about the user
        /// </summary>
        /// <param name="id">Identificator no know who to change</param>
        /// <param name="userInfo">Updated information</param>
        /// <param name="oldPassword">If not null, there is an attempt to change password</param>
        /// <param name="newPassword">Same as with oldPassword</param>
        public static async Task EditUser(UserToken userToken, EditUserRequest request)
        {
/*            const string url = "https://localhost:5011/users/edit";

            var client = new RestClient<EditUserRequest, bool>(url, RestRequestType.PUT, userToken);*/

            string url = "https://localhost:5011/users/edit";
            string devUrl = "http://194.67.103.237:5010/users/edit";

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            client.DefaultRequestHeaders.Add("token", userToken.Body);
            client.DefaultRequestHeaders.Add("userId", userToken.UserId.ToString());

            HttpResponseMessage response = await client.PutAsJsonAsync(
                devUrl, request);

            //  await client.ExecuteAsync(request);
            int t = 1;
        }
    }
}
