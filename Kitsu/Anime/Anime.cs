using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Kitsu.Models;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Anime
{
    public class Anime
    {
        // Search for an anime with the name
        public static async Task<AnimeModelByName> SearchAnimeAsync(string name)
        {
            var json = await AnimeByNameAsync(name);
            
            try
            {
                var anime = JsonConvert.DeserializeObject<AnimeModelByName>(json);
                return anime;
            }
            catch (Exception e)
            {
                var err = "{'error':'" + e.Message + "'}";
                var anime = JsonConvert.DeserializeObject<AnimeModelByName>(err);
                return anime;
            }
        }

        // Get an anime by it's id
        public static async Task<AnimeModelById> GetAnimeAsync(int id)
        {
            var json = await AnimeByIdAsync(id);
            
            try
            {
                var anime = JsonConvert.DeserializeObject<AnimeModelById>(json);
                return anime;
            }
            catch (Exception e)
            {
                var err = "{'error':'" + e.Message + "'}";
                var anime = JsonConvert.DeserializeObject<AnimeModelById>(err);
                return anime;
            }
        }
        
        /* v Http requests v */
        private const string UserAgent = "Kitsu/nuget_package - (https://github.com/KurozeroPB/Kitsu)";
        
        // Request anime by name
        private static async Task<string> AnimeByNameAsync(string name)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            var stringTask = client.GetStringAsync($"https://kitsu.io/api/edge/anime?filter[text]={name}&page[offset]=0");
            var json = await stringTask;

            return json;
        }

        // Request anime by id
        private static async Task<string> AnimeByIdAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            var stringTask = client.GetStringAsync($"https://kitsu.io/api/edge/anime/{id}");
            var json = await stringTask;

            return json;
        }
    }
}