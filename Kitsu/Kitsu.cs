using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertToConstant.Global
// ReSharper disable UnusedMember.Global

namespace Kitsu
{
    public static class Kitsu
    {
        public static readonly string Version = "1.3.0";
        private static readonly string UserAgent = $"Kitsu/v{Version} NugetPackage (https://github.com/KurozeroPB/Kitsu)";

        private static HttpClient RequestClient()
        {
            var client = new HttpClient() {BaseAddress = new Uri("https://kitsu.io/api/edge/")};
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
        public static async Task<AllAnnoucementsModel> GetAnnoucementsAsync()
        {
            var json = await Client.GetStringAsync("site-announcements");
            var annoucements = JsonConvert.DeserializeObject<AllAnnoucementsModel>(json);
            if (annoucements.Data.Count <= 0) { throw new NoDataFoundException("Could not find any annoucements"); }
            return annoucements;
        }
        
        /// <summary>
        /// Get a site annoucement with a specific id
        /// </summary>
        /// <param name="id">Annoucement id</param>
        /// <returns>Object with annoucement data</returns>
        public static async Task<AnnoucementsModel> GetAnnoucementsAsync(int id)
        {
            var json = await Client.GetStringAsync($"site-announcements/{id}");
            var annoucements = JsonConvert.DeserializeObject<AnnoucementsModel>(json);
            return annoucements;
        }
    }
}
