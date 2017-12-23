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
        public static async Task<AnimeModelByName> GetAnimeAsync(string name)
        {
            var json = await RequestAnimeAsync(name);
            
            var anime = JsonConvert.DeserializeObject<AnimeModelByName>(json);
            return anime;
        }

        // Get an anime by it's id
        public static async Task<AnimeModelById> GetAnimeAsync(int id)
        {
            var json = await RequestAnimeAsync(id);
            
            var anime = JsonConvert.DeserializeObject<AnimeModelById>(json);
            return anime;
        }
        
        /* v Http requests v */
        private const string UserAgent = "Kitsu/nuget_package - (https://github.com/KurozeroPB/Kitsu)";
        
        // Request anime by name
        private static async Task<string> RequestAnimeAsync(string name)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            var resp = await client.GetStringAsync($"https://kitsu.io/api/edge/anime?filter[text]={name}&page[offset]=0");
            return resp;
        }

        // Request anime by id
        private static async Task<string> RequestAnimeAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            var resp = await client.GetStringAsync($"https://kitsu.io/api/edge/anime/{id}");
            return resp;
        }
    }
}