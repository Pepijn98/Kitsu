using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Kitsu.Announcements;
using Kitsu.Authorize;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertToConstant.Global
// ReSharper disable UnusedMember.Global

namespace Kitsu
{
    public static class Kitsu
    {
        public static readonly string Version = "1.4.0";
        private static readonly string UserAgent = $"Kitsu/v{Version} NugetPackage (https://github.com/KurozeroPB/Kitsu)";
        internal const string BaseUri = "https://kitsu.io/api/edge";
        internal const string BaseAuthUri = "https://kitsu.io/api/oauth";

        private static HttpClient RequestClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            return client;
        }
        
        internal static readonly HttpClient Client = RequestClient();

        /// <summary>
        /// Autheticate with your username and password
        /// </summary>
        /// <param name="username">Your username</param>
        /// <param name="password">Your password</param>
        /// <returns>Object with your auth data</returns>
        /// <exception cref="InvalidAuthData"></exception>
        public static async Task<AuthorizeModel> Authenticate(string username, string password)
        {
            var body = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", username },
                { "password", password }
            };
            var content = new FormUrlEncodedContent(body);
            var response = await Client.PostAsync($"{BaseAuthUri}/token", content);
            var json = await response.Content.ReadAsStringAsync();
            var auth = JsonConvert.DeserializeObject<AuthorizeModel>(json);

            if (string.IsNullOrEmpty(auth.AccessToken))
            {
                var invalidAuth = JsonConvert.DeserializeObject<AuthorizeErrorModel>(json);
                throw new InvalidAuthData(invalidAuth.ErrorDescription);
            }
            
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Utils.UppercaseFirst(auth.TokenType), auth.AccessToken);
            return auth;
        }
        
        /// <summary>
        /// Get all the site announcements
        /// </summary>
        /// <returns>List with announcements data objects</returns>
        /// <exception cref="NoDataFoundException"></exception>
        public static async Task<AllAnnouncementsModel> GetAnnouncementsAsync()
        {
            var json = await Client.GetStringAsync($"{BaseUri}/site-announcements");
            var announcements = JsonConvert.DeserializeObject<AllAnnouncementsModel>(json);
            if (announcements.Data.Count <= 0) throw new NoDataFoundException("Could not find any announcements");
            return announcements;
        }
        
        /// <summary>
        /// Get a site annoucement with a specific id
        /// </summary>
        /// <param name="id">Announcement id</param>
        /// <returns>Object with announcement data</returns>
        public static async Task<AnnouncementsModel> GetAnnouncementsAsync(int id)
        {
            var json = await Client.GetStringAsync($"{BaseUri}/site-announcements/{id}");
            var announcements = JsonConvert.DeserializeObject<AnnouncementsModel>(json);
            return announcements;
        }
    }
}
