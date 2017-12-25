using System.Net.Http;
using System.Threading.Tasks;
using Kitsu.Models;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.Anime
{
    public class Anime
    {
        private readonly HttpClient _client = Kitsu.Client();
        
        // Search for an anime with the name
        public async Task<AnimeModelByName> GetAnimeAsync(string name, int offset = 0)
        {
            var json = await _client.GetStringAsync($"https://kitsu.io/api/edge/anime?filter[text]={name}&page[offset]={offset}");
            
            var anime = JsonConvert.DeserializeObject<AnimeModelByName>(json);
            return anime;
        }

        // Get an anime by its id
        public async Task<AnimeModelById> GetAnimeAsync(int id)
        {
            var resp = await _client.GetAsync($"https://kitsu.io/api/edge/anime/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var anime = JsonConvert.DeserializeObject<AnimeModelById>(json);
            return anime;
        }
    }
}