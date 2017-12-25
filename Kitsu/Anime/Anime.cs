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
        public static async Task<AnimeModelByName> GetAnimeAsync(string name, int offset = 0)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", Kitsu.UserAgent);

            var json = await client.GetStringAsync($"https://kitsu.io/api/edge/anime?filter[text]={name}&page[offset]={offset}");
            
            var anime = JsonConvert.DeserializeObject<AnimeModelByName>(json);
            return anime;
        }

        // Get an anime by its id
        public static async Task<AnimeModelById> GetAnimeAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", Kitsu.UserAgent);

            var resp = await client.GetAsync($"https://kitsu.io/api/edge/anime/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var anime = JsonConvert.DeserializeObject<AnimeModelById>(json);
            return anime;
        }
    }
}