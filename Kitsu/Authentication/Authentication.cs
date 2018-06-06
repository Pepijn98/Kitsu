using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Authentication
{
    public static class Authentication
    {
        /// <summary>
        /// Autheticate with your username and password
        /// </summary>
        /// <param name="username">Your username</param>
        /// <param name="password">Your password</param>
        /// <returns>Object with your auth data</returns>
        /// <exception cref="InvalidAuthData"></exception>
        public static async Task<AuthenticationModel> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) throw new InvalidAuthData("username or password can't be empty");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{Kitsu.BaseAuthUri}/token")
            {
                Content = new StringContent(
                    $"{{\"grant_type\": \"password\", \"username\": \"{username}\", \"password\": \"{password}\"}}",
                    Encoding.UTF8,
                    "application/vnd.api+json"
                )
            };
            var response = await Kitsu.Client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            
            var auth = JsonConvert.DeserializeObject<AuthenticationModel>(json);
            if (string.IsNullOrEmpty(auth.AccessToken))
            {
                var invalidAuth = JsonConvert.DeserializeObject<AuthenticationErrorModel>(json);
                throw new InvalidAuthData(invalidAuth.ErrorDescription);
            }
            
            Kitsu.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Utils.UppercaseFirst(auth.TokenType), auth.AccessToken);
            return auth;
        }
    }
}