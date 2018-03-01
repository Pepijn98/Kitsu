using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertToConstant.Global

namespace Kitsu
{
    public static class Kitsu
    {
        public static readonly string Version = "1.2.0-beta1";
        private static readonly string UserAgent = $"Kitsu/v{Version} NugetPackage (https://github.com/KurozeroPB/Kitsu)";

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
        /// Get all the site annoucements
        /// </summary>
        /// <returns>List with annoucements data objects</returns>
        public static async Task<AllAnnoucementsModel> GetSiteAnnoucements()
        {
            var json = await Client.GetStringAsync("https://kitsu.io/api/edge/site-announcements");
            var annoucements = JsonConvert.DeserializeObject<AllAnnoucementsModel>(json);
            return annoucements;
        }
        
        /// <summary>
        /// Get a site annoucement with a specific id
        /// </summary>
        /// <param name="id">Annoucement id</param>
        /// <returns>Object with annoucement data</returns>
        public static async Task<AnnoucementsModel> GetSiteAnnoucements(int id)
        {
            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/site-announcements/{id}");
            var annoucements = JsonConvert.DeserializeObject<AnnoucementsModel>(json);
            return annoucements;
        }
    }
}
